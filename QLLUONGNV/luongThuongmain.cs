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
    public partial class luongThuongmain : Form
    {
        public luongThuongmain()
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
            panelcontainer.Controls.Add(childForm);
            panelcontainer.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        private void btquaylaidi_Click(object sender, EventArgs e)
        {
            btquaylaidi.Visible = false;
            OpenChildForm(new Bangchamcong());

        }

        private void btNgaynghi_Click(object sender, EventArgs e)
        {
            btquaylaidi.Visible=true;
            OpenChildForm(new Ngaynghi());
            btChamcong.ForeColor = Color.White;
            btChamcong.FillColor = Color.MediumSlateBlue;
            btChamcong.BorderColor = Color.MediumSlateBlue;
            btNgaynghi.ForeColor = Color.MediumSlateBlue;
            btNgaynghi.FillColor = Color.White;
            btNgaynghi.BorderColor = Color.MediumSlateBlue;
        }

        private void btChamcong_Click(object sender, EventArgs e)
        {
            btquaylaidi.Visible = true;
            OpenChildForm(new ChamCong());
            btNgaynghi.ForeColor = Color.White;
            btNgaynghi.FillColor = Color.MediumSlateBlue;
            btNgaynghi.BorderColor = Color.MediumSlateBlue;
            btChamcong.ForeColor = Color.MediumSlateBlue;
            btChamcong.FillColor = Color.White;
            btChamcong.BorderColor = Color.MediumSlateBlue;
        }

        private void luongThuongmain_Load(object sender, EventArgs e)
        {
            OpenChildForm(new Bangchamcong());
        }
    }
}
