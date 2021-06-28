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
using System.IO;
using Microsoft.Office.Interop.Excel;
using app = Microsoft.Office.Interop.Excel.Application;
using DataTable = System.Data.DataTable;


namespace DOAN.NET
{
    public partial class DoanVien : Form
    {
        private void getdata(string MaHD)
        {
            SqlCommand cmd = new SqlCommand("Select * from KyLuat where madv='" + MaHD + "'", SBT.conn);
            SBT.conn.Open();
            SqlDataAdapter add = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            add.Fill(ds, "kl");
            dgv1.DataSource = ds.Tables["kl"];
            SBT.conn.Close();
        }
        private void getdv()
        {
            SqlCommand cmd = new SqlCommand("Select * from DoanVien ", SBT.conn);
            SBT.conn.Open();
            SqlDataAdapter add2 = new SqlDataAdapter(cmd);
            DataSet ds2 = new DataSet();
            add2.Fill(ds2, "dv");
            dgv.DataSource = ds2.Tables["dv"];
            SBT.conn.Close();
        }

        private void ClearText()
        {
            txtmadv.Clear();
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
            txtnamhoc.Clear();
            txtmakl.Clear();
            txtvipham.Clear();
            txtmadv2.Clear();
            txtnamhoc2.Clear();
        }
        public DoanVien()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TrangChu frm = new TrangChu();
            frm.Show();
            this.Hide();
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {

        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            txtmadv.Enabled = true;
            getdv();
            ptb_image.Hide();

            ClearText();
            getdata(txtmadv.Text);
        }

