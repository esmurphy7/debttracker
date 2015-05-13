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

namespace DebtTracker.MobileService
{
    public static class DebttrackerMobileServiceManager
    {
        public static MobileServiceClient serviceClient = new MobileServiceClient
        (
            "https://debttracker.azure-mobile.net/",
            "IfsLQMYiUHObNtCttJMvYenStchggQ16"
        );

        //TODO: write CRUD APi to communicate with debttracker service
    }
}