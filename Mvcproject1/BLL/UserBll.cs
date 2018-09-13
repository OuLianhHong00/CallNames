using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAO;

namespace BLL
{
    public class UserBll
    {
        private UserDao userdao = new UserDao();
     
        public User queryUserByUsername(string username)
        {
           return userdao.queryUserByUsername(username);
        }
    }
}
