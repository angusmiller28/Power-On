using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace miller0061072133
{
    public class Customer
    {
        // setters and getters
        private string Title { get; set; }
        private string Fname { get; set; }
        private string Mname { get; set; }
        private string Lname { get; set; }
        private string Country { get; set; }
        private string State { get; set; }
        private string City { get; set; }
        private string Suburb { get; set; }
        private string Postcode { get; set; }
        private string StreetType { get; set; }
        private string StreetName { get; set; }
        private string StreetNumber { get; set; }
        private string PropertyName { get; set; }
        private string ShippingTitle { get; set; }
        private string ShippingFname { get; set; }
        private string ShippingMname { get; set; }
        private string ShippingLname { get; set; }
        private string ShippingEmail { get; set; }
        private string ShippingCountry { get; set; }
        private string ShippingState { get; set; }
        private string ShippingCity { get; set; }
        private string ShippingSuburb { get; set; }
        private string ShippingPostcode { get; set; }
        private string ShippingStreetType { get; set; }
        private string ShippingStreetName { get; set; }
        private string ShippingStreetNumber { get; set; }
        private string ShippingPropertyName { get; set; }
        private string ID { get; set; }
        private string Email { get; set; }
        private string CardHoldersName { get; set; }
        private string CardNumber { get; set; }
        private string CardStartDate { get; set; }
        private string CardEndDate { get; set; }
        private string CardIssueNumber { get; set; }
        
        // Constructors
        public Customer()
        {
            Console.Write("Hello. This is the Customer Class");
        }

        public Customer(string Title, string Fname, string Mname, string Lname, string Country, string State, string City, string suburb, string postcode, string streetType, string streetName, string streetNumber, string propertyName, string email)
        {
            GenerateID();
            this.Title = Title;
            this.Fname = Fname;
            this.Mname = Mname;
            this.Lname = Lname;
            this.Country = Country;
            this.State = State;
            this.City = City;
            this.Suburb = suburb;
            this.Postcode = postcode;
            this.StreetName = streetName;
            this.StreetType = streetType;
            this.StreetNumber = streetNumber;
            this.PropertyName = propertyName;
            this.Email = email;

        }


        public string GetCardNumber()
        {
            return this.CardNumber;
        }

        // private 
        private void GenerateID()
        {
            this.ID = Guid.NewGuid().ToString("N");
        }

        // public
        public void AddPaymentData(string cardNumber, string cardholdersName, string cardStartDate, string cardEndDate, string cardIssueNumber)
        {
            this.CardHoldersName = cardholdersName;
            this.CardNumber = cardNumber;
            this.CardStartDate = cardStartDate;
            this.CardEndDate = cardEndDate;
            this.CardIssueNumber = cardIssueNumber;
        }

        public void AddShippingData(string ShippingTitle, string ShippingFname, string ShippingMname, string ShippingLname, string ShippingEmail, string ShippingCountry, string ShippingState, string ShippingCity, string ShippingSuburb, string ShippingPostcode, string ShippingStreetType, string ShippingStreetName, string ShippingStreetNumber, string ShippingPropertyName)
        {
            this.ShippingTitle = ShippingTitle;
            this.ShippingFname = ShippingFname;
            this.ShippingMname = ShippingMname;
            this.ShippingLname = ShippingLname;
            this.ShippingEmail = ShippingEmail;
            this.ShippingCountry = ShippingCountry;
            this.ShippingState = ShippingState;
            this.ShippingCity = ShippingCity;
            this.ShippingSuburb = ShippingSuburb;
            this.ShippingPostcode = ShippingPostcode;
            this.ShippingStreetName = ShippingStreetName;
            this.ShippingStreetType = ShippingStreetType;
            this.ShippingStreetNumber = ShippingStreetNumber;
            this.ShippingPropertyName = ShippingPropertyName;
        }

        public void Insert(Customer customer)
        {
            this.ID = customer.ID;
            this.Title = customer.Title;
            this.Fname = customer.Fname;
            this.Mname = customer.Mname;
            this.Lname = customer.Lname;
            this.Country = customer.Country;
            this.State = customer.State;
            this.City = customer.City;
            this.Suburb = customer.Suburb;
            this.Postcode = customer.Postcode;
            this.StreetName = customer.StreetName;
            this.StreetNumber = customer.StreetNumber;
            this.StreetType = customer.StreetType;
            this.Email = customer.Email;
            this.PropertyName = customer.PropertyName;
        }

        public string GetID()
        {
            return this.ID;
        }

        public string GetAddress()
        {
            return this.StreetNumber + " " + this.StreetName + " " + this.StreetType + " " + this.Suburb + " " + this.City + " " + this.State + " " + this.Country;
        }

        public string GetName()
        {
            return this.Title + " " + this.Fname + " " + Mname + " " + Lname;
        }

        public string GetTitle()
        {
            return this.Title;
        }

        public string GetFirstName()
        {
            return this.Fname;
        }

        public string GetMiddleName()
        {
            return this.Mname;
        }

        public string GetLastName()
        {
            return this.Lname;
        }

        public string GetEmail()
        {
            return this.Email;
        }

        public string GetCountry()
        {
            return this.Country;
        }

        public string GetState()
        {
            return this.State;
        }

        public string GetCity()
        {
            return this.City;
        }

        public string GetSuburb()
        {
            return this.Suburb;
        }

        public string GetPostcode()
        {
            return this.Postcode;
        }

        public string GetStreetType()
        {
            return this.StreetType;
        }

        public string GetStreetName()
        {
            return this.StreetName;
        }

        public string GetUnitNumber()
        {
            return this.StreetNumber;
        }

        public string GetPropertyName()
        {
            return this.PropertyName;
        }

        public string GetShippingAddress()
        {
            return this.ShippingStreetNumber + " " + this.ShippingStreetName + " " + this.ShippingStreetType + " " + this.ShippingSuburb + " " + this.ShippingCity + " " + this.ShippingState + " " + this.ShippingCountry;
        }

        public string GetNameShipping()
        {
            return this.ShippingTitle + " " + this.ShippingFname + " " + ShippingMname + " " + ShippingLname;
        }

        public string GetTitleShipping()
        {
            return this.ShippingTitle;
        }

        public string GetFirstNameShipping()
        {
            return this.ShippingFname;
        }

        public string GetMiddleNameShipping()
        {
            return this.ShippingMname;
        }

        public string GetLastNameShipping()
        {
            return this.ShippingLname;
        }

        public string GetEmailShipping()
        {
            return this.ShippingEmail;
        }

        public string GetCountryShipping()
        {
            return this.ShippingCountry;
        }

        public string GetStateShipping()
        {
            return this.ShippingState;
        }

        public string GetCityShipping()
        {
            return this.ShippingCity;
        }

        public string GetSuburbShipping()
        {
            return this.ShippingSuburb;
        }

        public string GetPostcodeShipping()
        {
            return this.ShippingPostcode;
        }

        public string GetStreetTypeShipping()
        {
            return this.ShippingStreetType;
        }

        public string GetStreetNameShipping()
        {
            return this.ShippingStreetName;
        }

        public string GetUnitNumberShipping()
        {
            return this.ShippingStreetNumber;
        }

        public string GetPropertyNameShipping()
        {
            return this.ShippingPropertyName;
        }

        public string GetCardHoldersName()
        {
            return this.CardHoldersName;
        }

        public string GetCardStartDate()
        {
            return this.CardStartDate;
        }

        public string GetCardEndDate()
        {
            return this.CardEndDate;
        }

        public string GetCardIssueNumber()
        {
            return this.CardIssueNumber;
        }
    }
}