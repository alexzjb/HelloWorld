using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Guid[] uniques = new Guid[2] { new Guid( "8111A7E31F7DC3F827C272E434E23E26"),new Guid( "8111A7E3-1F7D-C3F8-27C2-72E434E23E26" )};
            string[] uniqueNames = uniques.Select(s => s.ToString("D").ToUpper()).ToArray();
            //List<string> UniqueNameList = new List<string>(uniqueNames);

            Console.WriteLine($"Hello World! {JsonConvert.SerializeObject(uniqueNames)}");
            Console.ReadLine();
        }
    }
}
