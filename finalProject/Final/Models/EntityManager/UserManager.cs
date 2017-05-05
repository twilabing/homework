using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Final.Models.DB;
using Final.Models.ViewModel;
using System.Data;
using System.Data.SqlClient;

namespace Final.Models.EntityManager
{
    public class UserManager
    {
        public void AddUser(User newUser) {
            using (CE_WebEntities db = new CE_WebEntities()) {
                user NU = new user();
                NU.userName = newUser.userName;
                NU.userPassword = newUser.userPassword;

                db.users.Add(NU);
                db.SaveChanges();
            }
        }

        public bool GetUser(string userName, string userPassword) {
            using (CE_WebEntities db = new CE_WebEntities()) {
                return db.users.Where(o => o.userName.Equals(userName) && o.userPassword.Equals(userPassword)).Any();
            }
        }


        public int GetUserID(string userName)
        {   
            using (CE_WebEntities db = new CE_WebEntities())
            {
                var userExists =  db.users.Where(o => o.userName.Equals(userName));
                if (userExists.Any()) return userExists.FirstOrDefault().userID;
            }
            return 0;
        }

    }
}