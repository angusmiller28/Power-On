using miller0061072133;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace miller
{
    public partial class Shipping : System.Web.UI.Page
    {
        Customer customer;
        Cart myCart;
        Validation validate = new Validation();
        protected void Page_Load(object sender, EventArgs e)
        {
            myCart = (Cart)Session["myCart"];

            // validate customer has items in cart
            if (Session["myCart"] == null)
            {
                Response.Redirect("Home.aspx");
            }
            else if (myCart.GetItems().Count == 0)
            {
                Response.Redirect("Home.aspx");
            }

            customer = (Customer)Session["customer"];

            if (Session["customer"] == null)
            {
                Response.Redirect("Checkout.aspx");
            }

            if (!IsPostBack) //check if the webpage is loaded for the first time.
            {
                ViewState["PreviousPage"] = Request.UrlReferrer;//Saves the Previous page url in ViewState

                // add items to title listbox
                lst_title.Items.Add("Mr");
                lst_title.Items.Add("Mrs");
                // add items to street type 
                lst_street_type.Items.Add("ST");
                lst_street_type.Items.Add("TER");
                lst_street_type.Items.Add("DR");
                lst_street_type.Items.Add("AVE");
            }
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

        protected void btn_next_click(object sender, EventArgs e)
        {
            // get customer data for session
            string title = lst_title.Text;
            string city = txt_city.Text;
            string country = txt_country.Text;
            string email = txt_email_address.Text;
            string fname = txt_fname.Text;
            string lname = txt_lname.Text;
            string mname = txt_mname.Text;
            string postcode = txt_postcode.Text;
            string property = txt_property_name.Text;
            string state = txt_state.Text;
            string streetName = txt_street_name.Text;
            string streetType = lst_street_type.Text;
            string suburb = txt_suburb.Text;
            string unitNumber = txt_unit_number.Text;
            string propertyName = txt_property_name.Text;

            // validate data
            validate.Title(title);
            validate.Name(streetName, "Street Name");
            validate.Name(propertyName, "Property Name");
            validate.Name(fname, "First Name");
            validate.Name(mname, "Middle Name");
            validate.Name(lname, "Last Name");
            validate.Name(country, "Country");
            validate.Name(state, "State");
            validate.Name(city, "City");
            validate.Name(suburb, "Suburb");
            validate.Postcode(postcode);
            validate.StreetType(streetType);
            validate.StreetNumber(unitNumber);
            validate.Email(email);

            // save customer data to session
            if (validate.AllValid)
            {
                customer.AddShippingData(title, fname, mname, lname, email, country, state, city, suburb, postcode, streetType, streetName, unitNumber, propertyName);
                Response.Redirect("Payment.aspx");      
            }
            else
            {
                // add all invalid data error messsages to a label and add to checkout view
                for (int i = 0; i <= validate.GetErrorMessages().Count - 1; i++)
                {
                    Label lbl = new Label();
                    lbl.Text = validate.GetErrorMessages()[i];
                    error_messages.Controls.Add(lbl);
                }
            }
        }
    }

}