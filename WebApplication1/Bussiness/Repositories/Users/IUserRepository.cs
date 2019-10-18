using Bussiness.Services.Base;
using MyDbTest.Models;
using MyDbTest.Repositories;

namespace Bussiness.Repositories.Users
{
    public interface IUserRepository : IRepository<Usuario, RestaurantDbContext>
    {
    }
}
