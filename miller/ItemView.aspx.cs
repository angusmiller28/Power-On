using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace miller0061072133
{
    public partial class ItemView : System.Web.UI.Page
    {
        Cart myCart;
        string result;
        protected void Page_Init(object sender, EventArgs e)
        {
            string man_ID = get_productID();

            //create argument list
            XsltArgumentList xslArg = new XsltArgumentList();
            xslArg.AddParam("productid", "", man_ID);

            //load the data
            XPathDocument xdoc = new XPathDocument(Server.MapPath("Models\\productlist.xml"));
            //load Xslt
            XslCompiledTransform transformed = new XslCompiledTransform();
            transformed.Load(Server.MapPath("Controllers\\productController.xslt"));
            StringWriter sw = new StringWriter();
            //transform it
            transformed.Transform(xdoc, xslArg, sw);
            result = sw.ToString();
            //remove namespace
            result = result.Replace("xmlns:asp=\"remove\"", "");

            //parse control
            Control ctrl = Page.ParseControl(result);
            Placeholder1.Controls.Add(ctrl);

            AddReviewsSection();
        }

        protected void AddReviewsSection()
        {
            ///////////////////////
            // Add review section
            ///////////////////////
            HtmlGenericControl container = new HtmlGenericControl("div");
            
            HtmlGenericControl comment = new HtmlGenericControl("textarea");

            // Set attributes
            for(int i=0; i<5; i++)
            {
                HtmlGenericControl rating = new HtmlGenericControl("i");
                rating.Attributes.Add("class", "fa fa-star-o");
                rating.Attributes.Add("aria-hidden", "true");
                container.Controls.Add(rating);
            }
            

            //rating.InnerText = "Rating";
            comment.InnerText = "This is a comment";

            
            container.Controls.Add(comment);

            addReviewContainer.Controls.Add(container);

            ///////////////////////
            // Users Review section
            ///////////////////////
            container = new HtmlGenericControl("div");
            HtmlGenericControl name = new HtmlGenericControl("h2");
            comment = new HtmlGenericControl("p");

            name.InnerText = "Angus Miller";
            comment.InnerText = "This is a comment";

            container.Controls.Add(name);
            container.Controls.Add(comment);

            // attributes
            container.ID = "product-review-card";
            reviewContainer.Controls.Add(container);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) //check if the webpage is loaded for the first time.
            {
                ViewState["PreviousPage"] = Request.UrlReferrer;//Saves the Previous page url in ViewState
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

        protected void btn_Add_Review_Click(object sender, EventArgs e)
        {
            // add review to database with the product id, user, comment etc
            try
            {

                
            
                // datebase connection 
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CustomerConnectionString"].ConnectionString);
                conn.Open();

                string insertQuery = "insert into Review(UserID, ProductID, Comment, Rating) values (@UserID, @ProductID, @Comment, @Rating)";
                SqlCommand cmd = new SqlCommand(insertQuery, conn);
                cmd.Parameters.AddWithValue("@UserID", 1);
                cmd.Parameters.AddWithValue("@ProductID", "1000-0000-000");
                cmd.Parameters.AddWithValue("@Comment", "First Comment");
                cmd.Parameters.AddWithValue("@Rating", "6");
                cmd.ExecuteNonQuery();

                conn.Close();


            }
            catch (Exception ex)
            {
                Debug.WriteLine("error" + ex.ToString());
            }
        }

        protected void Button_Click1(object sender, EventArgs e)
        {

            if (Session["myCart"] == null)
            {
                Session["myCart"] = new Cart();
            }

            

            string id = get_productID();
            // get xml data for id//load the data
            var doc = XDocument.Load(Server.MapPath("Models\\productlist.xml"));
            string ID = get_productID();
            string name = doc.Descendants("product").Where(x => (string) x.Element("code") == id).Select(x => (string) x.Element("name")).FirstOrDefault();
            string image = doc.Descendants("product").Where(x => (string)x.Element("code") == id).Select(x => (string)x.Element("image")).FirstOrDefault();
            string description = doc.Descendants("product").Where(x => (string)x.Element("code") == id).Select(x => (string)x.Element("description")).FirstOrDefault();
            double price = Double.Parse(doc.Descendants("product").Where(x => (string)x.Element("code") == id).Select(x => (string)x.Element("price")).FirstOrDefault());        

            myCart = (Cart)Session["myCart"];
            myCart.Insert(new CartItem(ID, 
                name, 
                image, 
                description, 
                price, 
                1)
            );

            Response.Redirect("ShoppingCart.aspx");
        }

        protected string get_productID()
        {
            string productID = Request.QueryString["Product"];
            if (productID == "")
            {
                return null;
            }
            this.product_id.Text = productID;
            return productID;
        }

        
    }
}