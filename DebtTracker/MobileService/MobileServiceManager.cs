using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;

namespace DebtTracker.MobileService
{
    public static class MobileServiceManager
    {
        private const string localEndpoint = "http://localhost:50780/";
        private const string prodEndpoint = "https://debttracker.azure-mobile.net/";
                
        private const string localAppKey = "debttrackerlocalkey";
        private const string prodAppKey = "IfsLQMYiUHObNtCttJMvYenStchggQ16";

        public static MobileServiceClient serviceClient = new MobileServiceClient
        (
            localEndpoint,
            localAppKey            
        );

        public static async Task Authenticate(MobileServiceUser user, Activity context)
        {
            user = await serviceClient.LoginAsync(context, MobileServiceAuthenticationProvider.Facebook);
        }

        //TODO: write CRUD APi to communicate with debttracker service
    }
}