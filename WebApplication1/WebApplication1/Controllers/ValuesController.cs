using Bussiness.Services;
using Bussiness.Services.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class ValuesController : ApiController
    {

        public ICalculatorService _calculatorService;
        public IUserAppService _userAppService;
        public ICustomerAppService _customerAppService;
        
        //
        //        
        public ValuesController(ICalculatorService calculatorService, IUserAppService userAppService, ICustomerAppService customerAppService)
        {
            _calculatorService = calculatorService;
            _userAppService = userAppService;
            _customerAppService = customerAppService;
        }

        // GET api/values
        public IEnumerable<string> Get()
        {

            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            _userAppService.SaveUser(id.ToString());
            _customerAppService.SaveCustomer(id.ToString());
            return _calculatorService.Substract(id, 5).ToString();
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
            _userAppService.SaveUser(value);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
