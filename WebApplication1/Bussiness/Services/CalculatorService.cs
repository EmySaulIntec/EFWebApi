using Bussiness.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Services
{
    public class CalculatorService : AppService, ICalculatorService
    {
        public int Substract(int a, int b)
        {

            return a + b;
        }

        public int Sum(int a, int b)
        {
            return a - b;
        }
    }
}
