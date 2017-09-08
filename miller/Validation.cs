using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace miller
{

    public class Validation
    {
        private List<String> ErrorMessages { get; set; }
        public String ValidCardType { get; set; }
        private Regex exp;
        private Match match;
        public bool AllValid = true;
        
        public Validation()
        {
            ErrorMessages = new List<String>();
        }

        public List<String> GetErrorMessages()
        {
            return this.ErrorMessages;
        }

        public void Name(string name, string typeName)
        {
            exp = new Regex(@"^*[A-Za-z]$");
            match = exp.Match(name);
            if (match.Success == false)
            {
                ErrorMessages.Add(typeName + " is invalid.");
                AllValid = false;
            }
        }

        public void Email(string email)
        {
            exp = new Regex(@"^*[A-Za-z]$");
            match = exp.Match(email);
            if (match.Success == false)
            {
                ErrorMessages.Add("Email is invalid.");
                AllValid = false;
            }
        }


        public void StreetNumber(string streetNumber)
        {
            exp = new Regex(@"^*[A-Za-z0-9]$");
            match = exp.Match(streetNumber);
            if (match.Success == false)
            {
                ErrorMessages.Add("Street Number is invalid.");
                AllValid = false;
            }
        }


        public void Title(string title)
        {
            exp = new Regex(@"(Mr|Mrs)");
            match = exp.Match(title);
            if (match.Success == false)
            {
                ErrorMessages.Add("Title is invalid.");
                AllValid = false;
            }
        }

        public void StreetType(string title)
        {
            exp = new Regex(@"(ST|TER|DR|AVE)");
            match = exp.Match(title);
            if (match.Success == false)
            {
                ErrorMessages.Add("Streeet Type is invalid.");
                AllValid = false;
            }
        }

        public void Postcode(string postcode)
        {
            exp = new Regex(@"^[0-9]{4}$");
            match = exp.Match(postcode);
            if (match.Success == false)
            {
                ErrorMessages.Add("Postcode is invalid.");
                AllValid = false;
            }
        }

        public void CardNumber(string cardNumber)
        {
            exp = new Regex(@"^4[0-9]{12}(?:[0-9]{3})?$"); // for visa
            Match visa = exp.Match(cardNumber);
            exp = new Regex(@"^(?:5[1-5][0-9]\d{1}|222[1-9]|2[3-6][0-9]\d{1}|27[01][0-9]|2‌​720)([\ \-]?)\d{4}\1\d{4}\1\d{4}$"); // for visa mastercard
            Match master = exp.Match(cardNumber);
            exp = new Regex(@"^(62[0-9]{14,17})$"); // for union pay
            Match union = exp.Match(cardNumber);

            if (visa.Success)
            {
                ValidCardType = "Card Type: Visa";
            }
            else if (master.Success)
            {
                ValidCardType = "Card Type: Visa Master Card";
            }
            else if (union.Success)
            {
                ValidCardType = "Card Type: Union Pay Card";
            }
            else
            {
                ErrorMessages.Add("Card Number is invalid.");
                AllValid = false;
            }
        }

        public void CardHolder(string cardholder)
        {
            exp = new Regex(@"^*[A-Za-z]$");
            match = exp.Match(cardholder);
            if (match.Success == false)
            {
                ErrorMessages.Add("Card Holders Name is invalid.");
                AllValid = false;
            }
        }

        public void CVV(string cvv)
        {
            exp = new Regex(@"^[0-9]{3}$");
            match = exp.Match(cvv);
            if (match.Success == false)
            {
                ErrorMessages.Add("CVV is invalid.");
                AllValid = false;
            }
        }

        public void CardDate(string date, string dateType)
        {
            exp = new Regex(@"^(0[1-9]|1[0-2])\/?([0-9]{4}|[0-9]{2})$");
            match = exp.Match(date);
            if (match.Success == false)
            {
                ErrorMessages.Add(dateType + " is invalid.");
                AllValid = false;
            }
        }
    }
}
