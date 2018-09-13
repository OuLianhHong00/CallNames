using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
  public  class Teach
    {
        private string tea_id;//教师编号
        private string cou_id;//课程编号
        private string cou_num;//课序号
        private string stu_name;//学生姓名
        private string stu_id;//学生学号

        public string Tea_id
        {
            get
            {
                return tea_id;
            }

            set
            {
                tea_id = value;
            }
        }

        public string Cou_id
        {
            get
            {
                return cou_id;
            }

            set
            {
                cou_id = value;
            }
        }

        public string Cou_num
        {
            get
            {
                return cou_num;
            }

            set
            {
                cou_num = value;
            }
        }

        public string Stu_name
        {
            get
            {
                return stu_name;
            }

            set
            {
                stu_name = value;
            }
        }

        public string Stu_id
        {
            get
            {
                return stu_id;
            }

            set
            {
                stu_id = value;
            }
        }
    }
}
