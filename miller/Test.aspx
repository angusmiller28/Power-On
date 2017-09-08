<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="miller0061072133.Views.Test" %>

<%@ Register Src="~/Partials/header.ascx" TagPrefix="uc1" TagName="header" %>
<%@ Register Src="~/Partials/footer.ascx" TagPrefix="uc1" TagName="footer" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="container">
            <uc1:header runat="server" ID="header" />
        <section id="main">
          <section>
              <asp:Label ID="product_id" runat="server" Text="Label"></asp:Label>
            <asp:Xml ID="Xml1" runat="server" DocumentSource="~/Models/productlist.xml"  TransformSource="~/Controllers/productController.xslt"></asp:Xml>
          </section>
            </section>
            <uc1:footer runat="server" ID="footer" />
            </div>

    </form>
</body>
</html>
