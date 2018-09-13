using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using System.Data;
using System.Data.SqlClient;
 
namespace DAO
{
   public class CourseDao
    {

        //展示课程
        public SqlDataReader showCourse(string tea_id)
        {
          
            string sql = " select cou_id,cou_name from cou_infor where tea_id = @tea_id ";
            SqlParameter[] pms = {
                new SqlParameter("@tea_id",tea_id),
            };
            pms[0].Value = tea_id;
            return SqlHelper.ExecuteReader(sql, CommandType.Text, pms);
        }
        //查询单科出勤--只是绑定数据表
        public DataTable attendanceOneCourse(string cou_id,string tea_id)
        {
            string sql = "select stu_name as'姓名', stu_id as'学号',[state] as '考勤状态', cou_name as'课程', ck_time as '考勤时间' from ck_infor join cou_infor on(ck_infor.cou_id = cou_infor.cou_id) where ck_infor.tea_id =  @tea_id and ck_infor.cou_id = @cou_id";
            SqlParameter[] pms = {
                new SqlParameter("@tea_id",tea_id),
                 new SqlParameter("@cou_id",cou_id)
            };
            return SqlHelper.ExcuteDataTable(sql,CommandType.Text,pms);
        }

        public int InsertCourse(string Cou_id, string Cou_num, string Cou_cName, string Cou_time, string coucover_path, string tea_id)

        {
            string sql = "insert into cou_infor(cou_id,cou_num,cou_name,cou_time,cou_cover_path,tea_id)values(@cou_id,@cou_num,@cou_cname,@cou_time,@cou_cover,@tea_id)";
            SqlParameter[] ps = {
                 new SqlParameter("@cou_id", Cou_id),
                new SqlParameter("@cou_num", Cou_num),
                new SqlParameter("@cou_cname",Cou_cName),

                new SqlParameter("@cou_time",Cou_time),
                 new SqlParameter("@cou_cover",coucover_path),
                new SqlParameter("@tea_id", tea_id),
             };
     
            int r = SqlHelper.ExecuteNonQuery(sql, CommandType.Text, ps);
       
            return r;
         }
     }
}
