using System.Collections.Generic;
using System.Linq;
using Ministore.CrossCuttingConcerns.DTOs;

namespace Ministore.DataAccess.Mappers
{
    public static class UserMapper
    {
        public static UserDto ToUserDto(this User model)
        {
            if (model == null) return null;
            var dto = new UserDto
            {
                Id = model.Id,
                Name = model.Name,
                Password = model.Password,
                Username = model.Username,
                Role = model.Role
            };
            return dto;
        }

        public static List<UserDto> ToUserDtoList(this List<User> listModel)
        {
            return listModel == null ? new List<UserDto>() : listModel.Select(model => model.ToUserDto()).ToList();
        }
    }
}
