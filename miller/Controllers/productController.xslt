<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:asp="http://www.w3.org/1999/xhtml" xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl" >
    <xsl:output method="xml" indent="yes"/>
  <xsl:param name="productid"></xsl:param>

  <xsl:template match="/">
    <html>
      <body>
        <xsl:apply-templates select="categorylist/category/subcategory/types/type/*"/>
      </body>
    </html>
  </xsl:template>

  <!-- Select product for single view -->
  <xsl:template match="categorylist/category/subcategory/types/type/*">
      <xsl:if test="$productid=code[text()]">
        <div class="product-container">
          <div id="product-header-container">
            <!-- Product Name -->
            <h1 id="item-title">
              <xsl:value-of select="*[2]"/>
            </h1>
            <!-- Product ID -->
            <p id="product_id">
              Product ID <xsl:value-of select="*[1]"/>
            </p>
          </div>


            <div id="product-image-container">
              <img>
                <!-- Product Image -->
                <xsl:attribute name="src">
                  /imgs/<xsl:value-of select="*[5]"/>
                </xsl:attribute>
                <xsl:attribute name="align">
                  left
                </xsl:attribute>
              </img>
              <div id="product-image-sub-container">



                <img>
                  <!-- Product Image -->
                  <xsl:attribute name="src">
                    /imgs/<xsl:value-of select="*[5]"/>
                  </xsl:attribute>
                  <xsl:attribute name="align">
                    left
                  </xsl:attribute>
                </img>
                <img>
                  <!-- Product Image -->
                  <xsl:attribute name="src">
                    /imgs/<xsl:value-of select="*[5]"/>
                  </xsl:attribute>
                  <xsl:attribute name="align">
                    left
                  </xsl:attribute>
                </img>
                <img>
                  <!-- Product Image -->
                  <xsl:attribute name="src">
                    /imgs/<xsl:value-of select="*[5]"/>
                  </xsl:attribute>
                  <xsl:attribute name="align">
                    left
                  </xsl:attribute>
                </img>
                <div id="product-sub-images-more">
                  <img>
                    <!-- Product Image -->
                    <xsl:attribute name="src">
                      /imgs/<xsl:value-of select="*[5]"/>
                    </xsl:attribute>
                    <xsl:attribute name="align">
                      left
                    </xsl:attribute>
                  </img>
                  <img>
                    <!-- Product Image -->
                    <xsl:attribute name="src">
                      /imgs/<xsl:value-of select="*[5]"/>
                    </xsl:attribute>
                    <xsl:attribute name="align">
                      left
                    </xsl:attribute>
                  </img>
                </div>
              </div>
            </div>
            <div id="price-container">
              <ul>
                <li><h4>Availability:</h4></li>
                <li>In-Stock at PowerOn (Yes)</li>
              </ul>
              <ul>
                <li><h4>Delivery:</h4></li>
                <li>Calculate shipping cost and time</li>
                <li>
                 100% Off On Shipping
                </li>
                <li>Offer Ends 31/08/2017</li>
              </ul>
              <ul>
                <li>Quantity: <input type="number" /></li>
              </ul>
              <ul>
                <li class="previous-price-text center-text margin-bottom-5">
                  was $800.00
                </li>
                <li>
                  <h1 class="price-text center-text">$<xsl:value-of select="*[3]"/></h1>
                </li>
              </ul>
            </div>
            <div id="product-content-container">
              <div id="product-content-description">
                <h1 id="overview">Description</h1>
                <!-- Product Description -->
                <p><xsl:value-of select="*[7]"/></p>
              </div>
              <div id="product-content-description">
                <h1 id="specs">Specs</h1>
                <!-- Product Description -->
                <ul id="product-content-table">
                  <ul class="spec-item">
                    <li class="spec-name">Product ID</li>
                    <li class="spec-data"><xsl:value-of select="*[1]"/></li>
                  </ul>
                  <ul class="spec-item">
                    <li class="spec-name">Brand</li>
                    <li class="spec-data">Seagate</li>
                  </ul>
                  <ul class="spec-item">
                    <li class="spec-name">Interface</li>
                    <li class="spec-data">2x USB 3.0 Type A</li>
                  </ul>
                  <ul class="spec-item">
                    <li class="spec-name">Form Factor</li>
                    <li class="spec-data">3.5 Inch</li>
                  </ul>
                  <ul class="spec-item">
                    <li class="spec-name">Features</li>
                    <li class="spec-data">
                      <ul>
                        <li>Integrated USB hub with 2 x USB 3.0 Type-A Ports (USB 2.0 Compatible)</li>
                        <li>1 x Micro-USB 3.0 (Micro-B 10-pin) Port</li>
                        <li>Up to 160 MB/s Data Transfer Speed</li>
                        <li>Back Up Files and Recharge Devices</li>
                        <li>Two Free Years of OneDrive Cloud Storage</li>
                      </ul>
                    </li>
                  </ul>
                </ul>
              </div>
              <div id="product-content-description">
                <h1 id="shipping">Shipping</h1>
                <!-- Product Description -->
                <p> Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.</p>
              </div>
              <div id="product-content-description">
                <h1 id="reviews">Reviews</h1>
                <!-- Product Description -->
                <p> Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.</p>
              </div>
            </div>


        </div>
      </xsl:if>
  </xsl:template>
</xsl:stylesheet>
