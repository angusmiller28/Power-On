using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace miller0061072133.Partials
{
    public partial class header1 : System.Web.UI.UserControl
    {
        Customer customer;
        protected void Page_Load(object sender, EventArgs e)
        {
            customer = (Customer)Session["customer"];

            if (Session["customer"] != null && customer.GetID() != null)
            {
                HtmlGenericControl ul = new HtmlGenericControl("ul");
                HtmlGenericControl ul_inner = new HtmlGenericControl("ul");
                HtmlGenericControl li = new HtmlGenericControl("li");
                HtmlGenericControl li_profile_section = new HtmlGenericControl("li");
                HtmlGenericControl button = new HtmlGenericControl("div");
                HtmlGenericControl button_link = new HtmlGenericControl("a");
                Image profile_icon = new Image();

                Label myAccount = new Label();

                // Set data
                myAccount.Text = "My Account";
                profile_icon.ImageUrl = "#";
                button_link.InnerText = "View Profile";

                // Set Attributes
                li.Attributes.Add("class", "navbar-title");
                ul_inner.Attributes.Add("class", "navbar-dropdown-inner account-navbar-section");
                button.Attributes.Add("class", "btn btn-primary btn-large");
                button_link.Attributes.Add("class", "#");

                // Add to page
                li.Controls.Add(myAccount);
                li.Controls.Add(ul_inner);
                ul_inner.Controls.Add(li_profile_section);
                li_profile_section.Controls.Add(profile_icon);
                li_profile_section.Controls.Add(button);
                button.Controls.Add(button_link);

                ul.Controls.Add(li);

                accountContainer.Controls.Add(ul);
            }
            else
            {

            }
                
        }
    }
}