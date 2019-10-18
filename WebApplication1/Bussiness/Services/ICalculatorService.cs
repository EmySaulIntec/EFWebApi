using Bussiness.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Services
{
    public interface ICalculatorService : IAppService
    {
        int Sum(int a, int b);
        int Substract(int a, int b);
    }
}
