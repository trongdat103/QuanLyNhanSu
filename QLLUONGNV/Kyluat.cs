using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLLUONGNV
{
    public partial class Kyluat : Form
    {
        SqlConnection MyCon = new SqlConnection(@"Data Source=TRONGDAT\SQLEXPRESS;Initial Catalog=QLNhanvienluong;Integrated Security=True");
        public Kyluat()
        {
            InitializeComponent();
            for (int i = 1; i <= 12; i++)
            {
                cbxThangKl.Items.Add(i);
            }

            int currentYearDS = DateTime.Now.Year;
            for (int j = currentYearDS - 10; j <= currentYearDS + 10; j++)
            {
                cbxNamKl.Items.Add(j);
            }
            cbxThangKl.SelectedIndex = DateTime.Now.Month - 1;
            cbxNamKl.SelectedItem = DateTime.Now.Year;
        }
        private void Load_Nhanvien()
        {
            string sqlphongban = "select  MaNV, TenNV  from NhanVien ";
            SqlDataAdapter adapter = new SqlDataAdapter(sqlphongban, MyCon);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            cbxManv.DataSource = dt;
            // Đặt thuộc tính DisplayMember là một chuỗi kết hợp của Mã nhân viên và Tên nhân viên
            cbxManv.DisplayMember = "MaNV"; // Chỉ cần hiển thị Mã nhân viên trong ComboBox
            cbxManv.ValueMember = "MaNV";

            // Tạo một cột mới trong DataTable để chứa thông tin kết hợp của Mã nhân viên và Tên nhân viên
            dt.Columns.Add("MaNV_TenNV", typeof(string));
            foreach (DataRow row in dt.Rows)
            {
                row["MaNV_TenNV"] = row["MaNV"] + " - " + row["TenNV"]; // Kết hợp Mã và Tên
            }

            // Đặt thuộc tính DisplayMember là cột mới chứa thông tin kết hợp của Mã và Tên
            cbxManv.DisplayMember = "MaNV_TenNV";
        }
        private void Load_Kyluat()
        {
            string sqlphongban = "select  MaKyLuat, LoaiKyLuat  from KyLuat ";
            SqlDataAdapter adapter = new SqlDataAdapter(sqlphongban, MyCon);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            cbxMaKyluat.DataSource = dt;
            cbxMaKyluat.DisplayMember = "LoaiKyLuat";
            cbxMaKyluat.ValueMember = "MaKyLuat";
        }
        private void LoadDLGridView()
        {
            //string sql = "select NhanVien.* from NhanVien inner join PhongBan on PhongBan.MaPhongBan  = NhanVien.MaPhongBan where NhanVien.MaPhongBan = '" + cbxPhongbann.SelectedValue.ToString() + "'";          
            string sql = "select KLNhanVien.MaKlNv, KLNhanVien.MaNV,KLNhanVien.MaKyLuat,KLNhanVien.LyDo,KLNhanVien.NgayKyLuat,KLNhanVien.SoTienPhat  from KLNhanVien inner join NhanVien on NhanVien.MaNV = KLNhanVien.MaNV inner join KyLuat on KyLuat.MaKyLuat = KLNhanVien.MaKyLuat  where NhanVien.Xoa = 0 ";
            SqlDataAdapter ad = new SqlDataAdapter(sql, MyCon);
            DataTable dt1 = new DataTable();
            ad.Fill(dt1);
            dgvKyluat.DataSource = dt1;
            dgvKyluat.AllowUserToAddRows = false;
            dgvKyluat.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvKyluat.DataSource = dt1;
            dgvKyluat.AllowUserToAddRows = false;
            dgvKyluat.RowTemplate.Height = 30;
            dgvKyluat.ColumnHeadersDefaultCellStyle.BackColor = Color.MediumSlateBlue; // Đổi màu thành màu đỏ
            dgvKyluat.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvKyluat.DefaultCellStyle.ForeColor = Color.Black;
            dgvKyluat.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
            dgvKyluat.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvKyluat.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvKyluat.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvKyluat.Columns[0].HeaderText = "Mã kỷ luật";
            dgvKyluat.Columns[1].HeaderText = "Mã nhân viên";
            dgvKyluat.Columns[2].HeaderText = "Loại kỷ luật";
            dgvKyluat.Columns[3].HeaderText = "Lý do kỷ luật";
            dgvKyluat.Columns[4].HeaderText = "Ngày kỷ luật";
            dgvKyluat.Columns[5].HeaderText = "Tiền Phạt";
        }
        private void Kyluat_Load(object sender, EventArgs e)
        {
            LoadDLGridView();
            Load_Nhanvien();
            Load_Kyluat();
            dtpNgaykyluat.Value = DateTime.Now;         
            btLuuKl.Enabled = false;
        }
        bool them = false;
        private void btThemKl_Click(object sender, EventArgs e)
        {
            them = true;
            txtTienphat.ResetText();
            RTXLydo.ResetText();
            dtpNgaykyluat.Text = null;
            txtMaKyluat.ResetText();
            btLuuKl.Enabled = true;
        }

        private void dgvKyluat_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int dong;
            dong = e.RowIndex;
            txtMaKyluat.Text = dgvKyluat.Rows[dong].Cells[0].Value.ToString();
            cbxManv.SelectedValue = dgvKyluat.Rows[dong].Cells[1].Value.ToString();
            cbxMaKyluat.SelectedValue = dgvKyluat.Rows[dong].Cells[2].Value.ToString();
            RTXLydo.Text = dgvKyluat.Rows[dong].Cells[3].Value.ToString();
            dtpNgaykyluat.Text = dgvKyluat.Rows[dong].Cells[4].Value.ToString();
            txtTienphat.Text = dgvKyluat.Rows[dong].Cells[5].Value.ToString();
        }

        private void btLocKyL_Click()
        {
            string sql = @"SELECT KLNhanVien.MaKlNv,KLNhanVien.MaNV,KLNhanVien.MaKyLuat,KLNhanVien.LyDo,KLNhanVien.NgayKyLuat,KLNhanVien.SoTienPhat
                FROM KLNhanVien 
                INNER JOIN NhanVien ON NhanVien.MaNV = KLNhanVien.MaNV 
                WHERE NhanVien.Xoa = 0";

            // Thêm điều kiện tháng và năm sinh vào truy vấn
            if (!string.IsNullOrEmpty(cbxThangKl.SelectedItem.ToString()) && !string.IsNullOrEmpty(cbxNamKl.SelectedItem.ToString()))
            {
                sql += " AND MONTH(KLNhanVien.NgayKyLuat) = " + cbxThangKl.SelectedItem.ToString() +
                       " AND YEAR(KLNhanVien.NgayKyLuat) = " + cbxNamKl.SelectedItem.ToString();
            }
            SqlCommand cmd = new SqlCommand(sql, MyCon);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            MyCon.Open();
            adapter.Fill(dt);
            MyCon.Close();
            //load_Songaycong();
            dgvKyluat.DataSource = dt;
            dgvKyluat.AllowUserToAddRows = false;
            dgvKyluat.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvKyluat.DataSource = dt;
            dgvKyluat.AllowUserToAddRows = false;
            dgvKyluat.RowTemplate.Height = 30;
            dgvKyluat.ColumnHeadersDefaultCellStyle.BackColor = Color.MediumSlateBlue; // Đổi màu thành màu đỏ
            dgvKyluat.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvKyluat.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
            dgvKyluat.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvKyluat.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvKyluat.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvKyluat.Columns[0].HeaderText = "Mã kỷ luật";
            dgvKyluat.Columns[1].HeaderText = "Mã nhân viên";
            dgvKyluat.Columns[2].HeaderText = "Mã kỷ luật";
            dgvKyluat.Columns[3].HeaderText = "Lý do kỷ luật";
            dgvKyluat.Columns[4].HeaderText = "Ngày kỷ luật";
            dgvKyluat.Columns[5].HeaderText = "Tiền Phạt";
        }

        private void btLuuKl_Click(object sender, EventArgs e)
        {
            try
            {
                if (them == true)
                {
                    MyCon.Open();

                    // Kiểm tra xem ngày khuyến thưởng đã tồn tại trong cơ sở dữ liệu hay không
                    string sqlCheck = "SELECT COUNT(*) FROM KLNhanVien WHERE NgayKyLuat = @NgayKyLuat AND MaNV =@txtManv";
                    SqlCommand cmdCheck = new SqlCommand(sqlCheck, MyCon);
                    cmdCheck.Parameters.AddWithValue("@NgayKyLuat", dtpNgaykyluat.Value.Date);
                    cmdCheck.Parameters.AddWithValue("@txtManv", cbxManv.SelectedValue.ToString());
                    int existingRecords = (int)cmdCheck.ExecuteScalar();

                    if (existingRecords > 0)
                    {
                        MessageBox.Show("Nhân viên này đã kỷ luật trong tháng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        // Thực hiện lưu dữ liệu nếu ngày không tồn tại trong cơ sở dữ liệu
                        string sql1 = "INSERT INTO KLNhanVien (MaNV, MaKyLuat, LyDo, NgayKyLuat, SoTienPhat) VALUES (@MaNV, @MaKyLuat, @LyDo, @NgayKyLuat, @SoTienPhat)";
                        SqlCommand cmd1 = new SqlCommand(sql1, MyCon);
                        cmd1.Parameters.AddWithValue("@MaNV", cbxManv.SelectedValue.ToString());
                        cmd1.Parameters.AddWithValue("@MaKyLuat", cbxMaKyluat.SelectedValue.ToString());
                        cmd1.Parameters.AddWithValue("@LyDo", RTXLydo.Text);
                        cmd1.Parameters.AddWithValue("@NgayKyLuat", dtpNgaykyluat.Value.Date);
                        cmd1.Parameters.AddWithValue("@SoTienPhat", txtTienphat.Text);
                        cmd1.ExecuteNonQuery();
                        LoadDLGridView();
                        MessageBox.Show("Đã lưu thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    // Reset các control và load lại dữ liệu vào GridView
                    txtTienphat.ResetText();
                    RTXLydo.ResetText();
                    dtpNgaykyluat.Value = DateTime.Today;
                    txtMaKyluat.ResetText();
                    LoadDLGridView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                MyCon.Close();
                btLuuKl.Enabled = false;
            }
        }

        private void btSuaKl_Click(object sender, EventArgs e)
        {
            int currentIndex = dgvKyluat.CurrentCell.RowIndex;
            string IDKyluat = Convert.ToString(dgvKyluat.Rows[currentIndex].Cells[0].Value.ToString());
            if (txtMaKyluat.Text == IDKyluat)
            {
                MyCon.Open();
                string sql2 = "Update KLNhanVien set MaNV = N'" + cbxManv.SelectedValue.ToString() + "', MaKyLuat = N'" + cbxMaKyluat.SelectedValue.ToString() + "', LyDo = N'" + RTXLydo.Text + "', NgayKyLuat = N'" + dtpNgaykyluat.Text + "', SoTienPhat = N'" + txtTienphat.Text + "' WHERE MaKlNv = '" + txtMaKyluat.Text + "'";
                SqlCommand Cmd2 = new SqlCommand(sql2, MyCon);
                Cmd2.ExecuteNonQuery();
                LoadDLGridView();
                MessageBox.Show("Cập nhật thành công !", "Thông Báo");
            }
            else { MessageBox.Show("Không được thay đổi mã kỷ luật!", "Thông Báo"); }
            MyCon.Close();
        }

        private void btXoaKl_Click(object sender, EventArgs e)
        {
            if (MyCon.State == ConnectionState.Closed)
                MyCon.Open();

            if (dgvKyluat.SelectedCells.Count > 0)
            {
                DialogResult Traloi;
                Traloi = MessageBox.Show("Bạn có chắc chắn xóa không?",
               "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Traloi == DialogResult.Yes)
                {
                    int currentIndex = dgvKyluat.CurrentCell.RowIndex;
                    string MaKyLuat = Convert.ToString(dgvKyluat.Rows[currentIndex].Cells[0].Value.ToString());
                    string sql3 = "delete from KLNhanVien where MaKlNv ='" + MaKyLuat + "'";
                    SqlCommand cmd3 = new SqlCommand(sql3, MyCon);
                    cmd3.ExecuteNonQuery();
                    LoadDLGridView();
                }
            }
            else MessageBox.Show("Cần chọn dòng cần xóa");
            MyCon.Close();
        }

        private void dgvKyluat_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvKyluat.Columns[e.ColumnIndex].Name == "SoTienPhat" && e.RowIndex >= 0)
            {
                // Kiểm tra giá trị của ô
                if (e.Value != null)
                {
                    double tienphat;
                    // Chuyển giá trị của ô thành kiểu double
                    if (double.TryParse(e.Value.ToString(), out tienphat))
                    {
                        // Làm tròn đến 0 chữ số thập phân và định dạng lại giá trị của ô theo đơn vị tiền tệ Việt Nam
                        e.Value = tienphat.ToString("#,##0") + " VNĐ";
                        e.FormattingApplied = true;
                    }
                }
            }
        }

        private void cbxThangKl_SelectionChangeCommitted(object sender, EventArgs e)
        {
            btLocKyL_Click();
        }

        private void cbxNamKl_SelectionChangeCommitted(object sender, EventArgs e)
        {
            btLocKyL_Click();
        }

        private void btInKhen_Click(object sender, EventArgs e)
        {

        }

        private void btInKyluat_Click(object sender, EventArgs e)
        {
            LoadInKyluat();
        }
        private DataTable GetDataTableFromDataGridView(DataGridView dgv)
        {
            var dt = new DataTable();

            // Thêm các cột từ DataGridView vào DataTable
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                dt.Columns.Add(column.Name, column.ValueType);
            }

            // Thêm các hàng từ DataGridView vào DataTable
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (!row.IsNewRow)
                {
                    DataRow dataRow = dt.NewRow();
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        dataRow[cell.ColumnIndex] = cell.Value ?? DBNull.Value;
                    }
                    dt.Rows.Add(dataRow);
                }
            }

            return dt;
        }
        private void LoadInKyluat()
        {
            // Lấy dữ liệu từ DataGridView gvdNhanvien
            DataTable dt = GetDataTableFromDataGridView(dgvKyluat);

            // Tạo báo cáo và thiết lập dữ liệu nguồn
            ReportKyLuat rpt = new ReportKyLuat();
            rpt.SetDataSource(dt);
            string thangKyluat = cbxThangKl.Text;
            string namKyluat = cbxNamKl.Text;
            // Truyền giá trị vào TextObject trong báo cáo
            TextObject txtthangKyluat = (TextObject)rpt.ReportDefinition.Sections["Section1"].ReportObjects["txtThangKyLuat"];
            txtthangKyluat.Text = thangKyluat;
            TextObject txtNamKyluat = (TextObject)rpt.ReportDefinition.Sections["Section1"].ReportObjects["txtNamKyluat"];
            txtNamKyluat.Text = namKyluat;
            // Hiển thị báo cáo trong Form2
            InKyLuat kyluat = new InKyLuat();
            kyluat.ShowReport(rpt);
            kyluat.ShowDialog();
        }
    }
}
