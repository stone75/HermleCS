using System;
using System.Windows.Forms;

namespace HermleCS
{
    public partial class formHTTPComponent : Form
    {
        Comm.CommHTTPComponent http = Comm.CommHTTPComponent.Instance;

        public formHTTPComponent()
        {
            InitializeComponent();
        }

        private void btnHTPPCall_Click(object sender, EventArgs e)
        {
            string ipaddr = txtIPAddr.Text;
            string port = txtPortNum.Text;
            string url = txtURL.Text;
            string body = txtPostData.Text;

            string target = $"http://{ipaddr}:{port}/{url}";
            string rval = "";
            if (body == "")
            {
                rval = http.GetAPI(target);
            } else
            {
                rval = http.PostAPI(target, body);
            }
            txtResult.Text = rval;

        }

        private void btnPreset1_Click(object sender, EventArgs e)
        {
            txtIPAddr.Text = "daum.net";
            txtPortNum.Text = "80";
            txtURL.Text = "";
            txtPostData.Text = "";
        }

        private void btnPreset2_Click(object sender, EventArgs e)
        {
            txtIPAddr.Text = "t.odinox.com";
            txtPortNum.Text = "80";
            txtURL.Text = "g.php?a=1&bb=22&ccc=333";
            txtPostData.Text = "";
        }

        private void btnPreset3_Click(object sender, EventArgs e)
        {
            txtIPAddr.Text = "t.odinox.com";
            txtPortNum.Text = "80";
            txtURL.Text = "p.php";
            txtPostData.Text = "{\r\n    \"name\": \"John\",\r\n    \"age\": 25,\r\n    \"email\": \"john@example.com\"\r\n}";
        }

        private void btnPreset4_Click(object sender, EventArgs e)
        {
            txtIPAddr.Text = "192.168.0.1";
            txtPortNum.Text = "80";
            txtURL.Text = "api/v1/robot/position";
            txtPostData.Text = "";
        }

        private void btnPreset5_Click(object sender, EventArgs e)
        {
            txtIPAddr.Text = "192.168.0.1";
            txtPortNum.Text = "80";
            txtURL.Text = "api/v1/robot/move";
            txtPostData.Text = "{\r\n    \"x\": 100,\r\n    \"y\": 200,\r\n    \"z\": 150,\r\n    \"speed\": 50\r\n}";

        }

        private void btnPreset6_Click(object sender, EventArgs e)
        {
            txtIPAddr.Text = "192.168.0.1";
            txtPortNum.Text = "80";
            txtURL.Text = "KAREL/AUTO_START_TEST.TP";
            txtPostData.Text = "";
        }
    }
}
