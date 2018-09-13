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
    public partial class TraditionCheck : Form
    {//实例化类

        TeachBll teachbll = new TeachBll();
        CheckBll ck_inforBll = new CheckBll();
        /// <summary>
        /// 传统考勤的构造函数
        /// </summary>
        /// <param name="tea_id"></param>
        /// <param name="cou_id"></param>
        /// <param name="cou_num"></param>
        /// <param name="checkName"></param>
        public TraditionCheck(string tea_id, string cou_id, string cou_num, string checkName)
        {
            InitializeComponent();
            this.tea_id = tea_id;
            this.cou_id = cou_id;
            this.cou_num = cou_num;
            this.checkName = checkName;

        }
        //全局变量区
        string tea_id;//教师编号
        string cou_id;//课程号
        string cou_num;//课序号
        string checkName;//考勤名称
        int sijiCount = 0;//
        int lilunCount = 0;//
        int rows;//行数

        private void TraditionCheck_Load(object sender, EventArgs e)
        {
            //直接在页面加载的时候就查出学生通过老师编号，课程号，课序号
            DataTable dt1 = teachbll.SelectInforByTradition(tea_id, cou_id, cou_num);
            if (dt1.Rows.Count > 0)
            {
                rows = dt1.Rows.Count;
                DataTable dt2 = new DataTable();
                dt2.Columns.Add("序号");
                dt2.Columns.Add("姓名");
                dt2.Columns.Add("学号");
                dt2.Columns.Add("当前考勤状态");
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    DataRow dr = dt2.NewRow();
                    dr[0] = i + 1;
                    dr[1] = dt1.Rows[i][0];
                    dr[2] = dt1.Rows[i][1];
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

            }
            else
            {
                MessageBox.Show("该门课无学生");
            }

        }
        /// <summary>
        /// 返回按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_return_Click(object sender, EventArgs e)
        {
            Main t = new Main(tea_id);
            t.Show();
            this.Hide();
        }
        /// <summary>
        /// 传统考勤的保存事件
        /// </summary>
        private void saveInfos()
        {
            try
            {
                for (int i = 0; i < rows; i++)
                {
                    string stu_id = dataGridView1.Rows[i].Cells[2].Value.ToString().Trim();
                    string stu_name = dataGridView1.Rows[i].Cells[1].Value.ToString().Trim();
                    string cur_state = dataGridView1.Rows[i].Cells[3].Value.ToString().Trim();
                   // MessageBox.Show(stu_id+" "+stu_name+" "+cur_state);
                    //将页面上的学号，姓名，状态，连同checking界面传过来的checkname，课程号，课序号一起存进ck_infor表
                     int r = ck_inforBll.Insertck_inforByTradition(stu_id, stu_name, cur_state, checkName, cou_id, tea_id);
                     if (r > 0)
                    {
                        sijiCount++;
                    }

                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "错误提醒", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        /// <summary>
        /// 链接事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dataGridView1.Rows[e.RowIndex].Cells[3].Value = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

            }
            catch
            {

            }

        }
        //点击按钮的保存事件
        private void button_save_Click(object sender, EventArgs e)
        {
            lilunCount = rows;
            saveInfos();
            if (sijiCount == lilunCount)
            {
                MessageBox.Show("本次考勤成功", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                button_save.Enabled = false;
            }
        }


        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            //实现单击一次显示下拉列表框
            if (dataGridView1.Columns[e.ColumnIndex] is DataGridViewComboBoxColumn && e.RowIndex != -1)
            {
                SendKeys.Send("{F4}");
            }
        }

        
    }
}
