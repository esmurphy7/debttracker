using DebtrackerMobileServiceRepository.MobileServiceRepository;
using DebttrackerMobileServiceRepository.Authentication;
using DebttrackerMobileServiceRepository.Models;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientSimulator
{
    public class Tester
    {
        private MobileServiceUser _serviceUser;        

        public async void run()
        {
            while(true)
            {
                Init();
                string loginResponse = await TestLoginAsync();
                Console.WriteLine(loginResponse);

                string insertResponse = await TestInsertAsync();
                Console.WriteLine(insertResponse);

                //string getAllResponse = await TestGetAllSatisfyingItemsAsync();
                //Console.WriteLine(getAllResponse);  

                Console.WriteLine("Again?(y/n)");
                string again = Console.ReadLine();
                if (!again.Equals("y"))
                {
                    break;
                } 
            }

            Console.WriteLine("Done Tests");         
        }

        private void Init()
        {
        }

        private async Task<string> TestLoginAsync()
        {
            string response = String.Empty;

            Console.WriteLine("username?");
            string username = Console.ReadLine();

            Console.WriteLine("password?");
            string password = Console.ReadLine();

            try
            {
                var loginRequest = new LoginRequest()
                {
                    Username = username,
                    Password = password
                };

                await MobileServiceRepository.LoginAsync(loginRequest);
                response = String.Format("Logged in with userId: {0}", _serviceUser.UserId);
            }
            catch (Exception e)
            {
                response = String.Format("could not login: {0}", e.Message);
            }

            return response;
        }

        private async Task<string> TestInsertAsync()
        {
            string response = String.Empty;

            try
            {
                string curTime = DateTime.Now.ToString("h:mm:ss tt");
                var item = new TodoItem()
                {
                    Text = "from console app - "+curTime,
                    Complete = false
                };
                await MobileServiceRepository.InsertItemAsync<TodoItem>(item);
                response = String.Format("Inserted item with id: {0}", item.id);
            }
            catch (Exception e)
            {
                response = String.Format("could not insert: {0}", e.Message);
            }

            return response;
        }
        
        private async Task<string> TestGetAllSatisfyingItemsAsync()
        {
            string response = String.Empty;

            var item = new TodoItem()
            {
                id = Guid.NewGuid().ToString(),
                Text = "test",
                Complete = false
            };

            try
            {
                var items = await MobileServiceRepository.GetAllSatisfyingItemsAsync<TodoItem>(x => x.Complete == item.Complete, x => x.Text.Contains("console"));                
                response = String.Format("Got {0} items of type {1}", items.Count,item.GetType());
            }
            catch(Exception e)
            {
                response = String.Format("Could not get all items of type {0}: {1}", item.GetType(), e.Message);
            }

            return response;
        }
    }
}
