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
using Model;
using System.Data.SqlClient;

namespace MvcThreeModel
{
    public partial class AddCourseInfo : Form
    {

        //先实例化Course的BLL类
        private CourseBll CourseBLL = new CourseBll();
        //设置带参数的构造函数
        public AddCourseInfo(string id)
        {
            InitializeComponent();
            this.tea_id = id;
        }
        //全局变量
        string tea_id;//教工号
        string cou_cover_path = "";//图片
        string cou_id = "";//课程号
        string cou_num = "";//课序号

        //自定义函数区
        public void textChanged(TextBox t)
        {
            t.ForeColor = Color.Black;
            t.Font = new Font("宋体", 9);
        }
        //设置提醒函数
        public void setballoon(ToolTip t, Control c, string s)
        {
            t.Active = false;
            t.SetToolTip(c, s);
            t.Active = true;
            t.Show(s, c, c.Width / 2, c.Height / 2);
        }
        //保存课程信息函数
        public void saveCourseInfo()
        {


            try
            {

                string Cou_cName = t_cName.Text.Trim();
                string Cou_id = t_id.Text.Trim();//课程号
                string Cou_num = t_num.Text.Trim();//课序号
                string Cou_time = t_time.Text.Trim();
                string coucover_path = cou_cover_path;
                int r = CourseBLL.insertCourse(Cou_id, Cou_num, Cou_cName, Cou_time, coucover_path, tea_id);
                if (r == 1)
                {
                    MessageBox.Show("课程信息添加成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    b_next.Enabled = true;
                   // MessageBox.Show(Cou_id+"\n"+Cou_num+"\n");
                }

            }
            catch (Exception he)
            {

                MessageBox.Show(he.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        //点击保存的事件
        private void b_save_Click_1(object sender, EventArgs e)
        {


            try
            {
                if (t_cName.Text.Trim() == "") setballoon(toolTip_name, t_cName, "请输入课程名");
                else if (t_id.Text.Length != 10) setballoon(toolTip_sid, t_id, "请输入正确的课程号");
                else if (t_num.Text.Length != 4) setballoon(toolTip_num, t_num, "请输入正确的课序号");
                else saveCourseInfo();
            }
            catch
            {
                MessageBox.Show("您已添加该课程", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        //点击下一步的事件
        private void b_next_Click_1(object sender, EventArgs e)
        {
            cou_id = t_id.Text.Trim();
            cou_num = t_num.Text.Trim();
            Add_Stu_Info a = new Add_Stu_Info(tea_id, cou_id, cou_num);
            a.Show();
            this.Hide();
        }

        //课程号只能是数字的点击事件
        private void t_id_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }
        //课序号只能是数字点击事件
        private void t_num_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }
        //文本改变事件
        private void t_id_TextChanged_1(object sender, EventArgs e)
        {
            textChanged(t_id);
        }

        private void t_num_TextChanged_1(object sender, EventArgs e)
        {
            textChanged(t_num);
        }
        private void t_time_TextChanged_1(object sender, EventArgs e)
        {
            textChanged(t_time);
        }
        //鼠标点击事件
        private void t_id_MouseDown_1(object sender, MouseEventArgs e)
        {
            t_id.SelectAll();
            t_id.Focus();
            toolTip_sid.Active = false;
        }
        private void t_num_MouseDown_1(object sender, MouseEventArgs e)
        {
            t_num.SelectAll();
            t_num.Focus();
            toolTip_num.Active = false;
        }
        private void t_time_MouseDown_1(object sender, MouseEventArgs e)
        {
            t_time.SelectAll();
            t_time.Focus();

        }
        private void t_cName_MouseDown_1(object sender, MouseEventArgs e)
        {
            toolTip_name.Active = false;
        }
        private void b_return_Click_1(object sender, EventArgs e)
        {
            Main t = new Main(tea_id);
            t.Show();
            this.Hide();
        }
        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "请选择要插入的图片";
            fdlg.Filter = "JPG图片|*.jpg|BMP图片|*.bmp|Gif图片|*.gif";
            fdlg.CheckFileExists = true;
            fdlg.CheckPathExists = true;
            fdlg.Multiselect = false;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                string path = fdlg.FileName;//指定文件路径
                pictureBox1.ImageLocation = path;//将指定路径的图  
                cou_cover_path = @path;
            }
        }

        private void t_cName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
