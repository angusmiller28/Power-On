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

                <ul>
                  <li>Availability <i class="fa fa-chevron-down" aria-hidden="true"></i></li>
                  <li><input type="checkbox" name="" value="">In stock at PowerOn</li>
                  <li><input type="checkbox" name="" value="">In stock at Supplier</li>
                </ul>

                <ul>
                  <li>Brand <i class="fa fa-chevron-down" aria-hidden="true"></i></li>
                  <li><input type="checkbox" name="" value="">Seagate (8)</li>
                  <li><input type="checkbox" name="" value="">Western Digital (36)</li>
                  <li><input type="checkbox" name="" value="">Silicon Power (2)</li>
                  <li><input type="checkbox" name="" value="">Promise (1)</li>
                  <li class="nav-filter-more"><i class="fa fa-chevron-down" aria-hidden="true"></i>Show more</li>
                </ul>

                <ul>
                  <li>Capacity <i class="fa fa-chevron-down" aria-hidden="true"></i></li>
                  <li><input type="checkbox" name="" value="">120TB (1)</li>
                  <li><input type="checkbox" name="" value="">12TB (3)</li>
                  <li><input type="checkbox" name="" value="">16TB (2)</li>
                  <li><input type="checkbox" name="" value="">1TB (5)</li>
                  <li class="nav-filter-more"><i class="fa fa-chevron-down" aria-hidden="true"></i>Show more</li>
                </ul>

                <ul>
                  <li>USB Interface <i class="fa fa-chevron-down" aria-hidden="true"></i></li>
                  <li><input type="checkbox" name="" value="">No (1)</li>
                  <li><input type="checkbox" name="" value="">USB 3.0 (4.8Gbps) (3)</li>
                  <li><input type="checkbox" name="" value="">USB 3.0 (5Gbps) 16TB (23)</li>
                  <li><input type="checkbox" name="" value="">USB 3.1 (10Gbps) 1TB (13)</li>
                  <li class="nav-filter-more"><i class="fa fa-chevron-down" aria-hidden="true"></i>Show more</li>
                </ul>
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
