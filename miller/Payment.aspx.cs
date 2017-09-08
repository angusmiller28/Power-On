using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using miller;

namespace miller0061072133.Views
{
    public partial class Payment : System.Web.UI.Page
    {
        Customer customer;
        Cart myCart;
        Validation validate = new Validation();

        protected void Page_Load(object sender, EventArgs e)
        {
            customer = (Customer)Session["customer"];
            myCart = (Cart)Session["myCart"];

            // If customer is on this page and doesnt have items in card redirect to home. Else if customer session has not been created and the customer data has been complete
            // else redirect user to checkout to add details.
            if (Session["myCart"] == null)
            {
                Response.Redirect("Home.aspx");
            }
            else if (myCart.GetItems().Count == 0)
            {
                Response.Redirect("Home.aspx");
            }

            if (Session["customer"] == null)
            {
                Response.Redirect("Checkout.aspx");
            }
            else if (customer.GetSuburb() == null)
            {
                Response.Redirect("Checkout.aspx");
            }
           

            // check if the webpage is loaded for the first time.
            if (!IsPostBack)
            {
                ViewState["PreviousPage"] = Request.UrlReferrer; //Saves the Previous page url in ViewState
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            //Check if the ViewState 
            //contains Previous page URL
            if (ViewState["PreviousPage"] != null)
            {
                Response.Redirect(ViewState["PreviousPage"].ToString());//Redirect to Previous page by retrieving the PreviousPage Url from ViewState.
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            // get customer payment data for session
            string cardNumber = txt_card_number.Text;
            string cardHoldersName = txt_cardholders_name.Text;
            string cardStartDate = txt_card_start_date.Text;
            string cardEndDate = txt_card_end_date.Text;
            string cardIssueNumber = txt_card_issue_number.Text;

            // validate data
            //validate.CardNumber(cardNumber);
            validate.CardHolder(cardHoldersName);
            validate.CardDate(cardStartDate, "Start Date");
            validate.CardDate(cardEndDate, "End Date");
            validate.CVV(cardIssueNumber);

            if (validate.AllValid)
            {
                // save customer payment data to session
                customer.AddPaymentData(txt_card_number.Text, txt_cardholders_name.Text, txt_card_start_date.Text, txt_card_end_date.Text, txt_card_issue_number.Text);
                Response.Redirect("Review.aspx");
            }
            else
            {
                // add all invalid data error messsages to a label and add to payment view
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