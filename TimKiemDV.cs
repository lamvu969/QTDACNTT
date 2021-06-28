using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace DOAN.NET
{
    public partial class TimKiemDV : Form
    {
        public TimKiemDV()
        {
            InitializeComponent();
        }
        private void quayLạiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TrangChu frm = new TrangChu();
            frm.Show();
            this.Hide();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult tb = MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (tb == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select * from DoanVien where madv='" + txtma.Text + "' or hoten='" + txtma.Text + "' or chidoan='" + txtma.Text + "' or gioitinh='" + txtma.Text + "'  ", SBT.conn);
            SBT.conn.Open();
            SqlDataAdapter add = new SqlDataAdapter(cmd);
            DataSet tim = new DataSet();
            add.Fill(tim, "tmi");
            dgv.DataSource = tim.Tables["tmi"];
            SBT.conn.Close();
        }

        private void TimKiemDV_Load(object sender, EventArgs e)
        {
            
        }
    }
}
