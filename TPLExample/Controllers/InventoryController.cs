using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;

namespace TPLExample.Controllers
{
    public class InventoryController : ApiController
    {
        [HttpGet]
        public int GetTotoalInvetoryByProduct(int productId)
        {
            Thread.Sleep(1000);
            return 1000;
        }
    }
}
