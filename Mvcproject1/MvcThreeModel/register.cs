using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
namespace MvcThreeModel
{
    public partial class register : Form
    {
        public register()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           login f=new login ();
            f.Show();
            this.Hide();
        }
        //注册
        private void button1_Click(object sender, EventArgs e)
        {
            //try
          /// {
                string tea_id = textBox_id.Text;
                string password = textBox_password.Text;
                string tea_name = textBox_name.Text != "" ? textBox_name.Text : "";
                string tea_sex = radio_man.Checked ? "男" : "女";
                string tea_job = comboBox_job.Text != "" ? comboBox_job.Text : "";
                string informa = richTextBox1.Text != "" ? richTextBox1.Text : "";
                string tea_tel = textBox_tel.Text != "" ? textBox_tel.Text : "";
                string tea_qq = textBox_qq.Text != "" ? textBox_qq.Text : "";
                string tea_address = textBox_address.Text != "" ? textBox_address.Text : "";
                string tea_academy = textBox_academy.Text != "" ? textBox_academy.Text : "";
                string passmessage = textBox_passmessage.Text != "" ? textBox_passmessage.Text : "";
                string passquestion = comboBox_ques.Text != "" ? comboBox_ques.Text : "";
                TeacherBll teacher = new BLL.TeacherBll();
                if (tea_id != "" && password != "")
                {
                    if (teacher.registerTea(tea_id, tea_name, tea_sex, tea_job, informa, tea_tel, tea_qq, tea_address, tea_academy, password, passmessage, passquestion) == 1)
                    {
                        MessageBox.Show("注册成功，请返回登录", "成功提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    else MessageBox.Show( "此用户已存在", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else MessageBox.Show("请务必输入账号和密码", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
       
        }

        private void button_return_Click(object sender, EventArgs e)
        {
            login f = new login();
            f.Show();
            this.Hide();
        }
    }
}
