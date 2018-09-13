using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using System.Data;
using System.Data.SqlClient;
using Model;
namespace DAO
{
   public  class TeacherDao
    {
       
        public int registerTea(string tea_id, string tea_name, string tea_sex, string tea_job, string informa, string tea_tel, string tea_qq, string tea_address, string tea_academy, string password, string passmessage, string passquestion)
        {
            string sql = "insert into tea_inform (tea_id,tea_name,tea_sex,tea_job,informa,tea_tel,tea_qq,tea_address,tea_academy,tea_password,passmessage,passquestion)VALUES(@id,@tea_name,@tea_sex,@tea_job,@informa,@tea_tel,@tea_qq,@tea_address,@tea_academy,@password,@passmessage,@passquestion)";
            SqlParameter[] pms = {
                                 new SqlParameter("@id",SqlDbType.NChar,12),
                                 new SqlParameter("@tea_name",SqlDbType.NChar,10),
                                 new SqlParameter("@tea_sex",SqlDbType.NChar,2),
                                 new SqlParameter("@tea_job",SqlDbType.NChar,20),
                                 new SqlParameter("@informa",SqlDbType.NChar,50),
                                 new SqlParameter("@tea_tel",SqlDbType.Char,11),
                                 new SqlParameter("@tea_qq",SqlDbType.NChar,10),
                                 new SqlParameter("@tea_address",SqlDbType.NChar,50),
                                 new SqlParameter("@tea_academy",SqlDbType.NChar,20),
                                 new SqlParameter("@password",SqlDbType.NChar,10),
                                 new SqlParameter("@passmessage",SqlDbType.NVarChar,50),
                                 new SqlParameter("@passquestion",SqlDbType.NVarChar,50)
                                 };
            //给参数赋值
            pms[0].Value = tea_id;
            pms[1].Value = tea_name;
            pms[2].Value = tea_sex;
            pms[3].Value = tea_job;
            pms[4].Value = informa;
            pms[5].Value = tea_tel;
            pms[6].Value = tea_qq;
            pms[7].Value = tea_address;
            pms[8].Value = tea_academy;
            pms[9].Value = password;
            pms[10].Value = passmessage;
            pms[11].Value = passquestion;
            return   SqlHelper.ExecuteNonQuery(sql, CommandType.Text,pms);
        }
        public DataTable showCourse(string tea_id)
        {
            string sql = "select *from cou_infor where tea_id = @tea_id";
            SqlParameter[] pms = {
                new SqlParameter("@tea_id",tea_id),
            };
            return SqlHelper.ExcuteDataTable(sql,CommandType.Text,pms);
        }
        public int deleteCourse(string cou_name,string tea_id)
        {

           string sql= "  delete from cou_infor where cou_name = @ cou_name and tea_id = @tea_id ";
            SqlParameter[] pms = { new SqlParameter("@cou_name",cou_name),
                new SqlParameter("@tea_id",tea_id),
            };
            return SqlHelper.ExecuteNonQuery(sql,CommandType.Text,pms);
        }
        public DataTable checkImportStuInfos(string t_id, string cou_id, string cou_num)
        {
            string sql = "select * from teach_infor  where tea_id=@t_id  and cou_id=@cou_id and cou_num=@cou_num";
            SqlParameter[] pms =
                {
                 new SqlParameter("@t_id",t_id),
                 new SqlParameter ("@cou_id",cou_id),
                 new SqlParameter ("@cou_num",cou_num),
            };
            return SqlHelper.ExcuteDataTable(sql,CommandType.Text,pms);
        }
        //获取课程号和课序号
        public DataTable getCourseIdAndNum(string tea_id)
        {
           string sql= "select *from cou_infor where tea_id =@id";
            SqlParameter[] pms = {
                new SqlParameter ("@id",tea_id),
            };
            return SqlHelper.ExcuteDataTable(sql,CommandType.Text,pms); 
        }
        //获取教师个人信息
        public Teacher showTeacherInfo(string tea_id)
        {
            string sql = "select *from tea_inform where tea_id=@tea_id";
            SqlParameter[] pms =
                {
                   new SqlParameter("@tea_id",tea_id),
                 };
            DataTable dt = SqlHelper.ExcuteDataTable(sql,CommandType.Text,pms);
            Teacher teacher = null;
            if(dt.Rows.Count>0)
            {
                teacher = new Teacher();
                LoadEntity(dt.Rows[0],teacher);
            }
            return teacher;
           
        }
        //将数据表对象转换为teacher对象
         private void LoadEntity(DataRow dataRow, Teacher teacherInfo)
        {
            //判断是否为空
            teacherInfo.Informa = dataRow["informa"] != DBNull.Value ? dataRow["informa"].ToString() : string.Empty;
            teacherInfo.Tea_Tel= dataRow["tea_tel"] != DBNull.Value ? dataRow["tea_tel"].ToString() : string.Empty;
            teacherInfo.Tea_Sex = dataRow["tea_sex"] != DBNull.Value ? dataRow["tea_sex"].ToString() : string.Empty;
            teacherInfo.Tea_Qq = dataRow["tea_qq"] != DBNull.Value ? dataRow["tea_qq"].ToString() : string.Empty;
            teacherInfo.Tea_Password =dataRow["tea_password"].ToString();
            teacherInfo.Tea_Name = dataRow["tea_name"] != DBNull.Value ? dataRow["tea_name"].ToString() : string.Empty;
            teacherInfo.Tea_Job = dataRow["tea_job"] != DBNull.Value ? dataRow["tea_job"].ToString() : string.Empty;
            teacherInfo.Tea_Id = dataRow["tea_id"].ToString();
            teacherInfo.Tea_Address = dataRow["tea_address"] != DBNull.Value ? dataRow["tea_address"].ToString() : string.Empty;
            teacherInfo.Tea_Academy = dataRow["tea_academy"] != DBNull.Value ? dataRow["tea_academy"].ToString() : string.Empty;
            teacherInfo.Passmessage = dataRow["passmessage"] != DBNull.Value ? dataRow["passmessage"].ToString() : string.Empty;
            teacherInfo.Passquestion = dataRow["passquestion"] != DBNull.Value ? dataRow["passquestion"].ToString() : string.Empty;
 
        }
        //更新教师信息
        public int updateInfo(Teacher teacher)
        {
            string sql = "update tea_inform set tea_name=@tea_name,tea_sex=@tea_sex,tea_job=@tea_job,informa=@informa,tea_tel=@tea_tel,tea_qq=@tea_qq,tea_address=@tea_address,tea_academy=@tea_academy,tea_password=@tea_password,passmessage=@passmessage,passquestion=@passquestion where tea_id=@tea_id";
            SqlParameter[] pms = {
               
                new SqlParameter("@tea_name",teacher.Tea_Name),
                new SqlParameter("@tea_sex",teacher.Tea_Sex),
                new SqlParameter("@tea_job",teacher.Tea_Job),
                new SqlParameter("@informa",teacher.Informa),
                new SqlParameter("@tea_tel",teacher.Tea_Tel),
                new SqlParameter("@tea_qq",teacher.Tea_Qq),
                new SqlParameter("@tea_address",teacher.Tea_Address),
                new SqlParameter("@tea_academy",teacher.Tea_Academy),
                new SqlParameter("@tea_password",teacher.Tea_Password),
                new SqlParameter("@passmessage",teacher.Passmessage),
                new SqlParameter("@passquestion",teacher.Passquestion),
                new SqlParameter("@tea_id",teacher.Tea_Id.Trim()),
            };
            return SqlHelper.ExecuteNonQuery(sql,CommandType.Text,pms) ;
        }

