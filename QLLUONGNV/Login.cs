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
    public partial class Form1 : Form
    {
        SqlConnection MyCon = new SqlConnection(@"Data Source=TRONGDAT\SQLEXPRESS;Initial Catalog=QLNhanvienluong;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void butmatkhau_TextChanged(object sender, EventArgs e)
        {
           
        }
        public static Image userImage;
        private void btDangnhap_Click(object sender, EventArgs e)
        {
            if (MyCon.State == ConnectionState.Closed)
                MyCon.Open();
            QUYEN = LAYQUYEN();
            TEN = LAYTEN();
            userImage = LAYANH();
            if (QUYEN != "")
            {
                MessageBox.Show("Ban đã đăng nhập với quyền " + QUYEN, "Thông báo");
                Formmain frmM = new Formmain();
                frmM.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng ? ", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                txtTaikhoan.ResetText();
                txtmatkhau.ResetText();
                this.txtTaikhoan.Focus();
            }
            MyCon.Close();
        }
        public static string QUYEN = "";
        private string LAYQUYEN()
        {
            string Q = "";
            try
            {
                if (MyCon.State == ConnectionState.Closed)
                    MyCon.Open();
                string sql = "select Quyen FROM TaiKhoan WHERE (TaiKhoan = '" + txtTaikhoan.Text + "') and (MatKhau = '" + txtmatkhau.Text + "')";
                SqlDataAdapter Myadapter = new SqlDataAdapter(sql, MyCon);
                DataTable MyTable = new DataTable();
                Myadapter.Fill(MyTable);
                if (MyTable != null)
                {
                    foreach (DataRow MyRow in MyTable.Rows)
                        Q = MyRow["Quyen"].ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi đăng nhập");
            }
            finally
            {
                MyCon.Close();
            }
            return Q;
        }
        public static string TEN = "";
        private string LAYTEN()
        {
            string Q = "";
            try
            {
                if (MyCon.State == ConnectionState.Closed)
                    MyCon.Open();
                string sql = "select TenTaiKhoan FROM TaiKhoan WHERE (TaiKhoan = '" + txtTaikhoan.Text + "') and (MatKhau = '" + txtmatkhau.Text + "')";
                SqlDataAdapter Myadapter = new SqlDataAdapter(sql, MyCon);
                DataTable MyTable = new DataTable();
                Myadapter.Fill(MyTable);
                if (MyTable != null)
                {
                    foreach (DataRow MyRow in MyTable.Rows)
                        Q = MyRow["TenTaiKhoan"].ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi đăng nhập");
            }
            finally
            {
                MyCon.Close();
            }
            return Q;
        }
        private Image LAYANH()
        {
            Image img = null;
            try
            {
                if (MyCon.State == ConnectionState.Closed)
                    MyCon.Open();
                string sql = "SELECT HinhAnh FROM TaiKhoan WHERE TaiKhoan = @TaiKhoan AND MatKhau = @MatKhau";
                SqlCommand cmd = new SqlCommand(sql, MyCon);
                cmd.Parameters.AddWithValue("@TaiKhoan", txtTaikhoan.Text);
                cmd.Parameters.AddWithValue("@MatKhau", txtmatkhau.Text);

                SqlDataAdapter Myadapter = new SqlDataAdapter(cmd);
                DataTable MyTable = new DataTable();
                Myadapter.Fill(MyTable);

                if (MyTable != null && MyTable.Rows.Count > 0)
                {
                    byte[] imgBytes = (byte[])MyTable.Rows[0]["HinhAnh"];
                    using (MemoryStream ms = new MemoryStream(imgBytes))
                    {
                        img = Image.FromStream(ms);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đăng nhập: " + ex.Message);
            }
            finally
            {
                MyCon.Close();
            }
            return img;
        }
    }
}
