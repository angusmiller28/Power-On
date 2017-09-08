<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:output method="xml" indent="yes"/>

    <xsl:template match="/">
            <xsl:apply-templates select="//categorylist"/>
    </xsl:template>

    <xsl:template match="//categorylist">

        <!-- Category -->
        <ul id="sidenav-bar" class="hidden-content">
          <xsl:for-each select="./category">
          <li class="navbar-title">
            <li class="nav-title-section">
              <a class="subnav-link dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">
              <xsl:attribute name="href">ItemsView.aspx?category=<xsl:value-of select="@name" /></xsl:attribute>
              <xsl:value-of select="@name" />

              </a>
              <i class="fa fa-chevron-down"></i>
            </li>
            <!-- Subcategory -->
            <ul class="navbar-dropdown-inner">
            <xsl:for-each select="./subcategory">
              <li>
                <a class="dropdown-subitem">
                  <xsl:attribute name="href">ItemsView.aspx?subcategory=<xsl:value-of select="./link" /></xsl:attribute>
                  <b>
                    <xsl:value-of select="@name" />
                  </b>
                </a>

                  <!-- Types -->
                  <ul>
                  <xsl:for-each select="./types/*">
                    <li class="submenu-item">
                      <a class="dropdown-typesitem" href="#">
                      <xsl:attribute name="href">ItemsView.aspx?type=<xsl:value-of select="@name" /></xsl:attribute>
                      <xsl:value-of select="@name" />
                    </a>
                    </li>
                  </xsl:for-each><!-- end-type-loop -->
                </ul>
              </li>

            </xsl:for-each> <!-- end-subcategory-loop -->
            </ul>
          </li>
          </xsl:for-each> <!-- end-category-loop -->
        </ul>

      <!-- <ul>
        <li class="navbar-title">Live Chat</li>
        <li class="navbar-title">Contact Us</li>
        <li class="navbar-title">Blogs</li>
        <li class="navbar-title">My Account
          <ul class="navbar-dropdown-inner">
            <li>
              <ul>
                <li><img class="profile-icon" src="../imgs/profile.jpg" /></li>
              </ul>
            </li>
            <li>
              <ul>
                <li>Angus Miller</li>
                <li>angus.miller28@gmail.com</li>
                <li><a href="#">View Profile</a></li>
              </ul>
            </li>
          </ul>
        </li>
      </ul> -->

    </xsl:template>
</xsl:stylesheet>
