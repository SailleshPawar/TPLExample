using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TPLClient.Models;

namespace TPLClient.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            HttpClient client =
        new HttpClient() { MaxResponseContentBufferSize = 1000000 };

            Stopwatch sw = new Stopwatch();
            sw.Start();

            Task<int> inventoryDownload =
                ProcessURLAsync("http://localhost:63922/api/Inventory?productId=1", client);
            Task<int> MRPAfterCouponDownload =
                ProcessURLAsync("http://localhost:63922/api/Coupon/100000100", client);
            Task<string> productNameDownload =
                ProcessURLAsyncString("http://localhost:63922/api/Values/1", client);


          await  Task.WhenAll(inventoryDownload, MRPAfterCouponDownload, productNameDownload);

            Product productInfo = new Product();
            productInfo.Heading = "Product information Fetching with TPL";
            // Await each task.  
            productInfo.InventoryCount =  inventoryDownload.Result;
            productInfo.DiscountedPrice =  MRPAfterCouponDownload.Result;
            productInfo.Name =  productNameDownload.Result;
            sw.Stop();
            productInfo.TotalExecutionTimeInSec = sw.Elapsed.Seconds;
            return View(productInfo);
        }

        async Task<int> ProcessURLAsync(string url, HttpClient client)
        {
            var Reponse = await client.GetStringAsync(url);
            return Convert.ToInt32(Reponse);
            // return (T)Convert.ChangeType(Reponse, typeof(T));
        }


        public ActionResult IndexSync()
        {
            HttpClient client =
        new HttpClient() { MaxResponseContentBufferSize = 1000000 };

            Stopwatch sw = new Stopwatch();
            sw.Start();

            Product productInfo = new Product();
            productInfo.Heading = "Product information Fetching without TPL"; 
            productInfo.InventoryCount =Convert.ToInt32(client.GetStringAsync("http://localhost:63922/api/Inventory?productId=1").Result);
            productInfo.DiscountedPrice = Convert.ToInt32(client.GetStringAsync("http://localhost:63922/api/Coupon/100000100").Result);
            productInfo.Name = client.GetStringAsync("http://localhost:63922/api/Values/1").Result.ToString();
            sw.Stop();
            productInfo.TotalExecutionTimeInSec = sw.Elapsed.TotalSeconds;
            return View("Index",productInfo);
        }


        async Task<string> ProcessURLAsyncString(string url, HttpClient client)
        {
            string Reponse = await client.GetStringAsync(url);
            return Reponse;
        }



        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}