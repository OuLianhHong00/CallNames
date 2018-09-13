using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using System.Data;
using System.Data.SqlClient; 

namespace BLL
{
   public  class CourseBll
    {
        private CourseDao courseDao = new DAO.CourseDao();
        public SqlDataReader  showCourse(string tea_id)
        {
            return courseDao.showCourse(tea_id);
        }
        public DataTable attendanceOneCourse(string cou_id, string tea_id)
        {
            return courseDao.attendanceOneCourse(cou_id,tea_id);
        }
        public int insertCourse(string Cou_id, string Cou_num, string Cou_cName, string Cou_time, string coucover_path, string tea_id)
 
        {
            return courseDao.InsertCourse(Cou_id, Cou_num, Cou_cName, Cou_time, coucover_path, tea_id);
 
        }
    }
}
