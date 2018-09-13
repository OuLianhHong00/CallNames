namespace MvcThreeModel
{
    partial class AddCourseInfo
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
            this.components = new System.ComponentModel.Container();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.l_couCover = new System.Windows.Forms.Label();
            this.t_time = new System.Windows.Forms.TextBox();
            this.t_num = new System.Windows.Forms.TextBox();
            this.t_id = new System.Windows.Forms.TextBox();
            this.t_cName = new System.Windows.Forms.TextBox();
            this.b_next = new System.Windows.Forms.Button();
            this.toolTip_sid = new System.Windows.Forms.ToolTip(this.components);
            this.b_return = new System.Windows.Forms.Button();
            this.b_save = new System.Windows.Forms.Button();
            this.l_cNum = new System.Windows.Forms.Label();
            this.l_cId = new System.Windows.Forms.Label();
            this.l_cName = new System.Windows.Forms.Label();
            this.toolTip_name = new System.Windows.Forms.ToolTip(this.components);
            this.l_time = new System.Windows.Forms.Label();
            this.g_add = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolTip_num = new System.Windows.Forms.ToolTip(this.components);
            this.g_add.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // l_couCover
            // 
            this.l_couCover.AutoSize = true;
            this.l_couCover.Location = new System.Drawing.Point(318, 40);
            this.l_couCover.Name = "l_couCover";
            this.l_couCover.Size = new System.Drawing.Size(65, 12);
            this.l_couCover.TabIndex = 21;
            this.l_couCover.Text = "课程封面：";
            // 
            // t_time
            // 
            this.t_time.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.t_time.ForeColor = System.Drawing.Color.Gray;
            this.t_time.Location = new System.Drawing.Point(111, 203);
            this.t_time.Name = "t_time";
            this.t_time.Size = new System.Drawing.Size(132, 21);
            this.t_time.TabIndex = 19;
            this.t_time.Text = "2018年秋季";
            this.t_time.TextChanged += new System.EventHandler(this.t_time_TextChanged_1);
            this.t_time.MouseDown += new System.Windows.Forms.MouseEventHandler(this.t_time_MouseDown_1);
            // 
            // t_num
            // 
            this.t_num.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.t_num.ForeColor = System.Drawing.Color.Gray;
            this.t_num.Location = new System.Drawing.Point(111, 148);
            this.t_num.MaxLength = 4;
            this.t_num.Name = "t_num";
            this.t_num.Size = new System.Drawing.Size(132, 21);
            this.t_num.TabIndex = 18;
            this.t_num.Text = "4位课序号";
            this.t_num.TextChanged += new System.EventHandler(this.t_num_TextChanged_1);
            this.t_num.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.t_num_KeyPress_1);
            this.t_num.MouseDown += new System.Windows.Forms.MouseEventHandler(this.t_num_MouseDown_1);
            // 
            // t_id
            // 
            this.t_id.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.t_id.ForeColor = System.Drawing.Color.Gray;
            this.t_id.Location = new System.Drawing.Point(111, 92);
            this.t_id.MaxLength = 10;
            this.t_id.Name = "t_id";
            this.t_id.Size = new System.Drawing.Size(132, 21);
            this.t_id.TabIndex = 17;
            this.t_id.Text = "10位课程号";
            this.t_id.TextChanged += new System.EventHandler(this.t_id_TextChanged_1);
            this.t_id.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.t_id_KeyPress_1);
            this.t_id.MouseDown += new System.Windows.Forms.MouseEventHandler(this.t_id_MouseDown_1);
            // 
            // t_cName
            // 
            this.t_cName.Location = new System.Drawing.Point(111, 37);
            this.t_cName.MaxLength = 20;
            this.t_cName.Name = "t_cName";
            this.t_cName.Size = new System.Drawing.Size(132, 21);
            this.t_cName.TabIndex = 16;
            this.t_cName.TextChanged += new System.EventHandler(this.t_cName_TextChanged);
            // 
            // b_next
            // 
            this.b_next.Enabled = false;
            this.b_next.Location = new System.Drawing.Point(168, 251);
            this.b_next.Name = "b_next";
            this.b_next.Size = new System.Drawing.Size(75, 23);
            this.b_next.TabIndex = 15;
            this.b_next.Text = "下一步";
            this.b_next.UseVisualStyleBackColor = true;
            this.b_next.Click += new System.EventHandler(this.b_next_Click_1);
            // 
            // toolTip_sid
            // 
            this.toolTip_sid.Active = false;
            this.toolTip_sid.IsBalloon = true;
            // 
            // b_return
            // 
            this.b_return.Location = new System.Drawing.Point(472, 8);
            this.b_return.Name = "b_return";
            this.b_return.Size = new System.Drawing.Size(75, 23);
            this.b_return.TabIndex = 24;
            this.b_return.Text = "返回";
            this.b_return.UseVisualStyleBackColor = true;
            this.b_return.Click += new System.EventHandler(this.b_return_Click_1);
            // 
            // b_save
            // 
            this.b_save.Location = new System.Drawing.Point(42, 251);
            this.b_save.Name = "b_save";
            this.b_save.Size = new System.Drawing.Size(75, 23);
            this.b_save.TabIndex = 14;
            this.b_save.Text = "保存";
            this.b_save.UseVisualStyleBackColor = true;
            this.b_save.Click += new System.EventHandler(this.b_save_Click_1);
            // 
            // l_cNum
            // 
            this.l_cNum.AutoSize = true;
            this.l_cNum.Location = new System.Drawing.Point(40, 151);
            this.l_cNum.Name = "l_cNum";
            this.l_cNum.Size = new System.Drawing.Size(53, 12);
            this.l_cNum.TabIndex = 13;
            this.l_cNum.Text = "课序号：";
            // 
            // l_cId
            // 
            this.l_cId.AutoSize = true;
            this.l_cId.Location = new System.Drawing.Point(40, 96);
            this.l_cId.Name = "l_cId";
            this.l_cId.Size = new System.Drawing.Size(53, 12);
            this.l_cId.TabIndex = 11;
            this.l_cId.Text = "课程号：";
            // 
            // l_cName
            // 
            this.l_cName.AutoSize = true;
            this.l_cName.Location = new System.Drawing.Point(40, 40);
            this.l_cName.Name = "l_cName";
            this.l_cName.Size = new System.Drawing.Size(53, 12);
            this.l_cName.TabIndex = 10;
            this.l_cName.Text = "课程名：";
            // 
            // toolTip_name
            // 
            this.toolTip_name.Active = false;
            this.toolTip_name.IsBalloon = true;
            // 
            // l_time
            // 
            this.l_time.AutoSize = true;
            this.l_time.Location = new System.Drawing.Point(40, 205);
            this.l_time.Name = "l_time";
            this.l_time.Size = new System.Drawing.Size(65, 12);
            this.l_time.TabIndex = 12;
            this.l_time.Text = "教学时间：";
            // 
            // g_add
            // 
            this.g_add.Controls.Add(this.l_couCover);
            this.g_add.Controls.Add(this.pictureBox1);
            this.g_add.Controls.Add(this.t_time);
            this.g_add.Controls.Add(this.t_num);
            this.g_add.Controls.Add(this.t_id);
            this.g_add.Controls.Add(this.t_cName);
            this.g_add.Controls.Add(this.b_next);
            this.g_add.Controls.Add(this.b_save);
            this.g_add.Controls.Add(this.l_cNum);
            this.g_add.Controls.Add(this.l_time);
            this.g_add.Controls.Add(this.l_cId);
            this.g_add.Controls.Add(this.l_cName);
            this.g_add.Location = new System.Drawing.Point(21, 37);
            this.g_add.Name = "g_add";
            this.g_add.Size = new System.Drawing.Size(526, 319);
            this.g_add.TabIndex = 23;
            this.g_add.TabStop = false;
            this.g_add.Text = "添加课程信息";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Gray;
            this.pictureBox1.Location = new System.Drawing.Point(320, 92);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(175, 180);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click_1);
            // 
            // AddCourseInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MvcThreeModel.Properties.Resources.bg2;
            this.ClientSize = new System.Drawing.Size(580, 381);
            this.Controls.Add(this.b_return);
            this.Controls.Add(this.g_add);
            this.Name = "AddCourseInfo";
            this.Text = "课程信息";
            this.g_add.ResumeLayout(false);
            this.g_add.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label l_couCover;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox t_time;
        private System.Windows.Forms.TextBox t_num;
        private System.Windows.Forms.TextBox t_id;
        private System.Windows.Forms.TextBox t_cName;
        private System.Windows.Forms.Button b_next;
        private System.Windows.Forms.ToolTip toolTip_sid;
        private System.Windows.Forms.Button b_return;
        private System.Windows.Forms.Button b_save;
        private System.Windows.Forms.Label l_cNum;
        private System.Windows.Forms.Label l_cId;
        private System.Windows.Forms.Label l_cName;
        private System.Windows.Forms.ToolTip toolTip_name;
        private System.Windows.Forms.Label l_time;
        private System.Windows.Forms.GroupBox g_add;
        private System.Windows.Forms.ToolTip toolTip_num;
    }
}