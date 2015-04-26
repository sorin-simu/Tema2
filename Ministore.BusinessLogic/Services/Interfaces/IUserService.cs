using System.Collections.Generic;
using Ministore.CrossCuttingConcerns.DTOs;

namespace Ministore.BusinessLogic.Services.Interfaces
{
    public interface IUserService
    {
        UserDto GetUser(string username, string password);
        UserDto GetUserByName(string name);
        string ForgotPassword(string username);
        void ChangePassword(string username, string password);
        void CreateUser(string username, string password, string name, string role);
        List<UserDto> GetAllUsers();
    }
}
