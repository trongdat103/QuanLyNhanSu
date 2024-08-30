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
    public partial class Bangchamcong : Form
    {
        SqlConnection MyCon = new SqlConnection(@"Data Source=TRONGDAT\SQLEXPRESS;Initial Catalog=QLNhanvienluong;Integrated Security=True");
        public Bangchamcong()
        {
            InitializeComponent();
            for (int j = 1; j <= 12; j++)
            {
                cbxThangDS.Items.Add(j);
            }

            int currentYearDS = DateTime.Now.Year;
            for (int j = currentYearDS - 10; j <= currentYearDS + 10; j++)
            {
                cbxNamDS.Items.Add(j);
            }
            cbxThangDS.SelectedIndex = DateTime.Now.Month - 1;
            cbxNamDS.SelectedItem = DateTime.Now.Year;
        }

        private void Bangchamcong_Load(object sender, EventArgs e)
        {
            Load_Phongban();
            LoadDLGridViewAll();
        }
        private void Load_Phongban()
        {
            string sqlphongban = "select  MaPhongBan, TenPhongBan  from PhongBan ";
            SqlDataAdapter adapter = new SqlDataAdapter(sqlphongban, MyCon);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            cbxPhongban.DataSource = dt;
            cbxPhongban.DisplayMember = "TenPhongBan";
            cbxPhongban.ValueMember = "MaPhongBan";
        }
        private void LoadDLGridViewAll()
        {
            string sql = "select Ngaylamviec.MaLamViec,Ngaylamviec.MaNV,NhanVien.TenNV, Ngaylamviec.SoNgayLam, Ngaylamviec.ThangLam, Ngaylamviec.NamLam from Ngaylamviec inner join NhanVien on NhanVien.MaNV = Ngaylamviec.MaNV where NhanVien.Xoa = 0";
            SqlDataAdapter ad = new SqlDataAdapter(sql, MyCon);
            DataTable dt1 = new DataTable();
            ad.Fill(dt1);
            dgvNhanvien.DataSource = dt1;
            dgvNhanvien.AllowUserToAddRows = false;
            dgvNhanvien.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvNhanvien.DataSource = dt1;
            dgvNhanvien.AllowUserToAddRows = false;
            dgvNhanvien.RowTemplate.Height = 30;
            dgvNhanvien.ColumnHeadersDefaultCellStyle.BackColor = Color.MediumSlateBlue; // Đổi màu thành màu đỏ
            dgvNhanvien.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvNhanvien.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
            dgvNhanvien.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvNhanvien.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvNhanvien.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvNhanvien.Columns[0].HeaderText = "Mã làm việc";
            dgvNhanvien.Columns[1].HeaderText = "Mã Nhân Viên";
            dgvNhanvien.Columns[2].HeaderText = "Họ Và Tên";
            dgvNhanvien.Columns[3].HeaderText = "Số ngày làm";
            dgvNhanvien.Columns[4].HeaderText = "Tháng làm việc";
            dgvNhanvien.Columns[5].HeaderText = "Năm làm việc";

        }
        private void LoadDLGridView()
        {
            //string sql = "select NhanVien.* from NhanVien inner join PhongBan on PhongBan.MaPhongBan  = NhanVien.MaPhongBan where NhanVien.MaPhongBan = '" + cbxPhongbann.SelectedValue.ToString() + "'";          
            string sql = @"SELECT Ngaylamviec.MaLamViec, Ngaylamviec.MaNV, NhanVien.TenNV, Ngaylamviec.SoNgayLam, Ngaylamviec.ThangLam, Ngaylamviec.NamLam 
               FROM Ngaylamviec 
               INNER JOIN NhanVien ON NhanVien.MaNV = Ngaylamviec.MaNV 
               WHERE NhanVien.Xoa = 0";

            // Thêm điều kiện lọc theo phòng ban nếu có
            if (!string.IsNullOrEmpty(cbxPhongban.SelectedValue.ToString()))
            {
                sql += " AND NhanVien.MaPhongBan = '" + cbxPhongban.SelectedValue.ToString() + "'";
            }

            // Thêm điều kiện tháng và năm nếu được chọn
            if (!string.IsNullOrEmpty(cbxThangDS.SelectedItem.ToString()) && !string.IsNullOrEmpty(cbxNamDS.SelectedItem.ToString()))
            {
                sql += " AND Ngaylamviec.ThangLam = " + cbxThangDS.SelectedItem.ToString() +
                       " AND Ngaylamviec.NamLam = " + cbxNamDS.SelectedItem.ToString();
            }
            SqlDataAdapter ad = new SqlDataAdapter(sql, MyCon);
            DataTable dt1 = new DataTable();
            ad.Fill(dt1);
            dgvNhanvien.DataSource = dt1;
            dgvNhanvien.AllowUserToAddRows = false;
            dgvNhanvien.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvNhanvien.DataSource = dt1;
            dgvNhanvien.AllowUserToAddRows = false;
            dgvNhanvien.RowTemplate.Height = 30;
            dgvNhanvien.ColumnHeadersDefaultCellStyle.BackColor = Color.MediumSlateBlue; // Đổi màu thành màu đỏ
            dgvNhanvien.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvNhanvien.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
            dgvNhanvien.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvNhanvien.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvNhanvien.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvNhanvien.Columns[0].HeaderText = "Mã làm việc";
            dgvNhanvien.Columns[1].HeaderText = "Mã Nhân Viên";
            dgvNhanvien.Columns[2].HeaderText = "Họ Và Tên";
            dgvNhanvien.Columns[3].HeaderText = "Số ngày làm";
            dgvNhanvien.Columns[4].HeaderText = "Tháng làm việc";
            dgvNhanvien.Columns[5].HeaderText = "Năm làm việc";

        }

        private void cbxThangDS_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadDLGridView();
            btAll.Visible = true;
        }

        private void btTim_Click(object sender, EventArgs e)
        {
            LoadTimkiem();
            btAll.Visible = true;
        }
        private void LoadTimkiem()
        {

            //string sqll = "select * from NhanVien WHERE TenNV like N'%" + txtTimkiem.Text + "%' or MaNV like N'%" + txtTimkiem.Text +"%' or DiaChi like N'%" + txtTimkiem.Text +"%'";
            string sql = "select Ngaylamviec.MaLamViec,Ngaylamviec.MaNV,NhanVien.TenNV, Ngaylamviec.SoNgayLam, Ngaylamviec.ThangLam, Ngaylamviec.NamLam from Ngaylamviec inner join NhanVien on NhanVien.MaNV = Ngaylamviec.MaNV WHERE (NhanVien.TenNV like N'%" + txtTimkiem.Text + "%' or Ngaylamviec.MaNV like N'%" + txtTimkiem.Text + "%') and Xoa = 0";
            SqlDataAdapter ad = new SqlDataAdapter(sql, MyCon);
            DataTable dt1 = new DataTable();
            ad.Fill(dt1);
            dgvNhanvien.DataSource = dt1;
            dgvNhanvien.AllowUserToAddRows = false;
            dgvNhanvien.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvNhanvien.DataSource = dt1;
            dgvNhanvien.AllowUserToAddRows = false;
            dgvNhanvien.RowTemplate.Height = 30;
            dgvNhanvien.ColumnHeadersDefaultCellStyle.BackColor = Color.MediumSlateBlue; // Đổi màu thành màu đỏ
            dgvNhanvien.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvNhanvien.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
            dgvNhanvien.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvNhanvien.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvNhanvien.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvNhanvien.Columns[0].HeaderText = "Mã làm việc";
            dgvNhanvien.Columns[1].HeaderText = "Mã Nhân Viên";
            dgvNhanvien.Columns[2].HeaderText = "Họ Và Tên";
            dgvNhanvien.Columns[3].HeaderText = "Số ngày làm";
            dgvNhanvien.Columns[4].HeaderText = "Tháng làm việc";
            dgvNhanvien.Columns[5].HeaderText = "Năm làm việc";


        }

        private void btAll_Click(object sender, EventArgs e)
        {
            LoadDLGridViewAll();
            btAll.Visible = false;
        }

        private void cbxNamDS_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadDLGridView();
            btAll.Visible = true;
        }

        private void cbxPhongban_SelectionChangeCommitted(object sender, EventArgs e)
        {
            btAll.Visible = true;
            LoadDLGridView();
        }

        private void btXoaBanCC_Click(object sender, EventArgs e)
        {
            if (MyCon.State == ConnectionState.Closed)
                MyCon.Open();

            if (dgvNhanvien.SelectedCells.Count > 0)
            {
                DialogResult Traloi;
                Traloi = MessageBox.Show("Bạn có chắc chắn xóa không?",
               "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Traloi == DialogResult.Yes)
                {
                    int currentIndex = dgvNhanvien.CurrentCell.RowIndex;
                    string Madanhsach = Convert.ToString(dgvNhanvien.Rows[currentIndex].Cells[0].Value.ToString());
                    string sql3 = "delete from Ngaylamviec where MaLamViec ='" + Madanhsach + "'";
                    SqlCommand cmd3 = new SqlCommand(sql3, MyCon);
                    cmd3.ExecuteNonQuery();
                    LoadDLGridViewAll();
                }
            }
            else MessageBox.Show("Cần chọn dòng cần xóa");
            MyCon.Close();
        }

        private void txtTimkiem_TextChanged(object sender, EventArgs e)
        {
            LoadTimkiem();
            btAll.Visible = true;
        }
    }
}
