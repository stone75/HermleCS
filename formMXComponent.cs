using HermleCS.Comm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace HermleCS
{
    public partial class formMXComponent : Form
    {
        CommMXComponent plccomm;

        public formMXComponent()
        {
            InitializeComponent();

            plccomm = CommMXComponent.Instance;
//            plccomm.test();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (txtLSN.Text == "")
            {
                MessageBox.Show("로지컬 스테이션 넘버를 넣어주세요",
                          Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int iLogicalStationNumber;
            if (GetIntValue(txtLSN, out iLogicalStationNumber) != true)
            {
                MessageBox.Show("로지컬 스테이션 넘버에는 숫자를 넣어주세요",
                          Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (plccomm.init(iLogicalStationNumber) != true)
            {
                MessageBox.Show("로지컬 스테이션 초기화에 실패했습니다.",
                          Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("로지컬 스테이션 초기화 완료",
                      Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            plccomm.destroy();
        }

        private bool GetIntValue(TextBox lptxt_SourceOfIntValue, out int iGottenIntValue)
        {
            iGottenIntValue = 0;

            try
            {
                String FormString = lptxt_SourceOfIntValue.Text;
                if (0 <= FormString.IndexOf("0X"))
                {
                    iGottenIntValue = Convert.ToInt32(lptxt_SourceOfIntValue.Text.Substring(2), 16);
                }
                else
                {
                    iGottenIntValue = Convert.ToInt32(lptxt_SourceOfIntValue.Text);
                }
            }
            catch (Exception exExcepion)
            {
                MessageBox.Show(exExcepion.Message,
                                  Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            if (txtWriteValue.Text == "")
            {
                MessageBox.Show("값을 입력해주세요",
                          Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int iValue;
            if (GetIntValue(txtWriteValue, out iValue) != true)
            {
                MessageBox.Show("숫자를 넣어주세요",
                          Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (iValue < 0 || iValue > 256)
            {
                MessageBox.Show("적당한 숫자를 넣어주세요",
                          Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool rval = plccomm.sendMessage(txtDeviceID.Text, (short)iValue);
            if (rval)
            {
                MessageBox.Show("성공",
                          Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                MessageBox.Show("실패",
                          Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            string value;

            bool rval = plccomm.readMessage(txtDeviceID.Text, out value);
            if (rval)
            {
                MessageBox.Show("성공",
                          Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("실패",
                          Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            txtReadValue.Text = value;

            return;
        }
    }
}
