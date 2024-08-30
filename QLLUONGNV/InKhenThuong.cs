using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLLUONGNV
{
    public partial class InKhenThuong : Form
    {
        public InKhenThuong()
        {
            InitializeComponent();
        }

        private void InKhenThuong_Load(object sender, EventArgs e)
        {

        }
        public void ShowReport(ReportKhenThuong report)
        {
            ReportKhen.ReportSource = report;
            ReportKhen.Refresh();
        }

        private void ReportKhen_Load(object sender, EventArgs e)
        {

        }
    }
}
