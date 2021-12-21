using System.Collections.Generic;
using Codar.Net.Users.Controllers.Models.Request;
using Codar.Net.Users.Models;

namespace Codar.Net.Users.Services.Interfaces
{
    public interface IUserService
    {
        void Save(UserRequest userRequest);
        string Login(LoginRequest loginRequest);
        IEnumerable<User> GetAll();
        void EditUser(int id, UserRequest updateUserRequest);
        void DeleteUser(int id);
    }
}