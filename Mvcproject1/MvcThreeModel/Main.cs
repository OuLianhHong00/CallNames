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
using BLL;
namespace MvcThreeModel
{
    public partial class Main : Form
    {
        public Main(string tea_id)
        {
            InitializeComponent();
            this.tea_id = tea_id;
            showCourse();
        }

        string tea_id;
        string cou_id = "";
        string cou_num = "";
        private TeacherBll teacherBll = new TeacherBll();
        struct cou_idAndcou_num
        {
            public string cou_id;
            public string cou_num;
        }
        List<cou_idAndcou_num> list;


        private void deleteCousInfos(object sender, EventArgs e)
        {
            ContextMenuStrip context = (ContextMenuStrip)sender;
            int info = teacherBll.deleteCourse(context.Text,tea_id);
             if (info> 0)

            {
                
                MessageBox.Show("删除成功", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                showCourse();

            }
            else
            {
   
                MessageBox.Show("删除失败", "提示错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //检查该课程是否导入了学生名单
        public bool checkImportStuInfos(string t_id, string cou_id, string cou_num)
        {
            DataTable dt= teacherBll.checkImportStuInfos(t_id,cou_id,cou_num);
            if (dt.Rows.Count > 0)
            {
                
                return true;
            }
            else
            {
               
                return false;
            }

        }
        //导入了学生才直接跳到考勤界面，否则跳到添加学生界面
        private void Picture_Click_checkStu(object sender, EventArgs e)
        {

            PictureBox p = (PictureBox)sender;
            
            DataTable dt =  teacherBll.getCourseIdAndNum(tea_id);
         
            cou_id = dt.Rows[Convert.ToInt32(p.Name)][0].ToString();
            cou_num = dt.Rows[Convert.ToInt32(p.Name)][1].ToString();
            
             checking c = new  checking(tea_id, cou_id, cou_num);
            c.Show();
            this.Hide();
        }
        private void Picture_Click_addStu(object sender, EventArgs e)
        {

            PictureBox p = (PictureBox)sender;
            
            DataTable dt =teacherBll.getCourseIdAndNum(tea_id);
            
            cou_id = dt.Rows[Convert.ToInt32(p.Name)][0].ToString();
            cou_num = dt.Rows[Convert.ToInt32(p.Name)][1].ToString();
            
             Add_Stu_Info a = new  Add_Stu_Info(tea_id, cou_id, cou_num);
            a.Show();
            this.Hide();
        }

        
        public void showCourse()
        {
            try
            {
                
                DataTable dt =teacherBll.showCourse(tea_id) ;
               
                if (dt.Rows.Count > 0)
                {
                    list = new List<cou_idAndcou_num>();
                    cou_idAndcou_num andcou_Num = new cou_idAndcou_num();
                    int p_x = 15;//
                    int p_y = 15;
                   
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        andcou_Num.cou_id = dt.Rows[i][0].ToString();
                        andcou_Num.cou_num = dt.Rows[i][1].ToString();
                        ContextMenuStrip menu = new ContextMenuStrip();
                        menu.Items.Add("修改课程");
                        menu.Items.Add("删除课程");
                        //右击直接修改

                        if (menu.Text == "删除课程")
                        {
                            menu.Click += deleteCousInfos;
                        }
                        PictureBox picture = new PictureBox();
                        picture.Name = i.ToString();//控件名                      
                        picture.ImageLocation = dt.Rows[i][4].ToString();
                        if (checkImportStuInfos(dt.Rows[i][5].ToString(), dt.Rows[i][0].ToString(), dt.Rows[i][1].ToString()) == false)//没有导入学生名单
                        {
                            picture.Click += Picture_Click_addStu;//跳转到点名界面
                        }
                        else picture.Click += Picture_Click_checkStu;
                        picture.Width = 120;
                        picture.Height = 120;
                        picture.BackColor = Color.Gray;
                        picture.Location = new Point(p_x, p_y);
                        picture.SizeMode = PictureBoxSizeMode.StretchImage;
                        p_x += 150;
                        if ((i + 1) % 3 == 0)
                        {
                            p_x = 15;
                            p_y += 150;
                        }
                        else { }
                        if ((i + 1) % 3 == 0)
                        {
                            pictureBox_default.Location = new Point(15, p_y);
                        }
                        else
                        {
                            pictureBox_default.Location = new Point(picture.Location.X + 150, picture.Location.Y);
                        }
                        picture.ContextMenuStrip = menu;
                        this.panel_main.Controls.Add(picture);
                        list.Add(andcou_Num);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void 添加课程及学生ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddCourseInfo a = new AddCourseInfo(tea_id);
            a.Show();
            this.Hide();
            
        }

        private void 查询考勤信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Count c = new Count(tea_id);
            c.Show();
            this.Hide();
        }

        private void 个人信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            perInfo p = new perInfo(tea_id);
            p.Show();
            this.Hide();
        }

        private void 修改考勤ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            updateAttendence u = new updateAttendence(tea_id);
            u.Show();
            this.Hide();
        }

        private void 注销登录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            login l = new login();
            l.Show();
            this.Hide();
        }

        private void 切换用户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            login l = new login();
            l.Show();
            this.Hide();
        }

      
    }
}
