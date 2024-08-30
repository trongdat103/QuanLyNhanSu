using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;

namespace QLLUONGNV
{
    public partial class PhongBan : Form
    {
        SqlConnection MyCon = new SqlConnection(@"Data Source=TRONGDAT\SQLEXPRESS;Initial Catalog=QLNhanvienluong;Integrated Security=True");
        public PhongBan()
        {
            InitializeComponent();
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
            panelcontainer1.Controls.Add(childForm);
            panelcontainer1.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        private void btQuanli_Click(object sender, EventArgs e)
        {

            if (Form1.QUYEN == "Nhân viên")
            {
                MessageBox.Show("Bạn không có quyền truy cập ! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                OpenChildForm(new Quanlyphongban());
                btThongke.ForeColor = Color.White;
                btThongke.FillColor = Color.MediumSlateBlue;
                btThongke.BorderColor = Color.MediumSlateBlue;
                btQuanli.ForeColor = Color.MediumSlateBlue;
                btQuanli.FillColor = Color.White;
                btQuanli.BorderColor = Color.MediumSlateBlue;
            }

        }
        private void PhongBan_Load(object sender, EventArgs e)
        {
            btThongke.ForeColor = Color.White;
            btThongke.FillColor = Color.MediumSlateBlue;
            btThongke.BorderColor = Color.MediumSlateBlue;
        }      
        private void btThongke_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Thongke());
            panelcontainer1.Visible = true;
            btQuanli.ForeColor = Color.White;
            btQuanli.FillColor = Color.MediumSlateBlue;
            btQuanli.BorderColor = Color.MediumSlateBlue;
            btThongke.ForeColor = Color.MediumSlateBlue;
            btThongke.FillColor = Color.White;
            btThongke.BorderColor = Color.MediumSlateBlue;
        }          
    }
}
