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
    public partial class InKyLuat : Form
    {
        public InKyLuat()
        {
            InitializeComponent();
        }

        private void InKyLuat_Load(object sender, EventArgs e)
        {

        }
        public void ShowReport(ReportKyLuat report)
        {
            crystalReportKL.ReportSource = report;
            crystalReportKL.Refresh();
        }

        private void crystalReportKL_Load(object sender, EventArgs e)
        {

        }
    }
}