        private void DoanVien_Load(object sender, EventArgs e)
        {
            txtmadv.Enabled = true;
            getdv();
            ClearText();

            ptb_image.Hide();
            getdata(txtmadv.Text);
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select * from DoanVien where madv='" + txttimkiem.Text + "' or hoten='" + txttimkiem.Text + "' or chidoan='" + txttimkiem.Text + "' or namhoc='" + txttimkiem.Text + "'  ", SBT.conn);
            SBT.conn.Open();
            SqlDataAdapter add = new SqlDataAdapter(cmd);
            DataSet tim = new DataSet();
            add.Fill(tim, "tmi");
            dgv.DataSource = tim.Tables["tmi"];
            SBT.conn.Close();
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            DialogResult tb = MessageBox.Show("Bạn có chắc muốn thêm đoàn viên mới này ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (tb == DialogResult.OK)
            {
                SqlCommand cmd = new SqlCommand("Select count (*) from DoanVien where madv= @madv", SBT.conn);
                SBT.conn.Open();
                cmd.Parameters.AddWithValue("@madv", txtmadv.Text);
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
                    SqlCommand cmd1 = new SqlCommand("INSERT INTO DoanVien(madv, hoten, chucvu, ngaysinh, ngayvaodoan, gioitinh, quequan, vanhoa, nangkhieu, chidoan, namhoc, img) Values(@madv, @hoten, @chucvu, @ngaysinh, @ngayvaodoan, @gioitinh, @quequan, @vanhoa, @nangkhieu, @chidoan, @namhoc, @img) ", SBT.conn);
                    SBT.conn.Open();
                    cmd1.Parameters.AddWithValue("@madv", txtmadv.Text);
                    cmd1.Parameters.AddWithValue("@hoten", txthoten.Text);
                    cmd1.Parameters.AddWithValue("@chucvu", txtchucvu.Text);
                    cmd1.Parameters.AddWithValue("@ngaysinh", txtngaysinh.Value);
                    cmd1.Parameters.AddWithValue("@ngayvaodoan", txtngayvaodoan.Value);


                    if (txtnam.Checked == true)
                    {
                        cmd1.Parameters.AddWithValue("@gioitinh", "Nam");
                    }
                    else
                    {
                        cmd1.Parameters.AddWithValue("@gioitinh", "Nữ");
                    }

                    cmd1.Parameters.AddWithValue("@quequan", txtquequan.Text);
                    cmd1.Parameters.AddWithValue("@vanhoa", txtvanhoa.Text);
                    cmd1.Parameters.AddWithValue("@nangkhieu", txtnangkhieu.Text);
                    cmd1.Parameters.AddWithValue("@chidoan", txtchidoan.Text);
                    cmd1.Parameters.AddWithValue("@namhoc", txtnamhoc.Text);
                    cmd1.Parameters.AddWithValue("@img", convertImageToBytes());
                    cmd1.ExecuteNonQuery();
                    SBT.conn.Close();
                    MessageBox.Show("Thêm thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    getdv();
                    ClearText();
                }
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            DialogResult tb = MessageBox.Show("Bạn có chắc muốn lưu thông tin đã sửa ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (tb == DialogResult.OK)
            {
                SqlCommand cmd1 = new SqlCommand("UPDATE DoanVien SET hoten=@hoten, chucvu=@chucvu, ngaysinh=@ngaysinh, ngayvaodoan=@ngayvaodoan, gioitinh=@gioitinh, quequan=@quequan, vanhoa=@vanhoa, nangkhieu=@nangkhieu, chidoan=@chidoan, namhoc=@namhoc, img=@img WHERE madv=@madv", SBT.conn);
                SBT.conn.Open();
                cmd1.Parameters.AddWithValue("@madv", txtmadv.Text);
                cmd1.Parameters.AddWithValue("@hoten", txthoten.Text);
                cmd1.Parameters.AddWithValue("@chucvu", txtchucvu.Text);
                cmd1.Parameters.AddWithValue("@ngaysinh", txtngaysinh.Value);
                cmd1.Parameters.AddWithValue("@ngayvaodoan", txtngayvaodoan.Value);


                if (txtnam.Checked == true)
                {
                    cmd1.Parameters.AddWithValue("@gioitinh", "Nam");
                }
                else
                {
                    cmd1.Parameters.AddWithValue("@gioitinh", "Nữ");
                }

                cmd1.Parameters.AddWithValue("@quequan", txtquequan.Text);
                cmd1.Parameters.AddWithValue("@vanhoa", txtvanhoa.Text);
                cmd1.Parameters.AddWithValue("@nangkhieu", txtnangkhieu.Text);
                cmd1.Parameters.AddWithValue("@chidoan", txtchidoan.Text);
                cmd1.Parameters.AddWithValue("@namhoc", txtnamhoc.Text);
                cmd1.Parameters.AddWithValue("@img", convertImageToBytes());
                ptb_image.Hide();
                cmd1.ExecuteNonQuery();
                SBT.conn.Close();
                MessageBox.Show("Sửa thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                getdv();
                ClearText();
                getdata(txtmadv.Text);
            }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            DialogResult tb = MessageBox.Show("Bạn có chắc muốn xóa ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (tb == DialogResult.OK)
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM DoanVien WHERE madv=@madv", SBT.conn);
                SBT.conn.Open();
                cmd.Parameters.AddWithValue("@madv", txtmadv.Text);
                cmd.ExecuteNonQuery();
                SBT.conn.Close();
                MessageBox.Show("Xóa thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                getdv();
                ClearText();
                getdata(txtmadv.Text);
            }
        }

        private void dgv_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int id = e.RowIndex;
            if (id >= 0)
            {
                txtmadv.Text = dgv.Rows[id].Cells["madv"].Value.ToString();
                txthoten.Text = dgv.Rows[id].Cells["hoten"].Value.ToString();
                txtchucvu.Text = dgv.Rows[id].Cells["chucvu"].Value.ToString();

                txtngaysinh.Value = Convert.ToDateTime(dgv.Rows[id].Cells["ngaysinh"].Value.ToString());
                txtngayvaodoan.Value = Convert.ToDateTime(dgv.Rows[id].Cells["ngayvaodoan"].Value.ToString());

                string gioitinh = dgv.Rows[id].Cells["gioitinh"].Value.ToString();
                if (gioitinh == "Nam")
                {
                    txtnam.Checked = true;
                }
                else
                {
                    txtnu.Checked = true;
                }

                txtquequan.Text = dgv.Rows[id].Cells["quequan"].Value.ToString();
                txtvanhoa.Text = dgv.Rows[id].Cells["vanhoa"].Value.ToString();
                txtnangkhieu.Text = dgv.Rows[id].Cells["nangkhieu"].Value.ToString();
                txtchidoan.Text = dgv.Rows[id].Cells["chidoan"].Value.ToString();
                txtnamhoc.Text = dgv.Rows[id].Cells["namhoc"].Value.ToString();

                int r = dgv.CurrentCell.RowIndex;
                txt_anhdv.Text = dgv.Rows[r].Cells[11].Value.ToString();
                byte[] b = (byte[])dgv.Rows[r].Cells[11].Value;
                ptb_image.Image = ByteArrayToImage(b);
                ptb_image.Show();
                SBT.conn.Close();

                getdata(txtmadv.Text);
            }
            txtmadv.Enabled = false;
        }

        private void quayLạiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TrangChu frm = new TrangChu();
            frm.Show();
            this.Hide();
        }
        Image ByteArrayToImage(byte[] b)
        {
            MemoryStream m = new MemoryStream(b);
            return Image.FromStream(m);
        }
        private byte[] convertImageToBytes()
        {
            FileStream fs;
            fs = new FileStream(txt_anhdv.Text, FileMode.Open, FileAccess.Read);
            byte[] picbyte = new byte[fs.Length];
            fs.Read(picbyte, 0, System.Convert.ToInt32(fs.Length));
            fs.Close();
            return picbyte;
        }
        private void btnchontep_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "JPG files (*.jpg)|*.jpg|GIF files (*.gif)|*.gif|All files (*.*)|*.*";
            dlg.FilterIndex = 1;
            dlg.RestoreDirectory = true;
            ptb_image.Show();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                ptb_image.ImageLocation = dlg.FileName;
                txt_anhdv.Text = dlg.FileName;
            }
        }

        private void dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = e.RowIndex;
            if (id >= 0)
            {
                txtmakl.Text = dgv1.Rows[id].Cells["makl"].Value.ToString();
                txtmadv2.Text = dgv1.Rows[id].Cells["madv"].Value.ToString();
                txtvipham.Text = dgv1.Rows[id].Cells["htvp"].Value.ToString();
                txtnamhoc2.Text = dgv1.Rows[id].Cells["namhoc"].Value.ToString();
                getdata(txtmadv.Text);
            }
            txtmakl.Enabled = false;
            txtmadv2.Enabled = false;
            txtvipham.Enabled = false;
            txtnamhoc2.Enabled = false;
        }

