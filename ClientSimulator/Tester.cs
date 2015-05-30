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
        private MobileServiceClient _serviceClient;
        private MobileServiceUser _serviceUser;        

        public async void run()
        {
            Init();
            string loginResponse = await TestLoginAsync();
            Console.WriteLine(loginResponse);

            string insertResponse = await TestInsertAsync();
            Console.WriteLine(insertResponse);
        }

        private void Init()
        {
            string localServiceAppKey = "debttrackerlocalkey";
            _serviceClient
                = new MobileServiceClient("http://localhost:50780/", localServiceAppKey);
            //  = new MobileServiceClient("https://debttracker.azure-mobile.net/","IfsLQMYiUHObNtCttJMvYenStchggQ16");
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

                _serviceUser = await _serviceClient.InvokeApiAsync<LoginRequest, MobileServiceUser>("CustomLogin", loginRequest);
                _serviceClient.CurrentUser = _serviceUser;
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

            var todoItemsTable = _serviceClient.GetTable<TodoItem>();
            string curTime = DateTime.Now.ToString("h:mm:ss tt");
            try
            {
                await todoItemsTable.InsertAsync(new TodoItem()
                {
                    Text = "from console app - " + curTime,
                    Complete = false
                });
            }
            catch (Exception e)
            {
                response = String.Format("could not insert: {0}", e.Message);
            }

            return response;
        }
    }
}
