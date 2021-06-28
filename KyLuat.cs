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
using System.Data.OleDb;

namespace DOAN.NET
{
    public partial class KyLuat : Form
    {
        public KyLuat()
        {
            InitializeComponent();
        }
        private void getdata(string MaHD)
        {
            SqlCommand cmd = new SqlCommand("Select * from DoanVien where madv='" + MaHD + "'", SBT.conn);
            SBT.conn.Open();
            SqlDataAdapter add = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            add.Fill(ds, "dv");
            dataGridView2.DataSource = ds.Tables["dv"];
            SBT.conn.Close();
        }
        private void getthongtinkl()
        {
            SqlCommand cmd = new SqlCommand("Select * from KyLuat ", SBT.conn);
            SBT.conn.Open();
            SqlDataAdapter add2 = new SqlDataAdapter(cmd);
            DataSet ds2 = new DataSet();
            add2.Fill(ds2, "kl");
            dgv1.DataSource = ds2.Tables["kl"];
            SBT.conn.Close();
        }
        private void clearText()
        {
            txtmakl.Clear();
            txtmadv.Clear();
            txtvipham.Clear();
            txtnamhoc.Clear();

            txthoten.Clear();
            txtchucvu.Clear();
            txtngaysinh.ResetText();
            txtngayvaodoan.ResetText();

            txtnam.Checked = false;
            txtnu.Checked = false;

            txtquequan.Clear();
            txtvanhoa.Clear();
            txtnangkhieu.Clear();
            txtchidoan.Clear();
            txtnamhoc2.Clear();
        }
        private void dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = e.RowIndex;
            if (id >= 0)
            {
                txtmakl.Text = dgv1.Rows[id].Cells["makl"].Value.ToString();
                txtmadv.Text = dgv1.Rows[id].Cells["madv"].Value.ToString();
                txtvipham.Text = dgv1.Rows[id].Cells["htvp"].Value.ToString();
                txtnamhoc.Text = dgv1.Rows[id].Cells["namhoc"].Value.ToString();

                getdata(txtmadv.Text);
            }
            txtmakl.Enabled = false;
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            DialogResult tb = MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (tb == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void KyLuat_Load(object sender, EventArgs e)
        {
            
            getthongtinkl();
            clearText();
            
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = e.RowIndex;
            if (id >= 0)
            {
                txtmadv.Text = dataGridView2.Rows[id].Cells["madv"].Value.ToString();
                txthoten.Text = dataGridView2.Rows[id].Cells["hoten"].Value.ToString();
                txtchucvu.Text = dataGridView2.Rows[id].Cells["chucvu"].Value.ToString();

                txtngaysinh.Value = Convert.ToDateTime(dataGridView2.Rows[id].Cells["ngaysinh"].Value.ToString());
                txtngayvaodoan.Value = Convert.ToDateTime(dataGridView2.Rows[id].Cells["ngayvaodoan"].Value.ToString());

                string gioitinh = dataGridView2.Rows[id].Cells["gioitinh"].Value.ToString();
                if (gioitinh == "Nam")
                {
                    txtnam.Checked = true;
                }
                else
                {
                    txtnu.Checked = true;
                }

                txtquequan.Text = dataGridView2.Rows[id].Cells["quequan"].Value.ToString();
                txtvanhoa.Text = dataGridView2.Rows[id].Cells["vanhoa"].Value.ToString();
                txtnangkhieu.Text = dataGridView2.Rows[id].Cells["nangkhieu"].Value.ToString();
                txtchidoan.Text = dataGridView2.Rows[id].Cells["chidoan"].Value.ToString();
                txtnamhoc2.Text = dataGridView2.Rows[id].Cells["namhoc"].Value.ToString();
            }
            txtmadv.Enabled = false;
        }

        private void dataGridView2_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int id = e.RowIndex;
            if (id >= 0)
            {
                txtmadv.Text = dataGridView2.Rows[id].Cells["madv"].Value.ToString();
                txthoten.Text = dataGridView2.Rows[id].Cells["hoten"].Value.ToString();
                txtchucvu.Text = dataGridView2.Rows[id].Cells["chucvu"].Value.ToString();

                txtngaysinh.Value = Convert.ToDateTime(dataGridView2.Rows[id].Cells["ngaysinh"].Value.ToString());
                txtngayvaodoan.Value = Convert.ToDateTime(dataGridView2.Rows[id].Cells["ngayvaodoan"].Value.ToString());

                string gioitinh = dataGridView2.Rows[id].Cells["gioitinh"].Value.ToString();
                if (gioitinh == "Nam")
                {
                    txtnam.Checked = true;
                }
                else
                {
                    txtnu.Checked = true;
                }

                txtquequan.Text = dataGridView2.Rows[id].Cells["quequan"].Value.ToString();
                txtvanhoa.Text = dataGridView2.Rows[id].Cells["vanhoa"].Value.ToString();
                txtnangkhieu.Text = dataGridView2.Rows[id].Cells["nangkhieu"].Value.ToString();
                txtchidoan.Text = dataGridView2.Rows[id].Cells["chidoan"].Value.ToString();
                txtnamhoc2.Text = dataGridView2.Rows[id].Cells["namhoc"].Value.ToString();
            }
            txthoten.Enabled = false;
            txtchucvu.Enabled = false;
            txtngaysinh.Enabled = false;
            txtngayvaodoan.Enabled = false;
            txtnam.Enabled = false;
            txtnu.Enabled = false;
            txtquequan.Enabled = false;
            txtvanhoa.Enabled = false;
            txtnangkhieu.Enabled = false;
            txtchidoan.Enabled = false;
            txtnamhoc2.Enabled = false;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TrangChu frm = new TrangChu();
            frm.Show();
            this.Hide();
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            txtmadv.Enabled = true;
            txtmakl.Enabled = true;
            txthoten.Enabled = true;
            txtchucvu.Enabled = true;
            txtngaysinh.Enabled = true;
            txtngayvaodoan.Enabled = true;
            txtnam.Enabled = true;
            txtnu.Enabled = true;
            txtquequan.Enabled = true;
            txtvanhoa.Enabled = true;
            txtnangkhieu.Enabled = true;
            txtchidoan.Enabled = true;
            txtnamhoc2.Enabled = true;

            getdata(txtmadv.Text);
            getthongtinkl();
            clearText();
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM KyLuat WHERE makl=@makl", SBT.conn);
            SBT.conn.Open();
            cmd.Parameters.AddWithValue("@makl", txtmakl.Text);
            cmd.ExecuteNonQuery();
            SBT.conn.Close();
            MessageBox.Show("Xóa thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            getthongtinkl();
            getdata(txtmadv.Text);
            clearText();
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select count (*) from KyLuat where makl= @makl", SBT.conn);
            SBT.conn.Open();
            cmd.Parameters.AddWithValue("@makl", txtmakl.Text);
            int Check = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            SBT.conn.Close();
            if (Check == 1)
            {
                MessageBox.Show("Đã tồn tại !", "thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                clearText();
            }
            if (Check == -1)
            {
                MessageBox.Show("Không được để trống các trường !", "thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                clearText();
            }
            else
            {
                SqlCommand cmd1 = new SqlCommand("INSERT INTO KyLuat(makl, madv, htvp, namhoc) Values(@makl, @madv, @htvp, @namhoc) ", SBT.conn);
                SBT.conn.Open();
                cmd1.Parameters.AddWithValue("@makl", txtmakl.Text);
                cmd1.Parameters.AddWithValue("@madv", txtmadv.Text);
                cmd1.Parameters.AddWithValue("@htvp", txtvipham.Text);
                cmd1.Parameters.AddWithValue("@namhoc", txtnamhoc.Text);
                
                cmd1.ExecuteNonQuery();
                SBT.conn.Close();
                MessageBox.Show("Thêm thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                getthongtinkl();
                getdata(txtmadv.Text);
                clearText();
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            SqlCommand cmd1 = new SqlCommand("UPDATE KyLuat SET madv=@madv, htvp=@htvp, namhoc=@namhoc WHERE makl=@makl", SBT.conn);
            SBT.conn.Open();
            cmd1.Parameters.AddWithValue("@makl", txtmakl.Text);
            cmd1.Parameters.AddWithValue("@madv", txtmadv.Text);
            cmd1.Parameters.AddWithValue("@htvp", txtvipham.Text);
            cmd1.Parameters.AddWithValue("@namhoc", txtnamhoc.Text);

            cmd1.ExecuteNonQuery();
            SBT.conn.Close();
            MessageBox.Show("Sửa thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            getdata(txtmadv.Text);
            getthongtinkl();
            clearText();
        }

        private void quayLạiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TrangChu frm = new TrangChu();
            frm.Show();
            this.Hide();
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select * from KyLuat where makl='" + txttimkiem.Text + "' or madv='" + txttimkiem.Text + "' or htvp='" + txttimkiem.Text + "' or namhoc='" + txttimkiem.Text + "' ", SBT.conn);
            SBT.conn.Open();
            SqlDataAdapter add = new SqlDataAdapter(cmd);
            DataSet tim = new DataSet();
            add.Fill(tim, "tmi");
            dgv1.DataSource = tim.Tables["tmi"];
            SBT.conn.Close();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult tb = MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (tb == DialogResult.OK)
            {
                Application.Exit();
            }
        }
    }
}
