using System.Collections.Generic;
using Codar.Net.Users.Controllers.Models.Request;
using Codar.Net.Users.Models;

namespace Codar.Net.Users.Repositories.Interfaces
{
    public interface IUserRepository
    {
        //Controller Methods
        void Save(User user);
        IEnumerable<User> GetAll();
        void EditUser(int id, UserRequest updateUserRequest);
        void DeleteUser(int id);

        //Util Methods
        User GetById(int id);
        User GetByEmail(string email);
    }
}