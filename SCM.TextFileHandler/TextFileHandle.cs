
// (c) Copyright Skillage I.T. 
// (c) This file is Skillage I.T. software and is made available under license. 
// (c) This software is developed by: Rajani Thomas 
// (c) Date: 06th November 2019 Time: 13.45 
// (c) File Name: TextFile.cs Version: 1-0

using System;
using System.Collections.Generic;
using System.IO;

namespace SCA.TextFileHandler
{
    public class TextFileHandle
    {

        private const string csvFilePath = @"c:\StockFile\stocklist.csv";
        

        /*Method is called at the beginning to see if stocklist file
         * is present in the c:/StockFile directory. Returns 'true' 
         * if file is found. It takes the fileName to be found as input paarameter */
        public bool FileExists(string fileName)
        {
           if ( (File.Exists(fileName)))
                return true;
            else return false;
        }

        /*This method passes the filePath to the textFileHandler to read the 
         * csv file . The contents of the csv file are stored in 'fileContents'
         * which is a list of string arrays. It also creates an XML file in the SCM.UI/bin/Debug directory
         from the contents in the stocklist.csv file.*/
        public List<String[]> GetFileContents()
        {
            var textFileOperator = new TextFileOperator();
          
            var fileContents = textFileOperator.ReadFile( csvFilePath );
            textFileOperator.CreateXMLFile(fileContents);
            return fileContents;
        }

        /*This method is called when the user clicks save on the GUI/ or one of the XML display buttons
         * It gets the updated values from the DataGridView and calls the 
         * FileOperator to write the values into the csvFile. Depending on the fileType, it does one of the 3 operations.*/
        public bool UpdateNewCurrentCount(List<String[]> fileContentList, int fileType)
        {
            var textFileOperator = new TextFileOperator();
            bool status;
            if (FileExists(csvFilePath))
            {
                bool fileStatus= false;
                switch (fileType)
                {
                    case 1: // When user exits application, update csv and xml files with new values
                        textFileOperator.WriteToCSVFile(fileContentList, csvFilePath);
                        textFileOperator.CreateXMLFile(fileContentList);
                        fileStatus = true;
                        break;
                    case 2: // User has clicked on XML_Format1 button
                        fileStatus = textFileOperator.LoadXMLStyle1(fileContentList);
                        break;
                    case 3:// User has clicked on XML_Format2 button
                        fileStatus = textFileOperator.LoadXMLStyle2(fileContentList);
                        break;
                }
                status = fileStatus;
            }
            else
                status = false;

            return status;
        }
    }
}
