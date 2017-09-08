<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProccessedPayment.aspx.cs" Inherits="miller.ProccessedPayment" %>
<%@ Register src="Partials/header.ascx" tagname="header" tagprefix="uc1" %>
<%@ Register src="Partials/nav.ascx" tagname="nav" tagprefix="uc2" %>
<%@ Register Src="Partials/header.ascx" TagPrefix="uc2" TagName="header" %>
<%@ Register src="Partials/footer.ascx" tagname="footer" tagprefix="uc3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
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
                    
                  </div>
                  <div id="navigation-view-controls">
                   
                  </div>
                </div>
                <section>
                    <h1>Success! Payment processed and your order being processed as we speak!</h1>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CustomerConnectionString %>" SelectCommand="SELECT * FROM [Customers]"></asp:SqlDataSource>

                </section>
              </section>

            <uc3:footer ID="footer1" runat="server" />
         </div>
    </form>
</body>
</html>
