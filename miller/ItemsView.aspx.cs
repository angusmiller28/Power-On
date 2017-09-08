using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace miller0061072133
{
    public partial class CategoryItemsView : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            StringWriter sw = new StringWriter();
            string category_ID = Request.QueryString["category"];
            string subcategory_ID = Request.QueryString["subcategory"];
            string type_ID = Request.QueryString["type"];

            string xmlPath = Request.PhysicalApplicationPath + @"App_Data\..\Models\productlist.xml";
            string xsltPath = Request.PhysicalApplicationPath + @"App_Data\..\Controllers\productlistController.xslt";
            XPathDocument xPathDoc = new XPathDocument(xmlPath);
            XslCompiledTransform transform = new XslCompiledTransform();
            XsltArgumentList xsltArgsList = new XsltArgumentList();

            if (category_ID != null)
                xsltArgsList.AddParam("categoryid", "", category_ID);
            if (subcategory_ID != null)
                xsltArgsList.AddParam("subcategoryid", "", subcategory_ID);
            if (type_ID != null)
                xsltArgsList.AddParam("typeid", "", type_ID);

            transform.Load(xsltPath);
            transform.Transform(xPathDoc, xsltArgsList, sw);

            string result = sw.ToString();
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
    }
}