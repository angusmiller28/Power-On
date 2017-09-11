using miller;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace miller0061072133
{
    public partial class CategoryItemsView : System.Web.UI.Page
    {
        string category_ID;
        string subcategory_ID;
        string type_ID;
        string xmlPath;

        protected void Page_Init(object sender, EventArgs e)
        {
            StringWriter sw = new StringWriter();
            category_ID = Request.QueryString["category"];
            subcategory_ID = Request.QueryString["subcategory"];
            type_ID = Request.QueryString["type"];

            xmlPath = Request.PhysicalApplicationPath + @"App_Data\..\Models\productlist.xml";
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

            Filter_Fill();
        }

        public ArrayList CreateArrayList(string FilterListOptions)
        {
            ArrayList options = new ArrayList();
            // break string and add to array list
            string[] tokens = FilterListOptions.Split(new[] { "+" }, StringSplitOptions.None);

            foreach (string token in tokens)
                options.Add(token);

            return options;
        }

        protected void Filter_Fill()
        {
            // get all filter options for this pages subcategory and store in arraylist
            // all filter titles
            Dictionary<string, ArrayList> filterList = new Dictionary<string, ArrayList>();
            // all filter options for that filter title
            Filter filterObj = new Filter();

            // Parse the XML string; you can also load the XML from a file.
            xmlPath = Request.PhysicalApplicationPath + @"App_Data\..\Models\productlist.xml";

            // Parse the XML string; you can also load the XML from a file.
            XElement xmlSource = XElement.Load(xmlPath);

            // Get a collection of elements under each order node
            foreach (var x in xmlSource.Descendants("filterGroupMain"))
            {
                string title = x.Element("optionTitle").Value;
                string FilterListOptions = x.Element("option").Value;

               filterList.Add(title, CreateArrayList(FilterListOptions));
            }

            string filtername = null;

            if (category_ID != null)
                filtername = category_ID;
            else if (subcategory_ID != null)
                filtername = subcategory_ID;
            else if (type_ID != null)
                filtername = type_ID;

            filtername = filtername.Replace("%20", "");
            filtername = filtername.Replace(" ", "");
            Debug.WriteLine(filtername);

            foreach (var x in xmlSource.Descendants("filterGroup" + filtername))
            {
                string title = x.Element("optionTitle").Value;
                string FilterListOptions = x.Element("option").Value;

                filterList.Add(title, CreateArrayList(FilterListOptions));
            }

            // add all filter option for category
            int count = filterList.Count;
            Debug.WriteLine("Count: " + count);
            for (int j = 0; j <= count-1; j++)
            {
                HtmlGenericControl ul = new HtmlGenericControl("ul");
                HtmlGenericControl li = new HtmlGenericControl("li");
                HtmlGenericControl i = new HtmlGenericControl("i");
        

                // set attributes
                i.Attributes.Add("class", "fa fa-chevron-down");
                li.Attributes.Add("aria-hidden", "true");


                // set data 
                li.InnerText = filterList.ElementAt(j).Key;


                li.Controls.Add(i);
                ul.Controls.Add(li);
                int optCount = filterList.ElementAt(j).Value.Count - 1;
                Debug.WriteLine("Option Count: " + optCount);
                for (int g = 0; g <= optCount; g++)
                {
                    HtmlGenericControl li2 = new HtmlGenericControl("li");
                    HtmlGenericControl input = new HtmlGenericControl("input");
                    li2.Attributes.Add("aria-hidden", "true");
                    input.Attributes.Add("type", "checkbox");
                    input.InnerText = filterList.ElementAt(j).Value[g].ToString();
                    li2.Controls.Add(input);
                    ul.Controls.Add(li2);
                }
                optCount = 0;
                
                navFilter.Controls.Add(ul);
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
    }
}