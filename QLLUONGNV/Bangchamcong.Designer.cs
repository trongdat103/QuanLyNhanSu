namespace QLLUONGNV
{
    partial class Bangchamcong
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Bangchamcong));
            this.btXoaBanCC = new Guna.UI2.WinForms.Guna2Button();
            this.cbxNamDS = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cbxThangDS = new Guna.UI2.WinForms.Guna2ComboBox();
            this.labelDSBangcong = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.dgvNhanvien = new Guna.UI2.WinForms.Guna2DataGridView();
            this.paneltop = new Guna.UI2.WinForms.Guna2Panel();
            this.txtTimkiem = new Guna.UI2.WinForms.Guna2TextBox();
            this.labelPhong = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.cbxPhongban = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btAll = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanvien)).BeginInit();
            this.paneltop.SuspendLayout();
            this.SuspendLayout();
            // 
            // btXoaBanCC
            // 
            this.btXoaBanCC.BackColor = System.Drawing.Color.GhostWhite;
            this.btXoaBanCC.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.btXoaBanCC.BorderRadius = 5;
            this.btXoaBanCC.BorderThickness = 1;
            this.btXoaBanCC.CheckedState.Parent = this.btXoaBanCC;
            this.btXoaBanCC.CustomImages.Parent = this.btXoaBanCC;
            this.btXoaBanCC.FillColor = System.Drawing.Color.MediumSlateBlue;
            this.btXoaBanCC.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btXoaBanCC.ForeColor = System.Drawing.Color.GhostWhite;
            this.btXoaBanCC.HoverState.FillColor = System.Drawing.Color.DarkSlateBlue;
            this.btXoaBanCC.HoverState.ForeColor = System.Drawing.Color.White;
            this.btXoaBanCC.HoverState.Parent = this.btXoaBanCC;
            this.btXoaBanCC.Location = new System.Drawing.Point(1061, 619);
            this.btXoaBanCC.Name = "btXoaBanCC";
            this.btXoaBanCC.PressedColor = System.Drawing.Color.MediumSlateBlue;
            this.btXoaBanCC.ShadowDecoration.Parent = this.btXoaBanCC;
            this.btXoaBanCC.Size = new System.Drawing.Size(97, 35);
            this.btXoaBanCC.TabIndex = 170;
            this.btXoaBanCC.Text = "Xóa";
            this.btXoaBanCC.Click += new System.EventHandler(this.btXoaBanCC_Click);
            // 
            // cbxNamDS
            // 
            this.cbxNamDS.AutoRoundedCorners = true;
            this.cbxNamDS.BackColor = System.Drawing.Color.Transparent;
            this.cbxNamDS.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.cbxNamDS.BorderRadius = 17;
            this.cbxNamDS.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbxNamDS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxNamDS.FillColor = System.Drawing.Color.GhostWhite;
            this.cbxNamDS.FocusedColor = System.Drawing.Color.Empty;
            this.cbxNamDS.FocusedState.Parent = this.cbxNamDS;
            this.cbxNamDS.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbxNamDS.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.cbxNamDS.FormattingEnabled = true;
            this.cbxNamDS.HoverState.Parent = this.cbxNamDS;
            this.cbxNamDS.ItemHeight = 30;
            this.cbxNamDS.ItemsAppearance.Parent = this.cbxNamDS;
            this.cbxNamDS.Location = new System.Drawing.Point(551, 133);
            this.cbxNamDS.Name = "cbxNamDS";
            this.cbxNamDS.ShadowDecoration.Parent = this.cbxNamDS;
            this.cbxNamDS.Size = new System.Drawing.Size(113, 36);
            this.cbxNamDS.TabIndex = 168;
            this.cbxNamDS.SelectionChangeCommitted += new System.EventHandler(this.cbxNamDS_SelectionChangeCommitted);
            // 
            // cbxThangDS
            // 
            this.cbxThangDS.AutoRoundedCorners = true;
            this.cbxThangDS.BackColor = System.Drawing.Color.Transparent;
            this.cbxThangDS.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.cbxThangDS.BorderRadius = 17;
            this.cbxThangDS.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbxThangDS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxThangDS.FillColor = System.Drawing.Color.GhostWhite;
            this.cbxThangDS.FocusedColor = System.Drawing.Color.Empty;
            this.cbxThangDS.FocusedState.Parent = this.cbxThangDS;
            this.cbxThangDS.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbxThangDS.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.cbxThangDS.FormattingEnabled = true;
            this.cbxThangDS.HoverState.Parent = this.cbxThangDS;
            this.cbxThangDS.ItemHeight = 30;
            this.cbxThangDS.ItemsAppearance.Parent = this.cbxThangDS;
            this.cbxThangDS.Location = new System.Drawing.Point(425, 134);
            this.cbxThangDS.Name = "cbxThangDS";
            this.cbxThangDS.ShadowDecoration.Parent = this.cbxThangDS;
            this.cbxThangDS.Size = new System.Drawing.Size(120, 36);
            this.cbxThangDS.TabIndex = 167;
            this.cbxThangDS.SelectionChangeCommitted += new System.EventHandler(this.cbxThangDS_SelectionChangeCommitted);
            // 
            // labelDSBangcong
            // 
            this.labelDSBangcong.AutoSize = false;
            this.labelDSBangcong.BackColor = System.Drawing.Color.Transparent;
            this.labelDSBangcong.Font = new System.Drawing.Font("Segoe UI Semibold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDSBangcong.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.labelDSBangcong.Location = new System.Drawing.Point(316, 93);
            this.labelDSBangcong.Name = "labelDSBangcong";
            this.labelDSBangcong.Size = new System.Drawing.Size(609, 35);
            this.labelDSBangcong.TabIndex = 166;
            this.labelDSBangcong.Text = "DANH SÁCH BẢNG CHẤM CÔNG NHÂN VIÊN";
            // 
            // dgvNhanvien
            // 
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            this.dgvNhanvien.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvNhanvien.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNhanvien.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dgvNhanvien.BackgroundColor = System.Drawing.Color.White;
            this.dgvNhanvien.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvNhanvien.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvNhanvien.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvNhanvien.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvNhanvien.ColumnHeadersHeight = 27;
            this.dgvNhanvien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvNhanvien.DefaultCellStyle = dataGridViewCellStyle11;
            this.dgvNhanvien.EnableHeadersVisualStyles = false;
            this.dgvNhanvien.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvNhanvien.Location = new System.Drawing.Point(12, 180);
            this.dgvNhanvien.Name = "dgvNhanvien";
            this.dgvNhanvien.RowHeadersVisible = false;
            this.dgvNhanvien.RowHeadersWidth = 51;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            this.dgvNhanvien.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvNhanvien.RowTemplate.Height = 24;
            this.dgvNhanvien.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNhanvien.Size = new System.Drawing.Size(1163, 430);
            this.dgvNhanvien.TabIndex = 165;
            this.dgvNhanvien.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            this.dgvNhanvien.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvNhanvien.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvNhanvien.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvNhanvien.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvNhanvien.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvNhanvien.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvNhanvien.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvNhanvien.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvNhanvien.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvNhanvien.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvNhanvien.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvNhanvien.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvNhanvien.ThemeStyle.HeaderStyle.Height = 27;
            this.dgvNhanvien.ThemeStyle.ReadOnly = false;
            this.dgvNhanvien.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvNhanvien.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvNhanvien.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvNhanvien.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvNhanvien.ThemeStyle.RowsStyle.Height = 24;
            this.dgvNhanvien.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvNhanvien.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // paneltop
            // 
            this.paneltop.BackColor = System.Drawing.Color.White;
            this.paneltop.Controls.Add(this.btAll);
            this.paneltop.Controls.Add(this.txtTimkiem);
            this.paneltop.Controls.Add(this.labelPhong);
            this.paneltop.Controls.Add(this.cbxPhongban);
            this.paneltop.CustomBorderColor = System.Drawing.Color.Silver;
            this.paneltop.Dock = System.Windows.Forms.DockStyle.Top;
            this.paneltop.Location = new System.Drawing.Point(0, 0);
            this.paneltop.Name = "paneltop";
            this.paneltop.ShadowDecoration.Parent = this.paneltop;
            this.paneltop.Size = new System.Drawing.Size(1187, 62);
            this.paneltop.TabIndex = 172;
            // 
            // txtTimkiem
            // 
            this.txtTimkiem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTimkiem.AutoRoundedCorners = true;
            this.txtTimkiem.BorderRadius = 18;
            this.txtTimkiem.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTimkiem.DefaultText = "";
            this.txtTimkiem.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTimkiem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTimkiem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTimkiem.DisabledState.Parent = this.txtTimkiem;
            this.txtTimkiem.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTimkiem.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTimkiem.FocusedState.Parent = this.txtTimkiem;
            this.txtTimkiem.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTimkiem.HoverState.Parent = this.txtTimkiem;
            this.txtTimkiem.IconLeft = ((System.Drawing.Image)(resources.GetObject("txtTimkiem.IconLeft")));
            this.txtTimkiem.IconLeftOffset = new System.Drawing.Point(5, 0);
            this.txtTimkiem.Location = new System.Drawing.Point(890, 10);
            this.txtTimkiem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTimkiem.Name = "txtTimkiem";
            this.txtTimkiem.PasswordChar = '\0';
            this.txtTimkiem.PlaceholderText = "Tìm kiếm";
            this.txtTimkiem.SelectedText = "";
            this.txtTimkiem.ShadowDecoration.Parent = this.txtTimkiem;
            this.txtTimkiem.Size = new System.Drawing.Size(272, 39);
            this.txtTimkiem.TabIndex = 105;
            this.txtTimkiem.TextOffset = new System.Drawing.Point(5, 0);
            this.txtTimkiem.TextChanged += new System.EventHandler(this.txtTimkiem_TextChanged);
            // 
            // labelPhong
            // 
            this.labelPhong.AutoSize = false;
            this.labelPhong.BackColor = System.Drawing.Color.Transparent;
            this.labelPhong.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPhong.Location = new System.Drawing.Point(12, 21);
            this.labelPhong.Name = "labelPhong";
            this.labelPhong.Size = new System.Drawing.Size(90, 28);
            this.labelPhong.TabIndex = 102;
            this.labelPhong.Text = "Phòng ban";
            // 
            // cbxPhongban
            // 
            this.cbxPhongban.AutoRoundedCorners = true;
            this.cbxPhongban.BackColor = System.Drawing.Color.Transparent;
            this.cbxPhongban.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.cbxPhongban.BorderRadius = 17;
            this.cbxPhongban.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbxPhongban.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPhongban.FillColor = System.Drawing.Color.GhostWhite;
            this.cbxPhongban.FocusedColor = System.Drawing.Color.Empty;
            this.cbxPhongban.FocusedState.Parent = this.cbxPhongban;
            this.cbxPhongban.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbxPhongban.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.cbxPhongban.FormattingEnabled = true;
            this.cbxPhongban.HoverState.Parent = this.cbxPhongban;
            this.cbxPhongban.ItemHeight = 30;
            this.cbxPhongban.ItemsAppearance.Parent = this.cbxPhongban;
            this.cbxPhongban.Location = new System.Drawing.Point(104, 12);
            this.cbxPhongban.Name = "cbxPhongban";
            this.cbxPhongban.ShadowDecoration.Parent = this.cbxPhongban;
            this.cbxPhongban.Size = new System.Drawing.Size(176, 36);
            this.cbxPhongban.TabIndex = 101;
            this.cbxPhongban.SelectionChangeCommitted += new System.EventHandler(this.cbxPhongban_SelectionChangeCommitted);
            // 
            // btAll
            // 
            this.btAll.BackColor = System.Drawing.Color.GhostWhite;
            this.btAll.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.btAll.BorderRadius = 5;
            this.btAll.BorderThickness = 1;
            this.btAll.CheckedState.Parent = this.btAll;
            this.btAll.CustomImages.Parent = this.btAll;
            this.btAll.FillColor = System.Drawing.Color.MediumSlateBlue;
            this.btAll.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btAll.ForeColor = System.Drawing.Color.GhostWhite;
            this.btAll.HoverState.FillColor = System.Drawing.Color.DarkSlateBlue;
            this.btAll.HoverState.ForeColor = System.Drawing.Color.White;
            this.btAll.HoverState.Parent = this.btAll;
            this.btAll.Location = new System.Drawing.Point(290, 12);
            this.btAll.Name = "btAll";
            this.btAll.PressedColor = System.Drawing.Color.MediumSlateBlue;
            this.btAll.ShadowDecoration.Parent = this.btAll;
            this.btAll.Size = new System.Drawing.Size(82, 35);
            this.btAll.TabIndex = 107;
            this.btAll.Text = "Tất cả";
            this.btAll.Visible = false;
            this.btAll.Click += new System.EventHandler(this.btAll_Click);
            // 
            // Bangchamcong
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1187, 661);
            this.Controls.Add(this.paneltop);
            this.Controls.Add(this.btXoaBanCC);
            this.Controls.Add(this.cbxNamDS);
            this.Controls.Add(this.cbxThangDS);
            this.Controls.Add(this.labelDSBangcong);
            this.Controls.Add(this.dgvNhanvien);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Bangchamcong";
            this.Text = "Bangchamcong";
            this.Load += new System.EventHandler(this.Bangchamcong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanvien)).EndInit();
            this.paneltop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btXoaBanCC;
        private Guna.UI2.WinForms.Guna2HtmlLabel labelDSBangcong;
        public Guna.UI2.WinForms.Guna2DataGridView dgvNhanvien;
        public Guna.UI2.WinForms.Guna2ComboBox cbxNamDS;
        public Guna.UI2.WinForms.Guna2ComboBox cbxThangDS;
        private Guna.UI2.WinForms.Guna2Panel paneltop;
        private Guna.UI2.WinForms.Guna2TextBox txtTimkiem;
        private Guna.UI2.WinForms.Guna2HtmlLabel labelPhong;
        private Guna.UI2.WinForms.Guna2ComboBox cbxPhongban;
        private Guna.UI2.WinForms.Guna2Button btAll;
    }
}