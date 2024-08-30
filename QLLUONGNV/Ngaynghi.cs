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
    public partial class Ngaynghi : Form
    {
        SqlConnection MyCon = new SqlConnection(@"Data Source=TRONGDAT\SQLEXPRESS;Initial Catalog=QLNhanvienluong;Integrated Security=True");
        public Ngaynghi()
        {
            InitializeComponent();
        }

        private void Ngaynghi_Load(object sender, EventArgs e)
        {
            Load_Nhanvien();
            dtpNgaynghi.Value = DateTime.Now;
        }
        private void Load_Nhanvien()
        {
            string sqlphongban = "select  MaNV, TenNV  from Nhanvien where Xoa = 0";
            SqlDataAdapter adapter = new SqlDataAdapter(sqlphongban, MyCon);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            CbxNgaynghi.DataSource = dt;
            CbxNgaynghi.DisplayMember = "TenNV";
            CbxNgaynghi.ValueMember = "MaNV";
        }

        private void btNgaynghi_Click(object sender, EventArgs e)
        {
            try
            {
                MyCon.Open();
                string checktontaiNC = "SELECT COUNT(*) FROM Ngaynghi WHERE Ngaynghi = @dtpNgaynghi AND MaNV = @MaNV";
                SqlCommand cmdCheckExistence = new SqlCommand(checktontaiNC, MyCon);
                cmdCheckExistence.Parameters.AddWithValue("@dtpNgaynghi", dtpNgaynghi.Text);
                cmdCheckExistence.Parameters.AddWithValue("@MaNV", CbxNgaynghi.SelectedValue.ToString());
                int count = (int)cmdCheckExistence.ExecuteScalar();
                if (count == 0) // Kiểm tra xem dữ liệu đã tồn tại trong cơ sở dữ liệu chưa
                {
                    string sql1 = "INSERT INTO Ngaynghi (Ngaynghi,MaNV) VALUES ('" + dtpNgaynghi.Text + "', N'" + CbxNgaynghi.SelectedValue.ToString() + "')";
                    SqlCommand Cmd1 = new SqlCommand(sql1, MyCon);
                    Cmd1.ExecuteNonQuery();
                    btNgaynghi.Enabled = false;
                    MessageBox.Show("Đã xác nhận nghỉ !", "Thông Báo");
                }
                else
                {
                    MessageBox.Show("Nhân viên này đã xác nhận nghỉ việc ngày hôm nay, không xác nhận nữa ! ", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    btNgaynghi.Enabled = false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Đã xác nhận nghỉ rồi ! ", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
            finally
            {
                MyCon.Close();
            }
        }
    }
}
