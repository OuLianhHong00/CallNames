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
    public class TeachDao
    {
        public int InsertIntoTeachInfo(string tea_id, string cou_id, string cou_num, string stu_name, string stu_id)
        {
            string sql = "insert into teach_infor (tea_id,cou_id,cou_num,stu_name,stu_id) VALUES (@tea_id,@cou_id,@cou_num,@stu_name,@stu_id)";
            SqlParameter[] ps =
                {
                new SqlParameter("@tea_id",SqlDbType.NChar,12),
                new SqlParameter("@cou_id",SqlDbType.NChar,10),
                new SqlParameter("@cou_num",SqlDbType.NChar,4),
                new SqlParameter("@stu_name",SqlDbType.VarChar,30),
                new SqlParameter("@stu_id",SqlDbType.NChar,12),
                };
            ps[0].Value = tea_id;
            ps[1].Value = cou_id;
            ps[2].Value = cou_num;
            ps[3].Value = stu_name;
            ps[4].Value = stu_id;
            return SqlHelper.ExecuteNonQuery(sql, CommandType.Text, ps);
            
        }
        /// <summary>
        /// 传统查询，用过新建考勤页面传过来的教师编号，课程号，课序号查询出学生信息，并返回
        /// </summary>
        /// <param name="tea_id"></param>
        /// <param name="cou_id"></param>
        /// <param name="cou_num"></param>
        /// <returns></returns>
        public DataTable SelectInforByTradition(string tea_id, string cou_id, string cou_num)
        {
            string sql = "select stu_name as'姓名' ,stu_id as '学号' from  teach_infor where tea_id=@tea_id and cou_id=@cou_id and cou_num=@cou_num";
            SqlParameter[] ps =
                {
                new SqlParameter("@tea_id", SqlDbType.NChar, 12),
                new SqlParameter("@cou_id", SqlDbType.NChar, 10),
                new SqlParameter("@cou_num",  SqlDbType.NChar,4),
                };
            ps[0].Value = tea_id;
            ps[1].Value = cou_id;
            ps[2].Value = cou_num;
            DataTable dt = SqlHelper.ExcuteDataTable(sql, CommandType.Text, ps);
            return dt;

        }

        public DataTable SelectTeachInfo(string id, string cou_id, string cou_num)
        {
            string sql = "select * from teach_infor where tea_id=@tea_id and cou_id=@cou_id and cou_num=@cou_num";
            SqlParameter[] ps =
                {
                new SqlParameter("@tea_id",id),
                new SqlParameter("@cou_id",cou_id),
                new SqlParameter("@cou_num",cou_num),
                };

            return SqlHelper.ExcuteDataTable(sql, CommandType.Text,ps);
 
        }
        private void LoadEntity(DataRow dataRow, Teach teach)
        {
            teach.Tea_id = Convert.ToString(dataRow["tea_id"]);
            //判断是否为空
            teach.Cou_id = dataRow["cou_id"] != DBNull.Value ? dataRow["cou_id"].ToString() : string.Empty;
            teach.Cou_num = dataRow["cou_num"] != DBNull.Value ? dataRow["cou_num"].ToString() : string.Empty;
            teach.Stu_id = dataRow["stu_id"] != DBNull.Value ? dataRow["stu_id"].ToString() : string.Empty;
            teach.Stu_name = dataRow["stu_name"] != DBNull.Value ? dataRow["stu_name"].ToString() : string.Empty;

        }

        /// <summary>
        /// 批量插入函数
        /// </summary>
        /// <param name="dt2"></param>
        /// <returns></returns>
        public int Insert_importStuInfos(DataTable dt2)
        {
            int r = 0;

            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                string sql = "insert into teach_infor values(@tea_id,@cou_id,@cou_num,@stu_name,@stu_id)";
                SqlParameter[] ps =
               {
                new SqlParameter("@tea_id", SqlDbType.NChar, 12),
                new SqlParameter("@cou_id", SqlDbType.NChar, 10),
                new SqlParameter("@cou_num",  SqlDbType.NChar,4),
                new SqlParameter("@stu_name", SqlDbType.VarChar, 30),
                new SqlParameter("@stu_id", SqlDbType.NChar, 12),
                };
                ps[0].Value = dt2.Rows[i][0];
                ps[1].Value = dt2.Rows[i][1];
                ps[2].Value = dt2.Rows[i][2];
                ps[3].Value = dt2.Rows[i][3];
                ps[4].Value = dt2.Rows[i][4];
               if( SqlHelper.ExecuteNonQuery(sql, CommandType.Text,ps)>0) r++;

            }
            return r;
            
        }
    }
}
