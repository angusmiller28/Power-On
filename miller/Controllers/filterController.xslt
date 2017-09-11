<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
  <xsl:output method="xml" indent="yes"/>
  <!-- Params from query string to filter item display -->
  <xsl:param name="categoryid" ></xsl:param>
  <xsl:param name="subcategoryid" ></xsl:param>
  <xsl:param name="typeid" ></xsl:param>
  
    <xsl:template match="/">
        <xsl:copy>
            <xsl:apply-templates select="/" />
        </xsl:copy>
    </xsl:template>

    <xsl:template match="/">
      <xsl:if test="($categoryid=category[text()]) or ($subcategoryid=subcategory[text()]) or ($typeid=type[text()])">

      </xsl:if>
    </xsl:template>
</xsl:stylesheet>
