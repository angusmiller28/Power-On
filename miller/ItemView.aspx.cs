using System;
using System.Collections.Generic;
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

        private void AddToShoppingCart(int ProductID)
        {
            
            //HttpCookieCollection myHTTPCookieCollection = new HttpCookieCollection();

            // Create product id cookie
            //HttpCookie productID = new HttpCookie("ProductID");
            //productID.Value = get_productID();
            //myHTTPCookieCollection.Add(productID);

            //Session.Add("myHTTPCookieCollection", myHTTPCookieCollection);
            //Response.Redirect("DisplayCookies.aspx");
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