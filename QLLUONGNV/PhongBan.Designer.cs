namespace QLLUONGNV
{
    partial class PhongBan
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
            this.paneltop = new Guna.UI2.WinForms.Guna2Panel();
            this.btThongke = new Guna.UI2.WinForms.Guna2Button();
            this.btQuanli = new Guna.UI2.WinForms.Guna2Button();
            this.panelcontainer1 = new Guna.UI2.WinForms.Guna2Panel();
            this.paneltop.SuspendLayout();
            this.SuspendLayout();
            // 
            // paneltop
            // 
            this.paneltop.BackColor = System.Drawing.Color.White;
            this.paneltop.Controls.Add(this.btThongke);
            this.paneltop.Controls.Add(this.btQuanli);
            this.paneltop.CustomBorderColor = System.Drawing.Color.Silver;
            this.paneltop.Dock = System.Windows.Forms.DockStyle.Top;
            this.paneltop.Location = new System.Drawing.Point(0, 0);
            this.paneltop.Name = "paneltop";
            this.paneltop.ShadowDecoration.Parent = this.paneltop;
            this.paneltop.Size = new System.Drawing.Size(1187, 62);
            this.paneltop.TabIndex = 1;
            // 
            // btThongke
            // 
            this.btThongke.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.btThongke.BorderRadius = 5;
            this.btThongke.BorderThickness = 1;
            this.btThongke.CheckedState.Parent = this.btThongke;
            this.btThongke.CustomImages.Parent = this.btThongke;
            this.btThongke.FillColor = System.Drawing.Color.White;
            this.btThongke.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btThongke.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.btThongke.HoverState.FillColor = System.Drawing.Color.MediumSlateBlue;
            this.btThongke.HoverState.ForeColor = System.Drawing.Color.White;
            this.btThongke.HoverState.Parent = this.btThongke;
            this.btThongke.Location = new System.Drawing.Point(12, 15);
            this.btThongke.Name = "btThongke";
            this.btThongke.PressedColor = System.Drawing.Color.MediumSlateBlue;
            this.btThongke.ShadowDecoration.Parent = this.btThongke;
            this.btThongke.Size = new System.Drawing.Size(99, 35);
            this.btThongke.TabIndex = 101;
            this.btThongke.Text = "Thống kê";
            this.btThongke.Click += new System.EventHandler(this.btThongke_Click);
            // 
            // btQuanli
            // 
            this.btQuanli.BackColor = System.Drawing.Color.GhostWhite;
            this.btQuanli.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.btQuanli.BorderRadius = 5;
            this.btQuanli.BorderThickness = 1;
            this.btQuanli.CheckedState.Parent = this.btQuanli;
            this.btQuanli.CustomImages.Parent = this.btQuanli;
            this.btQuanli.FillColor = System.Drawing.Color.MediumSlateBlue;
            this.btQuanli.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btQuanli.ForeColor = System.Drawing.Color.GhostWhite;
            this.btQuanli.HoverState.FillColor = System.Drawing.Color.DarkSlateBlue;
            this.btQuanli.HoverState.ForeColor = System.Drawing.Color.White;
            this.btQuanli.HoverState.Parent = this.btQuanli;
            this.btQuanli.Location = new System.Drawing.Point(117, 15);
            this.btQuanli.Name = "btQuanli";
            this.btQuanli.PressedColor = System.Drawing.Color.MediumSlateBlue;
            this.btQuanli.ShadowDecoration.Parent = this.btQuanli;
            this.btQuanli.Size = new System.Drawing.Size(99, 35);
            this.btQuanli.TabIndex = 3;
            this.btQuanli.Text = "Quản lý";
            this.btQuanli.Click += new System.EventHandler(this.btQuanli_Click);
            // 
            // panelcontainer1
            // 
            this.panelcontainer1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelcontainer1.Location = new System.Drawing.Point(0, 68);
            this.panelcontainer1.Name = "panelcontainer1";
            this.panelcontainer1.ShadowDecoration.Parent = this.panelcontainer1;
            this.panelcontainer1.Size = new System.Drawing.Size(1188, 664);
            this.panelcontainer1.TabIndex = 2;
            // 
            // PhongBan
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1187, 729);
            this.Controls.Add(this.panelcontainer1);
            this.Controls.Add(this.paneltop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PhongBan";
            this.Text = "PhongBan";
            this.Load += new System.EventHandler(this.PhongBan_Load);
            this.paneltop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel paneltop;
        private Guna.UI2.WinForms.Guna2Button btThongke;
        private Guna.UI2.WinForms.Guna2Button btQuanli;
        private Guna.UI2.WinForms.Guna2Panel panelcontainer1;
    }
}