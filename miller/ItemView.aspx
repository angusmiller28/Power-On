<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ItemView.aspx.cs" Inherits="miller0061072133.ItemView" %>
<%@ Register src="~/Partials/nav.ascx" tagname="nav" tagprefix="uc2" %>
<%@ Register src="~/Partials/header.ascx" TagPrefix="uc1" TagName="header" %>
<%@ Register src="~/Partials/footer.ascx" tagname="footer" tagprefix="uc3" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
</head>
<body>
    <form id="web1" runat="server">
      <div id="container">
        <uc1:header runat="server" ID="header" />
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
                <li><a href="#overview">Overview</a></li>
                <li><a href="#specs">Specs</a></li>
                <li><a href="#shipping">Shipping</a></li>
                <li><a href="#reviews">Reviews</a></li>

              </ul>
            </div>
            <div id="navigation-view-controls">
              <asp:Button ID="Button2" class="btn btn-primary" runat="server" Text="Add to cart" OnClick="Button_Click1"/>
            </div>
          </div>
          <section>
             <asp:Label ID="product_id" runat="server" Text="Label" style="display: none"></asp:Label>
              <asp:Placeholder id="Placeholder1" runat="server" />
          </section>
        </section>
        <uc3:footer ID="footer1" runat="server" />
      </div>
    </form>
</body>
</html>
