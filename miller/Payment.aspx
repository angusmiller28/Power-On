<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Payment.aspx.cs" Inherits="miller0061072133.Views.Payment" %>
<%@ Register src="~/Partials/header.ascx" tagname="header" tagprefix="uc1" %>
<%@ Register src="~/Partials/nav.ascx" tagname="nav" tagprefix="uc2" %>
<%@ Register src="~/Partials/footer.ascx" tagname="footer" tagprefix="uc3" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link href="Styles/customerDetails.min.css" rel="stylesheet" />
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
                  <asp:Button ID="Button2" class="btn btn-primary" runat="server" Text="Review & Pay" onclick="Button2_Click"/>
                </div>
              </div>
              <section id="checkout-container">
                  <ul>
                      <li><a href="Checkout.aspx">Customer Details</a></li>
                  </ul>
                      
                      <h1>Payment information</h1>
                                    <asp:PlaceHolder ID="error_messages" runat="server"></asp:PlaceHolder>

						  <asp:Label ID="lbl_error" runat="server" Text=""></asp:Label>
                          <asp:Label ID="lbl_card_type" runat="server" Text=""></asp:Label>
                  <div>
                    <asp:Label ID="lbl_cardholders_name" runat="server" Text="Cardholders name"></asp:Label>
                    <asp:TextBox ID="txt_cardholders_name" runat="server"></asp:TextBox>
                  </div>
						<div>
                          <asp:Label ID="lbl_card_number" runat="server" Text="Card Number"></asp:Label>
                          <asp:TextBox ID="txt_card_number" runat="server"></asp:TextBox>

						</div>  
                         <div>
                             <asp:Label ID="lbl_card_start_date" runat="server" Text="Start Date"></asp:Label>
                          <asp:TextBox ID="txt_card_start_date" runat="server"></asp:TextBox>
                         </div>
                         <div>
                             <asp:Label ID="lbl_card_end_date" runat="server" Text="End Date"></asp:Label>
                          <asp:TextBox ID="txt_card_end_date" runat="server"></asp:TextBox>
                         </div>
						  <div>
                            <asp:Label ID="lbl_card_issue_number" runat="server" Text="Issue Number"></asp:Label>
                          <asp:TextBox ID="txt_card_issue_number" runat="server"></asp:TextBox>
						  </div>
						  

              </section>
            </section>
        </div>
    </form>
</body>
</html>
