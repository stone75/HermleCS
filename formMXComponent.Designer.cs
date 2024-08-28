namespace HermleCS
{
    partial class formMXComponent
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLSN = new System.Windows.Forms.TextBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDeviceID = new System.Windows.Forms.TextBox();
            this.txtWriteValue = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnWrite = new System.Windows.Forms.Button();
            this.txtReadValue = new System.Windows.Forms.TextBox();
            this.btnRead = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Logical Station Number : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(6, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(589, 48);
            this.label2.TabIndex = 1;
            this.label2.Text = "MX Component 사용 연결";
            // 
            // txtLSN
            // 
            this.txtLSN.Location = new System.Drawing.Point(163, 90);
            this.txtLSN.Name = "txtLSN";
            this.txtLSN.Size = new System.Drawing.Size(131, 21);
            this.txtLSN.TabIndex = 2;
            this.txtLSN.Text = "0";
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(324, 90);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(116, 23);
            this.btnOpen.TabIndex = 3;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(478, 91);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(117, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(95, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "Device ID :";
            // 
            // txtDeviceID
            // 
            this.txtDeviceID.Location = new System.Drawing.Point(163, 148);
            this.txtDeviceID.Name = "txtDeviceID";
            this.txtDeviceID.Size = new System.Drawing.Size(131, 21);
            this.txtDeviceID.TabIndex = 6;
            this.txtDeviceID.Text = "M100";
            // 
            // txtWriteValue
            // 
            this.txtWriteValue.Location = new System.Drawing.Point(163, 212);
            this.txtWriteValue.Name = "txtWriteValue";
            this.txtWriteValue.Size = new System.Drawing.Size(131, 21);
            this.txtWriteValue.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(112, 217);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "Value :";
            // 
            // btnWrite
            // 
            this.btnWrite.Location = new System.Drawing.Point(324, 210);
            this.btnWrite.Name = "btnWrite";
            this.btnWrite.Size = new System.Drawing.Size(116, 23);
            this.btnWrite.TabIndex = 9;
            this.btnWrite.Text = "Write Value";
            this.btnWrite.UseVisualStyleBackColor = true;
            this.btnWrite.Click += new System.EventHandler(this.btnWrite_Click);
            // 
            // txtReadValue
            // 
            this.txtReadValue.Location = new System.Drawing.Point(163, 291);
            this.txtReadValue.Name = "txtReadValue";
            this.txtReadValue.ReadOnly = true;
            this.txtReadValue.Size = new System.Drawing.Size(131, 21);
            this.txtReadValue.TabIndex = 10;
            // 
            // btnRead
            // 
            this.btnRead.Location = new System.Drawing.Point(324, 291);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(116, 23);
            this.btnRead.TabIndex = 11;
            this.btnRead.Text = "Read Value";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(230, 236);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "( 0 ~ 255 )";
            // 
            // formMXComponent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnRead);
            this.Controls.Add(this.txtReadValue);
            this.Controls.Add(this.btnWrite);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtWriteValue);
            this.Controls.Add(this.txtDeviceID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.txtLSN);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "formMXComponent";
            this.Text = "formMXComponent";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLSN;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDeviceID;
        private System.Windows.Forms.TextBox txtWriteValue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnWrite;
        private System.Windows.Forms.TextBox txtReadValue;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.Label label5;
    }
}