using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Ministore.BusinessLogic.Services.Interfaces;
using Ministore.CrossCuttingConcerns.DTOs;
using Ministore.DataAccess.UnitOfWork;

namespace Ministore.BusinessLogic.Services.Implementations
{
    public class UserService : BaseService, IUserService
    {
        public UserService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }


        public UserDto GetUserByName(string name)
        {
            var currentUser = UnitOfWork.UserRepository.GetUserByName(name);
            return currentUser;
        }

        public UserDto GetUser(string username, string password)
        {
            //var encryptPassword = GetMd5Hash(password);
            var currentUser = UnitOfWork.UserRepository.GetUser(username, password);
            return currentUser;
        }

        public string ForgotPassword(string username)
        {
            var newPassword = RandomString(4);
            UnitOfWork.UserRepository.UpdatePassword(GetMd5Hash(newPassword), username);
            return newPassword;
        }

        public void ChangePassword(string username, string newPassword)
        {
            UnitOfWork.UserRepository.UpdatePassword(GetMd5Hash(newPassword), username);
        }

        public void CreateUser(string username, string password, string name, string role)
        {
            var newUser = new UserDto();
            UnitOfWork.UserRepository.Createuser(newUser);
        }

        public List<UserDto> GetAllUsers()
        {
            var users = UnitOfWork.UserRepository.GetAllUsers();
            return users;
        }

        private string GetMd5Hash(string input)
        {
            // Create a new instance of the MD5CryptoServiceProvider object.
            MD5 md5Hasher = MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        private static readonly Random Random = new Random((int)DateTime.Now.Ticks);

        private string RandomString(int size)
        {
            var builder = new StringBuilder();
            for (var i = 0; i < size; i++)
            {
                var ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * Random.NextDouble() + 65)));
                builder.Append(ch);
            }
            return builder.ToString();
        }
    }
}
