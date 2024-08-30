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
    public partial class Bangluong : Form
    {
        SqlConnection MyCon = new SqlConnection(@"Data Source=TRONGDAT\SQLEXPRESS;Initial Catalog=QLNhanvienluong;Integrated Security=True");
        public Bangluong()
        {
            InitializeComponent();
        }

        private void Bangluong_Load(object sender, EventArgs e)
        {
            
        }
       
        private void dgvBangluong_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Kiểm tra nếu đang định dạng cột "Thuclanh"
            if (dgvBangluong.Columns[e.ColumnIndex].Name == "Thuclanh" && e.RowIndex >= 0)
            {
                // Kiểm tra giá trị của ô
                if (e.Value != null)
                {
                    double thuclanh;
                    // Chuyển giá trị của ô thành kiểu double
                    if (double.TryParse(e.Value.ToString(), out thuclanh))
                    {
                        // Làm tròn đến 0 chữ số thập phân và định dạng lại giá trị của ô theo đơn vị tiền tệ Việt Nam
                        e.Value = thuclanh.ToString("#,##0") + " VNĐ";
                        e.FormattingApplied = true;
                    }
                }
            }
            if (dgvBangluong.Columns[e.ColumnIndex].Name == "HesoCV" && e.RowIndex >= 0)
            {
                // Kiểm tra giá trị của ô
                if (e.Value != null)
                {
                    double TienChucVu;
                    // Chuyển giá trị của ô thành kiểu double
                    if (double.TryParse(e.Value.ToString(), out TienChucVu))
                    {
                        // Làm tròn đến 0 chữ số thập phân và định dạng lại giá trị của ô theo đơn vị tiền tệ Việt Nam
                        e.Value = TienChucVu.ToString("#,##0") + " VNĐ";
                        e.FormattingApplied = true;
                    }
                }
            }
            if (dgvBangluong.Columns[e.ColumnIndex].Name == "Luongcoban" && e.RowIndex >= 0)
            {
                // Kiểm tra giá trị của ô
                if (e.Value != null)
                {
                    double TienCB;
                    // Chuyển giá trị của ô thành kiểu double
                    if (double.TryParse(e.Value.ToString(), out TienCB))
                    {
                        // Làm tròn đến 0 chữ số thập phân và định dạng lại giá trị của ô theo đơn vị tiền tệ Việt Nam
                        e.Value = TienCB.ToString("#,##0") + " VNĐ";
                        e.FormattingApplied = true;
                    }
                }
            }
            if (dgvBangluong.Columns[e.ColumnIndex].Name == "TongThuong" && e.RowIndex >= 0)
            {
                // Kiểm tra giá trị của ô
                if (e.Value != null)
                {
                    double TienThuong;
                    // Chuyển giá trị của ô thành kiểu double
                    if (double.TryParse(e.Value.ToString(), out TienThuong))
                    {
                        // Làm tròn đến 0 chữ số thập phân và định dạng lại giá trị của ô theo đơn vị tiền tệ Việt Nam
                        e.Value = TienThuong.ToString("#,##0") + " VNĐ";
                        e.FormattingApplied = true;
                    }
                }
            }
            if (dgvBangluong.Columns[e.ColumnIndex].Name == "TongTru" && e.RowIndex >= 0)
            {
                // Kiểm tra giá trị của ô
                if (e.Value != null)
                {
                    double Tientru;
                    // Chuyển giá trị của ô thành kiểu double
                    if (double.TryParse(e.Value.ToString(), out Tientru))
                    {
                        // Làm tròn đến 0 chữ số thập phân và định dạng lại giá trị của ô theo đơn vị tiền tệ Việt Nam
                        e.Value = Tientru.ToString("#,##0") + " VNĐ";
                        e.FormattingApplied = true;
                    }
                }
            }
            if (dgvBangluong.Columns[e.ColumnIndex].Name == "LuongThucTe" && e.RowIndex >= 0)
            {
                // Kiểm tra giá trị của ô
                if (e.Value != null)
                {
                    double LuongThucTe;
                    // Chuyển giá trị của ô thành kiểu double
                    if (double.TryParse(e.Value.ToString(), out LuongThucTe))
                    {
                        // Làm tròn đến 0 chữ số thập phân và định dạng lại giá trị của ô theo đơn vị tiền tệ Việt Nam
                        e.Value = LuongThucTe.ToString("#,##0") + " VNĐ";
                        e.FormattingApplied = true;
                    }
                }
            }
        }
        private double ExtractNumberFromString(string input)
        {
            string cleanedInput = new string(input.Where(char.IsDigit).ToArray());
            return double.Parse(cleanedInput);
        }

    }
}
