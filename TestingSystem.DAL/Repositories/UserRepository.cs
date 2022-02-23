using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingSystem.DAL.Abstract;
using TestingSystem.DAL.DbContexts;
using TestingSystem.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace TestingSystem.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TestingSystemDbContext _context;

        public UserRepository(TestingSystemDbContext context)
        {
            _context = context;
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
        }

        public User GetUserById(int id)
        {
            return _context.Users.Find(id);
        }

        public User GetUserByUserName(string userName)
        {
            return _context.Users.AsNoTracking().FirstOrDefault(u => u.UserName == userName);
        }

        public User GetUserByUserNameAndPassword(string userName, string password)
        {
            return _context.Users.FirstOrDefault(u => u.UserName == userName && u.Password == password);
        }
    }
}
