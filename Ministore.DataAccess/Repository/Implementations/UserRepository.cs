using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Ministore.CrossCuttingConcerns.DTOs;
using Ministore.DataAccess.Mappers;
using Ministore.DataAccess.Repository.Interfaces;

namespace Ministore.DataAccess.Repository.Implementations
{
    public class UserRepository : BaseRepository<User>,IUserRepository
    {
        public UserRepository(IObjectContextAdapter dbContext) : base(dbContext)
        {
        }

        private string GetMd5Hash(string input)
        {
            // Create a new instance of the MD5CryptoServiceProvider object.
            var md5Hasher = MD5.Create();

            // Convert the input string to a byte array and compute the hash.  
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            var sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            foreach (var d in data)
            {
                sBuilder.Append(d.ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }




        public UserDto GetUser(String username, String password)
        {
            return DbSet.FirstOrDefault(u => u.Username == username && u.Password == password).ToUserDto();
        }


        public UserDto GetUserByName(string name)
        {
            return DbSet.FirstOrDefault(u => u.Name == name).ToUserDto();
        }


        public void UpdatePassword(string password, string username)
        {
            var user = DbSet.FirstOrDefault(u => u.Username == username && u.Password == password);
            Edit(user);
        }

        public void Createuser(UserDto newUser)
        {
            var user = new User
            {
                Id = newUser.Id,
                Name = newUser.Name,
                Username = newUser.Username,
                Password = newUser.Password,
                Role = newUser.Role
            };
            Add(user);
        }

        public List<UserDto> GetAllUsers()
        {
            return All().ToUserDtoList();
        }
    }
}
