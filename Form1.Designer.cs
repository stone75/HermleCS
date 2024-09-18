namespace HermleCS
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnMXComponent = new System.Windows.Forms.Button();
            this.btnHTTPConnection = new System.Windows.Forms.Button();
            this.btnTCPComponent = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnMXComponent
            // 
            this.btnMXComponent.Enabled = false;
            this.btnMXComponent.Location = new System.Drawing.Point(12, 12);
            this.btnMXComponent.Name = "btnMXComponent";
            this.btnMXComponent.Size = new System.Drawing.Size(215, 63);
            this.btnMXComponent.TabIndex = 0;
            this.btnMXComponent.Text = "MX Component 로 통신";
            this.btnMXComponent.UseVisualStyleBackColor = true;
            this.btnMXComponent.Click += new System.EventHandler(this.btnMXComponent_Click);
            // 
            // btnHTTPConnection
            // 
            this.btnHTTPConnection.Location = new System.Drawing.Point(12, 203);
            this.btnHTTPConnection.Name = "btnHTTPConnection";
            this.btnHTTPConnection.Size = new System.Drawing.Size(215, 68);
            this.btnHTTPConnection.TabIndex = 1;
            this.btnHTTPConnection.Text = "HTTP Connection 통신";
            this.btnHTTPConnection.UseVisualStyleBackColor = true;
            this.btnHTTPConnection.Click += new System.EventHandler(this.btnHTTPConnection_Click);
            // 
            // btnTCPComponent
            // 
            this.btnTCPComponent.Enabled = false;
            this.btnTCPComponent.Location = new System.Drawing.Point(12, 108);
            this.btnTCPComponent.Name = "btnTCPComponent";
            this.btnTCPComponent.Size = new System.Drawing.Size(215, 63);
            this.btnTCPComponent.TabIndex = 2;
            this.btnTCPComponent.Text = "TCP Component 로 통신";
            this.btnTCPComponent.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(239, 283);
            this.Controls.Add(this.btnTCPComponent);
            this.Controls.Add(this.btnHTTPConnection);
            this.Controls.Add(this.btnMXComponent);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMXComponent;
        private System.Windows.Forms.Button btnHTTPConnection;
        private System.Windows.Forms.Button btnTCPComponent;
    }
}

