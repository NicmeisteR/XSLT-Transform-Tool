<xsl:stylesheet version='2.0' xmlns:xsl='http://www.w3.org/1999/XSL/Transform'>
    <xsl:template match='data'>

        <html>

        <head>
            <meta charset='utf-8'/>
            <meta http-equiv='X-UA-Compatible' content='IE=edge'/>
            <title>Title</title>
            <meta name='viewport' content='width=device-width, initial-scale=1'/>
        </head>

        <body>

            <div class="container">
                <xsl:value-of select="test/@value"/>
            </div>

        </body>

        </html>

    </xsl:template>
</xsl:stylesheet>