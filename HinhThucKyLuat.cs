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

namespace DOAN.NET
{
    public partial class HinhThucKyLuat : Form
    {
        public HinhThucKyLuat()
        {
            InitializeComponent();
        }
        private void getdata()
        {
            SqlCommand cmd = new SqlCommand("Select * from HinhThucKyLuat ", SBT.conn);
            SBT.conn.Open();
            SqlDataAdapter add = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            add.Fill(ds, "dv");
            dgv.DataSource = ds.Tables["dv"];
            SBT.conn.Close();
        }

        private void ClearText()
        {
            txtmaHTKL.Clear();
            txtmadv.Clear();
            txtHTKL.Clear();
            txtsbb.Clear();
            txtnamhoc.Clear();
        }
        private void quayLạiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TrangChu frm = new TrangChu();
            frm.Show();
            this.Hide();
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            txtmaHTKL.Enabled = true;
            getdata();
            ClearText();
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {

        }

        private void HinhThucKyLuat_Load(object sender, EventArgs e)
        {
            txtmaHTKL.Enabled = true;
            getdata();
            ClearText();
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select * from HinhThucKyLuat where mahtkl='" + txttimkiem.Text + "' or madv='" + txttimkiem.Text + "' or htkl='" + txttimkiem.Text + "' or namhoc='" + txttimkiem.Text + "' or sobienban='" + txttimkiem.Text + "' ", SBT.conn);
            SBT.conn.Open();
            SqlDataAdapter add = new SqlDataAdapter(cmd);
            DataSet tim = new DataSet();
            add.Fill(tim, "tmi");
            dgv.DataSource = tim.Tables["tmi"];
            SBT.conn.Close();
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select count (*) from HinhThucKyLuat where mahtkl= @mahtkl", SBT.conn);
            SBT.conn.Open();
            cmd.Parameters.AddWithValue("@mahtkl", txtmaHTKL.Text);
            int Check = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            SBT.conn.Close();
            if (Check == 1)
            {
                MessageBox.Show("Đã tồn tại !", "thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ClearText();
            }
            if (Check == -1)
            {
                MessageBox.Show("Không được để trống các trường !", "thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ClearText();
            }
            else
            {
                SqlCommand cmd1 = new SqlCommand("INSERT INTO HinhThucKyLuat (mahtkl, madv, htkl, namhoc, sobienban) Values(@mahtkl, @madv, @htkl, @namhoc, @sobienban) ", SBT.conn);
                SBT.conn.Open();
                cmd1.Parameters.AddWithValue("@mahtkl", txtmaHTKL.Text);
                cmd1.Parameters.AddWithValue("@madv", txtmadv.Text);
                cmd1.Parameters.AddWithValue("@htkl", txtHTKL.Text);
                cmd1.Parameters.AddWithValue("@namhoc", txtnamhoc.Text);
                cmd1.Parameters.AddWithValue("@sobienban", txtsbb.Text);

                cmd1.ExecuteNonQuery();
                SBT.conn.Close();
                MessageBox.Show("Thêm thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                getdata();
                ClearText();
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            SqlCommand cmd1 = new SqlCommand("UPDATE HinhThucKyLuat SET mahtkl=@mahtkl, madv=@madv, htkl=@htkl, namhoc=@namhoc, sobienban=@sobienban WHERE mahtkl=@mahtkl", SBT.conn);
            SBT.conn.Open();
            cmd1.Parameters.AddWithValue("@mahtkl", txtmaHTKL.Text);
            cmd1.Parameters.AddWithValue("@madv", txtmadv.Text);
            cmd1.Parameters.AddWithValue("@htkl", txtHTKL.Text);
            cmd1.Parameters.AddWithValue("@namhoc", txtnamhoc.Text);
            cmd1.Parameters.AddWithValue("@sobienban", txtsbb.Text);

            cmd1.ExecuteNonQuery();
            SBT.conn.Close();
            MessageBox.Show("Sửa thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            getdata();
            ClearText();
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM HinhThucKyLuat WHERE mahtkl=@mahtkl", SBT.conn);
            SBT.conn.Open();
            cmd.Parameters.AddWithValue("@mahtkl", txtmaHTKL.Text);
            cmd.ExecuteNonQuery();
            SBT.conn.Close();
            MessageBox.Show("Xóa thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            getdata();
            ClearText();
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = e.RowIndex;
            if (id >= 0)
            {
                txtmaHTKL.Text = dgv.Rows[id].Cells["mahtkl"].Value.ToString();
                txtmadv.Text = dgv.Rows[id].Cells["madv"].Value.ToString();
                txtHTKL.Text = dgv.Rows[id].Cells["htkl"].Value.ToString();
                txtnamhoc.Text = dgv.Rows[id].Cells["namhoc"].Value.ToString();
                txtsbb.Text = dgv.Rows[id].Cells["sobienban"].Value.ToString();
            }
            txtmaHTKL.Enabled = false;
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
