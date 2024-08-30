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
    public partial class InNhanVien : Form
    {
        SqlConnection MyCon = new SqlConnection(@"Data Source=TRONGDAT\SQLEXPRESS;Initial Catalog=QLNhanvienluong;Integrated Security=True");
        public InNhanVien()
        {
            InitializeComponent();
        }

        private void paneltop_Paint(object sender, PaintEventArgs e)
        {

        }
        public void ShowReport(CrystalReportNhanVien report)
        {
            ReportInNhanvien.ReportSource = report;
            ReportInNhanvien.Refresh();
        }
        private void InNhanVien_Load(object sender, EventArgs e)
        {
            
        }
        
    }
}
