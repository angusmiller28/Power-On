<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="miller.Signup" %>

<%@ Register src="Partials/header.ascx" tagname="header" tagprefix="uc1" %>
<%@ Register src="Partials/nav.ascx" tagname="nav" tagprefix="uc2" %>
<%@ Register Src="Partials/header.ascx" TagPrefix="uc2" TagName="header" %>
<%@ Register src="Partials/footer.ascx" tagname="footer" tagprefix="uc3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="container">
         <uc2:header runat="server" ID="header" />
         <nav id="subnav">
           <uc2:nav ID="nav1" runat="server" />
         </nav>
          <section id="main">
                <div id="page-controls">
                  <div id="navigation-page-controls">
                    <asp:Button runat="server" ID="btnBack" class="btn" Text="Back" onclick="btnBack_Click" />
                  </div>
                  <div id="navigation-content-controls">
                    <ul>
                      <li>Featured Products</li>
                      <li>Discounted Products</li>
                    </ul>
                  </div>
                  <div id="navigation-view-controls">
                  <asp:Button ID="Button2" class="btn btn-primary" runat="server" Text="Create" onclick="Button2_Click" />
                </div>
                </div>
                <section id="checkout-container">
                  
                      <h1>Billing information</h1>

                  <asp:PlaceHolder ID="error_messages" runat="server"></asp:PlaceHolder>
                        <div>
                          <asp:Label ID="lbl_username" runat="server" Text="Username"></asp:Label>
                          <asp:TextBox ID="txt_username" runat="server"></asp:TextBox>
                        </div>
						<div>
                             <asp:Label ID="lbl_password" runat="server" Text="Password"></asp:Label>
                          <asp:TextBox ID="txt_password" runat="server"></asp:TextBox>
						</div>
                          <div>
                              <asp:Label ID="lbl_email_address" runat="server" Text="Email Address"></asp:Label>
                          <asp:TextBox ID="txt_email_address" runat="server"></asp:TextBox>
                          </div>
                         
              </section>
          </section>

          <uc3:footer ID="footer1" runat="server" />

        </div>
    </form>
</body>
</html>
