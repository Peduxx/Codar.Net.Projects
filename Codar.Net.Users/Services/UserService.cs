using System;
using System.Collections.Generic;
using Codar.Net.Users.Auth.Services;
using Codar.Net.Users.Controllers.Models.Request;
using Codar.Net.Users.Services.Interfaces;
using Codar.Net.Users.Repositories.Interfaces;
using Codar.Net.Users.Models;
using SecureIdentity.Password;

namespace Codar.Net.Users.Services
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;
        private readonly TokenService _tokenService;

        public UserService(IUserRepository userRepository, TokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }
        public void Save(UserRequest userRequest)
        {
            try
            {
                if (_userRepository.GetByEmail(userRequest.Email) != null)
                    throw new Exception();

                User user = User.Create(
                    userRequest.Name,
                    userRequest.Email,
                    userRequest.Password,
                    userRequest.Age
                );
                
                user.Password = PasswordHasher.Hash(userRequest.Password);

                _userRepository.Save(user);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public string Login(LoginRequest loginRequest)
        {
            User user = _userRepository.GetByEmail(loginRequest.Email);

                if (user == null)
                    throw new Exception();

                if (!PasswordHasher.Verify(user.Password, loginRequest.Password))
                    throw new Exception();

                var token = _tokenService.GenerateToken(user);
                return token;
        }

        public IEnumerable<User> GetAll()
        {
            try
            {
                IEnumerable<User> users = _userRepository.GetAll();

                return users;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public void EditUser(int id, UserRequest updateUserRequest)
        {
            try
            {
                _userRepository.EditUser(id, updateUserRequest);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public void DeleteUser(int id)
        {
            try
            {
                _userRepository.DeleteUser(id);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}