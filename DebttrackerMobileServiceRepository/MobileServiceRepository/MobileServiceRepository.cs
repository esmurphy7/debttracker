using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;
using DebttrackerMobileServiceRepository.Models;
using LinqKit;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using DebttrackerMobileServiceRepository.Authentication;

namespace DebtrackerMobileServiceRepository.MobileServiceRepository
{
    public static class MobileServiceRepository
    {
        private const string localEndpoint = "http://localhost:50780/";
        private const string prodEndpoint = "https://debttracker.azure-mobile.net/";
                
        private const string localAppKey = "debttrackerlocalkey";
        private const string prodAppKey = "IfsLQMYiUHObNtCttJMvYenStchggQ16";

        private static MobileServiceClient _serviceClient = new MobileServiceClient
        (
            localEndpoint,
            localAppKey            
        );
        
        /// <summary>
        /// Get an item of type T specified by an id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public static async Task<T> GetItemAsync<T>(string id) where T : EntityModel
        {
            var table = _serviceClient.GetTable<T>();

            T item = await table.LookupAsync(id);

            return item;
        }

        /// <summary>
        /// Get an item of type T that has the same id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        /// <returns></returns>
        public static async Task<T> GetItemAsync<T>(T item) where T : EntityModel
        {
            var table = _serviceClient.GetTable<T>();

            T resultItem = await table.LookupAsync(item.id);

            return resultItem;
        }

        /// <summary>
        /// Get all items of type T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task<ICollection<T>> GetAllItemsAsync<T>() where T : EntityModel
        {
            ICollection<T> items = new List<T>();

            // get the reference to the database table
            var table = _serviceClient.GetTable<T>();

            items = await table.ToCollectionAsync<T>();

            return items;
        }

        /// <summary>
        /// Get all items of type T that satisfy the set of expressions. At least one expression must be specified
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expressions"></param>
        /// <returns></returns>
        public static async Task<ICollection<T>> GetAllSatisfyingItemsAsync<T>(params Expression<Func<T, bool>>[] expressions) where T : EntityModel
        {
            // if no expressions specified, throw exception
            if (expressions.Length == 0 || expressions == null)
            {
                throw new InvalidOperationException("At least one expression must be specified");
            }

            ICollection<T> items = new List<T>();

            // get the reference to the database table
            var table = _serviceClient.GetTable<T>();                       

            // query under the first expression
            IMobileServiceTableQuery<T> queryResults = table.Where(expressions[0]);

            // query under the remaining expressions
            for (int i = 1; i<expressions.Length; i++)
            {
                queryResults = queryResults.Where(expressions[i]);
            }

            // convert results to collection
            if(queryResults != null)
            {
                items = await queryResults.ToCollectionAsync<T>();
            }
            
            return items;
        }

        /// <summary>
        /// Insert a single item of type T to the database
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        /// <returns></returns>
        public static async Task InsertItemAsync<T>(T item) where T : EntityModel
        {
            var table = _serviceClient.GetTable<T>();

            await table.InsertAsync(item);
        }

        /// <summary>
        /// Insert a set of items of type T to the database
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="itemSet"></param>
        /// <returns></returns>
        public static async Task InsertItemSetAsync<T>(ICollection<T> itemSet) where T : EntityModel
        {
            var table = _serviceClient.GetTable<T>();

            foreach(T item in itemSet)
            {
                await table.InsertAsync(item);
            }
        }

        /// <summary>
        /// Update a single item of type T in the database
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        /// <returns></returns>
        public static async Task UpdateItemAsync<T>(T item) where T : EntityModel
        {
            var table = _serviceClient.GetTable<T>();

            await table.UpdateAsync(item);
        }

        /// <summary>
        /// Update a set of items of type T in the database
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="itemSet"></param>
        /// <returns></returns>
        public static async Task UpdateItemSetAsync<T>(ICollection<T> itemSet) where T : EntityModel
        {
            var table = _serviceClient.GetTable<T>();

            foreach(T item in itemSet)
            {
                await table.UpdateAsync(item);
            }
        }

        /// <summary>
        /// Delete an item of type T from the database
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        /// <returns></returns>
        public static async Task DeleteItemAsync<T>(T item) where T : EntityModel
        {
            var table = _serviceClient.GetTable<T>();

            await table.DeleteAsync(item);
        }

        /// <summary>
        /// Delete a set of items of type T from the database
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="itemSet"></param>
        /// <returns></returns>
        public static async Task DeleteItemSetAsync<T>(ICollection<T> itemSet) where T : EntityModel
        {
            var table = _serviceClient.GetTable<T>();

            foreach(T item in itemSet)
            {
                await table.DeleteAsync(item);
            }
        }

        /// <summary>
        /// Login via the customlogin api endpoint by passing a login request
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static async Task<MobileServiceUser> LoginAsync(LoginRequest request)
        {
            var serviceUser = await _serviceClient.InvokeApiAsync<LoginRequest, MobileServiceUser>("CustomLogin", request);
            _serviceClient.CurrentUser = serviceUser;
            return serviceUser;
        }

        /// <summary>
        /// Overload: Login via the customlogin api endpoint by passing explicit username and password
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static async Task LoginAsync(string username, string password)
        {
            await LoginAsync(new LoginRequest() { Username = username, Password = password });
        }

        /// <summary>
        /// Register via the custom registration api endpoint by passing a registration request
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static async Task<string> RegisterAsync(RegistrationRequest request)
        {
            string responseMessage = String.Empty;

            var response = await _serviceClient.InvokeApiAsync<RegistrationRequest, HttpResponseMessage>("CustomRegistration", request);

            var statusCode = response.StatusCode;

            switch (statusCode)
            {
                case HttpStatusCode.Created:
                    break;
                default:
                    responseMessage = response.Content.ToString();
                    break;
            }

            return responseMessage;
        }

        /// <summary>
        /// Overload: Register via the custom registration api endpoint by passing explicit username and password
        /// </summary>
        /// <param name="email"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static async Task<string> RegisterAsync(string email, string username, string password)
        {
            string responseMessage = String.Empty;

            var request = new RegistrationRequest()
            {
                Email = email,
                Username = username,
                Password = password
            };

            responseMessage = await RegisterAsync(request);

            return responseMessage;
        }
    }
}