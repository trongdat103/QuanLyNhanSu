using Guna.UI2.WinForms;
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
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing.Drawing2D;
using CrystalDecisions.CrystalReports.Engine;

namespace QLLUONGNV
{
    public partial class Nhanvien : Form
    {
        SqlConnection MyCon = new SqlConnection(@"Data Source=TRONGDAT\SQLEXPRESS;Initial Catalog=QLNhanvienluong;Integrated Security=True");
        public Nhanvien()
        {
            InitializeComponent();
        }
        private void Nhanvien_Load(object sender, EventArgs e)
        {
            butSuaLuu.Visible = false;
            btLuu.Visible = false;
            Butthongtin.Visible = false;
            Load_MaBacluong();
            Load_Chucvu();
            Load_Phucap();
            Load_Phongban();
            LoadDLGridViewAll();
            //LoadDataToChart();
            
        }

        private void Load_Phongban()
        {
            string sqlphongban = "select  MaPhongBan, TenPhongBan  from PhongBan ";
            SqlDataAdapter adapter = new SqlDataAdapter(sqlphongban, MyCon);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            cbxPhongbann.DataSource = dt;
            cbxPhongbann.DisplayMember = "TenPhongBan";
            cbxPhongbann.ValueMember = "MaPhongBan";
        }
        private void LoadDLGridViewAll()
        {
            string sql = "select * from NhanVien where Xoa = 0";
            SqlDataAdapter ad = new SqlDataAdapter(sql, MyCon);
            DataTable dt1 = new DataTable();
            ad.Fill(dt1);
            gvdNhanvien.DataSource = dt1;
            gvdNhanvien.AllowUserToAddRows = false;
            gvdNhanvien.EditMode = DataGridViewEditMode.EditProgrammatically;
            gvdNhanvien.DataSource = dt1;
            gvdNhanvien.AllowUserToAddRows = false;
            gvdNhanvien.RowTemplate.Height = 30;
            gvdNhanvien.ColumnHeadersDefaultCellStyle.BackColor = Color.MediumSlateBlue; // Đổi màu thành màu đỏ
            gvdNhanvien.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            gvdNhanvien.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
            gvdNhanvien.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            gvdNhanvien.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvdNhanvien.EditMode = DataGridViewEditMode.EditProgrammatically;
            gvdNhanvien.Columns[0].HeaderText = "Mã Nhân Viên";
            gvdNhanvien.Columns[1].HeaderText = "Họ Và Tên";
            gvdNhanvien.Columns[2].HeaderText = "Giới Tính";
            gvdNhanvien.Columns[3].HeaderText = "Ngày Sinh";
            gvdNhanvien.Columns[4].HeaderText = "Địa Chỉ";
            gvdNhanvien.Columns[5].HeaderText = "Điện Thoại";
            gvdNhanvien.Columns[6].HeaderText = "Trình Độ";
            gvdNhanvien.Columns[7].HeaderText = "Quốc Tịch";
            gvdNhanvien.Columns[8].HeaderText = "Dân Tộc";
            gvdNhanvien.Columns[9].HeaderText = "Tôn Giaó";
            gvdNhanvien.Columns[10].HeaderText = "Số Chứng Minh";
            gvdNhanvien.Columns[11].HeaderText = "Ngày Cấp";
            gvdNhanvien.Columns[12].HeaderText = "Nơi Cấp";
            gvdNhanvien.Columns[13].HeaderText = "Địa Chỉ Thường Chú";
            gvdNhanvien.Columns[14].HeaderText = "Địa Chỉ Tạm Chú";
            gvdNhanvien.Columns[15].HeaderText = "Ngày Vào Làm";
            gvdNhanvien.Columns[16].HeaderText = "Ngoại Ngữ";
            gvdNhanvien.Columns[17].HeaderText = "Tin Học";
            gvdNhanvien.Columns[18].HeaderText = "Bậc Lương";
            gvdNhanvien.Columns[19].HeaderText = "Chức Vụ";
            gvdNhanvien.Columns[20].HeaderText = "Phụ Cấp";
            gvdNhanvien.Columns[21].HeaderText = "Phòng Ban";
            gvdNhanvien.Columns[22].HeaderText = "Hình ảnh";
        }
        private void cbxPhongbann_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            
        }
        private void LoadDLGridView()
        {
            //string sql = "select NhanVien.* from NhanVien inner join PhongBan on PhongBan.MaPhongBan  = NhanVien.MaPhongBan where NhanVien.MaPhongBan = '" + cbxPhongbann.SelectedValue.ToString() + "'";
            string sql = "select NhanVien.* from NhanVien inner join PhongBan on PhongBan.MaPhongBan = NhanVien.MaPhongBan where NhanVien.MaPhongBan = '" + cbxPhongbann.SelectedValue.ToString() + "' and NhanVien.Xoa = 0";
            SqlDataAdapter ad = new SqlDataAdapter(sql, MyCon);
            DataTable dt1 = new DataTable();
            ad.Fill(dt1);
            gvdNhanvien.DataSource = dt1;
            gvdNhanvien.AllowUserToAddRows = false;
            gvdNhanvien.EditMode = DataGridViewEditMode.EditProgrammatically;
            gvdNhanvien.DataSource = dt1;
            gvdNhanvien.AllowUserToAddRows = false;
            gvdNhanvien.RowTemplate.Height = 30;
            gvdNhanvien.ColumnHeadersDefaultCellStyle.BackColor = Color.MediumSlateBlue; // Đổi màu thành màu đỏ
            gvdNhanvien.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            gvdNhanvien.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
            gvdNhanvien.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            gvdNhanvien.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvdNhanvien.EditMode = DataGridViewEditMode.EditProgrammatically;
            gvdNhanvien.Columns[0].HeaderText = "Mã Nhân Viên";
            gvdNhanvien.Columns[1].HeaderText = "Họ Và Tên";
            gvdNhanvien.Columns[2].HeaderText = "Giới Tính";
            gvdNhanvien.Columns[3].HeaderText = "Ngày Sinh";
            gvdNhanvien.Columns[4].HeaderText = "Địa Chỉ";
            gvdNhanvien.Columns[5].HeaderText = "Điện Thoại";
            gvdNhanvien.Columns[6].HeaderText = "Trình Độ";
            gvdNhanvien.Columns[7].HeaderText = "Quốc Tịch";
            gvdNhanvien.Columns[8].HeaderText = "Dân Tộc";
            gvdNhanvien.Columns[9].HeaderText = "Tôn Giaó";
            gvdNhanvien.Columns[10].HeaderText = "Số Chứng Minh";
            gvdNhanvien.Columns[11].HeaderText = "Ngày Cấp";
            gvdNhanvien.Columns[12].HeaderText = "Nơi Cấp";
            gvdNhanvien.Columns[13].HeaderText = "Địa Chỉ Thường Chú";
            gvdNhanvien.Columns[14].HeaderText = "Địa Chỉ Tạm Chú";
            gvdNhanvien.Columns[15].HeaderText = "Ngày Vào Làm";
            gvdNhanvien.Columns[16].HeaderText = "Ngoại Ngữ";
            gvdNhanvien.Columns[17].HeaderText = "Tin Học";
            gvdNhanvien.Columns[18].HeaderText = "Bậc Lương";
            gvdNhanvien.Columns[19].HeaderText = "Chức Vụ";
            gvdNhanvien.Columns[20].HeaderText = "Phụ Cấp";
            gvdNhanvien.Columns[21].HeaderText = "Phòng Ban";
            gvdNhanvien.Columns[22].HeaderText = "Hình ảnh";
        }
        private void Load_MaBacluong()
        {
            string sqlBacluong = "select MaBacLuong  from BacLuong";
            SqlDataAdapter adapter = new SqlDataAdapter(sqlBacluong, MyCon);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            cbxBacluong.DataSource = dt;
            cbxBacluong.DisplayMember = "MaBacLuong";
            cbxBacluong.ValueMember = "MaBacLuong";
        }
        private void Load_Chucvu()
        {
            string sqlchucvu = "select TenChucVu, MaChucVu  from ChucVu";
            SqlDataAdapter adapter = new SqlDataAdapter(sqlchucvu, MyCon);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            CbxChucvu.DataSource = dt;
            CbxChucvu.DisplayMember = "TenChucVu";
            CbxChucvu.ValueMember = "MaChucVu";
        }
        private void Load_Phucap()
        {
            string sqlphucap = "select MaPhuCap, TenPhuCap  from PhuCap";
            SqlDataAdapter adapter = new SqlDataAdapter(sqlphucap, MyCon);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            cbxPhucap.DataSource = dt;
            cbxPhucap.DisplayMember = "TenPhuCap";
            cbxPhucap.ValueMember = "MaPhuCap";
        }

