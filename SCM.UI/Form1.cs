
// (c) Copyright Skillage I.T. 
// (c) This file is Skillage I.T. software and is made available under license. 
// (c) This software is developed by: Rajani Thomas 
// (c) Date: 06th November 2019 Time: 13.45 
// (c) File Name: Form1.cs Version: 1-0

using System;
using System.Text;
using System.Windows.Forms;


namespace SCA.UI
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

       //Load DataGridView of Form1 
        private void Form1_Load(object sender, EventArgs e)
        {
            var formHandler = new FormHandler();
            formHandler.LoadDataGridVew(this.dataGridView1);
        }

        
        /* This method add automatic numbering to the Sl.No. column.*/
        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dataGridView1.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

           private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            int eventType = 1;       //Update files (stocklist.csv, XML_file)
            var formHandler = new FormHandler();
            formHandler.SaveNewCurrentCount(this.dataGridView1, eventType);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var formHandler = new FormHandler();
            int eventType = 2; //Update all XML-1 file)
            formHandler.SaveNewCurrentCount(this.dataGridView1, eventType);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var formHandler = new FormHandler();
            int eventType = 3; //Update all XML-1 file)
            formHandler.SaveNewCurrentCount(this.dataGridView1, eventType);
        }
    }
}
