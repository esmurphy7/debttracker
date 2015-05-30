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
                
            while(true)
            {
                tester.run();

                Console.WriteLine("Again?(y/n)");
                string again = Console.ReadLine();
                if (!again.Equals("y"))
                {
                    break;
                } 
            }                       
        }

        
    }
}
