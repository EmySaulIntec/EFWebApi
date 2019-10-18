using Bussiness.Services.Base;

namespace Bussiness.Services
{
    public interface IUserAppService : IAppService
    {
        void SaveUser(string name);
    }
}
