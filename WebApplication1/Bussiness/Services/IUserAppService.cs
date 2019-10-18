using Bussiness.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Services
{
    public interface IUserAppService : IAppService
    {
        void SaveUser(string name);
    }
}
