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
using Model;
using BLL;
namespace MvcThreeModel
{
    public partial class updateAttendence : Form
    {
        public updateAttendence(string tea_id)
        {
            InitializeComponent();
            this.tea_id = tea_id;
            InitCheckInfos(tea_id);//初始化显示考勤记录名称
        }
        string tea_id;
        private CheckBll checkBll = new CheckBll();
        public void InitCheckInfos(string tea_id)
        {
            SqlDataReader sda = checkBll.showCheck(tea_id);
              while (sda.Read())
            {
                comboBox_infos.Items.Add(sda["ck_time"]);
            }
            if (comboBox_infos.Items.Count == 0)
                comboBox_infos.Text = "该记录无考核信息";

        }//combobox添加内容
        //给相应考勤记录绑定本次考勤结果
        public void bindingSource()
        {
            if (comboBox_infos.Text != "该记录无考核信息")
            {
                
 
                DataTable dt1 = checkBll.showCheckDetail(tea_id, comboBox_infos.Text.Trim());
                 
                if (dt1.Rows.Count > 0)
                {
                    DataGridView dataGridView = new DataGridView();
                    DataTable dt2 = new DataTable();
                    dt2.Columns.Add("姓名");
                    dt2.Columns.Add("学号");
                    dt2.Columns.Add("考勤结果");
                    for (int i = 0; i < dt1.Rows.Count; i++)
                    {
                        DataRow dr = dt2.NewRow();
                        dr[0] = dt1.Rows[i][0];
                        dr[1] = dt1.Rows[i][1];
                        dr[2] = dt1.Rows[i][2];
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
                    dataGridView1.Columns[3].HeaderCell.Value = "选择考勤状态";

                }

            }
            else
            {
                MessageBox.Show("该门课无学生");
            }
          
        }
        private void button_save_Click(object sender, EventArgs e)
        {
            if (lilunCount == shijiCount)
            {
                MessageBox.Show("更改成功", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.Columns.RemoveAt(3);
                lilunCount = 0;
                shijiCount = 0;
                bindingSource();
                dataGridView1.Columns[3].HeaderCell.Value = "选择考勤状态";

            }
        }

        private void comboBox_infos_SelectedValueChanged(object sender, EventArgs e)
        {
            bindingSource();
        }
        int shijiCount = 0;//实际对出勤记录进行修改的人数
        int lilunCount = 0;//理论对出勤记录进行修改的人数
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //结束编辑事件 来更新修改详情出勤
            lilunCount++;
            Check user = new Check();
            try
            {
                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.ToString();
                user.State = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value.ToString();//新状态
                user.Stu_Id = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex - 2].Value.ToString();
                user.Tea_Id = tea_id.Trim();
                user.Ck_Time = comboBox_infos.Text.Trim();
                int row = checkBll.updateState(user);

                 if (row > 0) shijiCount++;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message, "更新错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void button_return_Click(object sender, EventArgs e)
        {
            Main m = new Main(tea_id);
            m.Show();
            this.Hide();
        }
    }
}
