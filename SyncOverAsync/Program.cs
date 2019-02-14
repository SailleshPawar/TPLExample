using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncOverAsync
{
    class Program
    {
        //synchrnous entry point
        static void Main(string[] args)
        {
            //asynchronous
            Task.Delay(5000).Wait();
           
            //how many threads


        }
    }
}
