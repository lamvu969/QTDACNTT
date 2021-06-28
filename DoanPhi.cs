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
    public partial class DoanPhi : Form
    {
        public DoanPhi()
        {
            InitializeComponent();
        }
        private void getdata()
        {
            SqlCommand cmd = new SqlCommand("Select * from DoanPhi ", SBT.conn);
            SBT.conn.Open();
            SqlDataAdapter add = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            add.Fill(ds, "dv");
            dgv.DataSource = ds.Tables["dv"];
            SBT.conn.Close();
        }

        private void ClearText()
        {
            txtmadoanphi.Clear();
            txtmadv.Clear();
            txtsotien.Clear();
            txthientai.Clear();
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
            txtmadoanphi.Enabled = true;
            getdata();
            ClearText();
        }

        private void DoanPhi_Load(object sender, EventArgs e)
        {
            txtmadoanphi.Enabled = true;
            getdata();
            ClearText();
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select * from DoanPhi where madp='" + txttimkiem.Text + "' or madv='" + txttimkiem.Text + "' or sotien='" + txttimkiem.Text + "' or hientai='" + txttimkiem.Text + "' or namhoc='" + txttimkiem.Text + "' ", SBT.conn);
            SBT.conn.Open();
            SqlDataAdapter add = new SqlDataAdapter(cmd);
            DataSet tim = new DataSet();
            add.Fill(tim, "tmi");
            dgv.DataSource = tim.Tables["tmi"];
            SBT.conn.Close();
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select count (*) from DoanPhi where madp= @madp", SBT.conn);
            SBT.conn.Open();
            cmd.Parameters.AddWithValue("@madp", txtmadoanphi.Text);
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
                SqlCommand cmd1 = new SqlCommand("INSERT INTO DoanPhi (madp, madv, sotien, hientai, namhoc) Values(@madp, @madv, @sotien, @hientai, @namhoc) ", SBT.conn);
                SBT.conn.Open();
                cmd1.Parameters.AddWithValue("@madp", txtmadoanphi.Text);
                cmd1.Parameters.AddWithValue("@madv", txtmadv.Text);
                cmd1.Parameters.AddWithValue("@sotien", txtsotien.Text);
                cmd1.Parameters.AddWithValue("@hientai", txthientai.Text);
                cmd1.Parameters.AddWithValue("@namhoc", txtnamhoc.Text);

                cmd1.ExecuteNonQuery();
                SBT.conn.Close();
                MessageBox.Show("Thêm thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                getdata();
                ClearText();
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            SqlCommand cmd1 = new SqlCommand("UPDATE DoanPhi SET madp=@madp, madv=@madv, sotien=@sotien, hientai=@hientai, namhoc=@namhoc WHERE madp=@madp", SBT.conn);
            SBT.conn.Open();
            cmd1.Parameters.AddWithValue("@madp", txtmadoanphi.Text);
            cmd1.Parameters.AddWithValue("@madv", txtmadv.Text);
            cmd1.Parameters.AddWithValue("@sotien", txtsotien.Text);
            cmd1.Parameters.AddWithValue("@hientai", txthientai.Text);
            cmd1.Parameters.AddWithValue("@namhoc", txtnamhoc.Text);

            cmd1.ExecuteNonQuery();
            SBT.conn.Close();
            MessageBox.Show("Sửa thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            getdata();
            ClearText();
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM DoanPhi WHERE madp=@madp", SBT.conn);
            SBT.conn.Open();
            cmd.Parameters.AddWithValue("@madp", txtmadoanphi.Text);
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
                txtmadoanphi.Text = dgv.Rows[id].Cells["madp"].Value.ToString();
                txtmadv.Text = dgv.Rows[id].Cells["madv"].Value.ToString();
                txtsotien.Text = dgv.Rows[id].Cells["sotien"].Value.ToString();
                txthientai.Text = dgv.Rows[id].Cells["hientai"].Value.ToString();
                txtnamhoc.Text = dgv.Rows[id].Cells["namhoc"].Value.ToString();
            }
            txtmadoanphi.Enabled = false;
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
