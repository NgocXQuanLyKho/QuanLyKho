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
    public partial class XuatHang : Form
    {
        int a;
        SqlCommand cmm;
        string strConn = @"Data Source=NGOCXINH\SQLEXPRESS;Initial Catalog=QuanLyKho;Integrated Security=True";
        SqlConnection conn = new SqlConnection();
        private void LoadData()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * from PhieuXuat", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvXuatHang.DataSource = dt;
            SqlDataAdapter da1 = new SqlDataAdapter("SELECT * from Chitietxuat", conn);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            dgvCTXuat.DataSource = dt1;

        }
        public XuatHang()
        {
            InitializeComponent();
            conn = new SqlConnection(strConn);
            conn.Open();
            LoadData();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            cmm = new SqlCommand("select count(*) from PhieuXuat", conn);
            SqlDataReader dr = cmm.ExecuteReader();
            int soluong = 0;
            if (dr.Read())
            {
                soluong = dr.GetInt32(0);
                dr.Close();
            }
            for (int i = 0; i <= soluong; i++)
            {
                txtMaPX.Text = (i + 1).ToString();
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
                        cmm = new SqlCommand("select count(*) from PhieuXuat", conn);

                        SqlCommand cmd = new SqlCommand("ThemPhieuXuat", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlParameter p = new SqlParameter();
                        p = new SqlParameter("@MaPX", txtMaPX.Text);
                        cmd.Parameters.Add(p);
                        p = new SqlParameter("@NgayXuat", date1.Value.Date.ToString(""));
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
                        SqlCommand cmd = new SqlCommand("SuaPhieuXuat", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlParameter p = new SqlParameter();
                        p = new SqlParameter("@MaPX", txtMaPX.Text);
                        cmd.Parameters.Add(p);
                        p = new SqlParameter("@NgayXuat", date1.Value.Date.ToString(""));
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
                            SqlCommand cmd = new SqlCommand("XoaPhieuXuat", conn);
                            cmd.CommandType = CommandType.StoredProcedure;
                            SqlParameter p = new SqlParameter("@MaPX", txtMaPX.Text);
                            cmd.Parameters.Add(p);
                            int count = cmd.ExecuteNonQuery();
                            if (count > 0)
                            {
                                MessageBox.Show("Xoá thành công!");
                                LoadData();
                                txtMaPX.Text = "";
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
            btnThem1.Enabled = false;
            btnSua1.Enabled = false;
            btnXoa1.Enabled = false;
            btnLuu1.Enabled = true;
            a = 1;
            cbxMaCTX.Text = "";
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
                        cmm = new SqlCommand("select count(*) from Chitietxuat", conn);

                        SqlCommand cmd = new SqlCommand("ThemCTXuat", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlParameter p = new SqlParameter();
                        p = new SqlParameter("@MaCTPX", cbxMaCTX.Text);
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
                        SqlCommand cmd = new SqlCommand("SuaCTXuat", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlParameter p = new SqlParameter();
                        p = new SqlParameter("@MaCTPX", cbxMaCTX.Text);
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
                            SqlCommand cmd = new SqlCommand("XoaCTXuat", conn);
                            cmd.CommandType = CommandType.StoredProcedure;
                            SqlParameter p = new SqlParameter();                            
                            p = new SqlParameter("@MaCTPX", cbxMaCTX.Text);
                            cmd.Parameters.Add(p);
                            
                            int count = cmd.ExecuteNonQuery();
                            if (count > 0)
                            {
                                MessageBox.Show("Xoá thành công!");
                                LoadData();
                                cbxMaCTX.Text = "";
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

        private void dgvXuatHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dgvCTXuat_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void XuatHang_Load(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from PhieuXuat", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cbxMaCTX.DataSource = dt;
            cbxMaCTX.DisplayMember = "maPX";
            cbxMaCTX.ValueMember = "maPX";

            //dgvCTXuat.DataSource = dt;
        }

        private void cbxMaCTX_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from Chitietxuat where maPX ='" + cbxMaCTX.Text + "'", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvCTXuat.DataSource = dt;
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

        private void dgvXuatHang_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                txtMaPX.Text = (dgvXuatHang.CurrentRow.Cells["maPX"].Value.ToString());
                date1.Text = Convert.ToString(dgvXuatHang.CurrentRow.Cells["ngayXuat"].Value);
                txtTongTien.Text = Convert.ToString(dgvXuatHang.CurrentRow.Cells["tongTien"].Value);
            }
        }

        private void dgvCTXuat_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                cbxMaCTX.Text = (dgvCTXuat.CurrentRow.Cells["maPX1"].Value.ToString());
                txtMaHH.Text = Convert.ToString(dgvCTXuat.CurrentRow.Cells["maHH"].Value);
                txtSoLuong.Text = Convert.ToString(dgvCTXuat.CurrentRow.Cells["soLuong"].Value);
                txtDonGia.Text = Convert.ToString(dgvCTXuat.CurrentRow.Cells["donGia"].Value);
            }
        }

        private void txtTimKiem_TextChanged_1(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * from PhieuXuat where maPX like N'%" + txtTimKiem.Text + "%' ", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvXuatHang.DataSource = dt;

            SqlDataAdapter da1 = new SqlDataAdapter("SELECT * from Chitietxuat where maPX like N'%" + txtTimKiem.Text + "%' ", conn);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            dgvCTXuat.DataSource = dt1;
        }

        private void btnTK_Click_1(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * from PhieuXuat where maPX like N'%" + txtTimKiem.Text + "%' ", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvXuatHang.DataSource = dt;

            SqlDataAdapter da1 = new SqlDataAdapter("SELECT * from Chitietxuat where maPX like N'%" + txtTimKiem.Text + "%' ", conn);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            dgvCTXuat.DataSource = dt1;
        }

        private void btnLamMoi_Click_1(object sender, EventArgs e)
        {
            LoadData();
            cbxMaCTX.Text = "";
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

        private void button1_Click(object sender, EventArgs e)
        {
            cmm = new SqlCommand("select count(*) from XuatHang", conn);
            SqlCommand cmd = new SqlCommand("LamMoiPX", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter p = new SqlParameter();
            p = new SqlParameter("@MaPX", txtMaPX.Text);
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
    }
}
