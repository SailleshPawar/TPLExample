using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace TPLExample.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public string Get2()
        {
            return "value1".ToString();
        }

        // GET api/values/5
        public async Task<string> GetDescription(int id)
        {
            Thread.Sleep(1000);
            var productName = "Samsung Note 8";
            return  productName;
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
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
