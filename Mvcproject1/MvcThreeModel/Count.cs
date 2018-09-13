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
using System.Drawing.Drawing2D;
using BLL;
using System.Windows.Forms.DataVisualization.Charting;

namespace MvcThreeModel
{
    public partial class Count : Form
    {
        public Count(string tea_id)
        {
            InitializeComponent();
            this.tea_id = tea_id;
            showCourse(tea_id);//展示课程
             
        }

        string tea_id;
        private CourseBll courseBll;
        string[] courseId = new string[20];//储存课程号
        private void showCourse(string tea_id)
        {
            courseBll = new CourseBll();
             
            SqlDataReader sda = courseBll.showCourse(tea_id);
            int i = 0;
            while (sda.Read())
            {
                c_course.Items.Add(sda["cou_name"]);
                courseId[i] = sda["cou_id"].ToString();
                i++;
            }
            if (c_course.Items.Count == 0)
                c_course.Text = "您还没有所教的课程";
        }
        //展示该课程出勤的情况
        private void showAttendance(string cou_id,string tea_id)
        {
            DataTable dt = courseBll.attendanceOneCourse(cou_id,tea_id);
           
            dataGridView1.DataSource = dt;
        }
        private void staticticsSecondCount(string cou_id)//该课程下的统计次数
        {
           
            int chuqin = 0;
            int qinjia = 0;
            int kuangke = 0;
            int chidao = 0;
            DataTable dt1  =courseBll.attendanceOneCourse(cou_id,tea_id);
           
            if (dt1.Rows.Count > 0)
            {

                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    if (dt1.Rows[i][2].ToString().Trim() == "请假") qinjia++;
                    else if (dt1.Rows[i][2].ToString().Trim() == "旷课") kuangke++;
                    else if (dt1.Rows[i][2].ToString().Trim() == "迟到") chidao++;
                    else if (dt1.Rows[i][2].ToString().Trim() == "出勤") chuqin++;
                }
                label_chidao.Text = "迟到：" + chidao + "人次";
                label_chuqin.Text = "出勤：" + chuqin + "人次";
                label_kuangke.Text = "旷课：" + kuangke + "人次";
                label_qingjia.Text = "请假：" + qinjia + "人次";

                if (chart1.ChartAreas.Count > 0)//如果已经有绘图
                {
                    chart1.ChartAreas.Clear();//清空
                }
                ChartArea chartArea1 = new  ChartArea();
                chartArea1.Name = "ChartArea1";
                chart1.ChartAreas.Add(chartArea1);
                chart1.Series[0].Points[0].YValues[0] = chuqin;
                chart1.Series[0].Points[1].YValues[0] = kuangke;
                chart1.Series[0].Points[2].YValues[0] = qinjia;
                chart1.Series[0].Points[3].YValues[0] = chidao;
            }
            else
            {
               // MessageBox.Show(chart1.ChartAreas.Count.ToString());
                if (chart1.ChartAreas.Count > 0)//如果已经有绘图
                {
                    chart1.ChartAreas.Clear();//清空
                }
               
              ChartArea chartArea1 = new  ChartArea();
                chartArea1.Name = "ChartArea1";
                chart1.ChartAreas.Add(chartArea1);
                MessageBox.Show("该课程无考核信息", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);

                chart1.Series[0].Points[0].YValues[0] = 0;
                chart1.Series[0].Points[1].YValues[0] = 0;
                chart1.Series[0].Points[2].YValues[0] = 0;
                chart1.Series[0].Points[3].YValues[0] = 0;
            }
        }

        private void button_course_Click(object sender, EventArgs e)
        {
            
            label_chidao.Text = "迟到：0人次";
            label_chuqin.Text = "出勤：0人次";
            label_kuangke.Text = "旷课：0人次";
            label_qingjia.Text = "请假：0人次";
            if (c_course.Text.Trim() != "")
            {
                showAttendance(courseId[c_course.SelectedIndex], tea_id);
                staticticsSecondCount(courseId[c_course.SelectedIndex]);
            }
            
        }

        private void b_return_Click(object sender, EventArgs e)
        {
            Main m = new Main(tea_id);
            m.Show();
            this.Hide();
        }
    }
}
