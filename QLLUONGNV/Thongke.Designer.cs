namespace QLLUONGNV
{
    partial class Thongke
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.paneltop = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2HtmlLabel21 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.CbxThongke = new Guna.UI2.WinForms.Guna2ComboBox();
            this.charthongkeGT = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartThongkeNV = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.gvdPhongban = new Guna.UI2.WinForms.Guna2DataGridView();
            this.paneltop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.charthongkeGT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartThongkeNV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvdPhongban)).BeginInit();
            this.SuspendLayout();
            // 
            // paneltop
            // 
            this.paneltop.BackColor = System.Drawing.Color.White;
            this.paneltop.Controls.Add(this.guna2HtmlLabel21);
            this.paneltop.Controls.Add(this.CbxThongke);
            this.paneltop.CustomBorderColor = System.Drawing.Color.Silver;
            this.paneltop.Dock = System.Windows.Forms.DockStyle.Top;
            this.paneltop.Location = new System.Drawing.Point(0, 0);
            this.paneltop.Name = "paneltop";
            this.paneltop.ShadowDecoration.Parent = this.paneltop;
            this.paneltop.Size = new System.Drawing.Size(1187, 62);
            this.paneltop.TabIndex = 2;
            this.paneltop.Paint += new System.Windows.Forms.PaintEventHandler(this.paneltop_Paint);
            // 
            // guna2HtmlLabel21
            // 
            this.guna2HtmlLabel21.AutoSize = false;
            this.guna2HtmlLabel21.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel21.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel21.Location = new System.Drawing.Point(733, 22);
            this.guna2HtmlLabel21.Name = "guna2HtmlLabel21";
            this.guna2HtmlLabel21.Size = new System.Drawing.Size(60, 28);
            this.guna2HtmlLabel21.TabIndex = 94;
            this.guna2HtmlLabel21.Text = "Chọn ";
            // 
            // CbxThongke
            // 
            this.CbxThongke.AutoRoundedCorners = true;
            this.CbxThongke.BackColor = System.Drawing.Color.Transparent;
            this.CbxThongke.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.CbxThongke.BorderRadius = 17;
            this.CbxThongke.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CbxThongke.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbxThongke.FillColor = System.Drawing.Color.GhostWhite;
            this.CbxThongke.FocusedColor = System.Drawing.Color.Empty;
            this.CbxThongke.FocusedState.Parent = this.CbxThongke;
            this.CbxThongke.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.CbxThongke.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.CbxThongke.FormattingEnabled = true;
            this.CbxThongke.HoverState.Parent = this.CbxThongke;
            this.CbxThongke.ItemHeight = 30;
            this.CbxThongke.Items.AddRange(new object[] {
            "Độ tuổi",
            "Giới tính"});
            this.CbxThongke.ItemsAppearance.Parent = this.CbxThongke;
            this.CbxThongke.Location = new System.Drawing.Point(809, 14);
            this.CbxThongke.Name = "CbxThongke";
            this.CbxThongke.ShadowDecoration.Parent = this.CbxThongke;
            this.CbxThongke.Size = new System.Drawing.Size(176, 36);
            this.CbxThongke.TabIndex = 93;
            this.CbxThongke.SelectionChangeCommitted += new System.EventHandler(this.CbxThongke_SelectionChangeCommitted);
            // 
            // charthongkeGT
            // 
            this.charthongkeGT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.charthongkeGT.BorderlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            chartArea1.Name = "ChartArea1";
            this.charthongkeGT.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.charthongkeGT.Legends.Add(legend1);
            this.charthongkeGT.Location = new System.Drawing.Point(591, 68);
            this.charthongkeGT.Name = "charthongkeGT";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.charthongkeGT.Series.Add(series1);
            this.charthongkeGT.Size = new System.Drawing.Size(596, 340);
            this.charthongkeGT.TabIndex = 103;
            this.charthongkeGT.Text = "chart1";
            // 
            // chartThongkeNV
            // 
            this.chartThongkeNV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            chartArea2.Name = "ChartArea1";
            this.chartThongkeNV.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartThongkeNV.Legends.Add(legend2);
            this.chartThongkeNV.Location = new System.Drawing.Point(-1, 68);
            this.chartThongkeNV.Name = "chartThongkeNV";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartThongkeNV.Series.Add(series2);
            this.chartThongkeNV.Size = new System.Drawing.Size(586, 340);
            this.chartThongkeNV.TabIndex = 102;
            this.chartThongkeNV.Text = "chart1";
            // 
            // gvdPhongban
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.gvdPhongban.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gvdPhongban.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvdPhongban.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.gvdPhongban.BackgroundColor = System.Drawing.Color.White;
            this.gvdPhongban.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gvdPhongban.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.gvdPhongban.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvdPhongban.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gvdPhongban.ColumnHeadersHeight = 27;
            this.gvdPhongban.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvdPhongban.DefaultCellStyle = dataGridViewCellStyle3;
            this.gvdPhongban.EnableHeadersVisualStyles = false;
            this.gvdPhongban.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.gvdPhongban.Location = new System.Drawing.Point(0, 414);
            this.gvdPhongban.Name = "gvdPhongban";
            this.gvdPhongban.RowHeadersVisible = false;
            this.gvdPhongban.RowHeadersWidth = 51;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            this.gvdPhongban.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.gvdPhongban.RowTemplate.Height = 24;
            this.gvdPhongban.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvdPhongban.Size = new System.Drawing.Size(1188, 315);
            this.gvdPhongban.TabIndex = 95;
            this.gvdPhongban.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            this.gvdPhongban.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.gvdPhongban.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.gvdPhongban.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.gvdPhongban.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.gvdPhongban.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.gvdPhongban.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.gvdPhongban.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.gvdPhongban.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.gvdPhongban.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.gvdPhongban.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.gvdPhongban.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.gvdPhongban.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gvdPhongban.ThemeStyle.HeaderStyle.Height = 27;
            this.gvdPhongban.ThemeStyle.ReadOnly = false;
            this.gvdPhongban.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.gvdPhongban.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.gvdPhongban.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.gvdPhongban.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.gvdPhongban.ThemeStyle.RowsStyle.Height = 24;
            this.gvdPhongban.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.gvdPhongban.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.gvdPhongban.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gvdPhongban_CellFormatting);
            // 
            // Thongke
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1187, 729);
            this.Controls.Add(this.gvdPhongban);
            this.Controls.Add(this.charthongkeGT);
            this.Controls.Add(this.chartThongkeNV);
            this.Controls.Add(this.paneltop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Thongke";
            this.Text = "Thongke";
            this.Load += new System.EventHandler(this.Thongke_Load);
            this.paneltop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.charthongkeGT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartThongkeNV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvdPhongban)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel paneltop;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel21;
        private Guna.UI2.WinForms.Guna2ComboBox CbxThongke;
        private System.Windows.Forms.DataVisualization.Charting.Chart charthongkeGT;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartThongkeNV;
        private Guna.UI2.WinForms.Guna2DataGridView gvdPhongban;
    }
}