        //查询老师当堂课的学生总数
        public DataTable StudentNumber(string teaid, string couid, string counum)
        {
            string sql = "select * from teach_infor where Tea_id=@teaid AND Cou_id=@couid AND Cou_num=@counum";
            SqlParameter[] pms = {
                new SqlParameter(@"teaid", teaid),
                new SqlParameter(@"couid", couid),
                new SqlParameter(@"counum",counum)
            };
            DataTable dt = SqlHelper.ExcuteDataTable(sql, CommandType.Text, pms);
            return dt;
        }
        //保存数据
        public int SaveData(Check ckstudent)
        {
            int flag = 0;
            string sql = "insert into ck_infor (stu_id,stu_name,[state],ck_time,cou_id,tea_id) values(@stu_id,@stu_name,@cur_state,@checkName,@cou_id,@tea_id )";
            SqlParameter[] pms = {
                new SqlParameter(@"stu_id", ckstudent.Stu_Id),
                new SqlParameter(@"stu_name", ckstudent.Stu_Name),
                new SqlParameter(@"cur_state",ckstudent.State),
                new SqlParameter(@"checkName",ckstudent.Ck_Time),
                new SqlParameter(@"cou_id",ckstudent.Cou_Id),
                new SqlParameter(@"tea_id",ckstudent.Tea_Id), };
            if (SqlHelper.ExecuteNonQuery(sql, CommandType.Text, pms) > 0)
            {
                flag = 1;
            }
            return flag;
        }

        public Teacher GetUserInfoModel(string userName, string userpwd)
        {
            
            return TeaLogin(userName,userpwd);

        }
        public Teacher TeaLogin(string userName, string userPwd)
        {
            string sql = @"SELECT tea_id,tea_password FROM tea_inform WHERE tea_id=@UserName AND tea_password=@Password";
            SqlParameter[] pms = {
                new SqlParameter(@"UserName", userName),
                new SqlParameter(@"Password", userPwd)
            };
            SqlDataReader reader = SqlHelper.ExecuteReader(sql, CommandType.Text, pms);
            Model.Teacher user = null;

            //读取具体的数据
            while (reader.Read())
            {
                if (user == null)
                {
                    user = new Model.Teacher();
                }
                //读取查询到的数据
                user.Tea_Id = reader.GetString(0);
                user.Tea_Password = reader.GetString(1);
               
            }
            return user;
        }
    }
}
