using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Suite;
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
    public partial class Formmain : Form
    {
        public Formmain()
        {
            InitializeComponent();
        }

        private void Formmain_Load(object sender, EventArgs e)
        {
            guna2ShadowForm1.SetShadowForm(this);
            panelcontainer.Visible = false;
            labelten.Text = "Username:"+ "\t" +Form1.TEN.ToString();
            Image anhavatar = Form1.userImage;
            if (anhavatar != null)
            {
                PicAvatar.Image = anhavatar;
            }
            else
            {
                PicAvatar.Image = null;
            }
        }

        private void Menupanel_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void btNhanvien_Click(object sender, EventArgs e)
        {
            if (Form1.QUYEN == "Nhân viên")
            {
                MessageBox.Show("Bạn không có quyền truy cập ! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                container(new Nhanvien());
                panelcontainer.Visible = true;
                labelmenutop.Text = "Nhân Viên";
                btNhanvien.FillColor = Color.MediumSlateBlue;
                btNhanvien.ForeColor = Color.White;
                butTrangchu.FillColor = Color.White;
                butTrangchu.ForeColor = Color.Black;
                btphongban.FillColor = Color.White;
                btphongban.ForeColor = Color.Black;
                butKhenThuong.FillColor = Color.White;
                butKhenThuong.ForeColor = Color.Black;
                btChamcong.FillColor = Color.White;
                btChamcong.ForeColor = Color.Black;
                btKyLuat.FillColor = Color.White;
                btKyLuat.ForeColor = Color.Black;
                btBangluong.FillColor = Color.White;
                btBangluong.ForeColor = Color.Black;
                btTaikhoan.FillColor = Color.White;
                btTaikhoan.ForeColor = Color.Black;
            }
        }          
        private void container(object _form)
        {
            if (panelcontainer.Controls.Count > 0) panelcontainer.Controls.Clear();
            Form fm = _form as Form;
            fm.TopLevel = false;
            fm.FormBorderStyle = FormBorderStyle.None;
            fm.Dock = DockStyle.Fill;
            panelcontainer.Controls.Add(fm);
            fm.Show();
        }

        private void butTrangchu_Click(object sender, EventArgs e)
        {
            Formmain_Load(sender, e);
            labelmenutop.Text = "Trang Chủ";
            butTrangchu.FillColor = Color.MediumSlateBlue;
            butTrangchu.ForeColor = Color.White;
            btNhanvien.FillColor = Color.White;
            btNhanvien.ForeColor = Color.Black;
            butKhenThuong.FillColor = Color.White;
            butKhenThuong.ForeColor = Color.Black;
            btChamcong.FillColor = Color.White;
            btChamcong.ForeColor = Color.Black;
            btKyLuat.FillColor = Color.White;
            btKyLuat.ForeColor = Color.Black;
            btphongban.FillColor = Color.White;
            btphongban.ForeColor = Color.Black;
            btBangluong.FillColor = Color.White;
            btBangluong.ForeColor = Color.Black;
            btTaikhoan.FillColor = Color.White;
            btTaikhoan.ForeColor = Color.Black;
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelcontainer_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void btphongban_Click(object sender, EventArgs e)
        {
            
                container(new PhongBan());
                panelcontainer.Visible = true;
                labelmenutop.Text = "Phòng Ban";
                btphongban.FillColor = Color.MediumSlateBlue;
                btphongban.ForeColor = Color.White;
                butTrangchu.FillColor = Color.White;
                butTrangchu.ForeColor = Color.Black;
                btNhanvien.FillColor = Color.White;
                btNhanvien.ForeColor = Color.Black;
                butKhenThuong.FillColor = Color.White;
                butKhenThuong.ForeColor = Color.Black;
                btChamcong.FillColor = Color.White;
                btChamcong.ForeColor = Color.Black;
                btKyLuat.FillColor = Color.White;
                btKyLuat.ForeColor = Color.Black;
                btBangluong.FillColor = Color.White;
                btBangluong.ForeColor = Color.Black;
                btTaikhoan.FillColor = Color.White;
                btTaikhoan.ForeColor = Color.Black;
            
        }

        private void butKhenThuong_Click(object sender, EventArgs e)
        {
            if (Form1.QUYEN == "Nhân viên")
            {
                MessageBox.Show("Bạn không có quyền truy cập ! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                container(new KhenThuongg());
                panelcontainer.Visible = true;
                labelmenutop.Text = "Khen Thưởng";
                butKhenThuong.FillColor = Color.MediumSlateBlue;
                butKhenThuong.ForeColor = Color.White;
                butTrangchu.FillColor = Color.White;
                butTrangchu.ForeColor = Color.Black;
                btNhanvien.FillColor = Color.White;
                btNhanvien.ForeColor = Color.Black;
                btphongban.FillColor = Color.White;
                btphongban.ForeColor = Color.Black;
                btChamcong.FillColor = Color.White;
                btChamcong.ForeColor = Color.Black;
                btKyLuat.FillColor = Color.White;
                btKyLuat.ForeColor = Color.Black;
                btBangluong.FillColor = Color.White;
                btBangluong.ForeColor = Color.Black;
                btTaikhoan.FillColor = Color.White;
                btTaikhoan.ForeColor = Color.Black;
            }
        }

        private void btChamcong_Click(object sender, EventArgs e)
        {
            if (Form1.QUYEN == "Nhân viên")
            {
                MessageBox.Show("Bạn không có quyền truy cập ! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                container(new luongThuongmain());
                panelcontainer.Visible = true;
                labelmenutop.Text = "Chấm công";
                btChamcong.FillColor = Color.MediumSlateBlue;
                btChamcong.ForeColor = Color.White;
                butTrangchu.FillColor = Color.White;
                butTrangchu.ForeColor = Color.Black;
                btNhanvien.FillColor = Color.White;
                btNhanvien.ForeColor = Color.Black;
                btphongban.FillColor = Color.White;
                btphongban.ForeColor = Color.Black;
                butKhenThuong.FillColor = Color.White;
                butKhenThuong.ForeColor = Color.Black;
                btKyLuat.FillColor = Color.White;
                btKyLuat.ForeColor = Color.Black;
                btBangluong.FillColor = Color.White;
                btBangluong.ForeColor = Color.Black;
                btTaikhoan.FillColor = Color.White;
                btTaikhoan.ForeColor = Color.Black;
            }
        }

        private void btKyLuat_Click(object sender, EventArgs e)
        {
            if (Form1.QUYEN == "Nhân viên")
            {
                MessageBox.Show("Bạn không có quyền truy cập ! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                container(new Kyluat());
                panelcontainer.Visible = true;
                labelmenutop.Text = "Kỷ luật";
                btKyLuat.FillColor = Color.MediumSlateBlue;
                btKyLuat.ForeColor = Color.White;
                butTrangchu.FillColor = Color.White;
                butTrangchu.ForeColor = Color.Black;
                btNhanvien.FillColor = Color.White;
                btNhanvien.ForeColor = Color.Black;
                btphongban.FillColor = Color.White;
                btphongban.ForeColor = Color.Black;
                butKhenThuong.FillColor = Color.White;
                butKhenThuong.ForeColor = Color.Black;
                btChamcong.FillColor = Color.White;
                btChamcong.ForeColor = Color.Black;
                btBangluong.FillColor = Color.White;
                btBangluong.ForeColor = Color.Black;
                btTaikhoan.FillColor = Color.White;
                btTaikhoan.ForeColor = Color.Black;
            }
        }

        private void btBangluong_Click(object sender, EventArgs e)
        {
            container(new Tienluong());
            panelcontainer.Visible = true;
            labelmenutop.Text = "Bảng lương";
            btBangluong.FillColor = Color.MediumSlateBlue;
            btBangluong.ForeColor = Color.White;
            butTrangchu.FillColor = Color.White;
            butTrangchu.ForeColor = Color.Black;
            btNhanvien.FillColor = Color.White;
            btNhanvien.ForeColor = Color.Black;
            btphongban.FillColor = Color.White;
            btphongban.ForeColor = Color.Black;
            butKhenThuong.FillColor = Color.White;
            butKhenThuong.ForeColor = Color.Black;
            btChamcong.FillColor = Color.White;
            btChamcong.ForeColor = Color.Black;
            btKyLuat.FillColor = Color.White;
            btKyLuat.ForeColor = Color.Black;
            btTaikhoan.FillColor = Color.White;
            btTaikhoan.ForeColor = Color.Black;
        }

        private void btTaikhoan_Click(object sender, EventArgs e)
        {
            if (Form1.QUYEN == "Nhân viên")
            {
                MessageBox.Show("Bạn không có quyền truy cập ! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                container(new Taikhoan());
                panelcontainer.Visible = true;
                labelmenutop.Text = "Tài khoản";
                btTaikhoan.FillColor = Color.MediumSlateBlue;
                btTaikhoan.ForeColor = Color.White;
                butTrangchu.FillColor = Color.White;
                butTrangchu.ForeColor = Color.Black;
                btNhanvien.FillColor = Color.White;
                btNhanvien.ForeColor = Color.Black;
                btphongban.FillColor = Color.White;
                btphongban.ForeColor = Color.Black;
                butKhenThuong.FillColor = Color.White;
                butKhenThuong.ForeColor = Color.Black;
                btChamcong.FillColor = Color.White;
                btChamcong.ForeColor = Color.Black;
                btKyLuat.FillColor = Color.White;
                btKyLuat.ForeColor = Color.Black;
                btBangluong.FillColor = Color.White;
                btBangluong.ForeColor = Color.Black;
            }
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Form1  form1 = new Form1();
            form1.Show();
        }
    }
}
