using Bussiness.Services.Base;
using Bussiness.TestRepositories.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Services.Customers
{
    public class CustomerAppService : AppService, ICustomerAppService
    {
        private ICustomerRepository _customerRepository;
        public CustomerAppService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public void SaveCustomer(string name)
        {
            _customerRepository.Create(new MyDbTest.ModelTest.Customer()
            {
                CustomerID = "ABSC",
                CompanyName = name
            });
        }
    }
}
