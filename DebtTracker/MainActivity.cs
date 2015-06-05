using System;
using Android.App;
using Android.OS;
using Android.Widget;
using Microsoft.WindowsAzure.MobileServices;

namespace DebtTracker
{
    [Activity(Label = "DebtTracker", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    { 
        private MobileServiceUser user;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Set UI eventhandlers
            var signUpBtn = FindViewById<Button>(Resource.Id.signupbutton);
            var signInBtn = FindViewById<Button>(Resource.Id.button1);

            signUpBtn.Click += OnSignUpButtonClick;            
            signInBtn.Click += OnSignInButtonClick;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="?"></param>
        private void OnSignUpButtonClick(object sender, EventArgs evtargs)
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="evtArgs"></param>
        private void OnSignInButtonClick(object sender, EventArgs evtArgs)
        {
            var alertBuilder = new AlertDialog.Builder(this);
            try
            {
                alertBuilder.SetMessage(String.Format("{0} logged in!",user.UserId))
                        .SetPositiveButton("Ok", (sendr, args) =>
                        {
                            // ok'd
                        })
                        .SetTitle("Authentication")
                        .Show();
            }
            catch (Exception ex)
            {
                alertBuilder.SetMessage(String.Format("login failed: {0}",ex.Message))
                        .SetPositiveButton("Ok", (sendr, args) =>
                        {
                            // ok'd
                        })
                        .SetTitle("Authentication")
                        .Show();
            }
        }
    }
}

