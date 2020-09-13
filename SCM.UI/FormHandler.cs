using SCA.TextFileHandler;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SCA.UI
{
    public class FormHandler
    {
        /* Loads the DataGridView with contents from the stoclist.csv
         * file. 
         * fileContents is a list of string arrayscontaining the data 
         * from the text file. Each string array of the list contaisn the 
         * four fields of the column*/
        public void LoadDataGridVew(DataGridView dataGridView)
        {
            dataGridView.Rows.Clear();
            
            var textFileHandle = new TextFileHandle();
            var fileContents = textFileHandle.GetFileContents();

            for (int i = 1; i < fileContents.Count; i++)
            {
                string[] column = fileContents[i];
                dataGridView.Rows.Add("0", column[0], column[1], Convert.ToInt32(column[2]), column[3]);
            }
        }


        /* When user click on 'Save button', the DataGridView contents are
         * updated into the List < String> array to be updated into the csv
         * text file.
         * File contents is a list of string arrays where each list contains
         * 4 string arrays correspondig to 'Item code', 'Item Despcription',
         * 'Current Count' and 'On Order'.*/
        public void SaveNewCurrentCount(DataGridView dataGridView, int xml_style_type)
        {
            var textFileHandle = new TextFileHandle();
            var fileContents = new List<String[]>();
            string[] dataGridContents = new string[4];

            for (int i = 0; i < 4 ; i++)
            {
                dataGridContents[i] = dataGridView.Columns[i+1].HeaderText;
            }
            fileContents.Add(dataGridContents);

            /*Loop through each row in the DataGrid and add it to fileContents)*/
             foreach ( DataGridViewRow row in dataGridView.Rows )
             {
                 dataGridContents = new string[4];
                 for (int i = 0; i < 4; i++ )
                 {
                     dataGridContents[i] = row.Cells[i + 1].Value.ToString();
                 }
                fileContents.Add( dataGridContents );
             }

             var saveSuccess = textFileHandle.UpdateNewCurrentCount(fileContents, xml_style_type);
            if (saveSuccess && xml_style_type==1)
                MessageBox.Show("Update Successful", " ", MessageBoxButtons.OK);
            else if(!saveSuccess)
                MessageBox.Show(@"Cannot Load/Update files. Make sure stocklist.csv, XSLT_Format_1.xslt 
and XSLT_Format_2.xslt files are in c:\StockFile directory", 
                                "Error Message", MessageBoxButtons.OK);
        }

     }
 }
