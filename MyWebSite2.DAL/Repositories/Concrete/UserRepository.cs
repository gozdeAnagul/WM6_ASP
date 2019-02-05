
using MyWebSite2.DAL.Entities;
using MyWebSite2.DAL.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyWebSite2.DAL.Repositories.Concrete
{
    public class UserRepository : IUserRepository
    {
        MyWebSite2Context _db;
        public UserRepository()
        {
            _db = new MyWebSite2Context();
        }
        public int AddItem(User item)
        {
            _db.User.Add(item);
            int sonuc;
            sonuc = _db.SaveChanges();
            return sonuc;
        }

        public int DeleteItem(User item)
        {
            _db.User.Remove(item);
            int sonuc;
            sonuc = _db.SaveChanges();
            return sonuc;
        }

        public ICollection<User> GetAllItem(Expression<Func<User, bool>> lambda = null)
        {
            return lambda != null ? _db.User
                .Where(lambda).ToList() :
                _db.User.ToList();
        }

        public User GetItem(Expression<Func<User, bool>> lambda = null)
        {
            return _db.User.Where(lambda).FirstOrDefault();
        }

        public int UpdateItem(User İtem)
        {
            User oldUSer = _db.User.Where(x => x.UserId == İtem.UserId).FirstOrDefault();
            oldUSer.FirstName = İtem.FirstName;
            oldUSer.LastName = İtem.LastName;
            oldUSer.Gender = İtem.Gender;
            oldUSer.Password = İtem.Password;
            oldUSer.Email = İtem.Email;
            int sonuc;
            sonuc = _db.SaveChanges();
            return sonuc;

        }
    }
}
