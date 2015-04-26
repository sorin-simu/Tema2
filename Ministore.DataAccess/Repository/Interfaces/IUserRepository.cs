using System;
using System.Collections.Generic;
using Ministore.CrossCuttingConcerns.DTOs;

namespace Ministore.DataAccess.Repository.Interfaces
{
    public interface IUserRepository
    {
        UserDto GetUser(String username, String password);
        UserDto GetUserByName(String name);
        void UpdatePassword(String password, String username);
        void Createuser(UserDto newUser);
        List<UserDto> GetAllUsers();
    }
}
