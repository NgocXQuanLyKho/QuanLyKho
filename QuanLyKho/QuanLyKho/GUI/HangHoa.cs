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
    public partial class HangHoa : Form
    {
        int a;
        SqlCommand cmm;
        string strConn = @"Data Source=NGOCXINH\SQLEXPRESS;Initial Catalog=QuanLyKho;Integrated Security=True";
        SqlConnection conn = new SqlConnection();
        private void LoadData()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * from HangHoa", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvHangHoa.DataSource = dt;
        }
        public HangHoa()
        {
            InitializeComponent();
            conn = new SqlConnection(strConn);
            conn.Open();
            LoadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmm = new SqlCommand("select count(*) from HangHoa", conn);
            SqlDataReader dr = cmm.ExecuteReader();
            int soluong = 0;
            if (dr.Read())
            {
                soluong = dr.GetInt32(0);
                dr.Close();
            }
            for (int i = 0; i <= soluong; i++)
            {
                txtMaHH.Text = (i + 1).ToString();
            }

            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            a = 1;            

            MessageBox.Show("Mời bạn thêm mới \n Ấn nút LƯU để lưu kết quả");

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            a = 2;
            MessageBox.Show("Ấn nút LƯU để lưu kết quả");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            a = 3;
            MessageBox.Show("Ấn nút LƯU để lưu kết quả");
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
             switch(a){
                case 1: 
                    {
                        cmm = new SqlCommand("select count(*) from HangHoa", conn);                        
                   
                        SqlCommand cmd = new SqlCommand("ThemHangHoa", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlParameter p = new SqlParameter();
                        p = new SqlParameter("@MaHH", txtMaHH.Text);
                        cmd.Parameters.Add(p);
                        p = new SqlParameter("@TenHH", txtTenHH.Text);
                        cmd.Parameters.Add(p);
                        p = new SqlParameter("@MaNCC", txtMaNCC.Text);
                        cmd.Parameters.Add(p);
                        p = new SqlParameter("@SoLuong", txtSoLuong.Text);
                        cmd.Parameters.Add(p);
                        int count = cmd.ExecuteNonQuery();
                        if (count > 0)
                        {
                            MessageBox.Show("Thêm mới thành công");
                            LoadData();
                        }
                        else MessageBox.Show("Không thể thêm mới");
                   
                        btnLuu.Enabled = false;
                        btnSua.Enabled = true;
                        btnThem.Enabled = true;
                        btnXoa.Enabled = true;
                        break;
                    }
                case 2:
                    {
                        SqlCommand cmd = new SqlCommand("SuaHangHoa", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlParameter p = new SqlParameter();
                        p = new SqlParameter("@MaHH", txtMaHH.Text);
                        cmd.Parameters.Add(p);
                        p = new SqlParameter("@TenHH", txtTenHH.Text);
                        cmd.Parameters.Add(p);
                        p = new SqlParameter("@MaNCC", txtMaNCC.Text);
                        cmd.Parameters.Add(p);
                        p = new SqlParameter("@SoLuong", txtSoLuong.Text);
                        cmd.Parameters.Add(p);
                        int count = cmd.ExecuteNonQuery();
                        if (count > 0)
                        {
                            MessageBox.Show("Sửa thành công");
                            LoadData();
                        }
                        else MessageBox.Show("Không thể sửa");
                        btnLuu.Enabled = false;
                        btnSua.Enabled = true;
                        btnThem.Enabled = true;
                        btnXoa.Enabled = true;
                        break;
                    }
                 case 3:
                    {
                        if (MessageBox.Show("Bạn có chắc chắn muốn xoá không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            SqlCommand cmd = new SqlCommand("XoaHangHoa", conn);
                            cmd.CommandType = CommandType.StoredProcedure;
                            SqlParameter p = new SqlParameter("@MaHH", txtMaHH.Text);
                            cmd.Parameters.Add(p);

                            int count = cmd.ExecuteNonQuery();
                            if (count > 0)
                            {
                                MessageBox.Show("Xoá thành công!");
                                LoadData();
                                txtMaHH.Text = "";
                                txtTenHH.Text = "";
                                txtMaNCC.Text = "";
                                txtSoLuong.Text = "";
                            }
                            else
                            {
                                MessageBox.Show("Không thể xoá bản ghi hiện tại!");
                            }
                        }
                        btnLuu.Enabled = false;
                        btnSua.Enabled = true;
                        btnThem.Enabled = true;
                        btnXoa.Enabled = true;
                        break;
                    }
            }        
        
        }

        private void dgvHangHoa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                txtMaHH.Text = (dgvHangHoa.CurrentRow.Cells["maHH"].Value.ToString());
                txtTenHH.Text = Convert.ToString(dgvHangHoa.CurrentRow.Cells["tenHH"].Value);
                txtMaNCC.Text = Convert.ToString(dgvHangHoa.CurrentRow.Cells["maNCC"].Value);
                txtSoLuong.Text = Convert.ToString(dgvHangHoa.CurrentRow.Cells["soluong"].Value);
                
            }         
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            LoadData();
            txtMaHH.Text = "";
            txtTenHH.Text = "";
            txtMaNCC.Text = "";
            txtSoLuong.Text = "";            
            
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            btnXoa.Enabled = true;
        }
    }
}
