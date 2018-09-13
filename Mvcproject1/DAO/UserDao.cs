using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Common;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
   
    public class UserDao
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public User queryUserByUsername(string name) {
            string sql = "select * from t_user where username='"+name+"'";
            SqlParameter[] pms = {
                                 new SqlParameter("@name",SqlDbType.VarChar,50),
                                 };
            //给参数赋值
            pms[0].Value = name;
      
            DataTable dt= SqlHelper.ExcuteDataTable(sql, CommandType.Text);
            User userInfo = null;
            if (dt.Rows.Count > 0)
            {
                userInfo = new User();
                LoadEntity(dt.Rows[0], userInfo);
            }
            return userInfo;
        }

        private void LoadEntity(DataRow dataRow, User userInfo)
        {
            userInfo.Id = Convert.ToInt32(dataRow["Id"]);
            //判断是否为空
            userInfo.Username = dataRow["username"] != DBNull.Value ? dataRow["username"].ToString() : string.Empty;
            userInfo.Password = dataRow["password"] != DBNull.Value ? dataRow["password"].ToString() : string.Empty;
           
        }
    }
}