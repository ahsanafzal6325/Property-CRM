using DATA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utilities.Services
{
    public static class UserServices
    {
        public static List<Menu> GetMainMenuById(int? id)
        {
            List<Menu> returnValue = null;
            try
            {
                using (FinalDBCotext db = new FinalDBCotext())
                {

                    returnValue = db.Menu.Where(x => x.MenuId == id).ToList();
                    //string SQL = $"select * from MainMenu where Id={id}";
                    //returnValue = db.Database.SqlQuery<Menu>(SQL).SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return returnValue;
        }
        public static List<Users> GetAllUsers()
        {
            List<Users> returnValue = new List<Users>();
            try
            {
                using (FinalDBCotext db = new FinalDBCotext())
                {
                    returnValue = db.Users.ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return returnValue;
        }
        public static Users GetUserById(int id)
        {
            Users returnValue = new Users();
            try
            {
                using (FinalDBCotext db = new FinalDBCotext())
                {
                    returnValue = db.Users.Find(id);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return returnValue;
        }
        public static List<UserRights> GetAllUserRightsByUserId(int userId)
        {
            List<UserRights> returnValue = new List<UserRights>();
            try
            {
                using (FinalDBCotext db = new FinalDBCotext())
                {
                    returnValue = db.UserRights.Where(x => x.UserId == userId).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return returnValue;
        }
        public static List<Menu> GetAllParentMenus()
        {
            List<Menu> returnValue = new List<Menu>();
            try
            {
                using (FinalDBCotext db = new FinalDBCotext())
                {
                    returnValue = db.Menu.ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return returnValue;
        }


    }
}
