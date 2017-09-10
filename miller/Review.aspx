<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Review.aspx.cs" Inherits="miller0061072133.Views.Review" %>
<%@ Register src="~/Partials/header.ascx" tagname="header" tagprefix="uc1" %>
<%@ Register src="~/Partials/nav.ascx" tagname="nav" tagprefix="uc2" %>
<%@ Register src="~/Partials/footer.ascx" tagname="footer" tagprefix="uc3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <link href="Styles/review.min.css" rel="stylesheet" />
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
</head>
<body>
    <form id="form1" runat="server">
       <div id="container">
       <uc1:header ID="header1" runat="server" />
            <nav id="subnav">
              <uc2:nav ID="nav1" runat="server" />
            </nav>
           
            <section id="main">
              <div id="page-controls">
                <div id="navigation-page-controls">
                  <asp:Button runat="server" ID="btnBack" class="btn" Text="Back" onclick="btnBack_Click" />            
                </div>
                <div id="navigation-content-controls">

                </div>
                <div id="navigation-view-controls">
                  <asp:Button ID="Button2" class="btn btn-primary" runat="server" Text="Confirm" onclick="Button2_Click" />
                </div>
              </div>
              <section id="checkout-container">
                  <div id="info-container">
                      <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CustomerConnectionString %>"></asp:SqlDataSource>

                       <ul>
                          <li> <a href="Checkout.aspx">Customer Details</a></li>
                          <li> <a href="Payment.aspx">Payment Details</a></li>
                      </ul>

                      <h1>Review information</h1>

                      <div id="product-info-container">
                          <h3>Product going to purchase</h3>
                          <asp:PlaceHolder id="PlaceHolder1" runat="server"/>
                          <asp:Label ID="lbl_grand_total" CssClass="lbl_review_details" runat="server" Text=""></asp:Label>
                       </div>
                       <div id="customer-info-container">          
                          <h3>Customer Details</h3>
                          <h3>Billing Details</h3>
                           <div>
                              <asp:Label ID="lbl_name" runat="server" Text="Full Name"></asp:Label>
                              <asp:Label ID="txt_name" runat="server"></asp:Label>
                           </div>
                           <div>
                              <asp:Label ID="lbl_email_address" runat="server" Text="Email Address"></asp:Label>
                              <asp:Label ID="txt_email_address" runat="server"></asp:Label>
                           </div>
                           <div>
                             <asp:Label ID="lbl_address" runat="server" Text="Address"></asp:Label>
                             <asp:Label ID="txt_address" runat="server"></asp:Label>
                           </div>

                           <h3>Shipping Details</h3>
                           <div>
                              <asp:Label ID="lbl_shipping_name" runat="server" Text="Full Name"></asp:Label>
                              <asp:Label ID="txt_shipping_name" runat="server"></asp:Label>
                           </div>
                           <div>
                              <asp:Label ID="lbl_shipping_email_address" runat="server" Text="Email Address"></asp:Label>
                              <asp:Label ID="txt_shipping_email_address" runat="server"></asp:Label>
                           </div>
                           <div>
                             <asp:Label ID="lbl_shipping_address" runat="server" Text="Address"></asp:Label>
                             <asp:Label ID="txt_shipping_address" runat="server"></asp:Label>
                           </div>
                          
                      </div>
                      <div id="payment-info-container">
                          <h3>Payment Details</h3>
                          <div>
                            <asp:Label ID="lbl_cardholders_name" runat="server" Text="Cardholders name"></asp:Label>
                              <asp:Label ID="txt_cardholders_name" runat="server"></asp:Label>
                          </div>
                          <div>
                            <asp:Label ID="lbl_card_number" runat="server" Text="Card Number"></asp:Label>
                            <asp:Label ID="txt_card_number" runat="server"></asp:Label>
                          </div>
                          <div>
                            <asp:Label ID="lbl_card_start_date" runat="server" Text="Start Date"></asp:Label>
                            <asp:Label ID="txt_card_start_date" runat="server"></asp:Label>
                          </div>
                          <div>
                            <asp:Label ID="lbl_card_end_date" runat="server" Text="End Date"></asp:Label>
                            <asp:Label ID="txt_card_end_date" runat="server"></asp:Label>
                          </div>
                          <div>
                            <asp:Label ID="lbl_card_issue_number" runat="server" Text="Issue Number"></asp:Label>
                            <asp:Label ID="txt_card_issue_number" runat="server"></asp:Label>
                          </div>
                      </div>
                  </div>
              </section>
            </section>
        </div>
    </form>
</body>
</html>
