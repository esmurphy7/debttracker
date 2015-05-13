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

namespace DebtTracker
{
    [Activity(Label = "SignUp")]
    public class SignUpActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "SignUp" layout resource
            SetContentView(Resource.Layout.SignUp);
        }

        public void OnSubmitButtonClick()
        {
            var alertBuilder = new AlertDialog.Builder(this);
            alertBuilder.SetMessage("Account created!")
                .SetPositiveButton("Ok", (sender, args) =>
                                            {
                                                // ok'd
                                            }
                                    )
                .SetTitle("Account Created Dialog");
        }
    }
}