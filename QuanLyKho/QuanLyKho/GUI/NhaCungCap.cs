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
    public partial class NhaCungCap : Form
    {
        int a;
        SqlCommand cmm;
        string strConn = @"Data Source=NGOCXINH\SQLEXPRESS;Initial Catalog=QuanLyKho;Integrated Security=True";
        SqlConnection conn = new SqlConnection();
        private void LoadData()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * from NCC", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvNhaCungCap.DataSource = dt;
        }
        public NhaCungCap()
        {
            InitializeComponent();
            conn = new SqlConnection(strConn);
            conn.Open();
            LoadData();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            cmm = new SqlCommand("select count(*) from NCC", conn);
            SqlDataReader dr = cmm.ExecuteReader();
            int soluong = 0;
            if (dr.Read())
            {
                soluong = dr.GetInt32(0);
                dr.Close();
            }
            for (int i = 0; i <= soluong; i++)
            {
                txtMaNCC.Text = (i + 1).ToString();
            }
            a = 1;
            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;                        

            MessageBox.Show("Mời bạn thêm mới \n Ấn nút LƯU để lưu kết quả");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            a = 2;
            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;            
            MessageBox.Show("Ấn nút LƯU để lưu kết quả");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            a = 3;
            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            MessageBox.Show("Ấn nút LƯU để lưu kết quả");
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            switch (a)
            {
                case 1:
                    {
                        cmm = new SqlCommand("select count(*) from NCC", conn);                        

                        SqlCommand cmd = new SqlCommand("ThemNCC", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlParameter p = new SqlParameter();
                        p = new SqlParameter("@MaNCC", txtMaNCC.Text);
                        cmd.Parameters.Add(p);
                        p = new SqlParameter("@TenNCC", txtTenNCC.Text);
                        cmd.Parameters.Add(p);
                        p = new SqlParameter("@DiaChi", txtDiaChi.Text);
                        cmd.Parameters.Add(p);
                        p = new SqlParameter("@SDT", txtSDT.Text);
                        cmd.Parameters.Add(p);
                        p = new SqlParameter("@Email", txtEmail.Text);
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
                        SqlCommand cmd = new SqlCommand("SuaNCC", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlParameter p = new SqlParameter();
                        p = new SqlParameter("@MaNCC", txtMaNCC.Text);
                        cmd.Parameters.Add(p);
                        p = new SqlParameter("@TenNCC", txtTenNCC.Text);
                        cmd.Parameters.Add(p);
                        p = new SqlParameter("@DiaChi", txtDiaChi.Text);
                        cmd.Parameters.Add(p);
                        p = new SqlParameter("@SDT", txtSDT.Text);
                        cmd.Parameters.Add(p);
                        p = new SqlParameter("@Email", txtEmail.Text);
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
                            SqlCommand cmd = new SqlCommand("XoaNCC", conn);
                            cmd.CommandType = CommandType.StoredProcedure;
                            SqlParameter p = new SqlParameter("@MaNCC", txtMaNCC.Text);
                            cmd.Parameters.Add(p);

                            int count = cmd.ExecuteNonQuery();
                            if (count > 0)
                            {
                                MessageBox.Show("Xoá thành công!");
                                LoadData();
                                txtMaNCC.Text = "";
                                txtTenNCC.Text = "";
                                txtDiaChi.Text = "";
                                txtSDT.Text = "";
                                txtEmail.Text = "";
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

        private void dgvNhaCungCap_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                txtMaNCC.Text = (dgvNhaCungCap.CurrentRow.Cells["maNCC"].Value.ToString());
                txtTenNCC.Text = Convert.ToString(dgvNhaCungCap.CurrentRow.Cells["tenNCC"].Value);
                txtDiaChi.Text = Convert.ToString(dgvNhaCungCap.CurrentRow.Cells["diaChi"].Value);
                txtSDT.Text = Convert.ToString(dgvNhaCungCap.CurrentRow.Cells["SDT"].Value);
                txtEmail.Text = Convert.ToString(dgvNhaCungCap.CurrentRow.Cells["email"].Value);
            }         
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadData();
            txtMaNCC.Text = "";
            txtTenNCC.Text = "";
            txtDiaChi.Text = "";
            txtSDT.Text = "";
            txtEmail.Text = "";

            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            btnXoa.Enabled = true;
        }
    }
}
