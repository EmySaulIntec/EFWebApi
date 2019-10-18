using Bussiness.Services;
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
        //
        //        
        public ValuesController(ICalculatorService calculatorService, IUserAppService userAppService)
        {
            _calculatorService = calculatorService;
            _userAppService = userAppService;
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
