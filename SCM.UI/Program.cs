// (c) Copyright Skillage I.T. 
// (c) This file is Skillage I.T. software and is made available under license. 
// (c) This software is developed by: Rajani Thomas 
// (c) Date: 06th November 2019 Time: 13.45 
// (c) File Name: Program.cs Version: 1-0



using SCA.TextFileHandler;
using System;
using System.Windows.Forms;

namespace SCA.UI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            /*Create an instance of the textFileHandle class*/
            var textFileHandle = new TextFileHandle();
            string csvFilePath = @"c:\StockFile\stocklist.csv";

            /*If stocklist file exists in the StockFile directory,
             * load form1 with DataGridView object. If stocklist file 
             * does not exist in the directory, load form 2 with message 
             * to add file in the correct directory*/
            if (textFileHandle.FileExists(csvFilePath))
            {
                Application.Run(new Form1());
            }
            else
            {
                Application.Run(new Form2());
            }
            
        }
    }
}
