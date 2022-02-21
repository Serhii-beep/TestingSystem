using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingSystem.DAL.Models;

namespace TestingSystem.DAL.Abstract
{
    public interface IUserRepository
    {
        void AddUser(User user);
        User GetUserById(int id);
        User GetUserByUserName(string userName);
        User GetUserByUserNameAndPassword(string userName, string password);
    }
}
