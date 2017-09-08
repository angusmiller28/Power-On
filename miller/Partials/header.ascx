<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="header.ascx.cs" Inherits="miller0061072133.Partials.header1" %>
<%@ Register src="~/Partials/nav.ascx" tagname="nav" tagprefix="uc2" %>
<link rel="stylesheet" href="Styles/reset.css" />
<link rel="stylesheet" href="Styles/font-awesome/css/font-awesome.min.css" />
<link href="https://fonts.googleapis.com/css?family=Open+Sans|Roboto:300,400,700" rel="stylesheet">
<link rel="stylesheet" href="Styles/style.min.css" />
<link rel="stylesheet" href="Styles/header.min.css" />
<link rel="stylesheet" href="Styles/subnav.min.css" />
<link rel="stylesheet" href="Styles/footer.min.css" />
<link rel="stylesheet" href="Styles/base.min.css" />
<link rel="stylesheet" href="Styles/layout.min.css"  />
<link rel="stylesheet" href="Styles/display.min.css"  />

<header id="header">
    <div id="logo">
        <a class="nav-link active Font-Style-Phone-Subheader-Style Font-Style-Tablet-Large-Subheader-Style Font-Style-Desktop-Subheader-Style Font-Style-Desktop-Large-Subheader-Style" href="Home.aspx">Power On</a>
        <span><i class="fa fa-phone" aria-hidden="true"></i>46621741</span>
    </div>
    <div id="notification-bar" class="hidden-content">
      <span>Added product to cart <i class="fa fa-check"></i></span>
    </div>
    <div id="categories">
      <a class="nav-link active" href="#">Categories<i class="fa fa-chevron-down"></i></a>
    </div>
    <div id="nav">
      <a class="nav-link active" href="ShoppingCart.aspx"><i class="fa fa-shopping-cart"></i></a>
      <a class="nav-link active" href="#"><i class="fa fa-bars"></i></a>
    </div>
    <div id="navbar-dropdown" >
      <ul class="hidden-content">
        <li class="navbar-title">Live Chat</li>
        <li class="navbar-title">Contact Us</li>
        <li class="navbar-title">Blogs</li>
        <asp:PlaceHolder ID="accountContainer" runat="server"></asp:PlaceHolder>
      </ul>
        
    </div>

</header>
