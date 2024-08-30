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
using System.Windows.Forms.DataVisualization.Charting;

namespace QLLUONGNV
{
    public partial class Thongke : Form
    {
        SqlConnection MyCon = new SqlConnection(@"Data Source=TRONGDAT\SQLEXPRESS;Initial Catalog=QLNhanvienluong;Integrated Security=True");
        public Thongke()
        {
            InitializeComponent();
        }

        private void Thongke_Load(object sender, EventArgs e)
        {

            LoadDataToChart();
            LoadDLGridView();
        }
        private void LoadDLGridView()
        {
            //string sql = "select NhanVien.* from NhanVien inner join PhongBan on PhongBan.MaPhongBan  = NhanVien.MaPhongBan where NhanVien.MaPhongBan = '" + cbxPhongbann.SelectedValue.ToString() + "'";
            string sqlQuery = "SELECT PhongBan.TenPhongBan, COUNT(*) AS SoLuongNhanVien,(AVG(BacLuong.HeSoLuong * 1800000)) AS Luongtrungbinh " +
                  "FROM PhongBan " +
                  "INNER JOIN NhanVien ON NhanVien.MaPhongBan = PhongBan.MaPhongBan " +
                  "INNER JOIN ChucVu ON ChucVu.MaChucVu = NhanVien.MaChucVu " +
                  "INNER JOIN BacLuong ON BacLuong.MaBacLuong = NhanVien.MaBacLuong " +
                  "WHERE NhanVien.Xoa = 0 AND PhongBan.DaXoa = 0 " + // Thêm "AND" ở đây
                  "GROUP BY NhanVien.MaPhongBan, PhongBan.MaPhongBan, PhongBan.TenPhongBan, PhongBan.SĐT";
            SqlDataAdapter ad = new SqlDataAdapter(sqlQuery, MyCon);
            DataTable dt1 = new DataTable();
            ad.Fill(dt1);
            gvdPhongban.DataSource = dt1;
            gvdPhongban.AllowUserToAddRows = false;
            gvdPhongban.EditMode = DataGridViewEditMode.EditProgrammatically;
            gvdPhongban.DataSource = dt1;
            gvdPhongban.AllowUserToAddRows = false;
            gvdPhongban.RowTemplate.Height = 30;
            gvdPhongban.ColumnHeadersDefaultCellStyle.BackColor = Color.MediumSlateBlue; // Đổi màu thành màu đỏ
            gvdPhongban.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            gvdPhongban.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
            gvdPhongban.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            gvdPhongban.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvdPhongban.EditMode = DataGridViewEditMode.EditProgrammatically;
            gvdPhongban.Columns[0].HeaderText = "Phòng ban";
            gvdPhongban.Columns[1].HeaderText = "Số lượng nhân viên";
            gvdPhongban.Columns[2].HeaderText = "Lương trung bình";
        }
        private void LoadDataToChart()
        {
            string sqlQuery = "SELECT PhongBan.TenPhongBan, COUNT(NhanVien.MaNV) AS SoLuongNhanVien " +
                              "FROM NhanVien INNER JOIN PhongBan ON NhanVien.MaPhongBan = PhongBan.MaPhongBan " +
                              "GROUP BY PhongBan.TenPhongBan";

            SqlCommand command = new SqlCommand(sqlQuery, MyCon);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();

            try
            {
                MyCon.Open();
                adapter.Fill(dataTable);

                // Xóa các Series trước đó trên biểu đồ (nếu có)
                chartThongkeNV.Series.Clear();

                // Tạo Series mới cho biểu đồ cột
                Series series = chartThongkeNV.Series.Add("NhanVien");

                // Thiết lập loại biểu đồ là cột
                series.ChartType = SeriesChartType.Column;

                // Thêm dữ liệu vào biểu đồ và tính phần trăm
                foreach (DataRow row in dataTable.Rows)
                {
                    string tenPhongBan = row["TenPhongBan"].ToString();
                    int soLuongNhanVien = Convert.ToInt32(row["SoLuongNhanVien"]);

                    // Thêm dữ liệu vào biểu đồ
                    series.Points.AddXY(tenPhongBan, soLuongNhanVien);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                MyCon.Close();
            }
        }
        private void LoadDataToChartAge()
        {
            string sqlQuery = "SELECT " +
                              "SUM(CASE WHEN DATEDIFF(YEAR, NhanVien.NgaySinh, GETDATE()) BETWEEN 18 AND 25 THEN 1 ELSE 0 END) AS Tuoi1825, " +
                              "SUM(CASE WHEN DATEDIFF(YEAR, NhanVien.NgaySinh, GETDATE()) BETWEEN 26 AND 35 THEN 1 ELSE 0 END) AS Tuoi2635, " +
                              "SUM(CASE WHEN DATEDIFF(YEAR, NhanVien.NgaySinh, GETDATE()) BETWEEN 36 AND 45 THEN 1 ELSE 0 END) AS Tuoi3645, " +
                              "SUM(CASE WHEN DATEDIFF(YEAR, NhanVien.NgaySinh, GETDATE()) BETWEEN 46 AND 55 THEN 1 ELSE 0 END) AS Tuoi4655, " +
                              "SUM(CASE WHEN DATEDIFF(YEAR, NhanVien.NgaySinh, GETDATE()) >= 56 THEN 1 ELSE 0 END) AS Tuoi56 " +
                              "FROM NhanVien";

            SqlCommand command = new SqlCommand(sqlQuery, MyCon);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();

            try
            {
                MyCon.Open();
                adapter.Fill(dataTable);

                // Xóa các Series trước đó trên biểu đồ (nếu có)
                charthongkeGT.Series.Clear();

                // Tạo Series mới cho biểu đồ tròn
                Series series = charthongkeGT.Series.Add("DoTuoi");

                // Thiết lập loại biểu đồ là tròn
                series.ChartType = SeriesChartType.Pie;

                // Thêm dữ liệu vào biểu đồ tròn
                foreach (DataRow row in dataTable.Rows)
                {
                    int tuoi1825 = Convert.ToInt32(row["Tuoi1825"]);
                    int tuoi2635 = Convert.ToInt32(row["Tuoi2635"]);
                    int tuoi3645 = Convert.ToInt32(row["Tuoi3645"]);
                    int tuoi4655 = Convert.ToInt32(row["Tuoi4655"]);
                    int tuoi56 = Convert.ToInt32(row["Tuoi56"]);

                    int totalEmployees = tuoi1825 + tuoi2635 + tuoi3645 + tuoi4655 + tuoi56;

                    // Tính phần trăm độ tuổi
                    double percent1825 = (double)tuoi1825 / totalEmployees * 100;
                    double percent2635 = (double)tuoi2635 / totalEmployees * 100;
                    double percent3645 = (double)tuoi3645 / totalEmployees * 100;
                    double percent4655 = (double)tuoi4655 / totalEmployees * 100;
                    double percent56 = (double)tuoi56 / totalEmployees * 100;

                    // Thêm dữ liệu vào biểu đồ tròn
                    series.Points.AddXY("18-25", percent1825);
                    series.Points.AddXY("26-35", percent2635);
                    series.Points.AddXY("36-45", percent3645);
                    series.Points.AddXY("46-55", percent4655);
                    series.Points.AddXY("56+", percent56);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                MyCon.Close();
            }
        }
        private void LoadDataToPieChartGT()
        {
            string sqlQuery = "SELECT " +
                              "SUM(CASE WHEN NhanVien.GioiTinh = N'Nam' THEN 1 ELSE 0 END) AS SoLuongNam, " +
                              "SUM(CASE WHEN NhanVien.GioiTinh = N'Nữ' THEN 1 ELSE 0 END) AS SoLuongNu " +
                              "FROM NhanVien";

            SqlCommand command = new SqlCommand(sqlQuery, MyCon);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();

            try
            {
                MyCon.Open();
                adapter.Fill(dataTable);

                // Xóa các Series trước đó trên biểu đồ (nếu có)
                charthongkeGT.Series.Clear();

                // Tạo Series mới cho biểu đồ tròn
                Series series = charthongkeGT.Series.Add("Gender");

                // Thiết lập loại biểu đồ là tròn
                series.ChartType = SeriesChartType.Pie;

                // Thêm dữ liệu vào biểu đồ tròn
                foreach (DataRow row in dataTable.Rows)
                {
                    int soLuongNam = Convert.ToInt32(row["SoLuongNam"]);
                    int soLuongNu = Convert.ToInt32(row["SoLuongNu"]);

                    // Tính tổng số lượng nhân viên
                    int totalEmployees = soLuongNam + soLuongNu;

                    // Tính phần trăm nam và nữ
                    double percentNam = (double)soLuongNam / totalEmployees * 100;
                    double percentNu = (double)soLuongNu / totalEmployees * 100;

                    // Thêm dữ liệu vào biểu đồ tròn
                    series.Points.AddXY($"Nam ({percentNam.ToString("0.00")}%)", soLuongNam);
                    series.Points.AddXY($"Nữ ({percentNu.ToString("0.00")}%)", soLuongNu);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                MyCon.Close();
            }
        }
        private void CbxThongke_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (CbxThongke.Text == "Giới tính")
            {
                LoadDataToPieChartGT();
            }
            if (CbxThongke.Text == "Độ tuổi")
            {
                LoadDataToChartAge();

            }
        }

        private void gvdPhongban_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (gvdPhongban.Columns[e.ColumnIndex].Name == "Luongtrungbinh" && e.RowIndex >= 0)
            {
                // Kiểm tra giá trị của ô
                if (e.Value != null)
                {
                    double luongtb;
                    // Chuyển giá trị của ô thành kiểu double
                    if (double.TryParse(e.Value.ToString(), out luongtb))
                    {
                        // Làm tròn đến 0 chữ số thập phân và định dạng lại giá trị của ô theo đơn vị tiền tệ Việt Nam
                        e.Value = luongtb.ToString("#,##0") + " VNĐ";
                        e.FormattingApplied = true;
                    }
                }
            }
        }

        private void paneltop_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
