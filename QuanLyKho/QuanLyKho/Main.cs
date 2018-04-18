using System;
using QuanLyKho.GUI;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKho
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           HangHoa frm = new HangHoa();
            frm.Show();
        }

        private void btnNCC_Click(object sender, EventArgs e)
        {
            
            NhaCungCap frm = new NhaCungCap();
            frm.Show();
        }

        private void btnNhapHang_Click(object sender, EventArgs e)
        {
            NhapHang frm = new NhapHang();
            frm.Show();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            ThongKe frm = new ThongKe();
            frm.Show();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
           TimKiem frm = new TimKiem();
            frm.Show();
        }

        private void btnXuatHang_Click(object sender, EventArgs e)
        {
            XuatHang frm = new XuatHang();
            frm.Show();
        }
    }
}
