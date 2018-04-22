using System;
using QuanLyKho.DAL;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuanLyKho
{
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {
            txtTenDN.ResetText();
            txtMK.Focus();
        }

        private void btnDN_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=NGOCXINH\SQLEXPRESS;Initial Catalog=QuanLyKho;Integrated Security=True");
            try
            {
                conn.Open();
                string TenDN = txtTenDN.Text;
                string MK = txtMK.Text;
                string sql = "select *from TaiKhoan where acc ='" + TenDN + "' and pass = '" + MK + "' ";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader dt = cmd.ExecuteReader();
                
                if (dt.Read() == true)
                {                    
                    this.Hide();
                    Main form = new Main();
                    form.Show();
                }
                else
                {
                    MessageBox.Show("Đăng nhập thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi kết nối");
            }       
            
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult tb = MessageBox.Show("Bạn có muốn thoát hay không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (tb==DialogResult.OK)
                Application.Exit();
        }

        private void Check_MK_CheckedChanged(object sender, EventArgs e)
        {
            if (Check_MK.Checked)
            {
                txtMK.UseSystemPasswordChar = true;
            }
            else
            {
                txtMK.UseSystemPasswordChar = false;
            }
        }
    }
}
