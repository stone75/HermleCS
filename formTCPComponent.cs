using System;
using System.Windows.Forms;

using Raon.Lib.Plc;

namespace HermleCS
{
    public partial class formTCPComponent : Form
    {
        private MelsecPlc __melsec;

        public formTCPComponent()
        {
            InitializeComponent();
            init();
        }

        private void putLog(string msg)
        {
            txtLog.Text += msg;
            txtLog.Text += "\r\n";
        }

        private void init()
        {
            putLog("MelSec Init...");

            try
            {
                __melsec = new MelsecPlc();
            }
            catch (Exception ex)
            {
                putLog(ex.Message);
                Console.WriteLine(ex.ToString());
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            putLog("TCP Connect Start...");

            int port = 0;
            string ip = txtIP.Text.ToString();
            string portStr = txtPort.Text.ToString();

            if (portStr.Length > 0)
            {
                port = int.Parse(portStr);
            }

            try
            {
                __melsec.IP = ip;
                __melsec.Port = port;
                __melsec.FrameType = MCProtocol.Mitsubishi.McFrame.MC3E;
                __melsec.Connect();

                if (__melsec.IsConnected() == true)
                {
                    putLog($"PLC Connected!!");
                }
                else
                {
                    putLog($"PLC Disconnected!!");
                }
            }
            catch (Exception ex)
            {
                putLog(ex.ToString());
            }

            txtAddress.ReadOnly = false;
            txtValue.ReadOnly = false;
            btnConnect.Enabled = false;
            btnRead.Enabled = true;
            btnWrite.Enabled = true;
        }

        private async void btnWrite_Click(object sender, EventArgs e)
        {
            string addr = txtAddress.Text.ToString();
            string data = txtValue.Text.ToString();
            int[] value;

            try
            {
                if (__melsec.IsConnected() == true)
                {
                    string[] sp = data.Split(',');
                    value = new int[sp.Length];

                    for (int i = 0; i < sp.Length; i++)
                    {
                        value[i] = int.Parse(sp[i]);
                    }
                    await __melsec.PLC.WriteDeviceBlock($"D{addr}", value.Length, value);
                }
                else
                {
                    putLog("PLC Disconnected!!");
                }

            }
            catch (Exception ex)
            {
                putLog(ex.ToString());
            }
        }

        private async void btnRead_Click(object sender, EventArgs e)
        {
            string addr = txtAddress.Text.ToString();
            string data = txtValue.Text.ToString();
            int[] value = new int[10];

            try
            {
                if (__melsec.IsConnected() == true)
                {
                    await __melsec.PLC?.ReadDeviceBlock($"D{addr}", 10, value);

                    txtValue.Text = "";
                    string readString = "";
                    foreach (int v in value)
                    {
                        readString += v.ToString() + ",";
                        putLog($"Read Value =  {v}");
                    }

                    txtValue.Text = readString;
                }
                else
                {
                    putLog("PLC Disconnected!!");
                }

            }
            catch (Exception ex)
            {
                putLog(ex.ToString());
            }
        }

        private void disconnect(object sender, FormClosingEventArgs e)
        {
            putLog("MelSec Close...");

            try
            {
                __melsec.Disconnect();
            }
            catch (Exception ex)
            {
                putLog(ex.Message);
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
