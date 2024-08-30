using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace QLLUONGNV
{
    public partial class ChamCong : Form
    {
        SqlConnection MyCon = new SqlConnection(@"Data Source=TRONGDAT\SQLEXPRESS;Initial Catalog=QLNhanvienluong;Integrated Security=True");
        public ChamCong()
        {
            InitializeComponent();
            for (int i = 1; i <= 12; i++)
            {
                cbxThangDD.Items.Add(i);
            }

            int currentYear = DateTime.Now.Year;
            for (int i = currentYear - 10; i <= currentYear + 10; i++)
            {
                cbxNamDD.Items.Add(i);
            }          
            cbxThangDD.SelectedIndex = DateTime.Now.Month - 1;
            cbxNamDD.SelectedItem = DateTime.Now.Year;
        }
        private void Load_PhongbanCC()
        {
            string sqlphongban = "select  MaPhongBan, TenPhongBan  from PhongBan ";
            SqlDataAdapter adapter = new SqlDataAdapter(sqlphongban, MyCon);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            cbxPhongbanCC.DataSource = dt;
            cbxPhongbanCC.DisplayMember = "TenPhongBan";
            cbxPhongbanCC.ValueMember = "MaPhongBan";
        }
        private void ChamCong_Load(object sender, EventArgs e)
        {           
            //LoadDLGridViewAll();
           // txtSoNgaylam.Text = songay.ToString();
            LoadTongdanhsach();
            Load_PhongbanCC();
        }      
      

        private void btDanhsach_Click(object sender, EventArgs e)
        {
           
            btReset.Visible = false;                     
            labelBangngay.Visible = false;
            panelThongtinNgayCong.Visible = false;
        }
        private void LoadDLGridViewAll()
        {
            //string sql = "select Ngaylamviec.MaLamViec,Ngaylamviec.MaNV,NhanVien.TenNV, Ngaylamviec.SoNgayLam, Ngaylamviec.ThangLam, Ngaylamviec.NamLam from Ngaylamviec inner join NhanVien on NhanVien.MaNV = Ngaylamviec.MaNV where NhanVien.Xoa = 0";
            //SqlDataAdapter ad = new SqlDataAdapter(sql, MyCon);
            //DataTable dt1 = new DataTable();
            //ad.Fill(dt1);
            //dgvNhanvien.DataSource = dt1;
            //dgvNhanvien.AllowUserToAddRows = false;
            //dgvNhanvien.EditMode = DataGridViewEditMode.EditProgrammatically;
            //dgvNhanvien.DataSource = dt1;
            //dgvNhanvien.AllowUserToAddRows = false;
            //dgvNhanvien.RowTemplate.Height = 30;
            //dgvNhanvien.ColumnHeadersDefaultCellStyle.BackColor = Color.MediumSlateBlue; // Đổi màu thành màu đỏ
            //dgvNhanvien.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            //dgvNhanvien.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
            //dgvNhanvien.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            //dgvNhanvien.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dgvNhanvien.EditMode = DataGridViewEditMode.EditProgrammatically;
            //dgvNhanvien.Columns[0].HeaderText = "Mã làm việc";
            //dgvNhanvien.Columns[1].HeaderText = "Mã Nhân Viên";
            //dgvNhanvien.Columns[2].HeaderText = "Họ Và Tên";
            //dgvNhanvien.Columns[3].HeaderText = "Số ngày làm";
            //dgvNhanvien.Columns[4].HeaderText = "Tháng làm việc";
            //dgvNhanvien.Columns[5].HeaderText = "Năm làm việc";
            
        }
       
        
        private void btXemngaycong_Click(object sender, EventArgs e)
        {
            labelNgaynghi.Visible = true;
            btReset.Visible = true;
            flowLayoutDD.Visible = true;
            btTG.Visible = true;
            flowLayoutDD.Visible = true;
            cbxThangDD.Visible = true;
            cbxNamDD.Visible = true;
            cbxPhongbanCC.Visible = true;
            dgvDanhsachCC.Visible = true;
            dgvNgaycongNV.Visible = true;
            panelThongtinNgayCong.Visible = true;
            labelBangngay.Visible = true;
            btDuyetNC.Visible = true;
        }

        private void dgvNhanvien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        private void loadNgaynghi()
        {
            try
            {
                MyCon.Open();
                if (dgvDanhsachCC.SelectedRows.Count > 0)
                {
                    int currentIndex = dgvDanhsachCC.CurrentCell.RowIndex;
                    // Lấy giá trị của ô đầu tiên trong hàng được chọn, có thể là IDnhanVien
                    string IDnhanVien = dgvDanhsachCC.Rows[currentIndex].Cells[0].Value.ToString();
                    string sql = @"SELECT Ngaynghi.Ngaynghi, NhanVien.TenNV, Ngaynghi.MaNV 
                FROM Ngaynghi 
                INNER JOIN NhanVien ON NhanVien.MaNV = Ngaynghi.MaNV 
                WHERE Ngaynghi.MaNV = '" + IDnhanVien + "' AND NhanVien.Xoa = 0";

                    // Thêm điều kiện tháng và năm sinh vào truy vấn
                    if (!string.IsNullOrEmpty(cbxThangDD.SelectedItem.ToString()) && !string.IsNullOrEmpty(cbxNamDD.SelectedItem.ToString()))
                    {
                        sql += " AND MONTH(Ngaynghi.Ngaynghi) = " + cbxThangDD.SelectedItem.ToString() +
                               " AND YEAR(Ngaynghi.Ngaynghi) = " + cbxNamDD.SelectedItem.ToString();
                    }
                    SqlCommand cmd = new SqlCommand(sql, MyCon);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    //load_Songaycong();
                    dgvNgaycongNV.DataSource = dt;
                    dgvNgaycongNV.AllowUserToAddRows = false;
                    dgvNgaycongNV.EditMode = DataGridViewEditMode.EditProgrammatically;
                    dgvNgaycongNV.DataSource = dt;
                    dgvNgaycongNV.AllowUserToAddRows = false;
                    dgvNgaycongNV.RowTemplate.Height = 30;
                    dgvNgaycongNV.ColumnHeadersDefaultCellStyle.BackColor = Color.MediumSlateBlue; // Đổi màu thành màu đỏ
                    dgvNgaycongNV.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                    dgvNgaycongNV.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
                    dgvNgaycongNV.CellBorderStyle = DataGridViewCellBorderStyle.Single;
                    dgvNgaycongNV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvNgaycongNV.EditMode = DataGridViewEditMode.EditProgrammatically;
                    dgvNgaycongNV.Columns[0].HeaderText = "Ngày nghỉ việc";
                    dgvNgaycongNV.Columns[1].HeaderText = "Họ Và Tên";
                    dgvNgaycongNV.Columns[2].HeaderText = "Mã nhân viên";
                }
                else
                {
                    // Xử lý trường hợp không có dòng nào được chọn, ví dụ:
                    MessageBox.Show("Danh sách phòng ban này trống", "Thông Báo");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Danh sách phòng ban này trống", "Thông Báo");
            }
             finally
            {
                MyCon.Close();
            }
        }
        private void btQuaylai_Click(object sender, EventArgs e)
        {
            labelNgaynghi.Visible = false;
            btTG.Visible = false;
            btReset.Visible = false;
            dgvDanhsachCC.Visible = false;
            flowLayoutDD.Visible = false;
            cbxNamDD.Visible = false;
            cbxThangDD.Visible = false;
            cbxPhongbanCC.Visible = false;
            dgvNgaycongNV.Visible = false;                         
            panelThongtinNgayCong.Visible = false;
        }

        private void butQuaylaiCC_Click(object sender, EventArgs e)
        {
            dgvNgaycongNV.Visible = false;
            labelBangngay.Visible = false;
        }     

        private void dgvNgaycongNV_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            
        }       
        private void btDuyetNC_Click(object sender, EventArgs e)
        {
            try
            {
                MyCon.Open();
                string checktontaiNC = "SELECT COUNT(*) FROM Ngaylamviec WHERE ThangLam = @cbxThangDD AND NamLam = @cbxNamDD AND MaNV =@txtManv";
                SqlCommand cmdCheckExistence = new SqlCommand(checktontaiNC, MyCon);
                cmdCheckExistence.Parameters.AddWithValue("@cbxThangDD", cbxThangDD.Text);
                cmdCheckExistence.Parameters.AddWithValue("@cbxNamDD", cbxNamDD.Text);
                cmdCheckExistence.Parameters.AddWithValue("@txtManv", txtManv.Text);
                int count = (int)cmdCheckExistence.ExecuteScalar();
                if (count == 0) // Kiểm tra xem dữ liệu đã tồn tại trong cơ sở dữ liệu chưa
                {
                    string sql1 = "INSERT INTO Ngaylamviec (MaNV,SoNgayLam,ThangLam,NamLam,TongThuong,TongTru ) VALUES ('" + txtManv.Text + "', N'" + txtSoNgaylam.Text + "', N'" + cbxThangDD.Text + "','" + cbxNamDD.Text + "',N'" + ExtractNumberFromString(txtTongThuong.Text) + "',N'" + ExtractNumberFromString(txtTongTru.Text) + "')";
                    SqlCommand Cmd1 = new SqlCommand(sql1, MyCon);
                    Cmd1.ExecuteNonQuery();
                    //LoadDLGridViewAll();
                    LoadDSchuacham();
                    //LoadTimkiem();
                    //LoadDLGridView();
                    MessageBox.Show("Đã duyệt thành công!", "Thông Báo");
                }
                else
                {
                    MessageBox.Show("Nhân viên này đã chấm công trong này tháng rồi ! ", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);                  
                }    
            }

            catch (Exception)
            {
                MessageBox.Show("Nhân viên này đã chấm công trong tháng rồi !!! ", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
            finally
            {
                MyCon.Close();
            }
        }
        

        private void btReset_Click(object sender, EventArgs e)
        {
            loadNgaynghi();
            int month = (int)cbxThangDD.SelectedItem;
            int year = (int)cbxNamDD.SelectedItem;

            // Xác định số ngày trong tháng và năm được chọn
            int daysInMonth = DateTime.DaysInMonth(year, month);
            flowLayoutDD.Controls.Clear();
            // Khởi tạo biến để đếm số ngày không phải chủ nhật
            int nonSundayDays = 0;
            buttonClicked = new bool[daysInMonth + 1];
            // Hiển thị các ngày trong tháng vào ListBox
            for (int day = 1; day <= daysInMonth; day++)
            {
                // Tạo button cho tất cả các ngày
                Guna2Button dayButton = new Guna2Button();
                dayButton.Width = 99;
                dayButton.Height = 74;
                dayButton.Text = day.ToString();
                dayButton.Name = "btnDay" + day.ToString();
                dayButton.AutoSize = true;
                dayButton.Margin = new Padding(5);
                buttonStates.Add(dayButton, false);
                dayButton.Click += DayButton_Click;
                dayButton.DoubleClick += DayButton_DoubleClick;
                dayButton.BorderRadius = 5;
                dayButton.BackColor = Color.White;
                dayButton.BorderColor = Color.MediumSlateBlue;
                dayButton.BorderThickness = 1;
                dayButton.FillColor = Color.White;
                dayButton.ForeColor = Color.MediumSlateBlue;
                // Nếu là ngày chủ nhật thì đổi màu và disable button
                if (new DateTime(year, month, day).DayOfWeek == DayOfWeek.Sunday)
                {
                    dayButton.Text = day.ToString() + " CN";
                    dayButton.BackColor = Color.DarkGray;
                    dayButton.FillColor = Color.Gainsboro;
                    dayButton.ForeColor = Color.DarkGray;
                    dayButton.BorderColor = Color.DarkGray;
                }
                if (new DateTime(year, month, day).DayOfWeek == DayOfWeek.Monday)
                {
                    dayButton.Text = day.ToString() + " Hai";
                }
                if (new DateTime(year, month, day).DayOfWeek == DayOfWeek.Tuesday)
                {
                    dayButton.Text = day.ToString() + " Ba";
                }
                if (new DateTime(year, month, day).DayOfWeek == DayOfWeek.Wednesday)
                {
                    dayButton.Text = day.ToString() + " Tư";
                }
                if (new DateTime(year, month, day).DayOfWeek == DayOfWeek.Thursday)
                {
                    dayButton.Text = day.ToString() + " Năm";
                }
                if (new DateTime(year, month, day).DayOfWeek == DayOfWeek.Friday)
                {
                    dayButton.Text = day.ToString() + " Sáu";
                }
                if (new DateTime(year, month, day).DayOfWeek == DayOfWeek.Saturday)
                {
                    dayButton.Text = day.ToString() + " Bảy";
                }
                else
                {
                    // Nếu không phải là ngày chủ nhật, tăng biến đếm
                    nonSundayDays++;
                }
                
                flowLayoutDD.Controls.Add(dayButton);
            }

            // Hiển thị số ngày không phải chủ nhật trong textBoxDaysInMonth
            txtSoNgaylam.Text = nonSundayDays.ToString();
            if (dgvDanhsachCC.SelectedRows.Count > 0)
            {
                int currentIndex = dgvDanhsachCC.CurrentCell.RowIndex;
                // Lấy giá trị của ô đầu tiên trong hàng được chọn, có thể là IDnhanVien
                string IDnhanVien = dgvDanhsachCC.Rows[currentIndex].Cells[0].Value.ToString();
                string sql = @"SELECT 
                           TienThuong                 
                   FROM 
                        KTNhanVien                                            
                   WHERE 
                        KTNhanVien.MaNV = @IDnhanVien AND 
                        MONTH(KTNhanVien.NgayKhenThuong) = @ThangLam AND
                        YEAR(KTNhanVien.NgayKhenThuong) = @NamLam ";
                double totalTienThuong = 0;
                using (SqlCommand command = new SqlCommand(sql, MyCon))
                {
                    command.Parameters.AddWithValue("@IDnhanVien", IDnhanVien);
                    command.Parameters.AddWithValue("@ThangLam", cbxThangDD.Text);
                    command.Parameters.AddWithValue("@NamLam", cbxNamDD.Text);
                    SqlDataAdapter ad = new SqlDataAdapter(command);
                    DataTable dt1 = new DataTable();
                    ad.Fill(dt1);

                    if (dt1.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt1.Rows)
                        {
                            double tienthuong = Convert.ToDouble(row["TienThuong"]);
                            totalTienThuong += tienthuong;
                        }

                        // Đặt giá trị tổng TienThuong vào TextBox
                        txtTongThuong.Text = totalTienThuong.ToString("N0") + " VNĐ";
                    }
                    else
                    {
                        double Tienthuong = 0;
                        // Nếu không có dữ liệu, đặt TextBox thành rỗng
                        txtTongThuong.Text = (Tienthuong).ToString("N0") + " VNĐ"; ;
                    }

                }
                string IDnhanVien1 = dgvDanhsachCC.Rows[currentIndex].Cells[0].Value.ToString();
                string sql1 = @"SELECT 
                           SoTienPhat                 
                   FROM 
                        KLNhanVien                                            
                   WHERE 
                        KLNhanVien.MaNV = @IDnhanVien AND 
                        MONTH(KLNhanVien.NgayKyLuat) = @ThangLam AND
                        YEAR(KLNhanVien.NgayKyLuat) = @NamLam ";
                double totalTienphat = 0;
                using (SqlCommand command = new SqlCommand(sql1, MyCon))
                {
                    command.Parameters.AddWithValue("@IDnhanVien", IDnhanVien1);
                    command.Parameters.AddWithValue("@ThangLam", cbxThangDD.Text);
                    command.Parameters.AddWithValue("@NamLam", cbxNamDD.Text);
                    SqlDataAdapter ad = new SqlDataAdapter(command);
                    DataTable dt1 = new DataTable();
                    ad.Fill(dt1);

                    if (dt1.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt1.Rows)
                        {
                            double tienphat = Convert.ToDouble(row["SoTienPhat"]);
                            totalTienphat += tienphat;
                        }

                        // Đặt giá trị tổng TienThuong vào TextBox
                        txtTongTru.Text = totalTienphat.ToString("N0") + " VNĐ";
                    }
                    else
                    {
                        double Tienphat = 0;
                        // Nếu không có dữ liệu, đặt TextBox thành rỗng
                        txtTongTru.Text = (Tienphat).ToString("N0") + " VNĐ"; ;
                    }

                }
            }
            else
            {
                MessageBox.Show("Danh sách phòng này trống", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }    
        }
        private void LoadTongdanhsach()
        {       
            string sql = "select Nhanvien.MaNV,Nhanvien.TenNV from NhanVien where NhanVien.Xoa = 0";
            SqlDataAdapter ad = new SqlDataAdapter(sql, MyCon);
            DataTable dt1 = new DataTable();
            ad.Fill(dt1);
            dgvDanhsachCC.DataSource = dt1;
            dgvDanhsachCC.AllowUserToAddRows = false;
            dgvDanhsachCC.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvDanhsachCC.DataSource = dt1;
            dgvDanhsachCC.AllowUserToAddRows = false;
            dgvDanhsachCC.RowTemplate.Height = 30;
            dgvDanhsachCC.ColumnHeadersDefaultCellStyle.BackColor = Color.MediumSlateBlue; // Đổi màu thành màu đỏ
            dgvDanhsachCC.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvDanhsachCC.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
            dgvDanhsachCC.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvDanhsachCC.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDanhsachCC.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvDanhsachCC.Columns[0].HeaderText = "Mã Nhân Viên";
            dgvDanhsachCC.Columns[1].HeaderText = "Họ Và Tên";          
        }
        private void LoadDSchuacham()
        {
            string sql = "SELECT Nhanvien.MaNV, Nhanvien.TenNV, Nhanvien.MaPhongBan " +
                  "FROM NhanVien " +
                  "INNER JOIN PhongBan ON PhongBan.MaPhongBan = NhanVien.MaPhongBan " +
                  "WHERE NhanVien.MaPhongBan = @cbxPhongbanCC " +
                  "AND NhanVien.Xoa = 0 " +
                  "AND NOT EXISTS (SELECT 1 FROM Ngaylamviec " +
                                  "WHERE Ngaylamviec.MaNV = NhanVien.MaNV " +
                                  "AND Ngaylamviec.ThangLam = @cbxThangDD " +
                                  "AND Ngaylamviec.NamLam = @cbxNamDD)";

            // Khởi tạo đối tượng SqlCommand
            using (SqlCommand cmd = new SqlCommand(sql, MyCon))
            {
                // Thêm các tham số vào đối tượng SqlCommand
                cmd.Parameters.AddWithValue("@cbxPhongbanCC", cbxPhongbanCC.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@cbxThangDD", cbxThangDD.Text);
                cmd.Parameters.AddWithValue("@cbxNamDD", cbxNamDD.Text);

                // Khởi tạo đối tượng SqlDataAdapter
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                DataTable dt1 = new DataTable();
                ad.Fill(dt1);

                // Cập nhật dữ liệu cho DataGridView
                dgvDanhsachCC.DataSource = dt1;
                dgvDanhsachCC.AllowUserToAddRows = false;
                dgvDanhsachCC.EditMode = DataGridViewEditMode.EditProgrammatically;
                dgvDanhsachCC.RowTemplate.Height = 30;
                dgvDanhsachCC.ColumnHeadersDefaultCellStyle.BackColor = Color.MediumSlateBlue;
                dgvDanhsachCC.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgvDanhsachCC.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
                dgvDanhsachCC.CellBorderStyle = DataGridViewCellBorderStyle.Single;
                dgvDanhsachCC.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvDanhsachCC.Columns[0].HeaderText = "Mã Nhân Viên";
                dgvDanhsachCC.Columns[1].HeaderText = "Họ Và Tên";
                dgvDanhsachCC.Columns[2].HeaderText = "Phòng Ban";
            }
        }
        private void cbxPhongbanCC_SelectionChangeCommitted(object sender, EventArgs e)
        {

            LoadDSchuacham();
        }

        private void dgvDanhsachCC_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int dong;
            dong = e.RowIndex;
            txtManv.Text = dgvDanhsachCC.Rows[dong].Cells[0].Value.ToString();
            txtTennv.Text = dgvDanhsachCC.Rows[dong].Cells[1].Value.ToString();
            if (e.RowIndex >= 0)
            {
                int currentIndex = e.RowIndex;
                // Lấy giá trị của ô đầu tiên trong hàng được chọn, có thể là IDnhanVien
                string IDnhanVien = dgvDanhsachCC.Rows[currentIndex].Cells[0].Value.ToString();
                string sql = @"SELECT 
                           TienThuong                 
                   FROM 
                        KTNhanVien                                            
                   WHERE 
                        KTNhanVien.MaNV = @IDnhanVien AND 
                        MONTH(KTNhanVien.NgayKhenThuong) = @ThangLam AND
                        YEAR(KTNhanVien.NgayKhenThuong) = @NamLam ";
                double totalTienThuong = 0;
                using (SqlCommand command = new SqlCommand(sql, MyCon))
                {
                    command.Parameters.AddWithValue("@IDnhanVien", IDnhanVien);
                    command.Parameters.AddWithValue("@ThangLam", cbxThangDD.Text);
                    command.Parameters.AddWithValue("@NamLam", cbxNamDD.Text);
                    SqlDataAdapter ad = new SqlDataAdapter(command);
                    DataTable dt1 = new DataTable();
                    ad.Fill(dt1);

                    if (dt1.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt1.Rows)
                        {
                            double tienthuong = Convert.ToDouble(row["TienThuong"]);
                            totalTienThuong += tienthuong;
                        }

                        // Đặt giá trị tổng TienThuong vào TextBox
                        txtTongThuong.Text = totalTienThuong.ToString("N0") + " VNĐ";
                    }
                    else
                    {
                        double Tienthuong = 0;
                        // Nếu không có dữ liệu, đặt TextBox thành rỗng
                        txtTongThuong.Text = (Tienthuong).ToString("N0") + " VNĐ"; ;
                    }

                }

            }
            if (e.RowIndex >= 0)
            {
                int currentIndex = e.RowIndex;
                // Lấy giá trị của ô đầu tiên trong hàng được chọn, có thể là IDnhanVien
                string IDnhanVien = dgvDanhsachCC.Rows[currentIndex].Cells[0].Value.ToString();
                string sql = @"SELECT 
                           SoTienPhat                 
                   FROM 
                        KLNhanVien                                            
                   WHERE 
                        KLNhanVien.MaNV = @IDnhanVien AND 
                        MONTH(KLNhanVien.NgayKyLuat) = @ThangLam AND
                        YEAR(KLNhanVien.NgayKyLuat) = @NamLam ";
                double totalTienphat = 0;
                using (SqlCommand command = new SqlCommand(sql, MyCon))
                {
                    command.Parameters.AddWithValue("@IDnhanVien", IDnhanVien);
                    command.Parameters.AddWithValue("@ThangLam", cbxThangDD.Text);
                    command.Parameters.AddWithValue("@NamLam", cbxNamDD.Text);
                    SqlDataAdapter ad = new SqlDataAdapter(command);
                    DataTable dt1 = new DataTable();
                    ad.Fill(dt1);

                    if (dt1.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt1.Rows)
                        {
                            double tienphat = Convert.ToDouble(row["SoTienPhat"]);
                            totalTienphat += tienphat;
                        }

                        // Đặt giá trị tổng TienThuong vào TextBox
                        txtTongTru.Text = totalTienphat.ToString("N0") + " VNĐ";
                    }
                    else
                    {
                        double Tienphat = 0;
                        // Nếu không có dữ liệu, đặt TextBox thành rỗng
                        txtTongTru.Text = (Tienphat).ToString("N0") + " VNĐ"; ;
                    }

                }

            }
        }
        private void dgvDanhsachCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                loadNgaynghi();
            }

        }

        private void dgvNhanvien_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        private void DayButton_DoubleClick(object sender, EventArgs e)
        {
            Guna2Button clickedButton = sender as Guna2Button;

            // Lấy trạng thái hiện tại của DayButton được double-click
            bool currentState = buttonStates[clickedButton];

            // Nếu DayButton đã được click trước đó, đặt lại trạng thái và màu sắc
            if (currentState)
            {
                buttonStates[clickedButton] = false;
                clickedButton.BackColor = Color.White;
                clickedButton.BorderColor = Color.MediumSlateBlue;
                clickedButton.BorderThickness = 1;
                clickedButton.FillColor = Color.White;
                clickedButton.ForeColor = Color.MediumSlateBlue;

                // Tăng giá trị của txtSoNgaylam
                int currentDays;
                if (int.TryParse(txtSoNgaylam.Text, out currentDays))
                {
                    if (clickedButton.Text.Contains("CN"))
                    {
                        currentDays--;
                        clickedButton.BackColor = Color.DarkGray;
                        clickedButton.FillColor = Color.Gainsboro;
                        clickedButton.ForeColor = Color.DarkGray;
                        clickedButton.BorderColor = Color.DarkGray;
                    }
                    else
                    {
                        currentDays++;
                    }
                    txtSoNgaylam.Text = currentDays.ToString();
                }
            }
        }
        private bool[] buttonClicked;
        private Dictionary<Guna2Button, bool> buttonStates = new Dictionary<Guna2Button, bool>();
        private void btTG_Click(object sender, EventArgs e)
        {
            loadNgaynghi();
            int month = (int)cbxThangDD.SelectedItem;
            int year = (int)cbxNamDD.SelectedItem;
            // Xác định số ngày trong tháng và năm được chọn
            int daysInMonth = DateTime.DaysInMonth(year, month);
            flowLayoutDD.Controls.Clear();
            // Khởi tạo biến để đếm số ngày không phải chủ nhật
            int nonSundayDays = 0;
            buttonClicked = new bool[daysInMonth + 1];
            // Hiển thị các ngày trong tháng vào ListBox
            for (int day = 1; day <= daysInMonth; day++)
            {
                // Tạo button cho tất cả các ngày
                Guna2Button dayButton = new Guna2Button();
                dayButton.Width = 99;
                dayButton.Height = 74;
                dayButton.Text = day.ToString();
                dayButton.Name = "btnDay" + day.ToString();
                dayButton.AutoSize = true;
                dayButton.Margin = new Padding(5);
                buttonStates.Add(dayButton, false);
                dayButton.Click += DayButton_Click;
                dayButton.DoubleClick += DayButton_DoubleClick;
                dayButton.BorderRadius = 5;
                dayButton.BackColor = Color.White;
                dayButton.BorderColor = Color.MediumSlateBlue;
                dayButton.BorderThickness = 1;
                dayButton.FillColor = Color.White;
                dayButton.ForeColor = Color.MediumSlateBlue;
                // Nếu là ngày chủ nhật thì đổi màu và disable button
                if (new DateTime(year, month, day).DayOfWeek == DayOfWeek.Sunday)
                {
                    dayButton.Text = day.ToString() + " CN";
                    dayButton.BackColor = Color.DarkGray;
                    dayButton.Enabled = false;
                }
                if (new DateTime(year, month, day).DayOfWeek == DayOfWeek.Monday)
                {
                    dayButton.Text = day.ToString() + " Hai";                   
                }
                if (new DateTime(year, month, day).DayOfWeek == DayOfWeek.Tuesday)
                {
                    dayButton.Text = day.ToString() + " Ba";                  
                }
                if (new DateTime(year, month, day).DayOfWeek == DayOfWeek.Wednesday)
                {
                    dayButton.Text = day.ToString() + " Tư";                   
                }
                if (new DateTime(year, month, day).DayOfWeek == DayOfWeek.Thursday)
                {
                    dayButton.Text = day.ToString() + " Năm";                    
                }
                if (new DateTime(year, month, day).DayOfWeek == DayOfWeek.Friday)
                {
                    dayButton.Text = day.ToString() + " Sáu";
                }
                if (new DateTime(year, month, day).DayOfWeek == DayOfWeek.Saturday)
                {
                    dayButton.Text = day.ToString() + " Bảy";
                }
                else
                {
                    // Nếu không phải là ngày chủ nhật, tăng biến đếm
                    nonSundayDays++;
                }

                flowLayoutDD.Controls.Add(dayButton);
            }

            // Hiển thị số ngày không phải chủ nhật trong textBoxDaysInMonth
            txtSoNgaylam.Text = nonSundayDays.ToString();
            if (dgvDanhsachCC.SelectedRows.Count > 0)
            {
                int currentIndex = dgvDanhsachCC.CurrentCell.RowIndex;
                // Lấy giá trị của ô đầu tiên trong hàng được chọn, có thể là IDnhanVien
                string IDnhanVien = dgvDanhsachCC.Rows[currentIndex].Cells[0].Value.ToString();
                string sql = @"SELECT 
                           TienThuong                 
                   FROM 
                        KTNhanVien                                            
                   WHERE 
                        KTNhanVien.MaNV = @IDnhanVien AND 
                        MONTH(KTNhanVien.NgayKhenThuong) = @ThangLam AND
                        YEAR(KTNhanVien.NgayKhenThuong) = @NamLam ";
                double totalTienThuong = 0;
                using (SqlCommand command = new SqlCommand(sql, MyCon))
                {
                    command.Parameters.AddWithValue("@IDnhanVien", IDnhanVien);
                    command.Parameters.AddWithValue("@ThangLam", cbxThangDD.Text);
                    command.Parameters.AddWithValue("@NamLam", cbxNamDD.Text);
                    SqlDataAdapter ad = new SqlDataAdapter(command);
                    DataTable dt1 = new DataTable();
                    ad.Fill(dt1);

                    if (dt1.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt1.Rows)
                        {
                            double tienthuong = Convert.ToDouble(row["TienThuong"]);
                            totalTienThuong += tienthuong;
                        }

                        // Đặt giá trị tổng TienThuong vào TextBox
                        txtTongThuong.Text = totalTienThuong.ToString("N0") + " VNĐ";
                    }
                    else
                    {
                        double Tienthuong = 0;
                        // Nếu không có dữ liệu, đặt TextBox thành rỗng
                        txtTongThuong.Text = (Tienthuong).ToString("N0") + " VNĐ"; ;
                    }

                }
                string IDnhanVien1 = dgvDanhsachCC.Rows[currentIndex].Cells[0].Value.ToString();
                string sql1 = @"SELECT 
                           SoTienPhat                 
                   FROM 
                        KLNhanVien                                            
                   WHERE 
                        KLNhanVien.MaNV = @IDnhanVien AND 
                        MONTH(KLNhanVien.NgayKyLuat) = @ThangLam AND
                        YEAR(KLNhanVien.NgayKyLuat) = @NamLam ";
                double totalTienphat = 0;
                using (SqlCommand command = new SqlCommand(sql1, MyCon))
                {
                    command.Parameters.AddWithValue("@IDnhanVien", IDnhanVien1);
                    command.Parameters.AddWithValue("@ThangLam", cbxThangDD.Text);
                    command.Parameters.AddWithValue("@NamLam", cbxNamDD.Text);
                    SqlDataAdapter ad = new SqlDataAdapter(command);
                    DataTable dt1 = new DataTable();
                    ad.Fill(dt1);

                    if (dt1.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt1.Rows)
                        {
                            double tienphat = Convert.ToDouble(row["SoTienPhat"]);
                            totalTienphat += tienphat;
                        }

                        // Đặt giá trị tổng TienThuong vào TextBox
                        txtTongTru.Text = totalTienphat.ToString("N0") + " VNĐ";
                    }
                    else
                    {
                        double Tienphat = 0;
                        // Nếu không có dữ liệu, đặt TextBox thành rỗng
                        txtTongTru.Text = (Tienphat).ToString("N0") + " VNĐ"; ;
                    }

                }
            }
            else
            {
                MessageBox.Show("Danh sách phòng này trống", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private double ExtractNumberFromString(string input)
        {
            string cleanedInput = new string(input.Where(char.IsDigit).ToArray());
            return double.Parse(cleanedInput);
        }
        private void DayButton_Click(object sender, EventArgs e)
        {
            Guna2Button clickedButton = sender as Guna2Button;

            int index = (int)ExtractNumberFromString(clickedButton.Text);

            // Lấy trạng thái hiện tại của DayButton được click
            bool currentState = buttonStates[clickedButton];

            // Kiểm tra xem DayButton đã được click hay chưa
            if (!currentState)
            {
                // Thay đổi trạng thái của DayButton và cập nhật màu sắc
                buttonStates[clickedButton] = true;
                clickedButton.BackColor = Color.White;
                clickedButton.ForeColor = Color.White;
                clickedButton.FillColor = Color.MediumSlateBlue;
                clickedButton.BorderColor = Color.MediumSlateBlue;
                clickedButton.BorderRadius = 5;

                // Giảm giá trị của txtSoNgaylam
                int currentDays;
                if (int.TryParse(txtSoNgaylam.Text, out currentDays) && currentDays > 0)
                {
                    // Kiểm tra nếu là ngày Chủ nhật thì tăng giá trị của currentDays thay vì giảm
                    if (clickedButton.Text.Contains("CN"))
                    {
                        currentDays++;
                        clickedButton.BorderRadius = 5;
                        clickedButton.BackColor = Color.White;
                        clickedButton.BorderColor = Color.MediumSeaGreen;
                        clickedButton.BorderThickness = 1;
                        clickedButton.FillColor = Color.MediumSeaGreen;
                        clickedButton.ForeColor = Color.White;
                    }
                    else
                    {
                        currentDays--;
                    }
                    txtSoNgaylam.Text = currentDays.ToString();
                }
            }
            else
            {
                // Nếu đã click trước đó, không làm gì cả
            }
        }
       

        private void btLocTT_Click(object sender, EventArgs e)
        {

        }

        private void cbxPhongbanCC_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbxThangDD_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadDSchuacham();
        }

        private void cbxNamDD_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadDSchuacham();
        }

        private void cbxPhongban_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }
    }
}
