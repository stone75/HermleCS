namespace HermleCS
{
    partial class formCSVTest
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.radioRound = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioDrill = new System.Windows.Forms.RadioButton();
            this.radioHSK = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioGeneral = new System.Windows.Forms.RadioButton();
            this.radioLocations = new System.Windows.Forms.RadioButton();
            this.radioStatus = new System.Windows.Forms.RadioButton();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtCSVContent = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // radioRound
            // 
            this.radioRound.AutoSize = true;
            this.radioRound.Checked = true;
            this.radioRound.Location = new System.Drawing.Point(20, 20);
            this.radioRound.Name = "radioRound";
            this.radioRound.Size = new System.Drawing.Size(59, 16);
            this.radioRound.TabIndex = 0;
            this.radioRound.TabStop = true;
            this.radioRound.Text = "Round";
            this.radioRound.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioDrill);
            this.groupBox1.Controls.Add(this.radioHSK);
            this.groupBox1.Controls.Add(this.radioRound);
            this.groupBox1.Location = new System.Drawing.Point(615, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(173, 101);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tool 선택";
            // 
            // radioDrill
            // 
            this.radioDrill.AutoSize = true;
            this.radioDrill.Location = new System.Drawing.Point(20, 64);
            this.radioDrill.Name = "radioDrill";
            this.radioDrill.Size = new System.Drawing.Size(44, 16);
            this.radioDrill.TabIndex = 2;
            this.radioDrill.Text = "Drill";
            this.radioDrill.UseVisualStyleBackColor = true;
            // 
            // radioHSK
            // 
            this.radioHSK.AutoSize = true;
            this.radioHSK.Location = new System.Drawing.Point(20, 42);
            this.radioHSK.Name = "radioHSK";
            this.radioHSK.Size = new System.Drawing.Size(47, 16);
            this.radioHSK.TabIndex = 1;
            this.radioHSK.Text = "HSK";
            this.radioHSK.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioGeneral);
            this.groupBox2.Controls.Add(this.radioLocations);
            this.groupBox2.Controls.Add(this.radioStatus);
            this.groupBox2.Location = new System.Drawing.Point(615, 135);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(173, 100);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Location 정보";
            // 
            // radioGeneral
            // 
            this.radioGeneral.AutoSize = true;
            this.radioGeneral.Location = new System.Drawing.Point(20, 64);
            this.radioGeneral.Name = "radioGeneral";
            this.radioGeneral.Size = new System.Drawing.Size(126, 16);
            this.radioGeneral.TabIndex = 3;
            this.radioGeneral.Text = "General Locations";
            this.radioGeneral.UseVisualStyleBackColor = true;
            // 
            // radioLocations
            // 
            this.radioLocations.AutoSize = true;
            this.radioLocations.Checked = true;
            this.radioLocations.Location = new System.Drawing.Point(20, 42);
            this.radioLocations.Name = "radioLocations";
            this.radioLocations.Size = new System.Drawing.Size(78, 16);
            this.radioLocations.TabIndex = 2;
            this.radioLocations.TabStop = true;
            this.radioLocations.Text = "Locations";
            this.radioLocations.UseVisualStyleBackColor = true;
            // 
            // radioStatus
            // 
            this.radioStatus.AutoSize = true;
            this.radioStatus.Location = new System.Drawing.Point(20, 20);
            this.radioStatus.Name = "radioStatus";
            this.radioStatus.Size = new System.Drawing.Size(58, 16);
            this.radioStatus.TabIndex = 1;
            this.radioStatus.Text = "Status";
            this.radioStatus.UseVisualStyleBackColor = true;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(615, 265);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(173, 35);
            this.btnLoad.TabIndex = 3;
            this.btnLoad.Text = "파일 Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(615, 315);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(173, 35);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "파일 Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtCSVContent
            // 
            this.txtCSVContent.Location = new System.Drawing.Point(12, 12);
            this.txtCSVContent.Multiline = true;
            this.txtCSVContent.Name = "txtCSVContent";
            this.txtCSVContent.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtCSVContent.Size = new System.Drawing.Size(575, 338);
            this.txtCSVContent.TabIndex = 5;
            this.txtCSVContent.Text = "CSV Content Here...";
            // 
            // formCSVTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 362);
            this.Controls.Add(this.txtCSVContent);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "formCSVTest";
            this.Text = "formCSVTest";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioRound;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioDrill;
        private System.Windows.Forms.RadioButton radioHSK;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioGeneral;
        private System.Windows.Forms.RadioButton radioLocations;
        private System.Windows.Forms.RadioButton radioStatus;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtCSVContent;
    }
}