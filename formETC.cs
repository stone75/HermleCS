﻿using System;
using System.Windows.Forms;

using HermleCS.Data;

namespace HermleCS
{
    public partial class formETC : Form
    {
        D data = D.Instance;

        public formETC()
        {
            InitializeComponent();
        }

        private void btnCurrentLocationn_Click(object sender, EventArgs e)
        {
            Locations loc = data.getCurrentLocation();
            String rval = "Current Locations Information :";
            rval += "\r\n---------------------------------";
            rval += "\r\n X : " + loc.x;
            rval += "\r\n Y : " + loc.y;
            rval += "\r\n Z : " + loc.z;
            rval += "\r\n RX : " + loc.rx;
            rval += "\r\n RY : " + loc.ry;
            rval += "\r\n RZ : " + loc.rz;

            txtLog.Text = rval;
        }
    }
}
