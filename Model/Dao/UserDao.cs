using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using PagedList;
using PagedList.Mvc;

namespace Model.Dao
{
    public class UserDao
    {
        OnLineShopDbContext db = null;
        public UserDao()
        {
            db = new OnLineShopDbContext();
        }
        public long Insert(User entity)
        {
            db.Users.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }


        //   phân trang
        public IEnumerable<User> LisAllPaging(int page, int pageSize)
        {
            return db.Users.OrderByDescending(x => x.CreateDate).ToPagedList(page, pageSize);
        }

        //   Update
        public bool Update(User entity)
        {
            try
            {
                var user = db.Users.Find(entity.ID);
                user.Name = entity.Name;
                if (!string.IsNullOrEmpty(user.Password))
                {

                    user.Password = entity.Password;
                }
                user.Addess = entity.Addess;
                user.Email = entity.Email;
                user.ModifedBy = entity.ModifedBy;
                user.ModifedDate = entity.ModifedDate;
                db.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public User GetById(string userName)
        {
            return db.Users.SingleOrDefault(x => x.UserName == userName);
        }
        public User ViewDetail(int id)
        {
            return db.Users.Find(id);
        }
        public int Login(string userName, string passWord)
        {
            var result = db.Users.SingleOrDefault(x => x.UserName == userName);
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (result.Status == false)
                {
                    return -1;
                }
                else
                {
                    if (result.Password == passWord)

                        return 1;
                    else
                        return -2;

                }

            }
        }
        public bool Delete(int id)
        {
            try
            {
                var user = db.Users.Find(id);
                db.Users.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }


}
