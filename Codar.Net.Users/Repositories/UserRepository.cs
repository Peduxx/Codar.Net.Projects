using System;
using System.Collections.Generic;
using System.Linq;
using Codar.Net.Users.Controllers.Models.Request;
using Codar.Net.Users.Data;
using Codar.Net.Users.Models;
using Codar.Net.Users.Repositories.Interfaces;

namespace Codar.Users.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDataContext _context;

        public UserRepository(UserDataContext context)
        {
            _context = context;
        }
        // Controller Methods
        public void Save(User user)
        {
            _context.Add(user);
            _context.SaveChanges();
        }

        public IEnumerable<User> GetAll()
        {
            IEnumerable<User> users = _context.Users.ToList();

            return users;
        }

        public void EditUser(int id, UserRequest updateUserRequest)
        {
            User user = GetById(id);

            user.Name = updateUserRequest.Name;
            user.Email = updateUserRequest.Email;
            user.Password = updateUserRequest.Password;
            user.Age = updateUserRequest.Age;
            
            _context.Update(user);
            _context.SaveChanges();
        }
        
        public void DeleteUser(int id)
        {
            User user = GetById(id);
            
            _context.Remove(user);
            _context.SaveChanges();
        }

        //Util Methods
        public User GetById(int id)
        {
            User user = _context.Users.FirstOrDefault(u => u.Id == id);

            return user;
        }

        public User GetByEmail(string email)
        {
            User user = _context.Users.FirstOrDefault(u => u.Email == email);

            return user;
        }
    }
}