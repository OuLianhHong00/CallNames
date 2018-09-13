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
using System.Data.OleDb;

namespace MvcThreeModel
{
    public partial class Add_Stu_Info : Form
    {
        public Add_Stu_Info(string tea_id, string cou_id, string cou_num)
        {
            InitializeComponent();
            this.tea_id = tea_id;
            this.cou_id = cou_id;
            this.cou_num = cou_num;
        }
        //全局变量
        string tea_id = "";//教工号
        string cou_id = "";//课程号
        string cou_num = "";//课序号
        //自定义函数区

        TeachBll teachbll = new TeachBll();
        //保存学生信息函数
        public void saveStuInfo()
        {
           // try
           // {
                string stu_id = textBox_id.Text.Trim();
                string stu_name = textBox_name.Text.Trim();
                if (textBox_name.Text.Trim() == "") setballoon(toolTip_name, textBox_name, "请输入学生姓名");
                else if (textBox_id.Text.Trim() == "") setballoon(toolTip_sid, textBox_id, "请输入学生学号");
                else
                {

                    int r = teachbll.InsertIntoTeachInfo(tea_id, cou_id, cou_num, stu_name, stu_id);
                    if (r > 0)
                    {
                        MessageBox.Show("添加成功", "成功提醒", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DataTable dt = teachbll.SelectTeachInfo(tea_id, cou_id, cou_num);
                        dataGridView1.DataSource = dt;
                    }

                }
          //  }
          //  catch (Exception e)
          //  {
             //   MessageBox.Show(e.Message, "错误提醒", MessageBoxButtons.OK, MessageBoxIcon.Error);
              //  MessageBox.Show(tea_id+"\n"+cou_id+"\n"+cou_num);
           // }
        }
        //自定义函数区
        //设置提醒函数
        public void setballoon(ToolTip t, Control c, string s)
        {
            t.Active = false;
            t.SetToolTip(c, s);
            t.Active = true;
            t.Show(s, c, c.Width / 2, c.Height / 2);
        }
        //学号只能是数字点击事件

        //点击添加Excel模板并导入到数据库函数
        /// <summary>
        /// 实现批量导入学生 给出Excel模板 然后导入数据库特定表中
        /// 思路：Excel表看出一个datatable，自己新建一个datatable组成为教师号，课程号，课序号
        /// 然后消去Excel有重复的数据--需要判断,将两张表组合成一个新的datatable
        /// 再用SqlBulkCopy批量实现导入
        /// </summary>
        /// 全局变量
        DataTable dt2 = new DataTable();
        public int importStuInfos()
        {
            try
            {
                string filepath = "";//文件路径+文件名.xlsx
                OpenFileDialog openFile = new OpenFileDialog();
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    filepath = openFileDialog1.FileName;
                    DataTable dt1 = new DataTable();
                    dt1 = ImportExcel(filepath);
                   
                    dt2.Columns.Add("教师号", typeof(string));
                    dt2.Columns.Add("课程号", typeof(string));
                    dt2.Columns.Add("课序号", typeof(string));
                    dt2.Columns.Add("姓名", typeof(string));
                    dt2.Columns.Add("学号", typeof(string));
                    for (int i = 0; i < dt1.Rows.Count; i++)
                    {
                        DataRow dr = dt2.NewRow();
                        dr[0] = tea_id;
                        dr[1] = cou_id;//课程号
                        dr[2] = cou_num;//课序号
                        dr[3] = dt1.Rows[i][0];
                        dr[4] = dt1.Rows[i][1];
                        dt2.Rows.Add(dr);
                    }   
                    int row = teachbll.Insert_importStuInfos(dt2);
                   
                    return row;
                }
                else return 0;
            }catch(Exception ee)
            {
                MessageBox.Show(ee.Message,"导入出错",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return -1;
            }
    
        }
        
        /// <summary>
        /// 点击保存按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_save_Click(object sender, EventArgs e)
        {
            saveStuInfo();
        }
        //点击批量导入按钮
        private void button_finish_Click(object sender, EventArgs e)
        {
           // int countInfos = 0;
            int r = importStuInfos();
           // if (r != 0)
           // {
           //     countInfos++;
          //  }
            if (r == dt2.Rows.Count)
            {
                MessageBox.Show("导入成功!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataTable dt = teachbll.SelectTeachInfo(tea_id, cou_id, cou_num);
                dataGridView1.DataSource = dt;
            }
            else if(r==-1)
            {
                MessageBox.Show("导入失败", "提示消息", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        /// <summary>
        ///返回主页点击事件
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
        /// 实现从Excel到datatable 格式为97-2003
        /// </summary>
        /// <param name="strFileName">strFileName指定的路径+文件名.xls</param>
        /// <returns></returns>
        public DataTable ImportExcel(string strFileName)
        {
            if (strFileName != "")
            {
                string conn = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strFileName + ";Extended Properties=Excel 4.0";
                string sql = "select * from [Sheet1$]";
                OleDbDataAdapter da = new OleDbDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            else
            {
                return null;
            }
        }
        //设置学号只能是数字
        private void textBox_id_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            toolTip_sid.Active = false;
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }
        //文本更改事件
        private void textBox_id_TextChanged_1(object sender, EventArgs e)
        {
            toolTip_sid.Active = false;
        }
        private void textBox_name_TextChanged_1(object sender, EventArgs e)
        {
            toolTip_name.Active = false;
        }
        private void textBox_name_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            toolTip_name.Active = false;
        }
 
    }
}
