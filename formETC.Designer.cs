namespace $safeprojectname$
{
    partial class formETC
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
            this.btnCurrentLocationn = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnCurrentLocationn
            // 
            this.btnCurrentLocationn.Location = new System.Drawing.Point(12, 12);
            this.btnCurrentLocationn.Name = "btnCurrentLocationn";
            this.btnCurrentLocationn.Size = new System.Drawing.Size(265, 47);
            this.btnCurrentLocationn.TabIndex = 0;
            this.btnCurrentLocationn.Text = "Current Locations";
            this.btnCurrentLocationn.UseVisualStyleBackColor = true;
            this.btnCurrentLocationn.Click += new System.EventHandler(this.btnCurrentLocationn_Click);
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(12, 234);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLog.Size = new System.Drawing.Size(265, 204);
            this.txtLog.TabIndex = 1;
            // 
            // formETC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 450);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.btnCurrentLocationn);
            this.Name = "formETC";
            this.Text = "formETC";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCurrentLocationn;
        private System.Windows.Forms.TextBox txtLog;
    }
}