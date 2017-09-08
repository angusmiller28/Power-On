<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SubCategoryView.aspx.cs" Inherits="miller0061072133.SubCategoryView" %>

<%@ Register src="../Partials/header.ascx" tagname="header" tagprefix="uc1" %>

<%@ Register src="../Partials/nav.ascx" tagname="nav" tagprefix="uc2" %>
<%@ Register Src="~/Partials/header.ascx" TagPrefix="uc2" TagName="header" %>


<%@ Register src="../Partials/footer.ascx" tagname="footer" tagprefix="uc3" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <header>
            <uc2:header runat="server" ID="header" />
        </header>
        <nav>
            <uc2:nav ID="nav1" runat="server" />
            <asp:Label ID="breadcrumbs" runat="server" Text="Bread Crumbs"></asp:Label>
        </nav>
        <div id="wrapper">
            <asp:Button runat="server" ID="btnBack" Text="Back" onclick="btnBack_Click" />
            <asp:Label ID="category_name" runat="server" Text="Category Name"></asp:Label>
            <asp:Xml ID="Xml1" runat="server" DocumentSource="~/Models/productCategoryData.xml" TransformSource="~/Controllers/productCategoryDetails.xslt"></asp:Xml>
        </div>
        <uc3:footer ID="footer1" runat="server" />
    </form>
</body>
</html>
