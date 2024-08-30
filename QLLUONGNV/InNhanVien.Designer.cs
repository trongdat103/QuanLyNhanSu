namespace QLLUONGNV
{
    partial class InNhanVien
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
            this.components = new System.ComponentModel.Container();
            this.paneltop = new Guna.UI2.WinForms.Guna2Panel();
            this.controlcloser = new Guna.UI2.WinForms.Guna2ControlBox();
            this.labelchitiet = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.ReportInNhanvien = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.paneltop.SuspendLayout();
            this.SuspendLayout();
            // 
            // paneltop
            // 
            this.paneltop.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.paneltop.Controls.Add(this.controlcloser);
            this.paneltop.Controls.Add(this.labelchitiet);
            this.paneltop.CustomBorderColor = System.Drawing.Color.Silver;
            this.paneltop.Dock = System.Windows.Forms.DockStyle.Top;
            this.paneltop.Location = new System.Drawing.Point(0, 0);
            this.paneltop.Name = "paneltop";
            this.paneltop.ShadowDecoration.Parent = this.paneltop;
            this.paneltop.Size = new System.Drawing.Size(1020, 71);
            this.paneltop.TabIndex = 98;
            this.paneltop.Paint += new System.Windows.Forms.PaintEventHandler(this.paneltop_Paint);
            // 
            // controlcloser
            // 
            this.controlcloser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.controlcloser.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.controlcloser.FillColor = System.Drawing.Color.Transparent;
            this.controlcloser.HoverState.Parent = this.controlcloser;
            this.controlcloser.IconColor = System.Drawing.Color.White;
            this.controlcloser.Location = new System.Drawing.Point(975, 0);
            this.controlcloser.Name = "controlcloser";
            this.controlcloser.ShadowDecoration.Parent = this.controlcloser;
            this.controlcloser.Size = new System.Drawing.Size(45, 29);
            this.controlcloser.TabIndex = 136;
            // 
            // labelchitiet
            // 
            this.labelchitiet.AutoSize = false;
            this.labelchitiet.BackColor = System.Drawing.Color.Transparent;
            this.labelchitiet.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelchitiet.ForeColor = System.Drawing.Color.White;
            this.labelchitiet.Location = new System.Drawing.Point(419, 18);
            this.labelchitiet.Name = "labelchitiet";
            this.labelchitiet.Size = new System.Drawing.Size(360, 37);
            this.labelchitiet.TabIndex = 135;
            this.labelchitiet.Text = "DANH SÁCH IN NHÂN VIÊN ";
            // 
            // ReportInNhanvien
            // 
            this.ReportInNhanvien.ActiveViewIndex = -1;
            this.ReportInNhanvien.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ReportInNhanvien.Cursor = System.Windows.Forms.Cursors.Default;
            this.ReportInNhanvien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReportInNhanvien.Location = new System.Drawing.Point(0, 71);
            this.ReportInNhanvien.Name = "ReportInNhanvien";
            this.ReportInNhanvien.Size = new System.Drawing.Size(1020, 596);
            this.ReportInNhanvien.TabIndex = 99;
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.TargetControl = this.paneltop;
            // 
            // InNhanVien
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1020, 667);
            this.Controls.Add(this.ReportInNhanvien);
            this.Controls.Add(this.paneltop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "InNhanVien";
            this.Text = "InNhanVien";
            this.Load += new System.EventHandler(this.InNhanVien_Load);
            this.paneltop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel paneltop;
        private Guna.UI2.WinForms.Guna2ControlBox controlcloser;
        private Guna.UI2.WinForms.Guna2HtmlLabel labelchitiet;
        public CrystalDecisions.Windows.Forms.CrystalReportViewer ReportInNhanvien;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
    }
}