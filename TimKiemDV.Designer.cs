namespace DOAN.NET
{
    partial class TimKiemDV
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TimKiemDV));
            this.radchidoan = new System.Windows.Forms.RadioButton();
            this.radgioitinh = new System.Windows.Forms.RadioButton();
            this.radtendv = new System.Windows.Forms.RadioButton();
            this.radmadv = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtma = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.quayLạiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thoátToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btntimkiem = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // radchidoan
            // 
            this.radchidoan.AutoSize = true;
            this.radchidoan.BackColor = System.Drawing.Color.Transparent;
            this.radchidoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radchidoan.Location = new System.Drawing.Point(41, 149);
            this.radchidoan.Margin = new System.Windows.Forms.Padding(4);
            this.radchidoan.Name = "radchidoan";
            this.radchidoan.Size = new System.Drawing.Size(93, 21);
            this.radchidoan.TabIndex = 28;
            this.radchidoan.TabStop = true;
            this.radchidoan.Text = "Chi đoàn";
            this.radchidoan.UseVisualStyleBackColor = false;
            // 
            // radgioitinh
            // 
            this.radgioitinh.AutoSize = true;
            this.radgioitinh.BackColor = System.Drawing.Color.Transparent;
            this.radgioitinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radgioitinh.Location = new System.Drawing.Point(41, 112);
            this.radgioitinh.Margin = new System.Windows.Forms.Padding(4);
            this.radgioitinh.Name = "radgioitinh";
            this.radgioitinh.Size = new System.Drawing.Size(90, 21);
            this.radgioitinh.TabIndex = 27;
            this.radgioitinh.TabStop = true;
            this.radgioitinh.Text = "Giới tính";
            this.radgioitinh.UseVisualStyleBackColor = false;
            // 
            // radtendv
            // 
            this.radtendv.AutoSize = true;
            this.radtendv.BackColor = System.Drawing.Color.Transparent;
            this.radtendv.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radtendv.Location = new System.Drawing.Point(41, 77);
            this.radtendv.Margin = new System.Windows.Forms.Padding(4);
            this.radtendv.Name = "radtendv";
            this.radtendv.Size = new System.Drawing.Size(133, 21);
            this.radtendv.TabIndex = 25;
            this.radtendv.TabStop = true;
            this.radtendv.Text = "Tên đoàn viên";
            this.radtendv.UseVisualStyleBackColor = false;
            // 
            // radmadv
            // 
            this.radmadv.AutoSize = true;
            this.radmadv.BackColor = System.Drawing.Color.Transparent;
            this.radmadv.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radmadv.Location = new System.Drawing.Point(41, 39);
            this.radmadv.Margin = new System.Windows.Forms.Padding(4);
            this.radmadv.Name = "radmadv";
            this.radmadv.Size = new System.Drawing.Size(126, 21);
            this.radmadv.TabIndex = 26;
            this.radmadv.TabStop = true;
            this.radmadv.Text = "Mã đoàn viên";
            this.radmadv.UseVisualStyleBackColor = false;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Menu;
            this.groupBox1.Controls.Add(this.txtma);
            this.groupBox1.Controls.Add(this.radmadv);
            this.groupBox1.Controls.Add(this.radchidoan);
            this.groupBox1.Controls.Add(this.radtendv);
            this.groupBox1.Controls.Add(this.radgioitinh);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBox1.ForeColor = System.Drawing.Color.Blue;
            this.groupBox1.Location = new System.Drawing.Point(470, 119);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(412, 192);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm theo các mục sau";
            // 
            // txtma
            // 
            this.txtma.Location = new System.Drawing.Point(218, 95);
            this.txtma.Name = "txtma";
            this.txtma.Size = new System.Drawing.Size(158, 24);
            this.txtma.TabIndex = 29;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(462, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(461, 45);
            this.label3.TabIndex = 30;
            this.label3.Text = "TÌM KIẾM ĐOÀN VIÊN";
            // 
            // dgv
            // 
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(35, 406);
            this.dgv.Name = "dgv";
            this.dgv.RowTemplate.Height = 24;
            this.dgv.Size = new System.Drawing.Size(1274, 169);
            this.dgv.TabIndex = 31;
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quayLạiToolStripMenuItem,
            this.thoátToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1321, 28);
            this.menuStrip1.TabIndex = 73;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // quayLạiToolStripMenuItem
            // 
            this.quayLạiToolStripMenuItem.Image = global::DOAN.NET.Properties.Resources.Custom_Icon_Design_Flatastic_8_Go_back;
            this.quayLạiToolStripMenuItem.Name = "quayLạiToolStripMenuItem";
            this.quayLạiToolStripMenuItem.Size = new System.Drawing.Size(95, 24);
            this.quayLạiToolStripMenuItem.Text = "Quay lại";
            this.quayLạiToolStripMenuItem.Click += new System.EventHandler(this.quayLạiToolStripMenuItem_Click);
            // 
            // thoátToolStripMenuItem
            // 
            this.thoátToolStripMenuItem.Image = global::DOAN.NET.Properties.Resources.button_cancel;
            this.thoátToolStripMenuItem.Name = "thoátToolStripMenuItem";
            this.thoátToolStripMenuItem.Size = new System.Drawing.Size(79, 24);
            this.thoátToolStripMenuItem.Text = "Thoát";
            this.thoátToolStripMenuItem.Click += new System.EventHandler(this.thoátToolStripMenuItem_Click);
            // 
            // btntimkiem
            // 
            this.btntimkiem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btntimkiem.BackgroundImage")));
            this.btntimkiem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btntimkiem.FlatAppearance.BorderSize = 0;
            this.btntimkiem.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btntimkiem.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btntimkiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btntimkiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btntimkiem.Image = global::DOAN.NET.Properties.Resources.search;
            this.btntimkiem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btntimkiem.Location = new System.Drawing.Point(611, 324);
            this.btntimkiem.Margin = new System.Windows.Forms.Padding(4);
            this.btntimkiem.Name = "btntimkiem";
            this.btntimkiem.Size = new System.Drawing.Size(166, 70);
            this.btntimkiem.TabIndex = 72;
            this.btntimkiem.Text = "Tìm kiếm";
            this.btntimkiem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btntimkiem.UseVisualStyleBackColor = true;
            this.btntimkiem.Click += new System.EventHandler(this.btntimkiem_Click);
            // 
            // TimKiemDV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(1321, 587);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.btntimkiem);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TimKiemDV";
            this.Text = "TimKiemDV";
            this.Load += new System.EventHandler(this.TimKiemDV_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radchidoan;
        private System.Windows.Forms.RadioButton radgioitinh;
        private System.Windows.Forms.RadioButton radtendv;
        private System.Windows.Forms.RadioButton radmadv;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Button btntimkiem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem quayLạiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thoátToolStripMenuItem;
        private System.Windows.Forms.TextBox txtma;
    }
}