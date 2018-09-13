using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DianMing_Sys;
namespace MvcThreeModel
{
    public partial class checking : Form
    {
        public checking()
        {
            InitializeComponent();
        }
        public checking(string tea_id, string cou_id, string cou_num)
        {
            InitializeComponent();
            this.tea_id = tea_id;
            this.cou_id = cou_id;
            this.cou_num = cou_num;
        }
        string tea_id;
        string cou_id;
        string cou_num;
        string checkName;//考勤名称
        private void button1_Click(object sender, EventArgs e)
        {
            checkName = dateTimePicker1.Value.ToShortDateString();
            if (r_random.Checked == true)
            {

                RandomDianming s = new RandomDianming(tea_id, cou_id, cou_num, checkName);
                s.Show();
                this.Hide();
            }
            else if (r_tra.Checked == true)
            {
                TraditionCheck t = new TraditionCheck(tea_id, cou_id, cou_num, checkName);
                t.Show();
                this.Hide();
            }
            else if (r_voice.Checked)
            {
                voice c = new voice(tea_id, cou_id, cou_num, checkName);
                c.Show();
                this.Hide();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Main t = new Main(tea_id);
            t.Show();
            this.Hide();
        }

      
    }
}
