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

namespace QuanLyKho.GUI
{
    public partial class TimKiem : Form
    {       
        string strConn = @"Data Source=NGOCXINH\SQLEXPRESS;Initial Catalog=QuanLyKho;Integrated Security=True";
        SqlConnection conn = new SqlConnection();
        private void LoadData()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * from HangHoa", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvTimKiem.DataSource = dt;
        }

        //public void LoadDataByTimKiem()
        //{
        //SqlDataAdapter da = new SqlDataAdapter("SELECT * from HangHoa where TenHH like N'%" + txtTenHH.Text + "%'", conn);
        //DataTable dt = new DataTable();
        //da.Fill(dt);
        //    dgvTimKiem.DataSource = dt;
        //}
       
        public TimKiem()
        {
            InitializeComponent();
            conn = new SqlConnection(strConn);
            conn.Open();
            LoadData();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Mã Hàng Hoá")
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * from HangHoa where MaHH like N'%" + txtTenHH.Text + "%'", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvTimKiem.DataSource = dt;
                //dgvTimKiem.DataSource = dt ("select * from HangHoa where MaHH like '%" + txtTenHH.Text.Trim() + "%'");
            }
            if (comboBox1.Text == "Tên Hàng Hoá")
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * from HangHoa where TenHH like N'%" + txtTenHH.Text + "%'", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvTimKiem.DataSource = dt;                
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TimKiem_Load(object sender, EventArgs e)
        {
            comboBox1.Text = "Mã Hàng Hoá";
            LoadData();
        }

        private void txtTenHH_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Mã Hàng Hoá")
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * from HangHoa where MaHH like N'%" + txtTenHH.Text + "%'", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvTimKiem.DataSource = dt;
                //dgvTimKiem.DataSource = dt ("select * from HangHoa where MaHH like '%" + txtTenHH.Text.Trim() + "%'");
            }
            if (comboBox1.Text == "Tên Hàng Hoá")
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * from HangHoa where TenHH like N'%" + txtTenHH.Text + "%'", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvTimKiem.DataSource = dt;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
