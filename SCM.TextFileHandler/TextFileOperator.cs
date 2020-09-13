
// (c) Copyright Skillage I.T. 
// (c) This file is Skillage I.T. software and is made available under license. 
// (c) This software is developed by: Rajani Thomas 
// (c) Date: 06th November 2019 Time: 13.45 
// (c) File Name: TextFileHandler.cs Version: 1-0

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Xsl;
using System.Diagnostics;


namespace SCA.TextFileHandler
{
    public class TextFileOperator
    {
        private const string csvFilePath = @"c:\StockFile\stocklist.csv";
        private string XMLfile = @"c:\StockFile\XML_File.xml";
        private string XSLT_Format1 = @"c:\StockFile\XSLT_Format_1.xslt";
        private string XSLT_Format2 = @"c:\StockFile\XSLT_Format_2.xslt";



        //Method to open the file and read its contents . Stores the value of the 
        // file in a List< String> Array
        public List<String[]> ReadFile(string filePath)
        {
            List<String[]> fileContents = new List<String[]>();

            try
            {
                StreamReader file = new StreamReader(filePath);
                string[] row;
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    row = line.Split(',');
                    fileContents.Add(row);
                }

                file.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Unable to read file" + e);
            }
            return fileContents;
        }


        /*  This method writes the new values entered by the user into the 
         *  text file*/

        public void WriteToCSVFile(List<String[]> newfileContents, string filePath)
        {
            var stringBuilder = new StringBuilder();

            foreach(var items in newfileContents)
            {
                string[] lineItems = items;
                string line = lineItems[0] + "," + lineItems[1] + "," + lineItems[2] + "," + lineItems[3];
                stringBuilder.AppendLine(line);
            }
            
            File.WriteAllText(filePath, stringBuilder.ToString());
        }

        /*This method creates an XML file from the stocklist.csv file contents 
         * in the SCM.UI/bin/Debug directory once the application loads.
         */
        public void CreateXMLFile(List<String[]> newfileContents)
        {
            XmlTextWriter writer = new XmlTextWriter(XMLfile, Encoding.UTF8);
            writer.Formatting = Formatting.Indented;
            writer.WriteStartDocument();
            writer.WriteStartElement("Stocklist");
            
            for(int i=1; i< newfileContents.Count; i++)
            {
                string[] lineItems = newfileContents[i];
                writer.WriteStartElement("Item");

                writer.WriteElementString("ItemCode", lineItems[0]);
                writer.WriteElementString("ItemDescription", lineItems[1]);
                writer.WriteElementString("CurrentCount", lineItems[2]);
                writer.WriteElementString("OnOrder", lineItems[3]);

                writer.WriteEndElement();
            }
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();
        }

        /* This method applies the XSLT_Format1.xslt stylesheet to the XML file and loads the file in the Web Browser. 
         * It checks if the xslt stylesheet is present in the c:\StockFile dirctory before performing transformation.
         * Returns false if file is not found
         */
        public bool LoadXMLStyle1(List<String[]> newfileContents)
        {
            string XmlFormat1 = @"c:\StockFile\XML_Format1.html";
            bool status;
            var txtFilehandle = new TextFileHandle();
            CreateXMLFile(newfileContents);

            XslCompiledTransform myXslCompiledTransform = new XslCompiledTransform();

            if (txtFilehandle.FileExists(XSLT_Format1))
            {
                myXslCompiledTransform.Load(XSLT_Format1);
                XmlWriter xmlWriter = XmlWriter.Create(XmlFormat1);
                myXslCompiledTransform.Transform(XMLfile, xmlWriter);
                Process.Start(XmlFormat1);
                xmlWriter.Dispose();
                status = true;
            }
            else
                status = false;

            return status;
        }

        /* This method applies the XSLT_Format2.xslt stylesheet to the XML file and loads the file in the Web Browser.
         * It checks if the xslt stylesheet is present in the c:\StockFile dirctory before performing transformation.
         * Returns false if file is not found
         */
        public bool LoadXMLStyle2(List<String[]> newfileContents)
        {
            string XmlFormat2 = @"c:\StockFile\XML_Format2.html";
            bool status;
            var txtFilehandle = new TextFileHandle();
            CreateXMLFile(newfileContents);
            XslCompiledTransform myXslCompiledTransform = new XslCompiledTransform();

            if (txtFilehandle.FileExists(XSLT_Format2))
            {
                myXslCompiledTransform.Load(XSLT_Format2);
                XmlWriter xmlWriter = XmlWriter.Create(XmlFormat2);
                myXslCompiledTransform.Transform(XMLfile, xmlWriter);
                Process.Start(XmlFormat2);
                xmlWriter.Dispose();
                status = true;
            }
            else
                status = false;

            return status;
        }
    }
}
