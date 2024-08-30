namespace QLLUONGNV
{
    partial class InKyLuat
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
            this.crystalReportKL = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
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
            this.paneltop.Size = new System.Drawing.Size(800, 71);
            this.paneltop.TabIndex = 100;
            // 
            // controlcloser
            // 
            this.controlcloser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.controlcloser.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.controlcloser.FillColor = System.Drawing.Color.Transparent;
            this.controlcloser.HoverState.Parent = this.controlcloser;
            this.controlcloser.IconColor = System.Drawing.Color.White;
            this.controlcloser.Location = new System.Drawing.Point(755, 0);
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
            this.labelchitiet.Location = new System.Drawing.Point(165, 16);
            this.labelchitiet.Name = "labelchitiet";
            this.labelchitiet.Size = new System.Drawing.Size(570, 37);
            this.labelchitiet.TabIndex = 135;
            this.labelchitiet.Text = "DANH SÁCH IN KỶ LUẬT NHÂN VIÊN ";
            // 
            // crystalReportKL
            // 
            this.crystalReportKL.ActiveViewIndex = -1;
            this.crystalReportKL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportKL.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportKL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportKL.Location = new System.Drawing.Point(0, 71);
            this.crystalReportKL.Name = "crystalReportKL";
            this.crystalReportKL.Size = new System.Drawing.Size(800, 379);
            this.crystalReportKL.TabIndex = 101;
            this.crystalReportKL.Load += new System.EventHandler(this.crystalReportKL_Load);
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.TargetControl = this.paneltop;
            // 
            // InKyLuat
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.crystalReportKL);
            this.Controls.Add(this.paneltop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "InKyLuat";
            this.Text = "InKyLuat";
            this.Load += new System.EventHandler(this.InKyLuat_Load);
            this.paneltop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel paneltop;
        private Guna.UI2.WinForms.Guna2ControlBox controlcloser;
        private Guna.UI2.WinForms.Guna2HtmlLabel labelchitiet;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportKL;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
    }
}