<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="miller0061072133.Views.Checkout" %>

<%@ Register src="~/Partials/header.ascx" tagname="header" tagprefix="uc1" %>
<%@ Register src="~/Partials/nav.ascx" tagname="nav" tagprefix="uc2" %>
<%@ Register src="~/Partials/footer.ascx" tagname="footer" tagprefix="uc3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Styles/customerDetails.min.css" rel="stylesheet" />
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
                  <asp:Button ID="Button2" class="btn btn-primary" runat="server" Text="Pay Details" OnClick="Button2_Click"  />
                </div>
              </div>
                <asp:PlaceHolder ID="customerContainer" runat="server"></asp:PlaceHolder>
              <section id="checkout-container">
                  
                      <h1>Billing information</h1>

                  <asp:PlaceHolder ID="error_messages" runat="server"></asp:PlaceHolder>
                        <div>
                          <asp:Label ID="lbl_title" runat="server" Text="Title"></asp:Label>
                          <asp:DropDownList ID="lst_title" runat="server"></asp:DropDownList>
                        </div>
                        <div>
                          <asp:Label ID="lbl_fname" runat="server" Text="Firstname"></asp:Label>
                          <asp:TextBox ID="txt_fname" runat="server"></asp:TextBox>
                        </div>
						<div>
                             <asp:Label ID="lbl_mname" runat="server" Text="Middle(s)"></asp:Label>
                          <asp:TextBox ID="txt_mname" runat="server"></asp:TextBox>
						</div>
                         <div>
                             <asp:Label ID="lbl_lname" runat="server" Text="Lastname"></asp:Label>
                          <asp:TextBox ID="txt_lname" runat="server"></asp:TextBox>
                         </div>
                          <div>
                              <asp:Label ID="lbl_email_address" runat="server" Text="Email Address"></asp:Label>
                          <asp:TextBox ID="txt_email_address" runat="server"></asp:TextBox>
                          </div>
                         
                          <div class="address-container">
                              <div>
                                  <h3>Address</h3>
                              </div>
                            
                            <div>
                                <asp:Label ID="lbl_country" runat="server" Text="Country"></asp:Label>
                                <asp:TextBox ID="txt_country" runat="server"></asp:TextBox>
                            </div>
                           <div>
                               <asp:Label ID="lbl_state" runat="server" Text="State"></asp:Label>
                                <asp:TextBox ID="txt_state" runat="server"></asp:TextBox>
                           </div>
                            <div>
                                 <asp:Label ID="lbl_city" runat="server" Text="city/town"></asp:Label>
                                <asp:TextBox ID="txt_city" runat="server"></asp:TextBox>
                            </div>
                            <div>
                                 <asp:Label ID="lbl_suburb" runat="server" Text="Suburb"></asp:Label>
                                <asp:TextBox ID="txt_suburb" runat="server"></asp:TextBox>
                            </div>
                            <div>
                                <asp:Label ID="lbl_postcode" runat="server" Text="Postcode"></asp:Label>
                                <asp:TextBox ID="txt_postcode" runat="server"></asp:TextBox>
                            </div>
                            <div>
                                <asp:Label ID="lbl_street_type" runat="server" Text="Street Type"></asp:Label>
                                <asp:DropDownList ID="lst_street_type" runat="server"></asp:DropDownList> 
                            </div>
                            <div>
                                <asp:Label ID="lbl_street_name" runat="server" Text="Street Name"></asp:Label>
                                <asp:TextBox ID="txt_street_name" runat="server"></asp:TextBox>
                            </div>
                            <div>
                                <asp:Label ID="lbl_unit_number" runat="server" Text="Unit/Street Number"></asp:Label>
                                <asp:TextBox ID="txt_unit_number" runat="server"></asp:TextBox>
                            </div>
                            <div>
                                <asp:Label ID="lbl_property_name" runat="server" Text="Property Name"></asp:Label>
                                <asp:TextBox ID="txt_property_name" runat="server"></asp:TextBox>
                            </div>
                            
                          </div>
              </section>
            </section>
        </div>
    </form>
</body>
</html>
