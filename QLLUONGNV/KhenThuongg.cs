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
using CrystalDecisions.CrystalReports.Engine;
using Guna.UI2.WinForms;

namespace QLLUONGNV
{
    public partial class KhenThuongg : Form
    {
        SqlConnection MyCon = new SqlConnection(@"Data Source=TRONGDAT\SQLEXPRESS;Initial Catalog=QLNhanvienluong;Integrated Security=True");
        public KhenThuongg()
        {
            InitializeComponent();
            for (int i = 1; i <= 12; i++)
            {
                cbxThangKT.Items.Add(i);
            }

            int currentYearDS = DateTime.Now.Year;
            for (int j = currentYearDS - 10; j <= currentYearDS + 10; j++)
            {
                cbxNamKT.Items.Add(j);
            }
            cbxThangKT.SelectedIndex = DateTime.Now.Month - 1;
            cbxNamKT.SelectedItem = DateTime.Now.Year;
        }
        private void Load_Nhanvien()
        {
            string sqlphongban = "select  MaNV, TenNV  from NhanVien ";
            SqlDataAdapter adapter = new SqlDataAdapter(sqlphongban, MyCon);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            cbxMaNV.DataSource = dt;
            // Đặt thuộc tính DisplayMember là một chuỗi kết hợp của Mã nhân viên và Tên nhân viên
            cbxMaNV.DisplayMember = "MaNV"; // Chỉ cần hiển thị Mã nhân viên trong ComboBox
            cbxMaNV.ValueMember = "MaNV";

            // Tạo một cột mới trong DataTable để chứa thông tin kết hợp của Mã nhân viên và Tên nhân viên
            dt.Columns.Add("MaNV_TenNV", typeof(string));
            foreach (DataRow row in dt.Rows)
            {
                row["MaNV_TenNV"] = row["MaNV"] + " - " + row["TenNV"]; // Kết hợp Mã và Tên
            }

            // Đặt thuộc tính DisplayMember là cột mới chứa thông tin kết hợp của Mã và Tên
            cbxMaNV.DisplayMember = "MaNV_TenNV";
        }
        private void Load_Khenthuong()
        {
            string sqlphongban = "select  LoaiKhenThuong, MaKhenThuong  from KhenThuong ";
            SqlDataAdapter adapter = new SqlDataAdapter(sqlphongban, MyCon);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            cbxMaKhenThuong.DataSource = dt;
            cbxMaKhenThuong.DisplayMember = "LoaiKhenThuong";
            cbxMaKhenThuong.ValueMember = "MaKhenThuong";
        }
        private void LoadDLGridView()
        {
            //string sql = "select NhanVien.* from NhanVien inner join PhongBan on PhongBan.MaPhongBan  = NhanVien.MaPhongBan where NhanVien.MaPhongBan = '" + cbxPhongbann.SelectedValue.ToString() + "'";          
            string sql = "select KTNhanVien.MaKtNv, KTNhanVien.MaNV,KTNhanVien.MaKhenThuong,KTNhanVien.LyDo,KTNhanVien.NgayKhenThuong,KTNhanVien.TienThuong  from KTNhanVien inner join NhanVien on NhanVien.MaNV = KTNhanVien.MaNV inner join KhenThuong on KhenThuong.MaKhenThuong = KTNhanVien.MaKhenThuong  where NhanVien.Xoa = 0 ";
            SqlDataAdapter ad = new SqlDataAdapter(sql, MyCon);
            DataTable dt1 = new DataTable();
            ad.Fill(dt1);
            dgvKhenThuong.DataSource = dt1;
            dgvKhenThuong.AllowUserToAddRows = false;
            dgvKhenThuong.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvKhenThuong.DataSource = dt1;
            dgvKhenThuong.AllowUserToAddRows = false;
            dgvKhenThuong.RowTemplate.Height = 30;
            dgvKhenThuong.ColumnHeadersDefaultCellStyle.BackColor = Color.MediumSlateBlue; // Đổi màu thành màu đỏ
            dgvKhenThuong.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvKhenThuong.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
            dgvKhenThuong.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvKhenThuong.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvKhenThuong.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvKhenThuong.Columns[0].HeaderText = "Mã khen thưởng";
            dgvKhenThuong.Columns[1].HeaderText = "Mã nhân viên";
            dgvKhenThuong.Columns[2].HeaderText = "Loại khen thưởng";
            dgvKhenThuong.Columns[3].HeaderText = "Lý do khen thưởng";
            dgvKhenThuong.Columns[4].HeaderText = "Ngày khen thưởng";
            dgvKhenThuong.Columns[5].HeaderText = "Tiền thưởng";
        }
        private void btThongke_Click(object sender, EventArgs e)
        {

        }

        private void KhenThuongg_Load(object sender, EventArgs e)
        {
            dtpNgaykhen.Value = DateTime.Now;
            Load_Nhanvien();
            Load_Khenthuong();
            LoadDLGridView();
            btLuuKT.Enabled = false;
        }
        bool them = false;
        private void btThem_Click(object sender, EventArgs e)
        {
            them = true;
            txtTienthuong.ResetText();
            RTXLydo.ResetText();
            dtpNgaykhen.Text = null;
            txtMakhen.ResetText();
            btLuuKT.Enabled = true;

        }