        private void btThem_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void gvdNhanvien_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int dong;
            dong = e.RowIndex;
            txtManv.Text = gvdNhanvien.Rows[dong].Cells[0].Value.ToString();
            txtTennv.Text = gvdNhanvien.Rows[dong].Cells[1].Value.ToString();
            txtGioitinh.Text = gvdNhanvien.Rows[dong].Cells[2].Value.ToString();
            dtpNgaysinh.Text = gvdNhanvien.Rows[dong].Cells[3].Value.ToString();
            txtDiachi.Text = gvdNhanvien.Rows[dong].Cells[4].Value.ToString();
            txtDienThoai.Text = gvdNhanvien.Rows[dong].Cells[5].Value.ToString();
            string CellTrinhdo = gvdNhanvien.Rows[dong].Cells[6].Value.ToString();
            int indexTrinhdo = cbxTrinhdo.FindStringExact(CellTrinhdo);
            if (indexTrinhdo != -1)
            {
                cbxTrinhdo.SelectedIndex = indexTrinhdo;
            }
            string CellQuoctich = gvdNhanvien.Rows[dong].Cells[7].Value.ToString();
            int indexQuoctich = cbxQuoctich.FindStringExact(CellQuoctich);
            if (indexQuoctich != -1)
            {
                cbxQuoctich.SelectedIndex = indexQuoctich;
            }
            string CellDantoc = gvdNhanvien.Rows[dong].Cells[8].Value.ToString();
            int indexDantoc = cbxDantoc.FindStringExact(CellDantoc);
            if (indexDantoc != -1)
            {
                cbxDantoc.SelectedIndex = indexDantoc;
            }
            txtTongiao.Text = gvdNhanvien.Rows[dong].Cells[9].Value.ToString();
            txtCMND.Text = gvdNhanvien.Rows[dong].Cells[10].Value.ToString();
            dtpNgaycap.Text = gvdNhanvien.Rows[dong].Cells[11].Value.ToString();
            txtNoicap.Text = gvdNhanvien.Rows[dong].Cells[12].Value.ToString();
            txtThuongchu.Text = gvdNhanvien.Rows[dong].Cells[13].Value.ToString();
            txtTamchu.Text = gvdNhanvien.Rows[dong].Cells[14].Value.ToString();
            dtpNgayvaolam.Text = gvdNhanvien.Rows[dong].Cells[15].Value.ToString();
            txtNgoaingu.Text = gvdNhanvien.Rows[dong].Cells[16].Value.ToString();
            txtTinhoc.Text = gvdNhanvien.Rows[dong].Cells[17].Value.ToString();
            cbxBacluong.Text = gvdNhanvien.Rows[dong].Cells[18].Value.ToString();
            CbxChucvu.SelectedValue = gvdNhanvien.Rows[dong].Cells[19].Value.ToString();
            cbxPhucap.SelectedValue = gvdNhanvien.Rows[dong].Cells[20].Value.ToString();
            cbxPhongbann.SelectedValue = gvdNhanvien.Rows[dong].Cells[21].Value.ToString();           
            object value = gvdNhanvien.Rows[dong].Cells[22].Value;
            // Kiểm tra nếu giá trị không phải là DBNull và không null
            if (value != DBNull.Value && value != null)
            {
                byte[] b = (byte[])value;
                picavartar.Image = ByteArrayToImage(b);
            }
            else
            {
                // Nếu giá trị là DBNull hoặc null, gán hình ảnh rỗng cho PictureBox
                picavartar.Image = null;
            }

        }
        Image ByteArrayToImage(byte[] b)
        {
            MemoryStream m = new MemoryStream(b);
            return Image.FromStream(m);
        }

        private void btSua_Click_1(object sender, EventArgs e)
        {
            btIn.Visible = false;
            gvdNhanvien.Visible = false;
            GroupboxThongtin.Visible = true;
            Butthongtin.Visible = true;
            btTimKiem.Visible = false;
            btThem.Visible = false;
            txtTimkiem.Visible = false;
            butSuaLuu.Visible = true;
            btLuu.Visible = false;
            btTatca.Visible = false;
            guna2HtmlLabel3.Text = "CHỈNH SỬA THÔNG TIN NHÂN VIÊN";
        }


        private void txtManv_MouseClick(object sender, MouseEventArgs e)
        {
            txtManv.ForeColor = Color.Black;
        }

        private void txtManv_MouseLeave(object sender, EventArgs e)
        {
            txtManv.ForeColor = System.Drawing.Color.FromArgb(125, 137, 149);
        }

        private void cbxPhongbann_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Butthongtin_Click_1(object sender, EventArgs e)
        {
            btIn.Visible = true;
            gvdNhanvien.Visible = true;
            GroupboxThongtin.Visible = false;
            Butthongtin.Visible = false;
            btTimKiem.Visible = true;
            btThem.Visible = true;
            txtTimkiem.Visible = true;
        }

        private void dgvnhanvienall_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cbxPhongbann_Click(object sender, EventArgs e)
        {
           
        }
        bool NvInPhong = false;
        private void cbxPhongbann_SelectionChangeCommitted(object sender, EventArgs e)
        {
            NvInPhong = true;
            btTatca.Visible = true;
            gvdNhanvien.Visible = true;
            LoadDLGridView();
        }

        private void btTatca_Click(object sender, EventArgs e)
        {

        }

        private void picavartar_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                picavartar.Image = Image.FromFile(open.FileName);
                this.Text = open.FileName;
            }
        }
        bool them = false;
        private void btThem_Click_1(object sender, EventArgs e)
        {
            btIn.Visible = false;
            guna2HtmlLabel3.Text = "THÊM MỚI THÔNG TIN NHÂN VIÊN";
            butSuaLuu.Visible = false;
            btLuu.Visible = true;
            them = true;
            txtManv.ResetText();
            txtTennv.ResetText();
            txtGioitinh.ResetText();
            dtpNgaysinh.Text = null;
            txtDiachi.ResetText();
            txtDienThoai.ResetText();
            cbxTrinhdo.ResetText();
            cbxQuoctich.ResetText();
            cbxDantoc.ResetText();
            txtTongiao.ResetText();
            txtCMND.ResetText();
            dtpNgaycap.Text = null;
            txtNoicap.ResetText();
            txtThuongchu.ResetText();
            txtTamchu.ResetText();
            dtpNgayvaolam.Text = null;
            txtNgoaingu.ResetText();
            txtTinhoc.ResetText();
            cbxBacluong.ResetText();
            cbxPhongbann.ResetText();
            cbxPhucap.ResetText();
            CbxChucvu.ResetText();
            GroupboxThongtin.Visible = true;
            Butthongtin.Visible = true;
            btTimKiem.Visible = false;
            btThem.Visible = false;
            txtTimkiem.Visible = false;
            GanMaNVlOAD();
        }
        private void GanMaNVlOAD()
        {
            if (MyCon.State == ConnectionState.Closed)
                MyCon.Open();
            string tongtienHD = "select MaPhongBan FROM  PhongBan where PhongBan.MaPhongBan = '" + cbxPhongbann.SelectedValue.ToString() + "'";
            SqlCommand cmd3 = new SqlCommand(tongtienHD, MyCon);
            cmd3.ExecuteNonQuery();
            txtManv.Text = Convert.ToString(cmd3.ExecuteScalar());
            MyCon.Close();
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            try
            {
            int Tinhtrangxoa = 0;
            if (them == true)
            {               
                byte[] b = ImageToByteArray(picavartar.Image);
                MyCon.Open();              
                //string sql1 = "Insert into NhanVien (MaNV, TenNV, GioiTinh,NgaySinh,DiaChi,SĐT,TrinhDo,QuocTinh,DanToc,TonGiao,SoCCCD,NgayCap,NoiCap,DiaChiThuongTru,DiaChiTamTru,NgayVaoLam,NgoaiNgu,TinHoc,MaBacLuong,MaChucVu,MaPhuCap,MaPhongBan,HinhAnh,Xoa) values('" + txtManv.Text + "',N'" + txtTennv.Text + "',N'" + txtGioitinh.Text + "','" + dtpNgaysinh.Text + "',N'" + txtDiachi.Text + "','" + txtDienThoai.Text + "',N'" + txtTrinhdo.Text + "',N'" + txtQuoctich.Text + "',N'" + txtDantoc.Text + "',N'" + txtTongiao.Text + "',N'" + txtCMND.Text + "',N'" + dtpNgaycap.Text + "',N'" + txtNoicap.Text + "',N'" + txtThuongchu.Text + "',N'" + txtTamchu.Text + "',N'" + dtpNgayvaolam.Text + "',N'" + txtNgoaingu.Text + "',N'" + txtTinhoc.Text + "',N'" + cbxBacluong.Text + "',N'" + CbxChucvu.SelectedValue.ToString() + "',N'" + cbxPhucap.SelectedValue.ToString() + "',N'" + cbxPhongbann.SelectedValue.ToString() + "', @HinhAnh'" + "','" + Tinhtrangxoa + "')";
                string sql1 = "INSERT INTO NhanVien (MaNV, TenNV, GioiTinh, NgaySinh, DiaChi, SĐT, TrinhDo, QuocTinh, DanToc, TonGiao, SoCCCD, NgayCap, NoiCap, DiaChiThuongTru, DiaChiTamTru, NgayVaoLam, NgoaiNgu, TinHoc, MaBacLuong, MaChucVu, MaPhuCap, MaPhongBan, HinhAnh, Xoa) " +
                "VALUES ('" + txtManv.Text + "', N'" + txtTennv.Text + "', N'" + txtGioitinh.Text + "', '" + dtpNgaysinh.Text + "', N'" + txtDiachi.Text + "', '" + txtDienThoai.Text + "', N'" + cbxTrinhdo.Text + "', N'" + cbxQuoctich.Text + "', N'" + cbxDantoc.Text + "', N'" + txtTongiao.Text + "', N'" + txtCMND.Text + "', N'" + dtpNgaycap.Text + "', N'" + txtNoicap.Text + "', N'" + txtThuongchu.Text + "', N'" + txtTamchu.Text + "', N'" + dtpNgayvaolam.Text + "', N'" + txtNgoaingu.Text + "', N'" + txtTinhoc.Text + "', N'" + cbxBacluong.Text + "', N'" + CbxChucvu.SelectedValue.ToString() + "', N'" + cbxPhucap.SelectedValue.ToString() + "', N'" + cbxPhongbann.SelectedValue.ToString() + "', @HinhAnh, " + Tinhtrangxoa + ")";
                SqlCommand Cmd1 = new SqlCommand(sql1, MyCon);
                Cmd1.Parameters.AddWithValue("@HinhAnh", b);
                Cmd1.ExecuteNonQuery();
                LoadDLGridView();
                GroupboxThongtin.Visible = false;
                gvdNhanvien.Visible = true;
                MessageBox.Show("Đã lưu thành công !", "Thông Báo");
                txtManv.ResetText();
                txtTennv.ResetText();
                txtGioitinh.ResetText();
                dtpNgaysinh.Text = null;
                txtDiachi.ResetText();
                txtDienThoai.ResetText();
                cbxTrinhdo.ResetText();
                cbxQuoctich.ResetText();
                cbxDantoc.ResetText();
                txtTongiao.ResetText();
                txtCMND.ResetText();
                dtpNgaycap.Text = null;
                txtNoicap.ResetText();
                txtThuongchu.ResetText();
                txtTamchu.ResetText();
                dtpNgayvaolam.Text = null;
                txtNgoaingu.ResetText();
                txtTinhoc.ResetText();
                btTimKiem.Visible = true;
                btThem.Visible = true;
                txtTimkiem.Visible = true;
                btIn.Visible = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Đã có nhân viên này trong danh sách ! ", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                txtManv.ResetText();
                txtTennv.ResetText();
                txtGioitinh.ResetText();
                dtpNgaysinh.Text = null;
                txtDiachi.ResetText();
                txtDienThoai.ResetText();
                cbxTrinhdo.ResetText();
                cbxQuoctich.ResetText();
                cbxDantoc.ResetText();
                txtTongiao.ResetText();
                txtCMND.ResetText();
                dtpNgaycap.Text = null;
                txtNoicap.ResetText();
                txtThuongchu.ResetText();
                txtTamchu.ResetText();
                dtpNgayvaolam.Text = null;
                txtNgoaingu.ResetText();
                txtTinhoc.ResetText();
            }
            finally
            {
                MyCon.Close();
            }
            byte[] ImageToByteArray(Image img)
            {
                MemoryStream m = new MemoryStream();
                img.Save(m, System.Drawing.Imaging.ImageFormat.Png);
                return m.ToArray();
            }
        }
        private void gvdNhanvien_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (gvdNhanvien.Columns[e.ColumnIndex].HeaderText == "Hình ảnh")
            {
                // Đảm bảo giá trị của ô không rỗng và là loại byte[]
                if (e.Value != null && e.Value != DBNull.Value && e.Value.GetType() == typeof(byte[]))
                {
                    byte[] imageData = (byte[])e.Value;

                    // Chuyển đổi dữ liệu hình ảnh từ mảng byte thành hình ảnh
                    using (MemoryStream ms = new MemoryStream(imageData))
                    {
                        Image img = Image.FromStream(ms);

                        // Chỉnh kích thước mong muốn cho hình ảnh
                        int desiredWidth = 30; // Chiều rộng mong muốn của hình ảnh
                        int desiredHeight = 30; // Chiều cao mong muốn của hình ảnh
                        Image resizedImage = (Image)(new Bitmap(img, new Size(desiredWidth, desiredHeight)));

                        // Gán hình ảnh đã chỉnh kích thước vào giá trị của ô
                        e.Value = resizedImage;
                    }
                }
            }
        }

        private void butSuaLuu_Click(object sender, EventArgs e)
        {
            byte[] b = null;

            // Chuyển đổi hình ảnh sang mảng byte nếu hình ảnh không null
            if (picavartar.Image != null)
            {
                b = ImageToByteArray(picavartar.Image);
            }

            int currentIndex = gvdNhanvien.CurrentCell.RowIndex;
            string IDnhanVien = Convert.ToString(gvdNhanvien.Rows[currentIndex].Cells[0].Value.ToString());

            if (txtManv.Text == IDnhanVien)
            {
                MyCon.Open();
                string sql2 = "UPDATE NhanVien SET TenNV = N'" + txtTennv.Text + "', " +
                                "GioiTinh = N'" + txtGioitinh.Text + "', " +
                                "NgaySinh = N'" + dtpNgaysinh.Text + "', " +
                                "DiaChi = N'" + txtDiachi.Text + "', " +
                                "SĐT = N'" + txtDienThoai.Text + "', " +
                                "TrinhDo = N'" + cbxTrinhdo.Text + "', " +
                                "QuocTinh = N'" + cbxQuoctich.Text + "', " +
                                "DanToc = N'" + cbxDantoc.Text + "', " +
                                "TonGiao = N'" + txtTongiao.Text + "', " +
                                "SoCCCD = N'" + txtCMND.Text + "', " +
                                "NgayCap = N'" + dtpNgaycap.Text + "', " +
                                "NoiCap = N'" + txtNoicap.Text + "', " +
                                "DiaChiThuongTru = N'" + txtThuongchu.Text + "', " +
                                "DiaChiTamTru = N'" + txtTamchu.Text + "', " +
                                "NgayVaoLam = N'" + dtpNgayvaolam.Text + "', " +
                                "NgoaiNgu = N'" + txtNgoaingu.Text + "', " +
                                "TinHoc = N'" + txtTinhoc.Text + "', " +
                                "MaBacLuong = N'" + cbxBacluong.Text + "', " +
                                "MaChucVu = N'" + CbxChucvu.SelectedValue.ToString() + "', " +
                                "MaPhuCap = N'" + cbxPhucap.SelectedValue.ToString() + "', " +
                                "MaPhongBan = N'" + cbxPhongbann.SelectedValue.ToString() + "', " +
                                "HinhAnh = @HinhAnh " +
                                "WHERE MaNV = '" + txtManv.Text + "'";

                SqlCommand Cmd2 = new SqlCommand(sql2, MyCon);
                Cmd2.Parameters.Add("@HinhAnh", SqlDbType.VarBinary).Value = (object)b ?? DBNull.Value;
                Cmd2.ExecuteNonQuery();
                Butthongtin.Visible = false;
                LoadDLGridView();
                GroupboxThongtin.Visible = false;
                gvdNhanvien.Visible = true;
                btIn.Visible = true;
                btTimKiem.Visible = true;
                btThem.Visible = true;
                txtTimkiem.Visible = true;
                MessageBox.Show("Cập nhật thành công !", "Thông Báo");
            }
            else
            {
                MessageBox.Show("Không được thay đổi mã nhân viên!", "Thông Báo");
            }

            MyCon.Close();

            byte[] ImageToByteArray(Image img)
            {
                MemoryStream m = new MemoryStream();
                img.Save(m, System.Drawing.Imaging.ImageFormat.Png);
                return m.ToArray();
            }
        }

        private void btTatca_Click_1(object sender, EventArgs e)
        {

            btTatca.Visible = false;
            NvInPhong = false;
            LoadDLGridViewAll();
        }

        private void btTimKiem_Click(object sender, EventArgs e)
        {
            LoadTimkiem();
            btTatca.Visible = true;
        }
        private void LoadTimkiem()
        {

            //string sqll = "select * from NhanVien WHERE TenNV like N'%" + txtTimkiem.Text + "%' or MaNV like N'%" + txtTimkiem.Text +"%' or DiaChi like N'%" + txtTimkiem.Text +"%'";
            string sqll = "select * from NhanVien WHERE (TenNV like N'%" + txtTimkiem.Text + "%' or MaNV like N'%" + txtTimkiem.Text + "%' or DiaChi like N'%" + txtTimkiem.Text + "%') and Xoa = 0";
            SqlDataAdapter ad = new SqlDataAdapter(sqll, MyCon);
            DataTable dt1 = new DataTable();
            ad.Fill(dt1);
            gvdNhanvien.DataSource = dt1;
            gvdNhanvien.AllowUserToAddRows = false;
            gvdNhanvien.EditMode = DataGridViewEditMode.EditProgrammatically;
            gvdNhanvien.RowTemplate.Height = 30;
            gvdNhanvien.ColumnHeadersDefaultCellStyle.BackColor = Color.MediumSlateBlue; // Đổi màu thành màu đỏ
            gvdNhanvien.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            gvdNhanvien.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
            gvdNhanvien.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            gvdNhanvien.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvdNhanvien.EditMode = DataGridViewEditMode.EditProgrammatically;
            gvdNhanvien.Columns[0].HeaderText = "Mã Nhân Viên";
            gvdNhanvien.Columns[1].HeaderText = "Họ Và Tên";
            gvdNhanvien.Columns[2].HeaderText = "Giới Tính";
            gvdNhanvien.Columns[3].HeaderText = "Ngày Sinh";
            gvdNhanvien.Columns[4].HeaderText = "Địa Chỉ";
            gvdNhanvien.Columns[5].HeaderText = "Điện Thoại";
            gvdNhanvien.Columns[6].HeaderText = "Trình Độ";
            gvdNhanvien.Columns[7].HeaderText = "Quốc Tịch";
            gvdNhanvien.Columns[8].HeaderText = "Dân Tộc";
            gvdNhanvien.Columns[9].HeaderText = "Tôn Giaó";
            gvdNhanvien.Columns[10].HeaderText = "Số Chứng Minh";
            gvdNhanvien.Columns[11].HeaderText = "Ngày Cấp";
            gvdNhanvien.Columns[12].HeaderText = "Nơi Cấp";
            gvdNhanvien.Columns[13].HeaderText = "Địa Chỉ Thường Chú";
            gvdNhanvien.Columns[14].HeaderText = "Địa Chỉ Tạm Chú";
            gvdNhanvien.Columns[15].HeaderText = "Ngày Vào Làm";
            gvdNhanvien.Columns[16].HeaderText = "Ngoại Ngữ";
            gvdNhanvien.Columns[17].HeaderText = "Tin Học";
            gvdNhanvien.Columns[18].HeaderText = "Bậc Lương";
            gvdNhanvien.Columns[19].HeaderText = "Chức Vụ";
            gvdNhanvien.Columns[20].HeaderText = "Phụ Cấp";
            gvdNhanvien.Columns[21].HeaderText = "Phòng Ban";
            gvdNhanvien.Columns[22].HeaderText = "Hình ảnh";
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            if (MyCon.State == ConnectionState.Closed)
                MyCon.Open();

            if (gvdNhanvien.SelectedCells.Count > 0)
            {
                DialogResult Traloi;
                Traloi = MessageBox.Show("Bạn có chắc chắn xóa không?",
               "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Traloi == DialogResult.Yes)
                {
                    int tinhtrangXoa = 1;
                    int currentIndex = gvdNhanvien.CurrentCell.RowIndex;
                    string IDnhanvien = Convert.ToString(gvdNhanvien.Rows[currentIndex].Cells[0].Value.ToString());
                    string sql3 = "UPDATE NHANVIEN SET Xoa = " + tinhtrangXoa + " WHERE MaNV = '" + IDnhanvien + "'";
                    SqlCommand cmd3 = new SqlCommand(sql3, MyCon);
                    cmd3.ExecuteNonQuery();                       
                    LoadDLGridViewAll();
                    MessageBox.Show("Xóa thành công !", "Thông Báo");
                }
            }
            else MessageBox.Show("Cần chọn dòng cần xóa");
            MyCon.Close();
        }

        private void txtTimkiem_TextChanged(object sender, EventArgs e)
        {
            LoadTimkiem();
        }

        private void btIn_Click(object sender, EventArgs e)
        {
            LoadBaoCaoNhanVien();
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
        private void LoadBaoCaoNhanVien()
        {
            // Lấy dữ liệu từ DataGridView gvdNhanvien
            DataTable dt = GetDataTableFromDataGridView(gvdNhanvien);

            // Tạo báo cáo và thiết lập dữ liệu nguồn
            CrystalReportNhanVien rpt = new CrystalReportNhanVien();
            rpt.SetDataSource(dt);
            string selectedText = cbxPhongbann.Text;
            if (NvInPhong == true)
            {
                // Truyền giá trị vào TextObject trong báo cáo
                TextObject txtPhongban = (TextObject)rpt.ReportDefinition.Sections["Section1"].ReportObjects["txtPhongban"];
                txtPhongban.Text = selectedText;
            }
            else
            {
                string tatca = "Tất cả";
                TextObject txtPhongban = (TextObject)rpt.ReportDefinition.Sections["Section1"].ReportObjects["txtPhongban"];
                txtPhongban.Text = tatca;
            }
            // Hiển thị báo cáo trong Form2
            InNhanVien form2 = new InNhanVien();
            form2.ShowReport(rpt);
            form2.ShowDialog();
        }
    }
}


