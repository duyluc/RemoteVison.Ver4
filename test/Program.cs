using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    internal class Program
    {
        class person
        {
            public string name { get; set; }
        }
        static void Main(string[] args)
        {
            Dictionary<string, person> d1 = new Dictionary<string, person>();
            Dictionary<string,person> d2 = new Dictionary<string, person>();

            person s = new person
            {
                name = "name"
            };
            
            d1.Add("son", s);
            Console.WriteLine(d1["son"].name);
            d2.Add("name", d1["son"]);
            d2["name"].name = "noname";
            Console.WriteLine(d1["son"].name);
            Console.WriteLine(d2["name"].name);
            Console.ReadKey();

        }
    }
}
