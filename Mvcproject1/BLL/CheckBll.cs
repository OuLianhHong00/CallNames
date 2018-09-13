using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DAO;
using Model;
namespace BLL
{
   public  class CheckBll
    {
        private CheckDao checkDao = new CheckDao();
        public SqlDataReader showCheck(string tea_id)
        {
            return checkDao.showCheck(tea_id);

        }
        public DataTable showCheckDetail(string tea_id,string ck_time)
        {

            return checkDao.showCheckDetail(tea_id,ck_time);
        }
        public int updateState(Check check)
        {
            return checkDao.updateState(check);
        }
        public int Insertck_inforByTradition(string stu_id, string stu_name, string cur_state, string ck_time, string cou_id, string tea_id)
        {
            return checkDao.Insertck_inforByTradition(stu_id, stu_name, cur_state, ck_time, cou_id, tea_id);
        }

    }
}
