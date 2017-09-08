using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using System.Data;

namespace miller0061072133.Views
{
    public partial class Review : System.Web.UI.Page
    {
        Customer customer;
        Cart myCart;
        protected void Page_Load(object sender, EventArgs e)
        {
            customer = (Customer)Session["customer"];
            myCart = (Cart)Session["myCart"];

            // validate customer has items in cart
            if (Session["customer"] == null)
            {
                Response.Redirect("Checkout.aspx");
            }
            else if (customer.GetSuburb() == null)
            {
                Response.Redirect("Checkout.aspx");
            }
            else if (customer.GetCardHoldersName() == null)
            {
                Response.Redirect("Payment.aspx");
            }
            else if (Session["myCart"] == null)
            {
                Response.Redirect("Home.aspx");
            } else if (myCart.GetItems().Count == 0)
            {
                Response.Redirect("Home.aspx");
            }

            // fill data
            FillData();
            if (!IsPostBack) //check if the webpage is loaded for the first time.
            {
                ViewState["PreviousPage"] = Request.UrlReferrer;//Saves the Previous page url in ViewState
            }

        }

        private void FillData(){
            if (Session["myCart"] == null)
			{
				Session["myCart"] = new Cart();
			}
           
            // product details
            double grand_total = 0.00;

			foreach (CartItem item in myCart.GetItems())
			{
                Label lbl_id = new Label();
                Label lbl_p_name = new Label();
                Label lbl_price = new Label();
                Label lbl_quantity = new Label();
                Image lbl_image = new Image();

                // set ids
                lbl_id.ID = "lbl_id";
                lbl_p_name.ID = "lbl_p_name";
                lbl_price.ID = "lbl_price";
                lbl_quantity.ID = "lbl_quantity";
                lbl_image.ID = "lbl_image";

                // set class'
                lbl_id.CssClass = "lbl_review_details";
                lbl_p_name.CssClass = "lbl_review_details";
                lbl_price.CssClass = "lbl_review_details";
                lbl_quantity.CssClass = "lbl_review_details";
                lbl_image.CssClass = "lbl_review_details";

                // set data
                lbl_id.Text = "ID: " + item.GetID();
                lbl_p_name.Text = "Name: " + item.GetName();
                lbl_price.Text = "Price: $" + item.GetPrice().ToString();
                lbl_quantity.Text = "Quantity: " + item.GetQuantity().ToString(); 
                lbl_image.ImageUrl = item.GetImage();

                PlaceHolder1.Controls.Add(lbl_id);
                PlaceHolder1.Controls.Add(lbl_p_name);
                PlaceHolder1.Controls.Add(lbl_price);
                PlaceHolder1.Controls.Add(lbl_quantity);
				PlaceHolder1.Controls.Add(lbl_image);

				grand_total += item.GetQuantity() * item.GetPrice();
			}

            lbl_grand_total.Text = "Grand Total is $" + grand_total.ToString();

            // customer details
            txt_name.Text = customer.GetName();
            txt_address.Text = customer.GetAddress();

            // payment details
            txt_cardholders_name.Text = customer.GetCardHoldersName();
            txt_card_number.Text = customer.GetCardNumber();
            txt_card_start_date.Text = customer.GetCardStartDate();
            txt_card_end_date.Text = customer.GetCardEndDate();
            txt_card_issue_number.Text = customer.GetCardIssueNumber();
            txt_email_address.Text = customer.GetEmail();
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            if (ViewState["PreviousPage"] != null)  //Check if the ViewState 
                                                    //contains Previous page URL
            {
                Response.Redirect(ViewState["PreviousPage"].ToString());//Redirect to 
                                                                        //Previous page by retrieving the PreviousPage Url from ViewState.
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            AddDataToDatabase();
            Response.Redirect("ProccessedPayment.aspx");
        }

        private void AddDataToDatabase()
        {
            try
            {

                // datebase connection 
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CustomerConnectionString"].ConnectionString);
                conn.Open();

                // insert into customer into database is customer has not been created
                string isCustomerCreated = "select count(id) from Customers where id = @customerID";
                SqlCommand cmd = new SqlCommand(isCustomerCreated, conn);
                cmd.Parameters.AddWithValue("@customerID", customer.GetID());
                Int32 count = (Int32)cmd.ExecuteScalar();

                Debug.WriteLine("is customer created ***********************" + count + "id: " + customer.GetID());
                if (count == 0) { 
                    string insertQuery = "insert into Customers(ID, Title, FirstName, MiddleName, LastName, EmailAddress, Country, State, City, Suburb, Postcode, StreetType, StreetName, UnitNumber, PropertyName, CardholdersName, CardNumber, StartDate, EndDate, IssueNumber) values (@ID, @Title, @FirstName, @MiddleName, @LastName, @EmailAddress, @Country, @State, @City, @Suburb, @Postcode, @StreetType, @StreetName, @UnitNumber, @PropertyName, @CardholdersName, @CardNumber, @StartDate, @EndDate, @IssueNumber)";
                    cmd = new SqlCommand(insertQuery, conn);
                    cmd.Parameters.AddWithValue("@ID", customer.GetID());
                    cmd.Parameters.AddWithValue("@Title", customer.GetTitle());
                    cmd.Parameters.AddWithValue("@FirstName", customer.GetFirstName());
                    cmd.Parameters.AddWithValue("@MiddleName", customer.GetMiddleName());
                    cmd.Parameters.AddWithValue("@LastName", customer.GetLastName());
                    cmd.Parameters.AddWithValue("@EmailAddress", customer.GetEmail());
                    cmd.Parameters.AddWithValue("@Country", customer.GetCountry());
                    cmd.Parameters.AddWithValue("@State", customer.GetState());
                    cmd.Parameters.AddWithValue("@City", customer.GetCity());
                    cmd.Parameters.AddWithValue("@Suburb", customer.GetSuburb());
                    cmd.Parameters.AddWithValue("@Postcode", customer.GetPostcode());
                    cmd.Parameters.AddWithValue("@StreetType", customer.GetStreetType());
                    cmd.Parameters.AddWithValue("@StreetName", customer.GetStreetName());
                    cmd.Parameters.AddWithValue("@UnitNumber", customer.GetUnitNumber());
                    cmd.Parameters.AddWithValue("@PropertyName", customer.GetPropertyName());
                    cmd.Parameters.AddWithValue("@CardholdersName", customer.GetCardHoldersName());
                    cmd.Parameters.AddWithValue("@CardNumber", customer.GetCardNumber());
                    cmd.Parameters.AddWithValue("@StartDate", customer.GetCardStartDate());
                    cmd.Parameters.AddWithValue("@EndDate", customer.GetCardEndDate());
                    cmd.Parameters.AddWithValue("@IssueNumber", customer.GetCardIssueNumber());
                    cmd.ExecuteNonQuery();
                }
                // add customers order to database
                for (int i=0; i <= myCart.GetItems().Count-1; i++)
                {
                    string insertQuery = "insert into Orders(CustomerID, ProductName, ProductImage, ProductPrice, ProductQuantity, ProductTotalPrice) values (@CustomerID, @ProductName, @ProductImage, @ProductPrice, @ProductQuantity, @ProductTotalPrice)";
                    cmd = new SqlCommand(insertQuery, conn);
                    cmd.Parameters.AddWithValue("@CustomerID", customer.GetID());
                    cmd.Parameters.AddWithValue("@ProductName", myCart.GetItems()[i].GetName());
                    cmd.Parameters.AddWithValue("@ProductImage", myCart.GetItems()[i].GetImage());
                    cmd.Parameters.AddWithValue("@ProductPrice", myCart.GetItems()[i].GetPrice());
                    cmd.Parameters.AddWithValue("@ProductQuantity", myCart.GetItems()[i].GetQuantity());
                    cmd.Parameters.AddWithValue("@ProductTotalPrice", myCart.GetItems()[i].GetQuantity() * myCart.GetItems()[i].GetPrice());
                    cmd.ExecuteNonQuery();
                }
                
                

                conn.Close();

                // Empty Cart 
                Session["myCart"] = null;

            }
            catch (Exception ex)
            {
                Debug.WriteLine("error" + ex.ToString());
            }
        }
    }
}