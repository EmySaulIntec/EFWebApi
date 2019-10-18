using Bussiness.Services.Base;
using Bussiness.Services.Users.Dto;

namespace Bussiness.Services
{
    public interface IUserAppService : IAppService
    {
        void SaveUser(string name);
        void SaveUser(UserDto user);
    }
}
