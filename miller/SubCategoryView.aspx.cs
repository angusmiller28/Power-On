using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace miller0061072133
{
    public partial class SubCategoryView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string man_ID = get_category_name();

            string xmlPath = Request.PhysicalApplicationPath + @"App_Data\..\Models\productCategoryData.xml";
            string xsltPath = Request.PhysicalApplicationPath + @"App_Data\..\Controllers\productCategoryDetails.xslt";
            XPathDocument xPathDoc = new XPathDocument(xmlPath);
            XslCompiledTransform transform = new XslCompiledTransform();
            XsltArgumentList xsltArgsList = new XsltArgumentList();
            xsltArgsList.AddParam("categoryid", "", man_ID);
            transform.Load(xsltPath);
            transform.Transform(xPathDoc, xsltArgsList, Response.Output);

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

        protected string get_category_name()
        {
            string category = Request.QueryString["category"];
            if (category == "")
            {
                return null;
            }
            return category;
        }
    }

   
}