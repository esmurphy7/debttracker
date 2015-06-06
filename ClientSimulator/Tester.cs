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
        public async Task Run()
        {
            while (true)
            {
                Init();

                string registerResponse = await TestRegistrationASync();
                Console.WriteLine(registerResponse);

                string loginResponse = await TestLoginAsync();
                Console.WriteLine(loginResponse);

                //string insertResponse = await TestInsertAsync();
                //Console.WriteLine(insertResponse);

                //string getAllResponse = await TestGetAllSatisfyingItemsAsync();
                //Console.WriteLine(getAllResponse);  

                //string updateItemsResponse = await TestUpdateItemSetAsync();
                //Console.WriteLine(updateItemsResponse);

                //string deleteItemsResponse = await TestDeleteItemSetAsync();
                //Console.WriteLine(deleteItemsResponse);

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

                var serviceUser = await MobileServiceRepository.LoginAsync(loginRequest);
                response = String.Format("Logged in with userId: {0}", serviceUser.UserId);
            }
            catch (Exception e)
            {
                response = String.Format("Unable not login: {0}", e.Message);
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
                    //Text = "from console app - " + curTime,
                    Complete = false
                };
                await MobileServiceRepository.InsertItemAsync<TodoItem>(item);
                response = String.Format("Inserted item with id: {0}", item.id);
            }
            catch (Exception e)
            {
                response = String.Format("Unable to insert: {0}", e.Message);
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
                response = String.Format("Got {0} items of type {1}", items.Count, item.GetType());
            }
            catch (Exception e)
            {
                response = String.Format("Could not get all items of type {0}: {1}", item.GetType(), e.Message);
            }

            return response;
        }

        private async Task<string> TestUpdateItemSetAsync()
        {
            string response = String.Empty;

            var items = await MobileServiceRepository.GetAllSatisfyingItemsAsync<TodoItem>(x => x.Complete == false);

            string curTime = DateTime.Now.ToString("h:mm:ss tt");
            foreach (var item in items)
            {
                item.Text = "updated from console app - " + curTime;
            }

            try
            {
                await MobileServiceRepository.UpdateItemSetAsync<TodoItem>(items);
                response = String.Format("Updated {0} items", items.Count);
            }
            catch (Exception e)
            {
                response = String.Format("Unable to update items: {0}", e.Message);
            }

            return response;
        }

        private async Task<string> TestDeleteItemSetAsync()
        {
            string response = String.Empty;

            var items = await MobileServiceRepository.GetAllSatisfyingItemsAsync<TodoItem>(item => item.Complete == false);

            try
            {
                await MobileServiceRepository.DeleteItemSetAsync<TodoItem>(items);
                response = String.Format("Deleted {0} items", items.Count);
            }
            catch(Exception e)
            {
                response = String.Format("Unable to delete items: {0}",e.Message);
            }

            return response;
        }

        private async Task<string> TestRegistrationASync()
        {
            string response = String.Empty;
            string testEmail = "example@domain.com";
            string testUsername = "testconsole";
            string testPassword = testUsername;

            try
            {
                var responseMessage = await MobileServiceRepository.RegisterAsync(testEmail, testUsername, testPassword);
                response = String.Format("Registered user with username: {0}, Response: {1}", testUsername, responseMessage.Message);
            }
            catch (Exception e)
            {
                response = String.Format("Unable to register user {0}: {1}", testUsername, e.Message);
            }

            return response;
        }
    }
}
