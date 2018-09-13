using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;
using BLL;
namespace MvcThreeModel
{
    public partial class perInfo : Form
    {
        public perInfo(string tea_id)
        {
            InitializeComponent();
            this.tea_id = tea_id;
            showPersonInfo();
        }
        string tea_id;
        private Teacher teacher  ;
        private TeacherBll teacherBll = new TeacherBll();
        private void showPersonInfo()
        {
            teacher = teacherBll.showTeacherInfo(tea_id);
            if (teacher != null)
            {
                textBox_id.Text = teacher.Tea_Id;
                textBox_pass.Text = teacher.Tea_Password.Trim();
                textBox_name.Text = teacher.Tea_Name.Trim();
                if (teacher.Tea_Sex.Trim() == "男") r_man.Checked = true;
                else r_woman.Checked = true;
                t_job_title.Text = teacher.Tea_Job.Trim();
                t_tel.Text = teacher.Tea_Tel.Trim();
                t_qq.Text = teacher.Tea_Qq.Trim();
                textBox_aca.Text = teacher.Tea_Academy.Trim();
                textBox_ques.Text = teacher.Passquestion.Trim();
                textBox_answer.Text = teacher.Passmessage.Trim();
                t_address.Text = teacher.Tea_Address.Trim();
                r_infor.Text = teacher.Informa.Trim();
            }
         }
        private void b_return_Click(object sender, EventArgs e)
        {
            Main m = new Main(tea_id);
            m.Show();
            this.Hide();
        }

        private void b_alter_Click(object sender, EventArgs e)
        {
            Teacher teacher = new Teacher();
            teacher.Tea_Id= textBox_id.Text.Trim();
            teacher.Tea_Password=textBox_pass.Text.Trim();
            teacher.Tea_Name =textBox_name.Text.Trim();
            if (r_man.Checked ==true) teacher.Tea_Sex="男";
            else teacher.Tea_Sex = "女";
            teacher.Tea_Job = t_job_title.Text.Trim();
            teacher.Tea_Tel= t_tel.Text.Trim();
            teacher.Tea_Qq = t_qq.Text.Trim();
            teacher.Tea_Academy = textBox_aca.Text.Trim();
            teacher.Passquestion= textBox_ques.Text.Trim();
            teacher.Passmessage= textBox_answer.Text.Trim();
            teacher.Tea_Address= t_address.Text.Trim();
            teacher.Informa= r_infor.Text.Trim();
            int row = teacherBll.updateInfo(teacher);
            if (row >0) MessageBox.Show("更新成功", "提示信息", MessageBoxButtons.OK,MessageBoxIcon.Information);
            else MessageBox.Show("更新失败", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void perInfo_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void l_name_Click(object sender, EventArgs e)
        {

        }

        private void l_sex_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void l_job_title_Click(object sender, EventArgs e)
        {

        }

        private void l_tel_Click(object sender, EventArgs e)
        {

        }
    }
}
