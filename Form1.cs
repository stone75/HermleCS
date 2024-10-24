﻿using System;
using System.Windows.Forms;

namespace HermleCS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnMXComponent_Click(object sender, EventArgs e)
        {
//            formMXComponent frm = new formMXComponent();
//            frm.ShowDialog();
        }

        private void btnHTTPConnection_Click(object sender, EventArgs e)
        {
            formHTTPComponent frm = new formHTTPComponent();
            frm.ShowDialog();
        }

        private void btnCSVTest_Click(object sender, EventArgs e)
        {
            formCSVTest frm = new formCSVTest();
            frm.ShowDialog();
        }

        private void btnETCTest_Click(object sender, EventArgs e)
        {
            formETC frm = new formETC();
            frm.ShowDialog();
        }

        private void btnTCPComponent_Click(object sender, EventArgs e)
        {
            formTCPComponent frm = new formTCPComponent();
            frm.ShowDialog();
        }

        private void btnTCPComponent_Click_1(object sender, EventArgs e)
        {
            formTCPComponent frm = new formTCPComponent();
            frm.ShowDialog();
        }
    }
}
