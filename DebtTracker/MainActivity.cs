using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Microsoft.WindowsAzure.MobileServices;

namespace DebtTracker
{
    [Activity(Label = "DebtTracker", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    { 
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Set UI eventhandlers
            var signUpBtn = FindViewById<Button>(Resource.Id.signupbutton);
            signUpBtn.Click += OnSignUpButtonClick;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="evtArgs"></param>
        private void OnSignUpButtonClick(object sender, EventArgs evtArgs)
        {
            var alertBuilder = new AlertDialog.Builder(this);
            alertBuilder.SetMessage("Sign Up clicked")
                        .SetPositiveButton("Ok", (sendr, args) =>
                        {
                            // ok'd
                        })
                        .SetTitle("Sign Up Test Dialog")
                        .Show();
        }
    }
}

