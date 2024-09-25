using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using HermleCS.Comm;
using HermleCS.Data;

namespace HermleCS
{
    public partial class formCSVTest : Form
    {
        D d;

        public formCSVTest()
        {
            InitializeComponent();

            d = D.Instance;
            d.init();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            C.log("btnLoad Clicked...");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            C.log("btnSave Clicked...");
        }
    }
}
