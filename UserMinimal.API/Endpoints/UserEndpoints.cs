using Carter;
using UserMinimal.API.Dtos;
using UserMinimal.API.Interfaces;
using UserMinimal.API.Mapper;
using UserMinimal.API.Models;

namespace UserMinimal.API.Endpoints;

public class UserEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        RouteGroupBuilder? userEndpointsGroup = app.MapGroup("api/users/");
        userEndpointsGroup.MapGet("", GetAllAsync);
        userEndpointsGroup.MapGet("{userId:int}", GetUserByIdAsync);
        userEndpointsGroup.MapPost("", CreateUserAsync);
        userEndpointsGroup.MapPost("list", CreateUsersAsync);
        userEndpointsGroup.MapPut("{userId:int}", UpdateUserAsync);
        userEndpointsGroup.MapDelete("{userId:int}", DeleteUserAsync);
    }

    public static async Task<IResult>? CreateUserAsync(UserDto newUser, IUserRepository userRepository)
    {
        User? addeduser = await userRepository.AddAsync(newUser.ToUserEntity());

        return addeduser is not null ? Results.Ok(addeduser.ToUserDto()) : Results.BadRequest("Something Went Wrong");

    }

    public static async Task<IResult> CreateUsersAsync(List<UserDto> newUsers, IUserRepository userRepository)
    {
        List<User> users = await userRepository.AddRangeAsync(newUsers.Select(u => u.ToUserEntity()).ToList());

        if (users.Count <= 0)
        {
            return Results.BadRequest("Something Went Wrong");
        }
        return Results.Ok(users);
    }

    public static async Task<IResult> UpdateUserAsync(int userId, UpdateUserDto updatedUser, IUserRepository userRepository)
    {
        User user = await userRepository.GetByIdAsync(userId);
        if (user is null)
            return Results.NotFound();
        else
        {
            user.Name = updatedUser.Name;
            user.Email = updatedUser.Email;
            user.Age = updatedUser.Age;

            userRepository.Update(user);
            return Results.Ok(user.ToUserDto());
        }
    }

    public static async Task<IResult> DeleteUserAsync(int userId, IUserRepository userRepository)
    {
        User user = await userRepository.GetByIdAsync(userId);
        if (user is null)
            return Results.NotFound();
        else
        {
            userRepository.Delete(user);
            return Results.Ok();
        }
    }

    public static async Task<IResult> GetAllAsync(IUserRepository userRepository)
    {
        List<UserDto> users = (await userRepository.GetAllAsync()).Select(u => new UserDto()
        {
            Name = u.Name,
            Email = u.Email,
            Age = u.Age
        }).ToList();
        return Results.Ok(users);
    }

    public static async Task<IResult> GetUserByIdAsync(int userId, IUserRepository userRepository)
    {
        User user = await userRepository.GetByIdAsync(userId);

        return user is not null ? Results.Ok(user.ToUserDto()) : Results.NotFound();
    }
}
