using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1
{
    internal class Program
    {
        [Flags]
        public enum commnad
        {
            Regis,
            None,
        }
        static void Main(string[] args)
        {
            commnad a = commnad.Regis & commnad.None;
            if(a == commnad.Regis)
            {
                Console.WriteLine("Regig");
            }
            if(a == commnad.None)
            {
                Console.WriteLine("None");
            }
            Console.WriteLine(a.ToString());
            Console.ReadKey();
        }
    }
}