        private void dgvKhenThuong_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int dong;
            dong = e.RowIndex;
            txtMakhen.Text = dgvKhenThuong.Rows[dong].Cells[0].Value.ToString();
            cbxMaNV.SelectedValue = dgvKhenThuong.Rows[dong].Cells[1].Value.ToString();
            cbxMaKhenThuong.SelectedValue = dgvKhenThuong.Rows[dong].Cells[2].Value.ToString();
            RTXLydo.Text = dgvKhenThuong.Rows[dong].Cells[3].Value.ToString();
            dtpNgaykhen.Text = dgvKhenThuong.Rows[dong].Cells[4].Value.ToString();
            txtTienthuong.Text = dgvKhenThuong.Rows[dong].Cells[5].Value.ToString();
        }      
        private void LoadDieukien()
        {
            string sql = @"SELECT KTNhanVien.MaKtNv,KTNhanVien.MaNV,KTNhanVien.MaKhenThuong,KTNhanVien.LyDo,KTNhanVien.NgayKhenThuong,KTNhanVien.TienThuong
                FROM KTNhanVien 
                INNER JOIN NhanVien ON NhanVien.MaNV = KTNhanVien.MaNV 
                WHERE NhanVien.Xoa = 0";

            // Thêm điều kiện tháng và năm sinh vào truy vấn
            if (!string.IsNullOrEmpty(cbxThangKT.SelectedItem.ToString()) && !string.IsNullOrEmpty(cbxNamKT.SelectedItem.ToString()))
            {
                sql += " AND MONTH(KTNhanVien.NgayKhenThuong) = " + cbxThangKT.SelectedItem.ToString() +
                       " AND YEAR(KTNhanVien.NgayKhenThuong) = " + cbxNamKT.SelectedItem.ToString();
            }
            SqlCommand cmd = new SqlCommand(sql, MyCon);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            MyCon.Open();
            adapter.Fill(dt);
            MyCon.Close();
            //load_Songaycong();
            dgvKhenThuong.DataSource = dt;
            dgvKhenThuong.AllowUserToAddRows = false;
            dgvKhenThuong.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvKhenThuong.DataSource = dt;
            dgvKhenThuong.AllowUserToAddRows = false;
            dgvKhenThuong.RowTemplate.Height = 30;
            dgvKhenThuong.ColumnHeadersDefaultCellStyle.BackColor = Color.MediumSlateBlue; // Đổi màu thành màu đỏ
            dgvKhenThuong.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvKhenThuong.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
            dgvKhenThuong.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvKhenThuong.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvKhenThuong.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvKhenThuong.Columns[0].HeaderText = "Mã khen thưởng";
            dgvKhenThuong.Columns[1].HeaderText = "Mã nhân viên";
            dgvKhenThuong.Columns[2].HeaderText = "Mã khen thưởng";
            dgvKhenThuong.Columns[3].HeaderText = "Lý do khen thưởng";
            dgvKhenThuong.Columns[4].HeaderText = "Ngày khen thưởng";
            dgvKhenThuong.Columns[5].HeaderText = "Tiền thưởng";
        }

