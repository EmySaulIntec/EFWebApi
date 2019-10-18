using Bussiness.Services.Base;

namespace Bussiness.Services.Customers
{
    public interface ICustomerAppService : IAppService
    {
        void SaveCustomer(string name);
    }
}