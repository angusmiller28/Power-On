<%@ Page Language="C#" Inherits="miller.Default" %>

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
                    <ul>
                      <li>Featured Products</li>
                      <li>Discounted Products</li>
                    </ul>
                  </div>
                  <div id="navigation-view-controls">
                    <i class="fa fa-th-large" aria-hidden="true"></i>
                  </div>
                </div>
                <section>
                  <h3>Feature Products</h3>
                  <div class="card-columns" id="featured-products">
                      <asp:Xml ID="Xml1" runat="server" DocumentSource="Models/productlist.xml" TransformSource="Controllers/productFeatured.xslt"></asp:Xml>
                  </div>
              </section>
              <section>
                  <h3>Discounted Products</h3>
                  <div class="card-columns" id="discount-products">
                      <asp:Xml ID="Xml2" runat="server" DocumentSource="Models/productlist.xml" TransformSource="Controllers/productDiscount.xslt"></asp:Xml>
                  </div>
              </section>
          </section>

          <uc3:footer ID="footer1" runat="server" />

        </div>
    </form>
</body>
</html>