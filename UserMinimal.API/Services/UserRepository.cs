using UserMinimal.API.Data;
using UserMinimal.API.Interfaces;
using UserMinimal.API.Models;

namespace Repository_With_UOW.EntityFrameworkCore.Services;
public class UserRepository : BaseRepository<User>, IUserRepository
{
    private readonly ApplicationDbContext _context;
    public UserRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
}
