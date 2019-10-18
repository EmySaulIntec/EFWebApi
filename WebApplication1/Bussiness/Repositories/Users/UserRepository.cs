using MyDbTest.Models;
using MyDbTest.Repositories;

namespace Bussiness.Repositories.Users
{
    public class UserRepository : Repository<Usuario, RestaurantDbContext>, IUserRepository
    {

    }
}
