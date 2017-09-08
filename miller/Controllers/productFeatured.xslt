<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">
    <xsl:output method="xml" indent="yes"/>
  <xsl:include href="productlistController.xslt" />
  <xsl:template match="/">
    <html>
      <body>
        <xsl:for-each select="categorylist/category/subcategory/types/type/product">
          <xsl:if test="feature='True'">
            <div class="card">
              <img class="card-img-top" alt="Card image cap" >
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
                  <li class="list-group-item price-text Font-Style-Phone-Subheader-Style Font-Style-Tablet-Large-Subheader-Style-Subheader-Style Font-Style-Desktop-Subheader-Style-Subheader-Style Font-Style-Desktop-Large-Subheader-Style-Subheader-Style" >
                    $<xsl:value-of select="*[3]"/>
                  </li>
                </ul>

                  <div class="btn btn-primary btn-center btn-large">
                    <a>
                      <xsl:attribute name="href">
                        ItemView.aspx?Product=<xsl:value-of select="*[1]"/>
                      </xsl:attribute> View Product
                    </a>
                  </div>
                </div>

                <div id="card-social-container">
                  <ul>
                    <li><i class="fa fa-thumbs-o-up" aria-hidden="true"></i>20</li>
                    <li><i class="fa fa-star-half-o" aria-hidden="true"></i>100</li>
                  </ul>
                </div>

            </div>
          </xsl:if>
        </xsl:for-each>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>
