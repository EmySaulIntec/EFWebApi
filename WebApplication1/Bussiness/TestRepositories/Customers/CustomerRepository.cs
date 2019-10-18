using MyDbTest.ModelTest;
using MyDbTest.Repositories;

namespace Bussiness.TestRepositories.Customers
{
    public class CustomerRepository : Repository<Customer, TestDbContext>, ICustomerRepository
    {
    }
}
