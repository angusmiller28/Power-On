<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt"
    xmlns:asp="http://example.com/asp"
    exclude-result-prefixes="msxsl" >

  <xsl:output method="xml" indent="yes"/>
  <!-- Params from query string to filter item display -->
  <xsl:param name="categoryid" ></xsl:param>
  <xsl:param name="subcategoryid" ></xsl:param>
  <xsl:param name="typeid" ></xsl:param>

  <xsl:template match="/">
    <h1>
      <xsl:value-of select="$categoryid"/>
    </h1>
    <h1>
      <xsl:value-of select="$subcategoryid"/>
    </h1>
    <h1>
      <xsl:value-of select="$typeid"/>
    </h1>
    <xsl:if test="($categoryid=category[text()]) and (position()=1)">
      <h1>
        <xsl:value-of select="$categoryid"/>
      </h1>
    </xsl:if>
    <xsl:if test="($subcategoryid=subcategory[text()]) and (position()=1)">
      <h1>
        <xsl:value-of select="$subcategoryid"/>
      </h1>
    </xsl:if>
    <xsl:if test="($typeid=type[text()]) and (position()=1)">
      <h1>
        <xsl:value-of select="$typeid"/>
      </h1>
    </xsl:if>

    <div class="card-columns">
          <xsl:apply-templates select="categorylist/category/subcategory/types/type/*"/>
    </div>
  </xsl:template>


  <xsl:template match="categorylist/category/subcategory/types/type/*">

      <xsl:if test="($categoryid=category[text()]) or ($subcategoryid=subcategory[text()]) or ($typeid=type[text()])">

        <div class="card">
          <img alt="Card image cap">
            <xsl:attribute name="src">
              /imgs/<xsl:value-of select="*[5]"/>
            </xsl:attribute>
          </img>
          <div class="card-block">
            <h4 class="card-title">
              <xsl:value-of select="*[2]"/>
            </h4>
            <p class="card-text">
              <xsl:value-of select="*[7]"/>
            </p>
            <ul class="list-group list-group-flush">
              <li class="list-group-item" >
                Price $<xsl:value-of select="*[3]"/>
              </li>
            </ul>
            <div>
              <a class="btn btn-primary btn-center btn-large">
                <xsl:attribute name="href">
                  ItemView.aspx?Product=<xsl:value-of select="*[1]"/>
                </xsl:attribute> View Product
              </a>

            </div>
          </div>

          <!-- <div id="card-social-container">
                <ul>
                  <li><i class="fa fa-thumbs-o-up" aria-hidden="true"></i>20</li>
                  <li><i class="fa fa-star-half-o" aria-hidden="true"></i>100</li>
                </ul>
              </div> -->
        </div>
      </xsl:if>

  </xsl:template>

</xsl:stylesheet>
