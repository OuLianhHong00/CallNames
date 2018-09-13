using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using Model;
using System.Data;
using Common;
namespace BLL
{
   public class TeacherBll
    {
        private TeacherDao teacherDao = new TeacherDao();
        //老师注册事件
        public int registerTea(string  tea_id,string  tea_name, string tea_sex, string tea_job, string informa, string tea_tel, string tea_qq, string tea_address, string tea_academy, string password, string passmessage, string passquestion)
        {
            return teacherDao.registerTea(tea_id,tea_name,tea_sex,tea_job,informa,tea_tel,tea_qq,tea_address,tea_academy,password,passmessage,passquestion);
        }
        //删除课程
        public DataTable showCourse(string tea_id)
        {

            return teacherDao.showCourse(tea_id);
        }
        //删除课程
        public int deleteCourse(string cou_name,string tea_id)
        {
            return teacherDao.deleteCourse(cou_name,tea_id);
        }
        //导入学生信息
        public DataTable checkImportStuInfos(string t_id, string cou_id, string cou_num)
        {
            return teacherDao.checkImportStuInfos(t_id,cou_id,cou_num);
        }
        //
        public DataTable getCourseIdAndNum(string tea_id)
        {
            return teacherDao.getCourseIdAndNum(tea_id);
        }
        public Teacher showTeacherInfo(string tea_id)
        {
            return teacherDao.showTeacherInfo(tea_id);
        }
        public int updateInfo(Teacher teacher)
        {
            return teacherDao.updateInfo(teacher);
        }
        //查询当门课学生名字和学号
        public List<Check> StudentInfo(String teaid, string couid, string counm)
        {
            DataTable dt = teacherDao.StudentNumber(teaid, couid, counm);
            CommonLeiconvertTable<Check> ConTable = new CommonLeiconvertTable<Check>();
            List<Check> list = ConTable.ConvertToList(dt);
            return list;
        }
        //登录查询
        public Teacher GetUserInfoModel(string userName, string userpwd)
        {  
            return teacherDao.TeaLogin(userName, userpwd); 
        }
    }
}
