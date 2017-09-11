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
using miller;

namespace miller0061072133
{
    public partial class ItemView : System.Web.UI.Page
    {
        Cart myCart;
        User user;
        string result;
        TextBox comment = new TextBox();

        protected void Page_Init(object sender, EventArgs e)
        {
            user = (User)Session["user"];
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

        protected bool LoggedIn(){
			

			// validate customer has items in cart
			if (user == null)
			{
                return false;
			}

            return true;
        }

        protected void AddReviewsSection()
        {
            // check if user is logged in
            if (LoggedIn())
            {
                ///////////////////////
                // Add review section
                ///////////////////////
                HtmlGenericControl container = new HtmlGenericControl("div");

                // Set attributes
                for (int i = 0; i < 5; i++)
                {
                    HtmlGenericControl rating = new HtmlGenericControl("i");
                    rating.Attributes.Add("class", "fa fa-star-o");
                    rating.Attributes.Add("aria-hidden", "true");
                    container.Controls.Add(rating);
                }

                comment.Text = "This is a comment";


                container.Controls.Add(comment);

                addReviewContainer.Controls.Add(container);
            }

			///////////////////////
			// Users Review section
			///////////////////////
			try
			{

				// datebase connection 
				SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CustomerConnectionString"].ConnectionString);
				conn.Open();

				string insertQuery = "select Username, Comment, Rating from Review where ProductID = @pageID";
				SqlCommand cmd = new SqlCommand(insertQuery, conn);
				cmd.Parameters.AddWithValue("@pageID", get_productID());
                SqlDataReader reader = cmd.ExecuteReader();

				while (reader.Read())
				{

					HtmlGenericControl container2 = new HtmlGenericControl("div");
					HtmlGenericControl username = new HtmlGenericControl("h2");
					HtmlGenericControl comment = new HtmlGenericControl("p");

					username.InnerText = (string)reader["Username"];
					comment.InnerText = (string)reader["Comment"];

					// Set attributes
					for (int i = 0; i < 5; i++)
					{
						HtmlGenericControl rating = new HtmlGenericControl("i");
						rating.Attributes.Add("class", "fa fa-star-o");
						rating.Attributes.Add("aria-hidden", "true");
						container2.Controls.Add(rating);
					}

					container2.Controls.Add(username);
					container2.Controls.Add(comment);

					// attributes
					container2.ID = "product-review-card";
					reviewContainer.Controls.Add(container2);

				}

				reader.NextResult();

				
				conn.Close();


			}
			catch (Exception ex)
			{
				Debug.WriteLine("error" + ex.ToString());
			}


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
            if (LoggedIn())
            {
                string username = user.GetUsername();
                // add review to database with the product id, user, comment etc
                try
                {

                    // datebase connection 
                    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CustomerConnectionString"].ConnectionString);
                    conn.Open();

                    string insertQuery = "insert into Review(Username, ProductID, Comment, Rating) values (@Username, @ProductID, @Comment, @Rating)";
                    SqlCommand cmd = new SqlCommand(insertQuery, conn);
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@ProductID", get_productID());
                    cmd.Parameters.AddWithValue("@Comment", comment.Text);
                    cmd.Parameters.AddWithValue("@Rating", "6");
                    cmd.ExecuteNonQuery();

                    conn.Close();


                }
                catch (Exception ex)
                {
                    Debug.WriteLine("error" + ex.ToString());
                }
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