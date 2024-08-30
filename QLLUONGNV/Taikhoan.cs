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
    public partial class Taikhoan : Form
    {
        SqlConnection MyCon = new SqlConnection(@"Data Source=TRONGDAT\SQLEXPRESS;Initial Catalog=QLNhanvienluong;Integrated Security=True");
        public Taikhoan()
        {
            InitializeComponent();
        }

        private void btDangnhap_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTaikhoan.Text) || string.IsNullOrEmpty(txtMatkhau.Text))
            {
                MessageBox.Show("Vui lòng nhập tài khoản và mật khẩu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (picavartar.Image == null)
            {
                MessageBox.Show("Vui lòng chọn hình ảnh đại diện.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            byte[] b = ImageToByteArray(picavartar.Image);

            try
            {
                MyCon.Open();
                string sql1 = "INSERT INTO TaiKhoan (TaiKhoan, MatKhau, TenTaiKhoan, Quyen, Hinhanh) VALUES (@TaiKhoan, @MatKhau, @TenTaiKhoan, @Quyen, @HinhAnh)";
                using (SqlCommand command = new SqlCommand(sql1, MyCon))
                {
                    command.Parameters.AddWithValue("@TaiKhoan", txtTaikhoan.Text);
                    command.Parameters.AddWithValue("@MatKhau", txtMatkhau.Text);
                    command.Parameters.AddWithValue("@TenTaiKhoan", txtTenhienthi.Text);
                    command.Parameters.AddWithValue("@Quyen", CbxQuyen.Text);
                    command.Parameters.AddWithValue("@HinhAnh", b);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Đã thêm thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDLGridView();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Tài khoản đã tồn tại!!! ", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
            finally
            {
                MyCon.Close();
            }

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

        private byte[] ImageToByteArray(Image img)
        {
            using (MemoryStream m = new MemoryStream())
            {
                img.Save(m, System.Drawing.Imaging.ImageFormat.Png);
                return m.ToArray();
            }
        }


        private void btThem_Click(object sender, EventArgs e)
        {

        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            if (MyCon.State == ConnectionState.Closed)
                MyCon.Open();

            if (dgvTaikhoan.SelectedCells.Count > 0)
            {
                DialogResult Traloi;
                Traloi = MessageBox.Show("Bạn có chắc chắn xóa không?",
               "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Traloi == DialogResult.Yes)
                {
                    int currentIndex = dgvTaikhoan.CurrentCell.RowIndex;
                    string Taikhoan = Convert.ToString(dgvTaikhoan.Rows[currentIndex].Cells[0].Value.ToString());
                    string sql3 = "delete from TaiKhoan where TaiKhoan ='" + Taikhoan + "'";
                    SqlCommand cmd3 = new SqlCommand(sql3, MyCon);
                    cmd3.ExecuteNonQuery();
                    LoadDLGridView();
                }
            }
            else MessageBox.Show("Cần chọn dòng cần xóa");
            MyCon.Close();
        }
        private void LoadDLGridView()
        {
            //string sql = "select NhanVien.* from NhanVien inner join PhongBan on PhongBan.MaPhongBan  = NhanVien.MaPhongBan where NhanVien.MaPhongBan = '" + cbxPhongbann.SelectedValue.ToString() + "'";
            string sql = "select * from TaiKhoan";
            SqlDataAdapter ad = new SqlDataAdapter(sql, MyCon);
            DataTable dt1 = new DataTable();
            ad.Fill(dt1);
            dgvTaikhoan.DataSource = dt1;
            dgvTaikhoan.AllowUserToAddRows = false;
            dgvTaikhoan.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvTaikhoan.DataSource = dt1;
            dgvTaikhoan.AllowUserToAddRows = false;
            dgvTaikhoan.RowTemplate.Height = 30;
            dgvTaikhoan.ColumnHeadersDefaultCellStyle.BackColor = Color.MediumSlateBlue; // Đổi màu thành màu đỏ
            dgvTaikhoan.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvTaikhoan.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
            dgvTaikhoan.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvTaikhoan.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvTaikhoan.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvTaikhoan.Columns[0].HeaderText = "Tên tài khoản";
            dgvTaikhoan.Columns[1].HeaderText = "Mật khẩu";
            dgvTaikhoan.Columns[2].HeaderText = "Tên hiển thị";
            dgvTaikhoan.Columns[3].HeaderText = "Quyền";
            dgvTaikhoan.Columns[4].HeaderText = "Hình ảnh";
        }

        private void Taikhoan_Load(object sender, EventArgs e)
        {
            LoadDLGridView();
        }

        private void dgvTaikhoan_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvTaikhoan.Columns[e.ColumnIndex].HeaderText == "Hình ảnh")
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

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void btTatca_Click(object sender, EventArgs e)
        {

        }

        private void btChitiet_Click(object sender, EventArgs e)
        {

        }
    }
}
