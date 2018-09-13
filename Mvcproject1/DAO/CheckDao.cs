using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Common;
using Model;
namespace DAO
{
  public   class CheckDao
    {

        public SqlDataReader showCheck(string tea_id)
        {
            string sql = "select distinct ck_time from ck_infor where tea_id=@tea_id";
            SqlParameter[] pms =
                {
                new SqlParameter("@tea_id",tea_id),
            };
            return SqlHelper.ExecuteReader(sql,CommandType.Text,pms);
        }
        //展示详细出勤情况
        public DataTable showCheckDetail(string tea_id,string ck_time)
        {
            string sql = "select stu_name as'姓名' ,stu_id as '学号' ,state as '考勤结果' from  ck_infor where tea_id=@tea_id  and ck_time=@ck_time";
            SqlParameter[] pms =
                {
                 new SqlParameter("@tea_id",tea_id),
                 new SqlParameter ("@ck_time",ck_time),
            };
            return SqlHelper.ExcuteDataTable(sql,CommandType.Text,pms);
        }
        public int updateState(Check check)
        {
            string sql= "update ck_infor set state =@state where tea_id =@tea_id  and stu_id =@stu_id and ck_time =@ck_time";
            SqlParameter[] pms = 
                {
                 new SqlParameter("@state",check.State),
                 new SqlParameter("@tea_id",check.Tea_Id),
                 new SqlParameter("@stu_id",check.Stu_Id),
                 new SqlParameter ("@ck_time",check.Ck_Time),
            };

            return SqlHelper.ExecuteNonQuery(sql,CommandType.Text,pms);
        }
        public int Insertck_inforByTradition(string stu_id, string stu_name, string cur_state, string ck_time, string cou_id, string tea_id)
        {
            int r = 0;
            string sql = "insert into ck_infor (stu_id,stu_name,[state],ck_time,cou_id,tea_id)values(@stu_id, @stu_name, @cur_state, @ck_time, @cou_id,@tea_id)";
            SqlParameter[] ps =
           {
                new SqlParameter("@stu_id", SqlDbType.NChar, 12),
                new SqlParameter("@stu_name", SqlDbType.NChar, 10),
                new SqlParameter("@cur_state",  SqlDbType.VarChar,20),
                new SqlParameter("@ck_time", SqlDbType.VarChar, 20),
                new SqlParameter("@cou_id", SqlDbType.NChar, 10),
                new SqlParameter("@tea_id", SqlDbType.NChar, 12),
                };
            ps[0].Value = stu_id;
            ps[1].Value = stu_name;
            ps[2].Value = cur_state;
            ps[3].Value = ck_time;
            ps[4].Value = cou_id;
            ps[5].Value = tea_id;
            r = SqlHelper.ExecuteNonQuery(sql, CommandType.Text, ps);
            return r;

        }
    }

}
