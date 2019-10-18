using MyDbTest.ModelTest;
using MyDbTest.Repositories;

namespace Bussiness.TestRepositories.Customers
{
    public interface ICustomerRepository : IRepository<Customer, TestDbContext>
    {
    }
}
