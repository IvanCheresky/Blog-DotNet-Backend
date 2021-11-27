using DotNet_Backend.Data.Contracts.Interfaces;
using System.Linq;

namespace DotNet_Backend.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IBlogContext _blogContext;

        public UserRepository(IBlogContext blogContext)
        {
            _blogContext = blogContext;
        }

        public IQueryable<User> GetAll()
        {
            return _blogContext.Users;
        }

        public User Get(int id)
        {
            return _blogContext.Users.Find(id);
        }

        public User Add(User user)
        {
            _blogContext.Users.Add(user);
            _blogContext.SaveChanges();

            return user;
        }

        public User Update(User user)
        {
            var u = Get(user.Id);

            if (!string.IsNullOrEmpty(user.Username))
            {
                u.Username = user.Username;
            }

            if (!string.IsNullOrEmpty(user.Password))
            {
                u.Password = user.Password;
            }

            _blogContext.Users.Update(u);
            _blogContext.SaveChanges();

            return u;
        }

        public void Delete(int id)
        {
            var u = _blogContext.Users.Find(id);
            _blogContext.Users.Remove(u);
            _blogContext.SaveChanges();
        }

        public void SaveChanges()
        {
            _blogContext.SaveChanges();
        }
    }
}