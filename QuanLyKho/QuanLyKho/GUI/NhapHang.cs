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
    public partial class NhapHang : Form
    {
        int a;
        SqlCommand cmm;
        string strConn = @"Data Source=NGOCXINH\SQLEXPRESS;Initial Catalog=QuanLyKho;Integrated Security=True";
        SqlConnection conn = new SqlConnection();
        private void LoadData()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * from PhieuNhap", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvNhapHang.DataSource = dt;
            SqlDataAdapter da1 = new SqlDataAdapter("SELECT * from Chitietnhap", conn);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            dgvCTNhap.DataSource = dt1;

        }
        public NhapHang()
        {
            InitializeComponent();          
            conn = new SqlConnection(strConn);
            conn.Open();
            LoadData();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmm = new SqlCommand("select count(*) from PhieuNhap", conn);
            SqlDataReader dr = cmm.ExecuteReader();
            int soluong = 0;
            if (dr.Read())
            {
                soluong = dr.GetInt32(0);
                dr.Close();
            }
            for (int i = 0; i <= soluong; i++)
            {
                txtMaPN.Text = (i + 1).ToString();
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
            switch (a)
            {
                case 1:
                    {
                        cmm = new SqlCommand("select count(*) from PhieuNhap", conn);

                        SqlCommand cmd = new SqlCommand("ThemPhieuNhap", conn);
                        cmd.CommandType = CommandType.StoredProcedure;                
                        SqlParameter p = new SqlParameter();
                        p = new SqlParameter("@MaPN", txtMaPN.Text);
                        cmd.Parameters.Add(p);
                        p = new SqlParameter("@NgayNhap", date1.Value.Date.ToString(""));
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
                        SqlCommand cmd = new SqlCommand("SuaPhieuNhap", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlParameter p = new SqlParameter();
                        p = new SqlParameter("@MaPN", txtMaPN.Text);
                        cmd.Parameters.Add(p);
                        p = new SqlParameter("@NgayNhap", date1.Value.Date.ToString(""));
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
                            SqlCommand cmd = new SqlCommand("XoaPhieuNhap", conn);
                            cmd.CommandType = CommandType.StoredProcedure;
                            SqlParameter p = new SqlParameter("@MaPN", txtMaPN.Text);
                            cmd.Parameters.Add(p);
                            
                            int count = cmd.ExecuteNonQuery();
                            if (count > 0)
                            {
                                MessageBox.Show("Xoá thành công!");
                                LoadData();
                                txtMaPN.Text = "";
                                txtTongTien.Text = "";                            
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

        private void btnThem1_Click(object sender, EventArgs e)
        {
            //cmm = new SqlCommand("select count(*) from Chitietnhap", conn);
            //SqlDataReader dr = cmm.ExecuteReader();
            btnThem1.Enabled = false;
            btnSua1.Enabled = false;
            btnXoa1.Enabled = false;
            btnLuu1.Enabled = true;
            a = 1;
            cbxMaCTN.Text = "";
            txtMaHH.Text = "";
            txtSoLuong.Text = "";
            txtDonGia.Text = "";


            MessageBox.Show("Mời bạn thêm mới \n Ấn nút LƯU để lưu kết quả");

        }

        private void btnSua1_Click(object sender, EventArgs e)
        {
            btnLuu1.Enabled = true;
            btnSua1.Enabled = false;
            btnThem1.Enabled = false;
            btnXoa1.Enabled = false;
            a = 2;
            MessageBox.Show("Ấn nút LƯU để lưu kết quả");
        }

        private void btnXoa1_Click(object sender, EventArgs e)
        {
            btnLuu1.Enabled = true;
            btnSua1.Enabled = false;
            btnThem1.Enabled = false;
            btnXoa1.Enabled = false;
            a = 3;
            MessageBox.Show("Ấn nút LƯU để lưu kết quả");
        }

        private void btnLuu1_Click(object sender, EventArgs e)
        {
            switch (a)
            {
                case 1:
                    {
                        cmm = new SqlCommand("select count(*) from Chitietnhap", conn);

                        SqlCommand cmd = new SqlCommand("ThemCTNhap", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlParameter p = new SqlParameter();
                        p = new SqlParameter("@MaCTPN", cbxMaCTN.Text);
                        cmd.Parameters.Add(p);                        
                        p = new SqlParameter("@MaHH", txtMaHH.Text);
                        cmd.Parameters.Add(p);
                        p = new SqlParameter("@SoLuong", txtSoLuong.Text);
                        cmd.Parameters.Add(p);
                        p = new SqlParameter("@DonGia", txtDonGia.Text);
                        cmd.Parameters.Add(p);
                        int count = cmd.ExecuteNonQuery();
                        if (count > 0)
                        {
                            MessageBox.Show("Thêm mới thành công");
                            LoadData();
                        }
                        else MessageBox.Show("Không thể thêm mới");

                        btnLuu1.Enabled = false;
                        btnSua1.Enabled = true;
                        btnThem1.Enabled = true;
                        btnXoa1.Enabled = true;
                        break;
                    }
                case 2:
                    {
                        SqlCommand cmd = new SqlCommand("SuaCTNhap", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlParameter p = new SqlParameter();
                        p = new SqlParameter("@MaCTPN", cbxMaCTN.Text);
                        cmd.Parameters.Add(p);                       
                        p = new SqlParameter("@MaHH", txtMaHH.Text);
                        cmd.Parameters.Add(p);
                        p = new SqlParameter("@SoLuong", txtSoLuong.Text);
                        cmd.Parameters.Add(p);
                        p = new SqlParameter("@DonGia", txtDonGia.Text);
                        cmd.Parameters.Add(p);
                        int count = cmd.ExecuteNonQuery();
                        if (count > 0)
                        {
                            MessageBox.Show("Sửa thành công");
                            LoadData();
                        }
                        else MessageBox.Show("Không thể sửa");
                        btnLuu1.Enabled = false;
                        btnSua1.Enabled = true;
                        btnThem1.Enabled = true;
                        btnXoa1.Enabled = true;
                        break;
                    }
                case 3:
                    {
                        if (MessageBox.Show("Bạn có chắc chắn muốn xoá không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            SqlCommand cmd = new SqlCommand("XoaCTNhap", conn);
                            SqlParameter p = new SqlParameter();
                            cmd.CommandType = CommandType.StoredProcedure;
                            p = new SqlParameter("@MaCTPN", cbxMaCTN.Text);
                            cmd.Parameters.Add(p);

                            int count = cmd.ExecuteNonQuery();
                            if (count > 0)
                            {
                                MessageBox.Show("Xoá thành công!");
                                LoadData();
                                cbxMaCTN.Text = "";
                            }
                            else
                            {
                                MessageBox.Show("Không thể xoá bản ghi hiện tại!");
                            }
                        }
                        btnLuu1.Enabled = false;
                        btnSua1.Enabled = true;
                        btnThem1.Enabled = true;
                        btnXoa1.Enabled = true;
                        break;
                    }
            }
        }

        private void dgvCTNhap_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvNhapHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void NhapHang_Load(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from PhieuNhap", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cbxMaCTN.DataSource = dt;
            cbxMaCTN.DisplayMember = "maPN";
            cbxMaCTN.ValueMember = "maPN";

            //dgvCTNhap.DataSource = dt;
        }

        private void cbxMaCTN_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from Chitietnhap where maPN ='" + cbxMaCTN.Text + "' ", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvCTNhap.DataSource = dt;
        }

        private void btnTK_Click(object sender, EventArgs e)
        {
           
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {

        }

        private void txtTK_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            
        }

        private void btnLamMoi1_Click(object sender, EventArgs e)
        {
          
        }

        private void btnTK_Click_1(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * from PhieuNhap where maPN like N'%" + txtTimKiem.Text + "%' ", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvNhapHang.DataSource = dt;

            SqlDataAdapter da1 = new SqlDataAdapter("SELECT * from Chitietnhap where maPN like N'%" + txtTimKiem.Text + "%' ", conn);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            dgvCTNhap.DataSource = dt1;
        }

        private void txtTimKiem_TextChanged_1(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * from PhieuNhap where maPN like N'%" + txtTimKiem.Text + "%' ", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvNhapHang.DataSource = dt;

            SqlDataAdapter da1 = new SqlDataAdapter("SELECT * from Chitietnhap where maPN like N'%" + txtTimKiem.Text + "%' ", conn);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            dgvCTNhap.DataSource = dt1;
        }

        private void btnLamMoi_Click_1(object sender, EventArgs e)
        {
            LoadData();
            cbxMaCTN.Text = "";
            txtSoLuong.Text = "";
            txtMaHH.Text = "";
            txtDonGia.Text = "";
            txtTongTien.Text = "";

            btnThem1.Enabled = true;
            btnSua1.Enabled = true;
            btnLuu1.Enabled = false;
            btnXoa1.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            btnXoa.Enabled = true;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            cmm = new SqlCommand("select count(*) from NhapHang", conn);
            SqlCommand cmd = new SqlCommand("LamMoiPN", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter p = new SqlParameter();
            p = new SqlParameter("@MaPN", txtMaPN.Text);
            cmd.Parameters.Add(p);

            int count = cmd.ExecuteNonQuery();
            if (count > 0)
            {
                MessageBox.Show("Cập nhật thành công");
                LoadData();
            }
            else MessageBox.Show("Không thể cập nhật");

            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = true;
            btnXoa.Enabled = true;
        }

        private void dgvCTNhap_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                cbxMaCTN.Text = (dgvCTNhap.CurrentRow.Cells["maPN1"].Value.ToString());
                txtMaHH.Text = Convert.ToString(dgvCTNhap.CurrentRow.Cells["maHH"].Value);
                txtSoLuong.Text = Convert.ToString(dgvCTNhap.CurrentRow.Cells["soLuong"].Value);
                txtDonGia.Text = Convert.ToString(dgvCTNhap.CurrentRow.Cells["donGia"].Value);               
            }
        }

        private void dgvNhapHang_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                txtMaPN.Text = (dgvNhapHang.CurrentRow.Cells["maPN"].Value.ToString());
                date1.Text = Convert.ToString(dgvNhapHang.CurrentRow.Cells["ngayNhap"].Value);
                txtTongTien.Text = Convert.ToString(dgvNhapHang.CurrentRow.Cells["tongTien"].Value);
            }
        }
    }
}