        private void btLuuKT_Click(object sender, EventArgs e)
        {

            try
            {
                if (them == true)
                {                 
                    MyCon.Open();               
                    // Kiểm tra xem ngày khuyến thưởng đã tồn tại trong cơ sở dữ liệu hay không
                    string sqlCheck = "SELECT COUNT(*) FROM KTNhanVien WHERE NgayKhenThuong = @NgayKhenThuong AND MaNV =@txtManv";
                    SqlCommand cmdCheck = new SqlCommand(sqlCheck, MyCon);
                    cmdCheck.Parameters.AddWithValue("@NgayKhenThuong", dtpNgaykhen.Value.Date);
                    cmdCheck.Parameters.AddWithValue("@txtManv", cbxMaNV.SelectedValue.ToString());
                    int existingRecords = (int)cmdCheck.ExecuteScalar();
                    if (existingRecords > 0)
                    {
                        MessageBox.Show("Nhân viên này đã khen thưởng trong tháng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        // Thực hiện lưu dữ liệu nếu ngày không tồn tại trong cơ sở dữ liệu
                        string sql1 = "INSERT INTO KTNhanVien (MaNV, MaKhenThuong, LyDo, NgayKhenThuong, TienThuong) VALUES (@MaNV, @MaKhenThuong, @LyDo, @NgayKhenThuong, @TienThuong)";
                        SqlCommand cmd1 = new SqlCommand(sql1, MyCon);
                        cmd1.Parameters.AddWithValue("@MaNV", cbxMaNV.SelectedValue.ToString());
                        cmd1.Parameters.AddWithValue("@MaKhenThuong", cbxMaKhenThuong.SelectedValue.ToString());
                        cmd1.Parameters.AddWithValue("@LyDo", RTXLydo.Text);
                        cmd1.Parameters.AddWithValue("@NgayKhenThuong", dtpNgaykhen.Value.Date);
                        cmd1.Parameters.AddWithValue("@TienThuong", txtTienthuong.Text);
                        cmd1.ExecuteNonQuery();
                        LoadDLGridView();
                        MessageBox.Show("Đã lưu thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    // Reset các control và load lại dữ liệu vào GridView
                    txtTienthuong.ResetText();
                    RTXLydo.ResetText();
                    dtpNgaykhen.Value = DateTime.Today;
                    txtMakhen.ResetText();
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
                btLuuKT.Enabled = false;
             
            }
        }

        private void btSuaKT_Click(object sender, EventArgs e)
        {
            int currentIndex = dgvKhenThuong.CurrentCell.RowIndex;
            string IDKhenthuong = Convert.ToString(dgvKhenThuong.Rows[currentIndex].Cells[0].Value.ToString());
            if (txtMakhen.Text == IDKhenthuong)
            {
                MyCon.Open();
                string sql2 = "Update KTNhanVien set MaNV = N'" + cbxMaNV.SelectedValue.ToString() + "', MaKhenThuong = N'" + cbxMaKhenThuong.SelectedValue.ToString() + "', LyDo = N'" + RTXLydo.Text + "', NgayKhenThuong = N'" + dtpNgaykhen.Text + "', TienThuong = N'" + txtTienthuong.Text + "' WHERE MaKtNv = '" + txtMakhen.Text + "'";
                SqlCommand Cmd2 = new SqlCommand(sql2, MyCon);
                Cmd2.ExecuteNonQuery();
                LoadDLGridView();
                MessageBox.Show("Cập nhật thành công !", "Thông Báo");               
            }
            else { MessageBox.Show("Không được thay đổi mã khen thưởng!", "Thông Báo"); }
            MyCon.Close();
        }

        private void btXoaKT_Click(object sender, EventArgs e)
        {
            if (MyCon.State == ConnectionState.Closed)
                MyCon.Open();

            if (dgvKhenThuong.SelectedCells.Count > 0)
            {
                DialogResult Traloi;
                Traloi = MessageBox.Show("Bạn có chắc chắn xóa không?",
               "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Traloi == DialogResult.Yes)
                {
                    int currentIndex = dgvKhenThuong.CurrentCell.RowIndex;
                    string MaKhenthuong = Convert.ToString(dgvKhenThuong.Rows[currentIndex].Cells[0].Value.ToString());
                    string sql3 = "delete from KTNhanVien where MaKtNv ='" + MaKhenthuong + "'";
                    SqlCommand cmd3 = new SqlCommand(sql3, MyCon);
                    cmd3.ExecuteNonQuery();
                    LoadDLGridView();
                }
            }
            else MessageBox.Show("Cần chọn dòng cần xóa");
            MyCon.Close();
        }

        private void dgvKhenThuong_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvKhenThuong.Columns[e.ColumnIndex].Name == "TienThuong" && e.RowIndex >= 0)
            {
                // Kiểm tra giá trị của ô
                if (e.Value != null)
                {
                    double tienthuong;
                    // Chuyển giá trị của ô thành kiểu double
                    if (double.TryParse(e.Value.ToString(), out tienthuong))
                    {
                        // Làm tròn đến 0 chữ số thập phân và định dạng lại giá trị của ô theo đơn vị tiền tệ Việt Nam
                        e.Value = tienthuong.ToString("#,##0") + " VNĐ";
                        e.FormattingApplied = true;
                    }
                }
            }
        }

        private void cbxThangKT_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadDieukien();
        }

        private void cbxNamKT_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadDieukien();
        }

        private void btInKhen_Click(object sender, EventArgs e)
        {
            LoadInKhenThuong();
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
        private void LoadInKhenThuong()
        {
            // Lấy dữ liệu từ DataGridView gvdNhanvien
            DataTable dt = GetDataTableFromDataGridView(dgvKhenThuong);

            // Tạo báo cáo và thiết lập dữ liệu nguồn
            ReportKhenThuong rpt = new ReportKhenThuong();
            rpt.SetDataSource(dt);
            string thangKhen = cbxThangKT.Text;
            string namkhen = cbxNamKT.Text;
                // Truyền giá trị vào TextObject trong báo cáo
            TextObject txtThangKhen = (TextObject)rpt.ReportDefinition.Sections["Section1"].ReportObjects["txtThangKhen"];
            txtThangKhen.Text = thangKhen;
            TextObject txtNamKhen = (TextObject)rpt.ReportDefinition.Sections["Section1"].ReportObjects["txtNamKhen"];
            txtNamKhen.Text = namkhen;          
            // Hiển thị báo cáo trong Form2
            InKhenThuong khenthuong = new InKhenThuong();
            khenthuong.ShowReport(rpt);
            khenthuong.ShowDialog();
        }
    }
}
