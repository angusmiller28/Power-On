using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace miller0061072133.Views
{
    public partial class ShoppingCart : System.Web.UI.Page
    {
        Cart myCart;
        Label emptyMessage = new Label();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["myCart"] == null)
            {
                Session["myCart"] = new Cart();
            }

            myCart = (Cart)Session["myCart"];

            emptyMessage.Text = "No items in cart!";
            emptyCartContainer.Controls.Add(emptyMessage);

            if (!IsPostBack)
            {
                FillData();
            }

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

        private void CartEmptyFillData() { 
            if (myCart.GetItems().Count == 0)
            {
                btnCheckout.Visible = false;
                emptyMessage.Visible = true;    
            } else
            {
                btnCheckout.Visible = true;
                emptyMessage.Visible = false;
            }
        }

        private void FillData()
        {
            gvShoppingCart.DataSource = myCart.GetItems();
            gvShoppingCart.DataBind();
            if (myCart.GetItems().Count == 0)
            {
                lblGrandTotal.Visible = false;
            } else
            {
                lblGrandTotal.Text = string.Format("Grand Total = {0,19:C}", myCart.GrandTotal);
                lblGrandTotal.Visible = true;
            }
            CartEmptyFillData();
        }

        protected void gvShoppingCart_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvShoppingCart.EditIndex = -1;
            FillData();
        }

        protected void gvShoppingCart_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            myCart.Delete(e.RowIndex);
            FillData();
        }

        protected void gvShoppingCart_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            TextBox txtQuantity = (TextBox)gvShoppingCart.Rows[e.RowIndex].Cells[3].Controls[0];
            int quantity = Int32.Parse(txtQuantity.Text);
            myCart.Update(e.RowIndex, quantity);
            gvShoppingCart.EditIndex = -1;
            FillData();
        }

        protected void gvShoppingCart_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvShoppingCart.EditIndex = e.NewEditIndex;
            FillData();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (myCart.GetItems().Count != 0)
                Response.Redirect("Checkout.aspx");
        }
    }
}