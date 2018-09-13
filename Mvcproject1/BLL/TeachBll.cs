using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using System.Data;
namespace BLL
{
    public class TeachBll
    {
        TeachDao teachdao = new TeachDao();
        public int InsertIntoTeachInfo(string tea_id, string cou_id, string cou_num, string stu_name, string stu_id)
        {
            return teachdao.InsertIntoTeachInfo(tea_id, cou_id, cou_num, stu_name, stu_id);
        }

        public int Insert_importStuInfos(DataTable dt2)
        {
            return teachdao.Insert_importStuInfos(dt2);

        }
        public DataTable SelectTeachInfo(string id, string cou_id, string cou_num)
        //public Teach SelectTeachInfo(string id, string cou_id, string cou_num)
        {
            return teachdao.SelectTeachInfo(id, cou_id, cou_num);
        }

        public DataTable SelectInforByTradition(string tea_id, string cou_id, string cou_num)
        {

            return teachdao.SelectInforByTradition(tea_id, cou_id, cou_num);
        }
    }
}
