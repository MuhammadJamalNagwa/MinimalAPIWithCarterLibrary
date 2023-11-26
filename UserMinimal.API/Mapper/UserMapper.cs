using UserMinimal.API.Dtos;
using UserMinimal.API.Models;

namespace UserMinimal.API.Mapper;

public static class UserMapper
{
    public static UserDto ToUserDto(this User entity)
    {
        return new UserDto()
        {
            Name = entity.Name,
            Age = entity.Age,
            Email = entity.Email
        };
    }

    public static User ToUserEntity(this UserDto dto)
    {
        return new User()
        {
            Name = dto.Name,
            Age = dto.Age,
            Email = dto.Email
        };
    }
}
