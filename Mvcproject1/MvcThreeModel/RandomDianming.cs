using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MvcThreeModel;
using BLL;
using Common;
using Model;
using DAO;
namespace DianMing_Sys
{
    public partial class RandomDianming : Form
    {
       TeacherBll teaclassbll = new TeacherBll();
       TeacherDao teaDao = new TeacherDao();
        public RandomDianming(string tea_id, string cou_id, string cou_num, string ck_time)
        {
            InitializeComponent();
            this.tea_id = tea_id;
            this.cou_id = cou_id;
            this.cou_num = cou_num;
            this.ck_time = ck_time;
            bindingSource();
        }
        string tea_id;//教师编号
        string cou_id;//课程编号
        string cou_num;//课序号
        string ck_time;//考勤时间
        bool isClick_1 = false;
        int num_1;//产生的随机数
        int max;
        int rows;//学生人数
        int lilunCount = 0;//人数理论值
        int sijiCount = 0;//人数实际值
        private void bindingSource()
        {
            List<Check> list = teaclassbll.StudentInfo(tea_id, cou_id, cou_num);
            if (list.Count() > 0)
            {
                rows = list.Count;
                DataTable dt2 = new DataTable();
                dt2.Columns.Add("序号");
                dt2.Columns.Add("姓名");
                dt2.Columns.Add("学号");
                dt2.Columns.Add("当前考勤状态");
                int i = 0;
                foreach (Check ck in list)
                {

                    DataRow dr = dt2.NewRow();
                    dr[0] = i++;
                    dr[1] = ck.Stu_Name;
                    dr[2] = ck.Stu_Id;
                    dr[3] = "出勤";
                    dt2.Rows.Add(dr);
                }
                dataGridView1.DataSource = dt2;
                DataGridViewComboBoxColumn a = new DataGridViewComboBoxColumn();
                a.Items.Add("旷课");
                a.Items.Add("迟到");
                a.Items.Add("请假");
                a.Items.Add("出勤");
                a.DefaultCellStyle.NullValue = "出勤";
                dataGridView1.Columns.Add(a);
                dataGridView1.Columns[3].HeaderCell.Value = "考勤状态";
                max = list.Count;
            }
            else
            {
                MessageBox.Show("该门课无学生");

            }
        }
        //图片点击函数
        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            isClick_1 = true;
            pictureBox2.Refresh();
            pictureBox2.Load("2.jpg");

            if (isClick_1 == false)
            {
                pictureBox2.Load("1.jpg");
            }
        }
        //图片绘制事件函数
        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            if (isClick_1 == true)
            {

                Graphics g = e.Graphics;
                Random r = new Random();
                List<Check> list = teaclassbll.StudentInfo(tea_id, cou_id, cou_num);
                max = list.Count;
                num_1 = r.Next(1, max);
                g.DrawString("随机数:" + (num_1), new Font("楷体", 15), new SolidBrush(Color.Red), new Point(1, 1));

                string stuName = dataGridView1.Rows[num_1].Cells[2].Value.ToString();

                labelName.Size = new System.Drawing.Size(100, 50);
                labelName.Text = stuName;
                labelName.ForeColor = Color.Red;
                // dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                this.dataGridView1.MultiSelect = false;
                dataGridView1.Rows[num_1].Selected = true;
                dataGridView1.CurrentCell = dataGridView1.Rows[num_1].Cells[4];
                dataGridView1.BeginEdit(true);
                //isClick_1 = false;
            }


        }

        //保存考勤，通过将dataGrideview中的每行转换为实体对象属性，在调用dao中的相应方法
        private void button1_Click(object sender, EventArgs e)
        {
            lilunCount = rows; ;
            for (int i = 0; i < rows; i++)
            {
                string stu_id = dataGridView1.Rows[i].Cells[3].Value.ToString().Trim();
                string stu_name = dataGridView1.Rows[i].Cells[2].Value.ToString().Trim();
                string cur_state = dataGridView1.Rows[i].Cells[4].Value.ToString().Trim();
                Check ck = new  Check();
                ck.Stu_Id = stu_id;
                ck.Stu_Name = stu_name;
                ck.State = cur_state;
                ck.Ck_Time = ck_time;
                ck.Cou_Id = cou_id;
                ck.Tea_Id = tea_id;
                sijiCount += teaDao.SaveData(ck);
            }
            if (sijiCount == lilunCount)
            {
                MessageBox.Show("保存成功");
                button1.Enabled = false;
            }
            else
            {
                MessageBox.Show("保存失败");
            }

            /*   //将datagrideview转换为datatable
              CommonDgvToTable Dgvtotable = new CommonDgvToTable();
              DataTable dt = Dgvtotable.GetDgvToTable(dataGridView1);
              //将DataTable 转换为实体
              CommonLeiconvertTable<CKStudenkModel> ConTable = new CommonLeiconvertTable<CKStudenkModel>();
              List<CKStudenkModel> list = ConTable.ConvertToList(dt);
              sijiCount = teaDao.SaveData(list);
              if (sijiCount == lilunCount)
              {
                  MessageBox.Show("保存成功");
                  button1.Enabled = false;
              }
              else
              {
                  MessageBox.Show("保存失败");
              }
              */
        }
        //对标识除出勤外的所有人标记
        bool Paint = true;
        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                if (Paint == true)
                {
                    string text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                    if (text == "旷课")
                    {
                        dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
                    }
                    else if (text == "迟到")
                    {
                        dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Chocolate;
                    }
                    else if (text == "请假")
                    {
                        dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.DarkOrange;
                    }
                    if (e.RowIndex == dataGridView1.RowCount - 1) Paint = false;
                }

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
     
       
      
        private void button2_Click(object sender, EventArgs e)
        {
            Main t = new Main(tea_id);
            t.Show();
            this.Hide();
        }
        //实现列变化
        private void dataGridView1_CellEndEdit_1(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.Rows[e.RowIndex].Cells[4].Value = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

        }

        private void dataGridView1_CellEnter_1(object sender, DataGridViewCellEventArgs e)
        {
            //实现单击一次显示下拉列表框
            if (dataGridView1.Columns[e.ColumnIndex] is DataGridViewComboBoxColumn && e.RowIndex != -1)
            {
                SendKeys.Send("{F4}");
            }
        }

        
        //退出到主程序

    }
}