        private void btnchontep_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "JPG files (*.jpg)|*.jpg|GIF files (*.gif)|*.gif|All files (*.*)|*.*";
            dlg.FilterIndex = 1;
            dlg.RestoreDirectory = true;
            ptb_image.Show();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                ptb_image.ImageLocation = dlg.FileName;
                txt_anhdv.Text = dlg.FileName;
            }
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult tb = MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (tb == DialogResult.OK)
            {
                Close();
            }
        }

        private void btnxuat_Click(object sender, EventArgs e)
        {
            export2Excel(dgv, @"E:\CNPM4\DOAN.NET\FileExcel\DS_", "Excel");
            MessageBox.Show("Xuất file Excel thành công");
        }
        private void export2Excel(DataGridView g, string duongdan, string tentap)
        {
            app obj = new app();
            obj.Application.Workbooks.Add(Type.Missing);
            obj.Columns.ColumnWidth = 25;
            for (int i = 1; i < g.Columns.Count + 1; i++)
            {
                obj.Cells[1, i] = g.Columns[i - 1].HeaderText;
            }
            for (int i = 0; i < g.Rows.Count; i++)
            {
                for (int j = 0; j < g.Columns.Count; j++)
                {
                    if (g.Rows[i].Cells[j].Value != null)
                    {
                        obj.Cells[i + 2, j + 1] = g.Rows[i].Cells[j].Value.ToString();
                    }
                }
            }
            obj.ActiveWorkbook.SaveCopyAs(duongdan + tentap + ".xlsx");
            obj.ActiveWorkbook.Saved = true;
        }
    }
}
