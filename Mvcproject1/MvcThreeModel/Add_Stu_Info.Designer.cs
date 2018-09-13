namespace MvcThreeModel
{
    partial class Add_Stu_Info
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox_hand = new System.Windows.Forms.GroupBox();
            this.textBox_id = new System.Windows.Forms.TextBox();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.button_save = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox_auto = new System.Windows.Forms.GroupBox();
            this.button_return = new System.Windows.Forms.Button();
            this.button_finish = new System.Windows.Forms.Button();
            this.label_result = new System.Windows.Forms.Label();
            this.toolTip_name = new System.Windows.Forms.ToolTip(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.toolTip_sid = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox_hand.SuspendLayout();
            this.groupBox_auto.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(43, 31);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(559, 237);
            this.dataGridView1.TabIndex = 23;
            // 
            // groupBox_hand
            // 
            this.groupBox_hand.Controls.Add(this.textBox_id);
            this.groupBox_hand.Controls.Add(this.textBox_name);
            this.groupBox_hand.Controls.Add(this.button_save);
            this.groupBox_hand.Controls.Add(this.label3);
            this.groupBox_hand.Controls.Add(this.label4);
            this.groupBox_hand.Location = new System.Drawing.Point(43, 283);
            this.groupBox_hand.Name = "groupBox_hand";
            this.groupBox_hand.Size = new System.Drawing.Size(254, 168);
            this.groupBox_hand.TabIndex = 21;
            this.groupBox_hand.TabStop = false;
            this.groupBox_hand.Text = "手动添加";
            // 
            // textBox_id
            // 
            this.textBox_id.Location = new System.Drawing.Point(89, 81);
            this.textBox_id.MaxLength = 12;
            this.textBox_id.Name = "textBox_id";
            this.textBox_id.Size = new System.Drawing.Size(132, 21);
            this.textBox_id.TabIndex = 17;
            this.textBox_id.TextChanged += new System.EventHandler(this.textBox_id_TextChanged_1);
            this.textBox_id.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_id_KeyPress_1);
            // 
            // textBox_name
            // 
            this.textBox_name.Location = new System.Drawing.Point(89, 26);
            this.textBox_name.MaxLength = 10;
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(132, 21);
            this.textBox_name.TabIndex = 16;
            this.textBox_name.TextChanged += new System.EventHandler(this.textBox_name_TextChanged_1);
            this.textBox_name.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_name_KeyPress_1);
            // 
            // button_save
            // 
            this.button_save.Location = new System.Drawing.Point(89, 133);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(131, 23);
            this.button_save.TabIndex = 14;
            this.button_save.Text = "保存";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "学号：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "姓名：";
            // 
            // groupBox_auto
            // 
            this.groupBox_auto.Controls.Add(this.button_return);
            this.groupBox_auto.Controls.Add(this.button_finish);
            this.groupBox_auto.Location = new System.Drawing.Point(354, 283);
            this.groupBox_auto.Name = "groupBox_auto";
            this.groupBox_auto.Size = new System.Drawing.Size(248, 168);
            this.groupBox_auto.TabIndex = 22;
            this.groupBox_auto.TabStop = false;
            this.groupBox_auto.Text = "批量导入";
            // 
            // button_return
            // 
            this.button_return.Location = new System.Drawing.Point(135, 133);
            this.button_return.Name = "button_return";
            this.button_return.Size = new System.Drawing.Size(75, 23);
            this.button_return.TabIndex = 16;
            this.button_return.Text = "返回主页";
            this.button_return.UseVisualStyleBackColor = true;
            this.button_return.Click += new System.EventHandler(this.button_return_Click);
            // 
            // button_finish
            // 
            this.button_finish.Location = new System.Drawing.Point(26, 133);
            this.button_finish.Name = "button_finish";
            this.button_finish.Size = new System.Drawing.Size(75, 23);
            this.button_finish.TabIndex = 15;
            this.button_finish.Text = "点击添加";
            this.button_finish.UseVisualStyleBackColor = true;
            this.button_finish.Click += new System.EventHandler(this.button_finish_Click);
            // 
            // label_result
            // 
            this.label_result.AutoSize = true;
            this.label_result.BackColor = System.Drawing.Color.Transparent;
            this.label_result.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label_result.Location = new System.Drawing.Point(41, 9);
            this.label_result.Name = "label_result";
            this.label_result.Size = new System.Drawing.Size(65, 12);
            this.label_result.TabIndex = 24;
            this.label_result.Text = "导入结果：";
            // 
            // toolTip_name
            // 
            this.toolTip_name.Active = false;
            this.toolTip_name.IsBalloon = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // toolTip_sid
            // 
            this.toolTip_sid.Active = false;
            this.toolTip_sid.IsBalloon = true;
            // 
            // Add_Stu_Info
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MvcThreeModel.Properties.Resources.bg2;
            this.ClientSize = new System.Drawing.Size(659, 490);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox_hand);
            this.Controls.Add(this.groupBox_auto);
            this.Controls.Add(this.label_result);
            this.Name = "Add_Stu_Info";
            this.Text = "学生信息";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox_hand.ResumeLayout(false);
            this.groupBox_hand.PerformLayout();
            this.groupBox_auto.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox_hand;
        private System.Windows.Forms.TextBox textBox_id;
        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox_auto;
        private System.Windows.Forms.Button button_return;
        private System.Windows.Forms.Button button_finish;
        private System.Windows.Forms.Label label_result;
        private System.Windows.Forms.ToolTip toolTip_name;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolTip toolTip_sid;
    }
}