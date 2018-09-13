using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;
using BLL;



namespace MvcThreeModel
{
    public partial class voice : Form
    {

        TeachBll teachbll = new TeachBll();
        CheckBll ck_inforBll = new CheckBll();

        //全局变量
        string tea_id;
        string cou_id;
        string cou_num;
        string checkName;
        int i = 0;
        bool startcall = false;
        int shijiCount = 0;
        int lilunCount = 0;
        int rows;

        public voice(string tea_id, string cou_id, string cou_num, string checkName)
        {
            InitializeComponent();
            this.tea_id = tea_id;
            this.cou_id = cou_id;
            this.cou_num = cou_num;
            this.checkName = checkName;
            bindingSource();
        }
        //页面加载的时候就显示出数据表
        private void bindingSource()
        {
            //    DBHelper.initSql();
            //    DBHelper.con.Open();
            //    SqlDataAdapter sda = new SqlDataAdapter("select stu_name as'姓名' ,stu_id as '学号' from  teach_infor where tea_id='" + tea_id + "' and cou_id='" + cou_id + "' and cou_num='" + cou_num + "'", DBHelper.con);
            DataTable dt1 = teachbll.SelectInforByTradition(tea_id, cou_id, cou_num);
            //sda.Fill(dt1);
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
            //DBHelper.con.Close();
        }
        //语音点名功能实现
        private void voice_MouseClick(object sender, MouseEventArgs e)
        {
            if (startcall == true)
            {
                if (e.Button == MouseButtons.Right && i < dataGridView1.Rows.Count - 1)
                {
                    string stuName = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    dataGridView1.Rows[i].Selected = true;
                    dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells[2];
                    SpeechSynthesizer s = new SpeechSynthesizer();
                    s.SpeakAsync(stuName);
                    i++;
                }
                else
                {
                    DialogResult dr2 = MessageBox.Show("全部学生已点名完成", "提示");
                }
            }
        }



        private void button2_Click(object sender, EventArgs e)
        {

            if (i != dataGridView1.CurrentCell.RowIndex)
            {
                i = dataGridView1.CurrentCell.RowIndex;
            }
            string stuName = dataGridView1.Rows[i].Cells[2].Value.ToString();
            SpeechSynthesizer s = new SpeechSynthesizer();
            s.SpeakAsync(stuName);
            i++;
            startcall = true;


        }/// <summary>
         /// 自写函数
         /// </summary>
         /// <param name="sender"></param>
         /// <param name="e"></param>
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dataGridView1.Rows[e.RowIndex].Cells[4].Value = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

            }
            catch
            {

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
        private void button_save_Click(object sender, EventArgs e)
        {
            lilunCount = rows;
            saveInfos();
            if (lilunCount == shijiCount)
            {
                MessageBox.Show("考勤成功", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                button_save.Enabled = false;
            }
        }
        //保存功能的实现
        private void saveInfos()
        {
            try
            {

                for (int i = 0; i < rows; i++)
                {
                    string stu_id = dataGridView1.Rows[i].Cells[3].Value.ToString().Trim();
                    string stu_name = dataGridView1.Rows[i].Cells[2].Value.ToString().Trim();
                    string cur_state = dataGridView1.Rows[i].Cells[4].Value.ToString().Trim();
                    int r = ck_inforBll.Insertck_inforByTradition(stu_id, stu_name, cur_state, checkName, cou_id, tea_id);

                    if (r > 0)
                    {
                        shijiCount++;
                    }

                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "错误提醒", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.Rows[e.RowIndex].Selected = true;

            i = e.RowIndex;

        }
        private void button_return_Click(object sender, EventArgs e)
        {
            Main t = new Main(tea_id);
            t.Show();
            this.Hide();
        }

        private void voice_Load(object sender, EventArgs e)
        {
        }
    }
}
