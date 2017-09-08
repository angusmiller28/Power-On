
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="miller0061072133.Views.ShoppingCart" %>

<%@ Register src="~/Partials/header.ascx" tagname="header" tagprefix="uc1" %>
<%@ Register src="~/Partials/nav.ascx" tagname="nav" tagprefix="uc2" %>
<%@ Register src="~/Partials/footer.ascx" tagname="footer" tagprefix="uc3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
                  <asp:Button runat="server" ID="btnBack" class="btn" Text="Back" onclick="btnBack_Click" />            </div>
                <div id="navigation-content-controls">

                </div>
                <div id="navigation-view-controls">
                  <asp:Button ID="btnCheckout" class="btn btn-primary" runat="server" Text="Check Out" OnClick="Button2_Click" />
                </div>
              </div>

              <section id="cart-container">
                <asp:PlaceHolder ID="emptyCartContainer" runat="server"></asp:PlaceHolder>
                <asp:gridview runat="server" ID="gvShoppingCart" AutoGenerateColumns="False" OnRowCancelingEdit="gvShoppingCart_RowCancelingEdit" OnRowDeleting="gvShoppingCart_RowDeleting" OnRowEditing="gvShoppingCart_RowEditing" OnRowUpdating="gvShoppingCart_RowUpdating">
                    <Columns>
                        <asp:BoundField DataField="NAME" HeaderText="Product" ReadOnly="True" />
                        <asp:ImageField DataImageUrlField="IMAGE" DataImageUrlFormatString="~\imgs\{0}" HeaderText="Image" ReadOnly="True">
                        </asp:ImageField>
                        <asp:BoundField DataField="PRICE" HeaderText="Price" ReadOnly="True" />
                        <asp:BoundField DataField="QUANTITY" HeaderText="Qty" />
                        <asp:TemplateField HeaderText="Total">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Double.Parse(Eval("PRICE").ToString())*Int32.Parse(Eval("Quantity").ToString()) %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField ShowEditButton="True" />
                        <asp:CommandField ShowDeleteButton="True" />
                    </Columns>
                </asp:gridview>
                <asp:Label ID="lblGrandTotal" runat="server" Text="lblGrandTotal" Visible="False"></asp:Label>
              </section>

            </section>

            <uc3:footer ID="footer1" runat="server" />
        </div>

    </form>
    </body>
</html>
