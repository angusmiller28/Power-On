<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:output method="xml" indent="yes"/>
    <xsl:param name="categoryid" ></xsl:param>

  <xsl:template match="/">
    <html>
      <head></head>
      <body>
        <b>
          Category:
        </b>
          <a>
          <xsl:attribute name="href">
            ItemsView.aspx?category=<xsl:value-of select="$categoryid" />
          </xsl:attribute>
            <xsl:value-of select="$categoryid" />
        </a>
        <xsl:apply-templates select="categorylist/category[@name=$categoryid]/*"/>
        <br />
      </body>
    </html>
  </xsl:template>

  <xsl:template match="categorylist/category/*">
      <div>
        <br/>
        <!-- Category Name and link -->
        <a>
          <xsl:attribute name="href">ItemsView.aspx?subcategory=<xsl:value-of select="*[1]"/></xsl:attribute>
          <xsl:value-of select="*[1]"/>
        </a> 
        <br />
        <img>
          <!-- Category Image -->
          <xsl:attribute name="src">../imgs/<xsl:value-of select="*[2]"/></xsl:attribute>
          <xsl:attribute name="align">
            left
          </xsl:attribute>
        </img>
        <!-- Category Description -->
        <p><xsl:value-of select="*[3]"/></p>
      
        <!-- Subcategorys list -->
        <h4>Sub Categories Types</h4>
        <ul>
          <xsl:for-each select="./types/*">
            <li><a>
              <xsl:attribute name="href">ItemsView.aspx?type=<xsl:value-of select="."/></xsl:attribute>
              <xsl:value-of select="."/>
            </a> </li>
          </xsl:for-each>
        </ul>
      </div>
  </xsl:template>
</xsl:stylesheet>
