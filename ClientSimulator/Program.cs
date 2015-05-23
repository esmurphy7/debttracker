using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            string localServiceAppKey = "debttrackerlocalkey";
            var serviceClient 
                = new MobileServiceClient("http://localhost:50780/", localServiceAppKey);
             //= new MobileServiceClient("https://debttracker.azure-mobile.net/","IfsLQMYiUHObNtCttJMvYenStchggQ16");

            var todoItemsTable = serviceClient.GetTable<TodoItem>();
            todoItemsTable.InsertAsync(new TodoItem()
                {
                    Text = "from console app",
                    Complete = false
                });
            Console.ReadLine();
        }
    }
}
