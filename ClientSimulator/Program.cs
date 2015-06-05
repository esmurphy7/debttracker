using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ClientSimulator
{
    class Program
    {      
        static void Main(string[] args)
        {
            Tester tester = new Tester();
            tester.Run().Wait();
            Console.ReadLine();           
        }        
    }
}
