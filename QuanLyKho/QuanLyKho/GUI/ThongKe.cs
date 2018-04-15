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
    public partial class ThongKe : Form
    {
        //string strConn = @"Data Source=NGOCXINH\SQLEXPRESS;Initial Catalog=QuanLyKho;Integrated Security=True";
        //SqlConnection conn = new SqlConnection();
        public ThongKe()
        {
            InitializeComponent();
        }

        private void cbxThongKe_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strConn = @"Data Source=NGOCXINH\SQLEXPRESS;Initial Catalog=QuanLyKho;Integrated Security=True";
            SqlConnection conn = new SqlConnection(strConn);
            SqlCommand com = new SqlCommand();
            com.CommandText = "select NCC.maNCC, tenNCC, tenHH, soLuong from NCC, HangHoa where NCC.maNCC = HangHoa.maNCC and NCC.tenNCC like N'" + cbxThongKe.SelectedItem + "'";
            com.Connection = conn;
            DataSet set = new DataSet();
            SqlDataAdapter ad = new SqlDataAdapter(com);
            ad.Fill(set);
            dgvThongKe.DataSource = set.Tables[0];

            //com.CommandText = "select * from PhieuNhap where maPN = '" + cbxThongKe.SelectedItem + "'";
            //com.Connection = conn;
            //DataSet set1 = new DataSet();
            //SqlDataAdapter ad1 = new SqlDataAdapter(com);
            //ad1.Fill(set1);
            //dgvThongKe.DataSource = set1.Tables[0];

            //com.CommandText = "select * from PhieuXuat where maPX = '" + cbxThongKe.SelectedItem + "'";
            //com.Connection = conn;
            //DataSet set2 = new DataSet();
            //SqlDataAdapter ad2 = new SqlDataAdapter(com);
            //ad2.Fill(set2);
            //dgvThongKe.DataSource = set2.Tables[0];

        }

        private void ThongKe_Load(object sender, EventArgs e)
        {
            string strConn = @"Data Source=NGOCXINH\SQLEXPRESS;Initial Catalog=QuanLyKho;Integrated Security=True";
            SqlConnection conn = new SqlConnection(strConn);
            SqlCommand com = new SqlCommand();
            com.CommandText = "select * from NCC";
            com.Connection = conn;
            conn.Open();
            SqlDataReader read = com.ExecuteReader();
            while (read.Read())
            {
                cbxThongKe.Items.Add(read["tenNCC"]);             
            }
            read.Close();
            conn.Close();

        }
    }
}
