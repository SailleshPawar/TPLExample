using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            //var list = ParallelEnumerable.Range(0, 10000000);
            //Parallel.ForEach(list, source =>
            //{
            //Console.WriteLine($"The actual value is {source}");
            //});
            //Console.ReadLine();


            try{

                 GetResult();
            }
            catch(AggregateException ex)
            {
               
                Console.WriteLine(ex.Message.ToString());       
            }
            catch(Exception ex)
            {

                Console.WriteLine(ex.Message.ToString());
            }



           

        }


        
        public static Task<string> GetResult()
        {
            throw new AggregateException("not imletend");
        }

    }
    

    

}
