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
    public partial class Inbangluong : Form
    {
        SqlConnection MyCon = new SqlConnection(@"Data Source=TRONGDAT\SQLEXPRESS;Initial Catalog=QLNhanvienluong;Integrated Security=True");
        public Inbangluong()
        {
            InitializeComponent();
            for (int j = 1; j <= 12; j++)
            {
                cbxThangluong.Items.Add(j);
            }

            int currentYearDS = DateTime.Now.Year;
            for (int j = currentYearDS - 10; j <= currentYearDS + 10; j++)
            {
                cbxNamluong.Items.Add(j);
            }
            cbxThangluong.SelectedIndex = DateTime.Now.Month - 1;
            cbxNamluong.SelectedItem = DateTime.Now.Year;
        }

        private void guna2GroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void Inbangluong_Load(object sender, EventArgs e)
        {         
        }
        private void LoadDLGridView()
        {
            string sql = "SELECT Ngaylamviec.MaNV, NhanVien.TenNV, ChucVu.TenChucVu, Ngaylamviec.ThangLam, Ngaylamviec.NamLam, Ngaylamviec.TongThuong, Ngaylamviec.TongTru, BacLuong.HeSoLuong * 1800000 AS Luongcoban, BacLuong.HeSoLuong * 1800000 / 22 * Ngaylamviec.SoNgayLam as LuongThucTe, Ngaylamviec.SoNgayLam, ChucVu.HeSoChucVu * 1800000 AS HesoCV, (BacLuong.HeSoLuong * 1800000 / 22 * Ngaylamviec.SoNgayLam) + (ChucVu.HeSoChucVu * 1800000) + Ngaylamviec.TongThuong - Ngaylamviec.TongTru AS Thuclanh FROM NhanVien INNER JOIN ChucVu ON ChucVu.MaChucVu = NhanVien.MaChucVu INNER JOIN BacLuong ON BacLuong.MaBacLuong = NhanVien.MaBacLuong INNER JOIN Ngaylamviec ON Ngaylamviec.MaNV = NhanVien.MaNV WHERE NhanVien.Xoa = 0";

            // Thêm điều kiện lọc theo phòng ban nếu có

            // Thêm điều kiện tháng và năm nếu được chọn
            if (!string.IsNullOrEmpty(cbxThangluong.SelectedItem?.ToString()) && !string.IsNullOrEmpty(cbxNamluong.SelectedItem?.ToString()))
            {
                sql += " AND Ngaylamviec.ThangLam = " + cbxThangluong.SelectedItem.ToString() +
                       " AND Ngaylamviec.NamLam = " + cbxNamluong.SelectedItem.ToString();
            }

            // Loại bỏ điều kiện WHERE thừa và thêm GROUP BY vào cuối câu truy vấn
            sql += " GROUP BY Ngaylamviec.MaNV, Ngaylamviec.ThangLam, Ngaylamviec.NamLam, NhanVien.TenNV, ChucVu.TenChucVu, BacLuong.HeSoLuong, Ngaylamviec.SoNgayLam, ChucVu.HeSoChucVu, Ngaylamviec.TongThuong, Ngaylamviec.TongTru";

            SqlDataAdapter Adapter = new SqlDataAdapter(sql, MyCon);
            DataTable DT = new DataTable();
            Adapter.Fill(DT);
            string thangluong = cbxThangluong.Text;
            string namluong = cbxNamluong.Text;
            Hienthiluong RPHD = new Hienthiluong();
            RPHD.SetDataSource(DT);
            // Truyền giá trị vào TextObject trong báo cáo
            TextObject txtThangluong = (TextObject)RPHD.ReportDefinition.Sections["Section1"].ReportObjects["txtThangLuong"];
            txtThangluong.Text = thangluong;
            TextObject txtNamLuong = (TextObject)RPHD.ReportDefinition.Sections["Section1"].ReportObjects["txtNamLuong"];
            txtNamLuong.Text = namluong;
            crystalReportViewer1.ReportSource = RPHD;

        }
        private void LoadDLGridViewPB()
        {
            string sql = "SELECT Ngaylamviec.MaNV, NhanVien.TenNV, ChucVu.TenChucVu, Ngaylamviec.ThangLam, Ngaylamviec.NamLam, Ngaylamviec.TongThuong, Ngaylamviec.TongTru, BacLuong.HeSoLuong * 1800000 AS Luongcoban, BacLuong.HeSoLuong * 1800000 / 22 * Ngaylamviec.SoNgayLam as LuongThucTe, Ngaylamviec.SoNgayLam, ChucVu.HeSoChucVu * 1800000 AS HesoCV, (BacLuong.HeSoLuong * 1800000 / 22 * Ngaylamviec.SoNgayLam) + (ChucVu.HeSoChucVu * 1800000) + Ngaylamviec.TongThuong - Ngaylamviec.TongTru AS Thuclanh FROM NhanVien INNER JOIN ChucVu ON ChucVu.MaChucVu = NhanVien.MaChucVu INNER JOIN BacLuong ON BacLuong.MaBacLuong = NhanVien.MaBacLuong INNER JOIN Ngaylamviec ON Ngaylamviec.MaNV = NhanVien.MaNV WHERE NhanVien.Xoa = 0";

            // Thêm điều kiện lọc theo phòng ban nếu có

            // Thêm điều kiện tháng và năm nếu được chọn
            if (!string.IsNullOrEmpty(cbxThangluong.SelectedItem?.ToString()) && !string.IsNullOrEmpty(cbxNamluong.SelectedItem?.ToString()))
            {
                sql += " AND Ngaylamviec.ThangLam = " + cbxThangluong.SelectedItem.ToString() +
                       " AND Ngaylamviec.NamLam = " + cbxNamluong.SelectedItem.ToString();
            }

            // Loại bỏ điều kiện WHERE thừa và thêm GROUP BY vào cuối câu truy vấn
            sql += " GROUP BY Ngaylamviec.MaNV, Ngaylamviec.ThangLam, Ngaylamviec.NamLam, NhanVien.TenNV, ChucVu.TenChucVu, BacLuong.HeSoLuong, Ngaylamviec.SoNgayLam, ChucVu.HeSoChucVu, Ngaylamviec.TongThuong, Ngaylamviec.TongTru";

            SqlDataAdapter Adapter = new SqlDataAdapter(sql, MyCon);
            DataTable DT = new DataTable();
            Adapter.Fill(DT);
            Hienthiluong RPHD = new Hienthiluong();
            RPHD.SetDataSource(DT);
            crystalReportViewer1.ReportSource = RPHD;

        }

        private void cbxThangluong_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadDLGridView();
        }

        private void cbxNamluong_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadDLGridView();
        }

        private void cbxPhong_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadDLGridViewPB();
        }
  
    }
}
