using System;
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
//            d.init();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            C.log("btnLoad Clicked...");
            int readlines = 0;

            if (radioRound.Checked)
            {
                if (radioLocations.Checked)
                {
                    readlines = d.ReadLocations("ROUND");
                    txtCSVContent.Text = d.getLocationValues(d.RoundLocations);
                } else if (radioGeneral.Checked)
                {
                    readlines = d.ReadGeneralLocations("ROUND");
                    txtCSVContent.Text = d.getGeneralLocationValues(d.RoundGeneralLocations);
                }
                else if (radioStatus.Checked)
                {
                    readlines = d.ReadStatus("ROUND");
                    txtCSVContent.Text = d.getStatusValues(d.RoundStatus);
                }
            } else if (radioDrill.Checked)
            {
                if (radioLocations.Checked)
                {
                    readlines = d.ReadLocations("DRILL");
                    txtCSVContent.Text = d.getLocationValues(d.DrillLocations);
                }
                else if (radioGeneral.Checked)
                {
                    readlines = d.ReadGeneralLocations("DRILL");
                    txtCSVContent.Text = d.getGeneralLocationValues(d.DrillGeneralLocations);
                }
                else if (radioStatus.Checked)
                {
                    readlines = d.ReadStatus("DRILL");
                    txtCSVContent.Text = d.getStatusValues(d.DrillStatus);
                }
            }
            else if (radioHSK.Checked)
            {
                if (radioLocations.Checked)
                {
                    readlines = d.ReadLocations("HSK");
                    txtCSVContent.Text = d.getLocationValues(d.HSKLocations);
                }
                else if (radioGeneral.Checked)
                {
                    readlines = d.ReadGeneralLocations("HSK");
                    txtCSVContent.Text = d.getGeneralLocationValues(d.HSKGeneralLocations);
                }
                else if (radioStatus.Checked)
                {
                    readlines = d.ReadStatus("HSK");
                    txtCSVContent.Text = d.getStatusValues(d.HSKStatus);
                }
            }
            else
            {
                C.log("Tool name is not selected");
                return;
            }

            C.log("Read CSV File Lines : " + readlines);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            C.log("btnSave Clicked...");
            int lines = 0;

            if (radioRound.Checked)
            {
                if (radioLocations.Checked)
                {
                    lines = d.WriteLocations("ROUND");
                    txtCSVContent.Text = "Round Location Saved...";
                }
                else if (radioGeneral.Checked)
                {
                    lines = d.WriteGeneralLocations("ROUND");
                    txtCSVContent.Text = "Round General Location Saved...";
                }
                else if (radioStatus.Checked)
                {
                    lines = d.WriteStatus("ROUND");
                    txtCSVContent.Text = "Round Status Saved...";
                }
            }
            else if (radioDrill.Checked)
            {
                if (radioLocations.Checked)
                {
                    lines = d.WriteLocations("DRILL");
                    txtCSVContent.Text = "Drill Location Saved...";
                }
                else if (radioGeneral.Checked)
                {
                    lines = d.WriteGeneralLocations("DRILL");
                    txtCSVContent.Text = "Drill General Location Saved...";
                }
                else if (radioStatus.Checked)
                {
                    lines = d.WriteStatus("DRILL");
                    txtCSVContent.Text = "Drill Status Saved...";
                }
            }
            else if (radioHSK.Checked)
            {
                if (radioLocations.Checked)
                {
                    lines = d.WriteLocations("HSK");
                    txtCSVContent.Text = "HSK Location Saved...";
                }
                else if (radioGeneral.Checked)
                {
                    lines = d.WriteGeneralLocations("HSK");
                    txtCSVContent.Text = "HSK General Location Saved...";
                }
                else if (radioStatus.Checked)
                {
                    lines = d.WriteStatus("HSK");
                    txtCSVContent.Text = "HSK Status Saved...";
                }
            }
            else
            {
                C.log("Tool name is not selected");
                return;
            }

            C.log("Write CSV File Lines : " + lines);
        }
    }
}
