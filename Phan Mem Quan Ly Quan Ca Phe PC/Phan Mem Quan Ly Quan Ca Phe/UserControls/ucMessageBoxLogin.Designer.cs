namespace Phan_Mem_Quan_Ly_Quan_Ca_Phe.UserControls
{
    partial class ucMessageBoxLogin
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.g2btnOK = new Guna.UI2.WinForms.Guna2Button();
            this.lbContent = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2AnimateWindow1 = new Guna.UI2.WinForms.Guna2AnimateWindow(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.g2btnOK);
            this.panel1.Controls.Add(this.lbContent);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(360, 220);
            this.panel1.TabIndex = 3;
            // 
            // g2btnOK
            // 
            this.g2btnOK.BorderRadius = 15;
            this.g2btnOK.CheckedState.Parent = this.g2btnOK;
            this.g2btnOK.CustomImages.Parent = this.g2btnOK;
            this.g2btnOK.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.g2btnOK.ForeColor = System.Drawing.Color.White;
            this.g2btnOK.HoverState.Parent = this.g2btnOK;
            this.g2btnOK.Location = new System.Drawing.Point(126, 157);
            this.g2btnOK.Name = "g2btnOK";
            this.g2btnOK.ShadowDecoration.Parent = this.g2btnOK;
            this.g2btnOK.Size = new System.Drawing.Size(108, 36);
            this.g2btnOK.TabIndex = 4;
            this.g2btnOK.Text = "OK";
            this.g2btnOK.Click += new System.EventHandler(this.g2btnOK_Click);
            // 
            // lbContent
            // 
            this.lbContent.Font = new System.Drawing.Font("Segoe UI", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbContent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(225)))));
            this.lbContent.Location = new System.Drawing.Point(1, 72);
            this.lbContent.Name = "lbContent";
            this.lbContent.Size = new System.Drawing.Size(355, 36);
            this.lbContent.TabIndex = 6;
            this.lbContent.Text = "Đây Là Thông Báo";
            this.lbContent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(225)))));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 21);
            this.label1.TabIndex = 5;
            this.label1.Text = "Thông Báo";
            // 
            // ucMessageBoxLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "ucMessageBoxLogin";
            this.Size = new System.Drawing.Size(360, 220);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbContent;
        private Guna.UI2.WinForms.Guna2Button g2btnOK;
        private Guna.UI2.WinForms.Guna2AnimateWindow guna2AnimateWindow1;
    }
}
