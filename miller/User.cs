using miller0061072133;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace miller
{
    public class User
    {
        Customer customer = new Customer();
        private string Username { get; set; }
        private byte[] Password { get; set; }
        private byte[] Salt { get; set; }
        private string Email { get; set; }
        private static int saltLengthLimit = 64;

        public User() { }
        public User(Dictionary<String, String> userData)
        {
            KeyValuePair<string, string> results = userData.FirstOrDefault(v => v.Key.Equals("username"));
            this.Username = results.Value;
            results = userData.FirstOrDefault(v => v.Key.Equals("email"));
            this.Email = results.Value;
        }

        public User(string username, string passwordStr, string email)
        {
            this.Username = username;
            this.Password = Encoding.ASCII.GetBytes(passwordStr); 
            this.Email = email;
        }
        public void AddUserToDatabase()
        {
            try
            {

                // datebase connection 
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CustomerConnectionString"].ConnectionString);
                conn.Open();

                // insert user into database
                string insertQuery = "insert into Users(Username, Salt, Password, Email) values (@Username,  @Salt, @Password, @Email)";
                SqlCommand cmd = new SqlCommand(insertQuery, conn);
                cmd.Parameters.AddWithValue("@UserName", Username);
                // do hashing and salt
                Salt = GenerateRandomSalt(saltLengthLimit);
                cmd.Parameters.Add("@Salt", SqlDbType.VarBinary, -1).Value = Salt;
                Password = GenerateSaltedHash(Password, Salt, 665000);
                cmd.Parameters.Add("@Password", SqlDbType.VarBinary, -1).Value = Password;
                cmd.Parameters.AddWithValue("@Email", Email);

                cmd.ExecuteNonQuery();

                conn.Close();

            } 
            catch (Exception ex)
            {
                Debug.WriteLine("error" + ex.ToString());
            }
        }


        private int ValidateUser(string username, byte[] password)
        {
            // get users salt
            // datebase connection 
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CustomerConnectionString"].ConnectionString);
            conn.Open();

            // validate user is in the database
            string selectQuery = "select COUNT(Username) FROM Users WHERE Username = @Username COLLATE SQL_Latin1_General_CP1_CS_AS";
            SqlCommand cmd = new SqlCommand(selectQuery, conn);
            cmd.Parameters.AddWithValue("@Username", username);
            Int32 count = (Int32)cmd.ExecuteScalar();

           

            if (count == 0)
            {
                Debug.WriteLine("username doesn't exist ***************************");
                return -2; // username doesn't exist
            }

            // get users salt
            selectQuery = "select Salt FROM Users WHERE Username = @Username";
            cmd = new SqlCommand(selectQuery, conn);
            cmd.Parameters.AddWithValue("@Username", username);
            byte[] usersSalt = (byte[])cmd.ExecuteScalar();

            // get users hashed password
            selectQuery = "select Password FROM Users WHERE Username = @Username";
            cmd = new SqlCommand(selectQuery, conn);
            cmd.Parameters.AddWithValue("@Username", username);
            byte[] usersPassword = (byte[])cmd.ExecuteScalar();

            // do hasing with users salt and entered password

            if (CompareByteArrays(usersPassword, GenerateSaltedHash(password, usersSalt, 665000)))
            {
                Debug.WriteLine("****************** password user entered matchs stored account for that username");
                return 0; // password user entered matchs stored account for that username
            }

            Debug.WriteLine("****************** password user entered does NOT match stored account for that username");
            return -1; // password user entered doesnt match stored account for that username
        }

        static byte[] GenerateSaltedHash(byte[] plainText, byte[] salt, int interationCount)
        {
            HashAlgorithm algorithm = new SHA256Managed();

            byte[] plainTextWithSaltBytes =
              new byte[plainText.Length + salt.Length];

            for (int i = 0; i < plainText.Length; i++)
            {
                plainTextWithSaltBytes[i] = plainText[i];
            }
            for (int i = 0; i < salt.Length; i++)
            {
                plainTextWithSaltBytes[plainText.Length + i] = salt[i];
            }
            byte[] hash = algorithm.ComputeHash(plainTextWithSaltBytes);
            for (int i = 0; i < interationCount; i++)
                hash = algorithm.ComputeHash(plainTextWithSaltBytes);
            return hash;
        }

        
        private byte[] GenerateRandomSalt(int maximumSaltLength)
        {
            var salt = new byte[maximumSaltLength];
            using (var random = new RNGCryptoServiceProvider())
            {
                random.GetNonZeroBytes(salt);
            }

            return salt;
        }

        private static bool CompareByteArrays(byte[] array1, byte[] array2)
        {
            if (array1.Length != array2.Length)
            {
                return false;
            }

            for (int i = 0; i < array1.Length; i++)
            {
                if (array1[i] != array2[i])
                {
                    return false;
                }
            }

            return true;
        }

        public Dictionary<String, String> LoginUser(string username, string passwordStr)
        {
            Dictionary<String, String> userData = null;
            byte[] password = Encoding.ASCII.GetBytes(passwordStr);
            if (ValidateUser(username, password) == 0)
            {
                userData = new Dictionary<String, String>();
                // Return User Date for Session
                // Get Users Data
                // datebase connection 
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CustomerConnectionString"].ConnectionString);
                conn.Open();

                // validate user is in the database
                string selectQuery = "select Email FROM Users WHERE Username = @Username";
                SqlCommand cmd = new SqlCommand(selectQuery, conn);
                cmd.Parameters.AddWithValue("@Username", username);
                String email = (String)cmd.ExecuteScalar();

                conn.Close();

                Debug.WriteLine("Adding user session date ******************************************************");
                userData.Add("username", username);
                userData.Add("email", email);
            }
            return userData;
        }

      
        public string GetUsername()
        {
            return this.Username;
        }

        public string GetEmail()
        {
            return this.Email;
        }
    }
}