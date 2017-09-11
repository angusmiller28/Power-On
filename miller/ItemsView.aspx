<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ItemsView.aspx.cs" Inherits="miller0061072133.CategoryItemsView" %>

<%@ Register src="~/Partials/nav.ascx" tagname="nav" tagprefix="uc1" %>
<%@ Register Src="~/Partials/header.ascx" TagPrefix="uc1" TagName="header" %>
<%@ Register src="~/Partials/footer.ascx" tagname="footer" tagprefix="uc2" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Hello</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
</head>
<body>
    <form id="form1" runat="server">
      <div id="container">

        <uc1:header runat="server" ID="header" />

        <nav id="subnav">
            <uc1:nav ID="nav1" runat="server" />
        </nav>
        <section id="main">
          <div id="page-controls">
            <div id="navigation-page-controls">
              <asp:Button runat="server" ID="btnBack" class="btn" Text="Back" onclick="btnBack_Click" />
            </div>
            <div id="navigation-content-controls">
              <ul>
                <li>
                  <label for="input-view-product">Show</label>
                  <select style="margin-right: 10px">
                    <option value="10">10</option>
                    <option value="20">20</option>
                    <option value="30">30</option>
                    <option value="40">40</option>
                  </select>
                </li>
                <li>
                  <label for="input-view-product">Sort By</label>
                  <select style="margin-right: 10px">
                    <option value="Popularity">Popularity</option>
                    <option value="Price Low - High">Price Low - High</option>
                    <option value="Price High - Low">Price High - Low</option>
                  </select>
                </li>
              </ul>
            </div>
            <div id="navigation-view-controls">
              <i class="fa fa-th-large" aria-hidden="true"></i>
              <i class="fa fa-filter" aria-hidden="true"></i>
            </div>
            <div id="navigation-filter-controls">
              <ul id="nav-filter">
                <asp:PlaceHolder ID="navFilter" runat="server"></asp:PlaceHolder>
                
              </ul>
            </div>
          </div>

          <asp:Placeholder id="Placeholder1" runat="server" />


        </section>

        <uc2:footer ID="footer1" runat="server" />
      </div>
    </form>
</body>
</html>
