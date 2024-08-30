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
    public partial class Quanlyphongban : Form
    {
        SqlConnection MyCon = new SqlConnection(@"Data Source=TRONGDAT\SQLEXPRESS;Initial Catalog=QLNhanvienluong;Integrated Security=True");
        public Quanlyphongban()
        {
            InitializeComponent();
        }

        private void btluusua_Click(object sender, EventArgs e)
        {
            int currentIndex = dgvPhongban.CurrentCell.RowIndex;
            string IDPhongban = Convert.ToString(dgvPhongban.Rows[currentIndex].Cells[0].Value.ToString());
            if (txtMaPB.Text == IDPhongban)
            {
                MyCon.Open();
                string sql2 = "Update PhongBan set TenPhongBan = N'" + txtTenPB.Text + "', SĐT = N'" + txtSodienthoai.Text + "' WHERE MaPhongBan = '" + txtMaPB.Text + "'";
                SqlCommand Cmd2 = new SqlCommand(sql2, MyCon);
                Cmd2.ExecuteNonQuery();
                LoadDLGridViewPB();
                MessageBox.Show("Cập nhật thành công !", "Thông Báo");
                btluusua.Enabled = false;
            }
            else { MessageBox.Show("Không được thay đổi mã phòng ban!", "Thông Báo"); }
            MyCon.Close();
        }
        private void LoadDLGridViewPB()
        {

            string sqlQuery = "SELECT MaPhongBan,TenPhongBan,SĐT " +
                                "FROM PhongBan Where PhongBan.DaXoa = 0 ";
            SqlDataAdapter ad = new SqlDataAdapter(sqlQuery, MyCon);
            DataTable dt1 = new DataTable();
            ad.Fill(dt1);
            dgvPhongban.DataSource = dt1;
            dgvPhongban.AllowUserToAddRows = false;
            dgvPhongban.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvPhongban.DataSource = dt1;
            dgvPhongban.AllowUserToAddRows = false;
            dgvPhongban.RowTemplate.Height = 30;
            dgvPhongban.ColumnHeadersDefaultCellStyle.BackColor = Color.MediumSlateBlue; // Đổi màu thành màu đỏ
            dgvPhongban.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvPhongban.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
            dgvPhongban.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvPhongban.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPhongban.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvPhongban.Columns[0].HeaderText = "Phòng ban";
            dgvPhongban.Columns[1].HeaderText = "Tên phòng ban";
            dgvPhongban.Columns[2].HeaderText = "Số điện thoại";
        }

        private void Quanlyphongban_Load(object sender, EventArgs e)
        {
            LoadDLGridViewPB();
        }

        private void dgvPhongban_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int currentIndex = e.RowIndex;
                // Lấy giá trị của ô đầu tiên trong hàng được chọn, có thể là IDnhanVien
                string IDnhanVien = dgvPhongban.Rows[currentIndex].Cells[0].Value.ToString();
                string sql = "select NhanVien.* from NhanVien inner join PhongBan on PhongBan.MaPhongBan = NhanVien.MaPhongBan where NhanVien.MaPhongBan = '" + IDnhanVien + "' and NhanVien.Xoa = 0";
                SqlDataAdapter ad = new SqlDataAdapter(sql, MyCon);
                DataTable dt1 = new DataTable();
                ad.Fill(dt1);
                dgvNv.DataSource = dt1;
                dgvNv.AllowUserToAddRows = false;
                dgvNv.EditMode = DataGridViewEditMode.EditProgrammatically;
                dgvNv.DataSource = dt1;
                dgvNv.AllowUserToAddRows = false;
                dgvNv.RowTemplate.Height = 30;
                dgvNv.ColumnHeadersDefaultCellStyle.BackColor = Color.MediumSlateBlue; // Đổi màu thành màu đỏ
                dgvNv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgvNv.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
                dgvNv.CellBorderStyle = DataGridViewCellBorderStyle.Single;
                dgvNv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvNv.EditMode = DataGridViewEditMode.EditProgrammatically;
                dgvNv.Columns[0].HeaderText = "Mã Nhân Viên";
                dgvNv.Columns[1].HeaderText = "Họ Và Tên";
                dgvNv.Columns[2].HeaderText = "Giới Tính";
                dgvNv.Columns[3].HeaderText = "Ngày Sinh";
                dgvNv.Columns[4].HeaderText = "Địa Chỉ";
                dgvNv.Columns[5].HeaderText = "Điện Thoại";
                dgvNv.Columns[6].HeaderText = "Trình Độ";
                dgvNv.Columns[7].HeaderText = "Quốc Tịch";
                dgvNv.Columns[8].HeaderText = "Dân Tộc";
                dgvNv.Columns[9].HeaderText = "Tôn Giaó";
                dgvNv.Columns[10].HeaderText = "Số Chứng Minh";
                dgvNv.Columns[11].HeaderText = "Ngày Cấp";
                dgvNv.Columns[12].HeaderText = "Nơi Cấp";
                dgvNv.Columns[13].HeaderText = "Địa Chỉ Thường Chú";
                dgvNv.Columns[14].HeaderText = "Địa Chỉ Tạm Chú";
                dgvNv.Columns[15].HeaderText = "Ngày Vào Làm";
                dgvNv.Columns[16].HeaderText = "Ngoại Ngữ";
                dgvNv.Columns[17].HeaderText = "Tin Học";
                dgvNv.Columns[18].HeaderText = "Bậc Lương";
                dgvNv.Columns[19].HeaderText = "Chức Vụ";
                dgvNv.Columns[20].HeaderText = "Phụ Cấp";
                dgvNv.Columns[21].HeaderText = "Phòng Ban";
                dgvNv.Columns[22].HeaderText = "Hình ảnh";
            }
        }

        private void dgvPhongban_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int dong;
            dong = e.RowIndex;
            txtMaPB.Text = dgvPhongban.Rows[dong].Cells[0].Value.ToString();
            txtTenPB.Text = dgvPhongban.Rows[dong].Cells[1].Value.ToString();
            txtSodienthoai.Text = dgvPhongban.Rows[dong].Cells[2].Value.ToString();
        }

        private void dgvNv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvNv.Columns[e.ColumnIndex].HeaderText == "Hình ảnh")
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

        private void dgvNv_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int dong;
            dong = e.RowIndex;
            labelManv.Text = dgvNv.Rows[dong].Cells[0].Value.ToString();
            labelTennv.Text = dgvNv.Rows[dong].Cells[1].Value.ToString();
            labelchucvu.Text = dgvNv.Rows[dong].Cells[20].Value.ToString();
            labelGioitinh.Text = dgvNv.Rows[dong].Cells[2].Value.ToString();
            labelTrinhdo.Text = dgvNv.Rows[dong].Cells[6].Value.ToString();
            labelDiachi.Text = dgvNv.Rows[dong].Cells[4].Value.ToString();
            object value = dgvNv.Rows[dong].Cells[22].Value;

            // Kiểm tra nếu giá trị không phải là DBNull và không null
            if (value != DBNull.Value && value != null)
            {
                byte[] b = (byte[])value;
                picavartar.Image = ByteArrayToImage(b);
                guna2HtmlLabel2.Visible = true;
            }
            else
            {
                // Nếu giá trị là DBNull hoặc null, gán hình ảnh rỗng cho PictureBox
                picavartar.Image = null;
                guna2HtmlLabel2.Visible = false;
            }
        }
        Image ByteArrayToImage(byte[] b)
        {
            MemoryStream m = new MemoryStream(b);
            return Image.FromStream(m);
        }
        bool them = false;

        private void btThem_Click(object sender, EventArgs e)
        {
            txtMaPB.ResetText();
            txtSodienthoai.ResetText();
            txtTenPB.ResetText();
            them = true;
            btLuumoi.Visible = true;
            btluusua.Visible = false;
        }

        private void btLuumoi_Click(object sender, EventArgs e)
        {
            try
            {
                int Tinhtrangxoa = 0;
                if (them == true)
                {
                    MyCon.Open();
                    string sql1 = "INSERT INTO PhongBan (MaPhongBan,TenPhongBan,SĐT,DaXoa) VALUES ('" + txtMaPB.Text + "', N'" + txtTenPB.Text + "', N'" + txtSodienthoai.Text + "','" + Tinhtrangxoa + "')";
                    SqlCommand Cmd1 = new SqlCommand(sql1, MyCon);
                    Cmd1.ExecuteNonQuery();
                    LoadDLGridViewPB();
                    txtMaPB.ResetText();
                    txtSodienthoai.ResetText();
                    txtTenPB.ResetText();
                    btLuumoi.Enabled = true;
                    MessageBox.Show("Đã lưu thành công !", "Thông Báo");

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Đã có phòng này trong danh sách ! ", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                txtMaPB.ResetText();
                txtSodienthoai.ResetText();
                txtTenPB.ResetText();
            }
            finally
            {
                MyCon.Close();
            }
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            btLuumoi.Visible = false;
            btluusua.Visible = true;
            btluusua.Enabled = true;
        }

        private void btXoa_Click(object sender, EventArgs e)
        {

            try
            {
                if (MyCon.State == ConnectionState.Closed)
                    MyCon.Open();

                if (dgvPhongban.SelectedCells.Count > 0)
                {
                    DialogResult Traloi;
                    Traloi = MessageBox.Show("Bạn có chắc chắn xóa không?",
                   "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (Traloi == DialogResult.Yes)
                    {
                        int currentIndex = dgvPhongban.CurrentCell.RowIndex;
                        string maphongban = Convert.ToString(dgvPhongban.Rows[currentIndex].Cells[0].Value.ToString());
                        string sql3 = "delete from PhongBan where MaPhongBan ='" + maphongban + "'";
                        SqlCommand cmd3 = new SqlCommand(sql3, MyCon);
                        cmd3.ExecuteNonQuery();
                        LoadDLGridViewPB();
                    }
                }
                else MessageBox.Show("Cần chọn dòng cần xóa");
                MyCon.Close();
            }
            catch {
                MessageBox.Show("Không thể xóa,phòng này còn nhân viên! ", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
            finally { MyCon.Close(); }
        }
    }
}
