using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class SqlHelper
    {
        //定义一个连接字符串
        //readonly修饰的变量，只能在初始化的时候复制，以及在构造函数中赋值，其他地方只能读取不能设置值
        private static readonly string conStr = ConfigurationManager.ConnectionStrings["dbhost"].ConnectionString;
        /// <summary>
        ///  ExecuteNonQuery
        /// </summary>
        /// <param name="sql">要执行的语句/param>
        /// <param name="type">指定类型（存储过程还是语句）</param>
        /// <param name="pms">参数</param>
        /// <returns></returns>
        public static int  ExecuteNonQuery(string sql, CommandType type, params SqlParameter[] pms)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    //判断传入的是sql语句还是存储过程
                    cmd.CommandType = type;
                    if (pms != null)
                    {
                        cmd.Parameters.AddRange(pms);
                    }
                    con.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        /// <summary>
        /// 返回单个值
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="type"></param>
        /// <param name="pms"></param>
        /// <returns></returns>
        public static object ExecuteScalar(string sql, CommandType type, params SqlParameter[] pms)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = type;
                    if (pms != null)
                    {
                        cmd.Parameters.AddRange(pms);
                    }
                    con.Open();
                    return cmd.ExecuteScalar();
                }
            }
        }
        public static SqlDataReader ExecuteReader(string sql, CommandType type, params SqlParameter[] pms)
        {
            //这里不使用using是因为reader对象不能关闭连接。reader对象在使用时，必须保证连接是打开的。
            SqlConnection con = new SqlConnection(conStr);
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.CommandType = type;
                if (pms != null)
                {
                    cmd.Parameters.AddRange(pms);
                }
                try
                {
                    con.Open();
                    //使用CommandBehavior.CloseConnection，表示将来使用完毕sqlDatareader后，在关闭reader的同时，关闭关联的Connection对象。
                    return cmd.ExecuteReader(CommandBehavior.CloseConnection);
                }
                //异常执行
                catch (Exception)
                {
                    con.Close();
                    con.Dispose();
                    throw;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="type"></param>
        /// <param name="pms"></param>
        /// <returns></returns>/.
        public static DataTable ExcuteDataTable(string sql, CommandType type, params SqlParameter[] pms)
        {
            DataTable dt = new DataTable();
            using (SqlDataAdapter adapter = new SqlDataAdapter(sql, conStr))
            {
                adapter.SelectCommand.CommandType = type;
                if (pms != null)
                {
                    adapter.SelectCommand.Parameters.AddRange(pms);
                }
                adapter.Fill(dt);
            }
            return dt;
        }
    }
}
