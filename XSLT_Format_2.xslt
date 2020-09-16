<?xml version="1.0" encoding="utf-8"?> 
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
	
	<xsl:template match="/">
		<html>
				
		<h1> 			Stocklist </h1>
		
		<body style="font-family:Arial;font-size:15pt">
			<table width="100%" border="1">
				<THEAD>
					  <TR>
						<TD width="10%"><B>Item Code</B></TD>
						<TD width="30%"><B>Item Description</B></TD>
						<TD width="15%"><B>Current Count</B></TD>
						<TD width="10%"><B>On Order</B></TD>
					 </TR>
				</THEAD> 
			
				<TBODY>
					 <xsl:for-each select="Stocklist/Item">
						 <TR> 
							  <TD width="10%"><xsl:value-of select="ItemCode" /></TD>   
							  <TD width="30%"><xsl:value-of select="ItemDescription" /></TD>
							  <TD width="15%"><xsl:value-of select="CurrentCount" /></TD>
							  <TD width="10%"><xsl:value-of select="OnOrder" /></TD>
						</TR>
					</xsl:for-each>
				</TBODY>
			
			</table>
		</body>
		</html>	
	</xsl:template>
</xsl:stylesheet>
		
		
		