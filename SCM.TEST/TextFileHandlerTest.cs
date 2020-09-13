
// (c) Copyright Skillage I.T. 
// (c) This file is Skillage I.T. software and is made available under license. 
// (c) This software is developed by: Rajani Thomas 
// (c) Date: 06th November 2019 Time: 13.45 
// (c) File Name: TextFileHandlerTest.cs Version: 1-0

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SCA.TextFileHandler;

namespace SCA.Test
{
    [TestClass]
    public class TextFileHandlerTest
    {
        [TestMethod]
        public void FileExistsTest()
        {
            string csvFilePath = @"c:\StockFile\stocklist.csv";
            var textFileHandle = new TextFileHandle();
            bool expected = true;
            bool actual = textFileHandle.FileExists(csvFilePath);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ReadFileTest()
        {
            string expected = "Item Code";
            var textFileHandle = new TextFileHandle();
            var fileContents = textFileHandle.GetFileContents();
            string[] row = fileContents[0];
            string actual = row[0];
            Assert.AreEqual(expected, actual);
        }

    }
}
