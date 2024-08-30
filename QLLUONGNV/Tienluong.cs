using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLLUONGNV
{
    public partial class Tienluong : Form
    {
        SqlConnection MyCon = new SqlConnection(@"Data Source=TRONGDAT\SQLEXPRESS;Initial Catalog=QLNhanvienluong;Integrated Security=True");
        public Tienluong()
        {
            InitializeComponent();
            for (int i = 1; i <= 12; i++)
            {
                cbxThangDS.Items.Add(i);
            }

            int currentYearDS = DateTime.Now.Year;
            for (int j = currentYearDS - 10; j <= currentYearDS + 10; j++)
            {
                cbxNamDS.Items.Add(j);
            }
            cbxThangDS.SelectedIndex = DateTime.Now.Month - 1;
            cbxNamDS.SelectedItem = DateTime.Now.Year;
        }
        
        private void Tienluong_Load(object sender, EventArgs e)
        {

            LoadDLGridView1();
            Load_PhongbanBL();
            Inbangluong();        
        }
        private void LoadDLGridView1()
        {
            //string sql = "select NhanVien.* from NhanVien inner join PhongBan on PhongBan.MaPhongBan  = NhanVien.MaPhongBan where NhanVien.MaPhongBan = '" + cbxPhongbann.SelectedValue.ToString() + "'";          
            string sql = "SELECT Ngaylamviec.MaNV,NhanVien.TenNV,ChucVu.TenChucVu,Ngaylamviec.ThangLam, Ngaylamviec.NamLam,Ngaylamviec.TongThuong,Ngaylamviec.TongTru, BacLuong.HeSoLuong * 1800000 AS Luongcoban,BacLuong.HeSoLuong * 1800000 / 22 * Ngaylamviec.SoNgayLam as LuongThucTe, Ngaylamviec.SoNgayLam, ChucVu.HeSoChucVu*1800000 AS HesoCV, (BacLuong.HeSoLuong * 1800000 / 22 * Ngaylamviec.SoNgayLam) + (ChucVu.HeSoChucVu * 1800000) + Ngaylamviec.TongThuong - Ngaylamviec.TongTru AS Thuclanh  FROM NhanVien INNER JOIN ChucVu ON ChucVu.MaChucVu = NhanVien.MaChucVu INNER JOIN BacLuong ON BacLuong.MaBacLuong = NhanVien.MaBacLuong INNER JOIN Ngaylamviec ON Ngaylamviec.MaNV = NhanVien.MaNV  WHERE NhanVien.Xoa = 0 GROUP BY Ngaylamviec.MaNV, Ngaylamviec.ThangLam, Ngaylamviec.NamLam, NhanVien.TenNV, ChucVu.TenChucVu, BacLuong.HeSoLuong, Ngaylamviec.SoNgayLam, ChucVu.HeSoChucVu, Ngaylamviec.TongThuong, Ngaylamviec.TongTru";
            SqlDataAdapter ad = new SqlDataAdapter(sql, MyCon);
            DataTable dt1 = new DataTable();
            ad.Fill(dt1);
            dgvBangluong.DataSource = dt1;
            dgvBangluong.AllowUserToAddRows = false;
            dgvBangluong.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvBangluong.DataSource = dt1;
            dgvBangluong.AllowUserToAddRows = false;
            dgvBangluong.RowTemplate.Height = 30;
            dgvBangluong.ColumnHeadersDefaultCellStyle.BackColor = Color.MediumSlateBlue; // Đổi màu thành màu đỏ
            dgvBangluong.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvBangluong.DefaultCellStyle.ForeColor = Color.Black;
            dgvBangluong.DefaultCellStyle.Font = new Font("Arial", 10);
            dgvBangluong.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
            dgvBangluong.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvBangluong.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvBangluong.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvBangluong.Columns["MaNV"].HeaderText = "Mã NV";
            dgvBangluong.Columns["TenNV"].HeaderText = "Tên NV";
            dgvBangluong.Columns["TenChucVu"].HeaderText = "Chức Vụ";
            dgvBangluong.Columns["ThangLam"].HeaderText = "Tháng Làm";
            dgvBangluong.Columns["NamLam"].HeaderText = "Năm Làm";
            dgvBangluong.Columns["TongThuong"].HeaderText = "Tổng Thưởng";
            dgvBangluong.Columns["TongTru"].HeaderText = "Các khoảng trừ";
            dgvBangluong.Columns["Luongcoban"].HeaderText = "Lương Cơ Bản";
            dgvBangluong.Columns["LuongThucTe"].HeaderText = "Lương Thực Tế";
            dgvBangluong.Columns["SoNgayLam"].HeaderText = "Số Ngày Làm";
            dgvBangluong.Columns["HesoCV"].HeaderText = "Phụ Cấp Chức Vụ";
            dgvBangluong.Columns["Thuclanh"].HeaderText = "Thực Lãnh";

        }
        // hàm ExtractNumberFromString để trích xuất số từ chuỗi:
        private double ExtractNumberFromString(string input)
        {
            string cleanedInput = new string(input.Where(char.IsDigit).ToArray());
            return double.Parse(cleanedInput);
        }
        private void dgvBangluong_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Kiểm tra nếu đang định dạng cột "Thuclanh"
            if (dgvBangluong.Columns[e.ColumnIndex].Name == "Thuclanh" && e.RowIndex >= 0)
            {
                // Kiểm tra giá trị của ô
                if (e.Value != null)
                {
                    double thuclanh;
                    // Chuyển giá trị của ô thành kiểu double
                    if (double.TryParse(e.Value.ToString(), out thuclanh))
                    {
                        // Làm tròn đến 0 chữ số thập phân và định dạng lại giá trị của ô theo đơn vị tiền tệ Việt Nam
                        e.Value = thuclanh.ToString("#,##0") + " VNĐ";
                        e.FormattingApplied = true;
                    }
                }
            }
            if (dgvBangluong.Columns[e.ColumnIndex].Name == "HesoCV" && e.RowIndex >= 0)
            {
                // Kiểm tra giá trị của ô
                if (e.Value != null)
                {
                    double TienChucVu;
                    // Chuyển giá trị của ô thành kiểu double
                    if (double.TryParse(e.Value.ToString(), out TienChucVu))
                    {
                        // Làm tròn đến 0 chữ số thập phân và định dạng lại giá trị của ô theo đơn vị tiền tệ Việt Nam
                        e.Value = TienChucVu.ToString("#,##0") + " VNĐ";
                        e.FormattingApplied = true;
                    }
                }
            }
            if (dgvBangluong.Columns[e.ColumnIndex].Name == "Luongcoban" && e.RowIndex >= 0)
            {
                // Kiểm tra giá trị của ô
                if (e.Value != null)
                {
                    double TienCB;
                    // Chuyển giá trị của ô thành kiểu double
                    if (double.TryParse(e.Value.ToString(), out TienCB))
                    {
                        // Làm tròn đến 0 chữ số thập phân và định dạng lại giá trị của ô theo đơn vị tiền tệ Việt Nam
                        e.Value = TienCB.ToString("#,##0") + " VNĐ";
                        e.FormattingApplied = true;
                    }
                }
            }
            if (dgvBangluong.Columns[e.ColumnIndex].Name == "TongThuong" && e.RowIndex >= 0)
            {
                // Kiểm tra giá trị của ô
                if (e.Value != null)
                {
                    double TienThuong;
                    // Chuyển giá trị của ô thành kiểu double
                    if (double.TryParse(e.Value.ToString(), out TienThuong))
                    {
                        // Làm tròn đến 0 chữ số thập phân và định dạng lại giá trị của ô theo đơn vị tiền tệ Việt Nam
                        e.Value = TienThuong.ToString("#,##0") + " VNĐ";
                        e.FormattingApplied = true;
                    }
                }
            }
            if (dgvBangluong.Columns[e.ColumnIndex].Name == "TongTru" && e.RowIndex >= 0)
            {
                // Kiểm tra giá trị của ô
                if (e.Value != null)
                {
                    double Tientru;
                    // Chuyển giá trị của ô thành kiểu double
                    if (double.TryParse(e.Value.ToString(), out Tientru))
                    {
                        // Làm tròn đến 0 chữ số thập phân và định dạng lại giá trị của ô theo đơn vị tiền tệ Việt Nam
                        e.Value = Tientru.ToString("#,##0") + " VNĐ";
                        e.FormattingApplied = true;
                    }
                }
            }
            if (dgvBangluong.Columns[e.ColumnIndex].Name == "LuongThucTe" && e.RowIndex >= 0)
            {
                // Kiểm tra giá trị của ô
                if (e.Value != null)
                {
                    double LuongThucTe;
                    // Chuyển giá trị của ô thành kiểu double
                    if (double.TryParse(e.Value.ToString(), out LuongThucTe))
                    {
                        // Làm tròn đến 0 chữ số thập phân và định dạng lại giá trị của ô theo đơn vị tiền tệ Việt Nam
                        e.Value = LuongThucTe.ToString("#,##0") + " VNĐ";
                        e.FormattingApplied = true;
                    }
                }
            }
        }

       

        private void btlockq_Click_1(object sender, EventArgs e)
        {
           
        }

        private void btAll_Click_1(object sender, EventArgs e)
        {
            LoadDLGridView1();
        }
        private void Load_PhongbanBL()
        {
            string sqlphongban = "select  MaPhongBan, TenPhongBan  from PhongBan ";
            SqlDataAdapter adapter = new SqlDataAdapter(sqlphongban, MyCon);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            cbxPhongban.DataSource = dt;
            cbxPhongban.DisplayMember = "TenPhongBan";
            cbxPhongban.ValueMember = "MaPhongBan";
        }

        private void cbxPhongban_SelectionChangeCommitted_1(object sender, EventArgs e)
        {
            loadtagridDieukien();
        }

        private void btChitiet_Click_1(object sender, EventArgs e)
        {
            ChitietBangluong chitiet = new ChitietBangluong();
            //panelcontainer.Controls.Clear(); // Xóa bất kỳ control nào đang tồn tại trên Pane
            int currentIndex = dgvBangluong.CurrentCell.RowIndex;
            // Lấy giá trị của ô đầu tiên trong hàng được chọn, có thể là IDnhanVien
            string IDnhanVien = dgvBangluong.Rows[currentIndex].Cells[0].Value.ToString();
            //string sql = "select NhanVien.* from NhanVien inner join PhongBan on PhongBan.MaPhongBan  = NhanVien.MaPhongBan where NhanVien.MaPhongBan = '" + cbxPhongbann.SelectedValue.ToString() + "'";          
            string sql = "SELECT BacLuong.HeSoLuong * 1800000 / 22 as Luongngay,Ngaylamviec.ThangLam, Ngaylamviec.NamLam,Ngaylamviec.TongThuong,Ngaylamviec.TongTru, BacLuong.HeSoLuong * 1800000 AS Luongcoban,BacLuong.HeSoLuong * 1800000 / 22 * Ngaylamviec.SoNgayLam as LuongThucTe, Ngaylamviec.SoNgayLam, ChucVu.HeSoChucVu*1800000 AS HesoCV, (BacLuong.HeSoLuong * 1800000 / 22 * Ngaylamviec.SoNgayLam) + (ChucVu.HeSoChucVu * 1800000) + Ngaylamviec.TongThuong - Ngaylamviec.TongTru AS Thuclanh  FROM NhanVien INNER JOIN ChucVu ON ChucVu.MaChucVu = NhanVien.MaChucVu INNER JOIN BacLuong ON BacLuong.MaBacLuong = NhanVien.MaBacLuong INNER JOIN Ngaylamviec ON Ngaylamviec.MaNV = NhanVien.MaNV  WHERE NhanVien.Xoa = 0 and NhanVien.MaNV = '" + IDnhanVien + "' GROUP BY Ngaylamviec.MaNV, Ngaylamviec.ThangLam, Ngaylamviec.NamLam, NhanVien.TenNV, ChucVu.TenChucVu, BacLuong.HeSoLuong, Ngaylamviec.SoNgayLam, ChucVu.HeSoChucVu, Ngaylamviec.TongThuong, Ngaylamviec.TongTru";
            SqlDataAdapter ad = new SqlDataAdapter(sql, MyCon);
            DataTable dt1 = new DataTable();
            ad.Fill(dt1);
            chitiet.dgvLuongsg.DataSource = dt1;
            chitiet.dgvLuongsg.AllowUserToAddRows = false;
            chitiet.dgvLuongsg.EditMode = DataGridViewEditMode.EditProgrammatically;
            chitiet.dgvLuongsg.DataSource = dt1;
            chitiet.dgvLuongsg.AllowUserToAddRows = false;
            chitiet.dgvLuongsg.RowTemplate.Height = 30;
            chitiet.dgvLuongsg.ColumnHeadersDefaultCellStyle.BackColor = Color.MediumSlateBlue; // Đổi màu thành màu đỏ
            chitiet.dgvLuongsg.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            chitiet.dgvLuongsg.DefaultCellStyle.ForeColor = Color.Black;
            chitiet.dgvLuongsg.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
            chitiet.dgvLuongsg.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            chitiet.dgvLuongsg.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            chitiet.dgvLuongsg.EditMode = DataGridViewEditMode.EditProgrammatically;
            chitiet.dgvLuongsg.Columns["Luongngay"].HeaderText = "Lương ngày";
            chitiet.dgvLuongsg.Columns["ThangLam"].HeaderText = "Tháng Làm";
            chitiet.dgvLuongsg.Columns["NamLam"].HeaderText = "Năm Làm";
            chitiet.dgvLuongsg.Columns["TongThuong"].HeaderText = "Tổng Thưởng";
            chitiet.dgvLuongsg.Columns["TongTru"].HeaderText = "Các khoảng trừ";
            chitiet.dgvLuongsg.Columns["Luongcoban"].HeaderText = "Lương Cơ Bản";
            chitiet.dgvLuongsg.Columns["LuongThucTe"].HeaderText = "Lương Thực Tế";
            chitiet.dgvLuongsg.Columns["SoNgayLam"].HeaderText = "Số Ngày Làm";
            chitiet.dgvLuongsg.Columns["HesoCV"].HeaderText = "Phụ Cấp Chức Vụ";
            chitiet.dgvLuongsg.Columns["Thuclanh"].HeaderText = "Thực Lãnh";
            chitiet.labelManv.Text = dgvBangluong.Rows[currentIndex].Cells[0].Value.ToString();
            chitiet.labelTennv.Text = dgvBangluong.Rows[currentIndex].Cells[1].Value.ToString();
            chitiet.labelchucvu.Text = dgvBangluong.Rows[currentIndex].Cells[2].Value.ToString();
            if (currentIndex >= 0)
            {             
                string sql1 = @"SELECT 
                           GioiTinh,NgaySinh,DiaChi,SĐT,TrinhDo,QuocTinh,DanToc,SoCCCD,NgayCap,NgayVaoLam,MaPhuCap,MaPhongBan,HinhAnh                
                   FROM 
                        NhanVien                                            
                   WHERE 
                        NhanVien.MaNV = @IDnhanVien";
                using (SqlCommand command1 = new SqlCommand(sql1, MyCon))
                {
                    command1.Parameters.AddWithValue("@IDnhanVien", IDnhanVien);
                    SqlDataAdapter ad1 = new SqlDataAdapter(command1);
                    DataTable dt11 = new DataTable();
                    ad1.Fill(dt11);
                    if (dt11.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt11.Rows)
                        { // Vì bạn chỉ lấy thông tin của một nhân viên cụ thể, nên chỉ cần lấy hàng đầu tiên từ DataTable                                                    // Lấy dữ liệu từ DataRow và đặt giá trị vào các TextBox
                            chitiet.labelGioitinh.Text = row["GioiTinh"].ToString();
                            chitiet.labelNgaysinh.Text = row["NgaySinh"].ToString();
                            chitiet.labelDiachi.Text = row["DiaChi"].ToString();
                            chitiet.labeldienthoai.Text = row["SĐT"].ToString();
                            chitiet.labelTrinhdo.Text = row["TrinhDo"].ToString();
                            chitiet.labelQuoctich.Text = row["QuocTinh"].ToString();
                            chitiet.labeldantoc.Text = row["DanToc"].ToString();
                            chitiet.labelSoCMND.Text = row["SoCCCD"].ToString();
                            chitiet.labelNgaycap.Text = row["NgayCap"].ToString();
                            chitiet.labelNgaylam.Text = row["NgayVaoLam"].ToString();
                            chitiet.labelPhucap.Text = row["MaPhuCap"].ToString();
                            chitiet.labelphongban.Text = row["MaPhongBan"].ToString();
                            object value = row["HinhAnh"];

                            // Kiểm tra nếu giá trị không phải là DBNull và không null
                            if (value != DBNull.Value && value != null)
                            {
                                byte[] b = (byte[])value;
                                chitiet.picavartar.Image = ByteArrayToImage(b);
                                guna2HtmlLabel2.Visible = true;
                            }
                            else
                            {
                                // Nếu giá trị là DBNull hoặc null, gán hình ảnh rỗng cho PictureBox
                                chitiet.picavartar.Image = null;
                                guna2HtmlLabel2.Visible = false;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Lỗi", "Thông báo");
                    }

                }

            }

            chitiet.ShowDialog();
            // Thêm UserControl vào Panel
        }      
        private void dgvBangluong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }  

        private void dgvBangluong_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        Image ByteArrayToImage(byte[] b)
        {
            MemoryStream m = new MemoryStream(b);
            return Image.FromStream(m);
        }
        private void Inbangluong()
        {
            
        }

        

       
        
        private void loadtagridDieukien()
        {
            string sql = "SELECT Ngaylamviec.MaNV, NhanVien.TenNV, ChucVu.TenChucVu, Ngaylamviec.ThangLam, Ngaylamviec.NamLam, Ngaylamviec.TongThuong, Ngaylamviec.TongTru, BacLuong.HeSoLuong * 1800000 AS Luongcoban, BacLuong.HeSoLuong * 1800000 / 22 * Ngaylamviec.SoNgayLam as LuongThucTe, Ngaylamviec.SoNgayLam, ChucVu.HeSoChucVu*1800000 AS HesoCV, (BacLuong.HeSoLuong * 1800000 / 22 * Ngaylamviec.SoNgayLam) + (ChucVu.HeSoChucVu * 1800000) + Ngaylamviec.TongThuong - Ngaylamviec.TongTru AS Thuclanh FROM NhanVien INNER JOIN ChucVu ON ChucVu.MaChucVu = NhanVien.MaChucVu INNER JOIN BacLuong ON BacLuong.MaBacLuong = NhanVien.MaBacLuong INNER JOIN Ngaylamviec ON Ngaylamviec.MaNV = NhanVien.MaNV WHERE NhanVien.Xoa = 0";

            if (!string.IsNullOrEmpty(cbxThangDS.SelectedItem?.ToString()) && !string.IsNullOrEmpty(cbxNamDS.SelectedItem?.ToString()))
            {
                sql += " AND Ngaylamviec.ThangLam = " + cbxThangDS.SelectedItem.ToString() +
                       " AND Ngaylamviec.NamLam = " + cbxNamDS.SelectedItem.ToString();
            }

            if (!string.IsNullOrEmpty(cbxPhongban.SelectedValue?.ToString()))
            {
                sql += " AND NhanVien.MaPhongBan = '" + cbxPhongban.SelectedValue.ToString() + "'";
            }

            sql += " GROUP BY Ngaylamviec.MaNV, Ngaylamviec.ThangLam, Ngaylamviec.NamLam, NhanVien.TenNV, ChucVu.TenChucVu, BacLuong.HeSoLuong, Ngaylamviec.SoNgayLam, ChucVu.HeSoChucVu, Ngaylamviec.TongThuong, Ngaylamviec.TongTru";

            SqlDataAdapter ad = new SqlDataAdapter(sql, MyCon);
            DataTable dt1 = new DataTable();
            ad.Fill(dt1);

            dgvBangluong.DataSource = dt1;
            dgvBangluong.AllowUserToAddRows = false;
            dgvBangluong.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvBangluong.RowTemplate.Height = 30;

            // Thiết lập font chữ cho các ô dữ liệu và tiêu đề cột
            dgvBangluong.DefaultCellStyle.Font = new Font("Arial", 10); // Điều chỉnh kích thước font chữ cho ô dữ liệu
            dgvBangluong.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold); // Điều chỉnh kích thước font chữ cho tiêu đề cột

            dgvBangluong.ColumnHeadersDefaultCellStyle.BackColor = Color.MediumSlateBlue;
            dgvBangluong.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvBangluong.DefaultCellStyle.ForeColor = Color.Black;
            dgvBangluong.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvBangluong.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvBangluong.Columns["MaNV"].HeaderText = "Mã NV";
            dgvBangluong.Columns["TenNV"].HeaderText = "Tên NV";
            dgvBangluong.Columns["TenChucVu"].HeaderText = "Chức Vụ";
            dgvBangluong.Columns["ThangLam"].HeaderText = "Tháng Làm";
            dgvBangluong.Columns["NamLam"].HeaderText = "Năm Làm";
            dgvBangluong.Columns["TongThuong"].HeaderText = "Tổng Thưởng";
            dgvBangluong.Columns["TongTru"].HeaderText = "Các khoản trừ";
            dgvBangluong.Columns["Luongcoban"].HeaderText = "Lương Cơ Bản";
            dgvBangluong.Columns["LuongThucTe"].HeaderText = "Lương Thực Tế";
            dgvBangluong.Columns["SoNgayLam"].HeaderText = "Số Ngày Làm";
            dgvBangluong.Columns["HesoCV"].HeaderText = "Phụ Cấp Chức Vụ";
            dgvBangluong.Columns["Thuclanh"].HeaderText = "Thực Lãnh";
        }
        private void btXoa_Click_1(object sender, EventArgs e)
        {

        }

        private void cbxPhongban_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbxThangDS_SelectionChangeCommitted(object sender, EventArgs e)
        {
            loadtagridDieukien();
        }

        private void cbxNamDS_SelectionChangeCommitted(object sender, EventArgs e)
        {
            loadtagridDieukien();
        }

        private void btIn_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Inbangluong());
            
        }
        private Form currentFormChild;
        private void OpenChildForm(Form childForm)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            currentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelcontainer.Controls.Add(childForm);
            panelcontainer.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
    }
}
