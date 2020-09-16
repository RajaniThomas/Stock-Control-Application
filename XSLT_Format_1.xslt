<?xml version="1.0" encoding="utf-8"?> 
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
	
	<xsl:template match="/">
	<html>
				
		<h1> WoodStocks Stocklist</h1>
		
		<body style="font-family:Arial;font-size:15pt;background-color:#EEEEEE">
			<xsl:for-each select="/Stocklist/Item">
			
				<div style="background-color: light blue;color:blue;padding:2px">
					<span style="font-weight:bold"><xsl:value-of select="ItemCode"/> - <xsl:value-of select="ItemDescription"/> </span> <br/> 
					<span style="font-style:italic; color:black"> Current Count: <xsl:value-of select="CurrentCount"/> </span> <br/>
					<span style="font-style:italic;color:black"> On Order: <xsl:value-of select="OnOrder"/> </span> <br/>
					<br></br>
				</div>
			
			</xsl:for-each>
		</body>
	</html>
	</xsl:template>

</xsl:stylesheet>
