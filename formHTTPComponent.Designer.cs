namespace HermleCS
{
    partial class formHTTPComponent
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
            this.txtIPAddr = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPortNum = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPostData = new System.Windows.Forms.TextBox();
            this.btnHTPPCall = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnPreset1 = new System.Windows.Forms.Button();
            this.btnPreset2 = new System.Windows.Forms.Button();
            this.btnPreset3 = new System.Windows.Forms.Button();
            this.btnPreset6 = new System.Windows.Forms.Button();
            this.btnPreset5 = new System.Windows.Forms.Button();
            this.btnPreset4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtIPAddr
            // 
            this.txtIPAddr.Location = new System.Drawing.Point(102, 13);
            this.txtIPAddr.Name = "txtIPAddr";
            this.txtIPAddr.Size = new System.Drawing.Size(172, 21);
            this.txtIPAddr.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "IP Address :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "Port Number :";
            // 
            // txtPortNum
            // 
            this.txtPortNum.Location = new System.Drawing.Point(102, 40);
            this.txtPortNum.Name = "txtPortNum";
            this.txtPortNum.Size = new System.Drawing.Size(49, 21);
            this.txtPortNum.TabIndex = 2;
            this.txtPortNum.Text = "80";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "URL :";
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(102, 67);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(172, 21);
            this.txtURL.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(60, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(204, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "Data : ---------------------------";
            // 
            // txtPostData
            // 
            this.txtPostData.Location = new System.Drawing.Point(14, 115);
            this.txtPostData.Multiline = true;
            this.txtPostData.Name = "txtPostData";
            this.txtPostData.Size = new System.Drawing.Size(260, 124);
            this.txtPostData.TabIndex = 7;
            // 
            // btnHTPPCall
            // 
            this.btnHTPPCall.Location = new System.Drawing.Point(14, 309);
            this.btnHTPPCall.Name = "btnHTPPCall";
            this.btnHTPPCall.Size = new System.Drawing.Size(260, 41);
            this.btnHTPPCall.TabIndex = 8;
            this.btnHTPPCall.Text = "HTTP 호출";
            this.btnHTPPCall.UseVisualStyleBackColor = true;
            this.btnHTPPCall.Click += new System.EventHandler(this.btnHTPPCall_Click);
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(14, 373);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.Size = new System.Drawing.Size(260, 189);
            this.txtResult.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 358);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(256, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "Result : ----------------------------------";
            // 
            // btnPreset1
            // 
            this.btnPreset1.Location = new System.Drawing.Point(13, 245);
            this.btnPreset1.Name = "btnPreset1";
            this.btnPreset1.Size = new System.Drawing.Size(75, 23);
            this.btnPreset1.TabIndex = 11;
            this.btnPreset1.Text = "Pre-Daum";
            this.btnPreset1.UseVisualStyleBackColor = true;
            this.btnPreset1.Click += new System.EventHandler(this.btnPreset1_Click);
            // 
            // btnPreset2
            // 
            this.btnPreset2.Location = new System.Drawing.Point(106, 245);
            this.btnPreset2.Name = "btnPreset2";
            this.btnPreset2.Size = new System.Drawing.Size(75, 23);
            this.btnPreset2.TabIndex = 12;
            this.btnPreset2.Text = "Pre-Get";
            this.btnPreset2.UseVisualStyleBackColor = true;
            this.btnPreset2.Click += new System.EventHandler(this.btnPreset2_Click);
            // 
            // btnPreset3
            // 
            this.btnPreset3.Location = new System.Drawing.Point(198, 245);
            this.btnPreset3.Name = "btnPreset3";
            this.btnPreset3.Size = new System.Drawing.Size(75, 23);
            this.btnPreset3.TabIndex = 13;
            this.btnPreset3.Text = "Pre-Post";
            this.btnPreset3.UseVisualStyleBackColor = true;
            this.btnPreset3.Click += new System.EventHandler(this.btnPreset3_Click);
            // 
            // btnPreset6
            // 
            this.btnPreset6.Location = new System.Drawing.Point(198, 277);
            this.btnPreset6.Name = "btnPreset6";
            this.btnPreset6.Size = new System.Drawing.Size(75, 23);
            this.btnPreset6.TabIndex = 16;
            this.btnPreset6.Text = "Pre-Move2";
            this.btnPreset6.UseVisualStyleBackColor = true;
            this.btnPreset6.Click += new System.EventHandler(this.btnPreset6_Click);
            // 
            // btnPreset5
            // 
            this.btnPreset5.Location = new System.Drawing.Point(106, 277);
            this.btnPreset5.Name = "btnPreset5";
            this.btnPreset5.Size = new System.Drawing.Size(75, 23);
            this.btnPreset5.TabIndex = 15;
            this.btnPreset5.Text = "Pre-Move";
            this.btnPreset5.UseVisualStyleBackColor = true;
            this.btnPreset5.Click += new System.EventHandler(this.btnPreset5_Click);
            // 
            // btnPreset4
            // 
            this.btnPreset4.Location = new System.Drawing.Point(13, 277);
            this.btnPreset4.Name = "btnPreset4";
            this.btnPreset4.Size = new System.Drawing.Size(75, 23);
            this.btnPreset4.TabIndex = 14;
            this.btnPreset4.Text = "Pre-Pos";
            this.btnPreset4.UseVisualStyleBackColor = true;
            this.btnPreset4.Click += new System.EventHandler(this.btnPreset4_Click);
            // 
            // formHTTPComponent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 574);
            this.Controls.Add(this.btnPreset6);
            this.Controls.Add(this.btnPreset5);
            this.Controls.Add(this.btnPreset4);
            this.Controls.Add(this.btnPreset3);
            this.Controls.Add(this.btnPreset2);
            this.Controls.Add(this.btnPreset1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.btnHTPPCall);
            this.Controls.Add(this.txtPostData);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtURL);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPortNum);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtIPAddr);
            this.Name = "formHTTPComponent";
            this.Text = "formHTTPComponent";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtIPAddr;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPortNum;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPostData;
        private System.Windows.Forms.Button btnHTPPCall;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnPreset1;
        private System.Windows.Forms.Button btnPreset2;
        private System.Windows.Forms.Button btnPreset3;
        private System.Windows.Forms.Button btnPreset6;
        private System.Windows.Forms.Button btnPreset5;
        private System.Windows.Forms.Button btnPreset4;
    }
}