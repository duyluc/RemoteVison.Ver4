using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1
{
    internal class Program
    {
        class testargs : EventArgs
        {
            public string a = "ok";
            public testargs()
            {

            }
        }
        static void Main(string[] args)
        {
            testargs test = new testargs();
            if(typeof(testargs).IsSubclassOf(typeof(EventArgs)))
            {
                Console.WriteLine("ok");
            }
            Console.ReadKey();
        }
    }
}
