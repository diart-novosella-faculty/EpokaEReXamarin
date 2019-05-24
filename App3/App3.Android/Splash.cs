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

namespace App3.Droid
{
    [Activity(MainLauncher = true, Theme = "@style/Theme.Splash",
        NoHistory = true)]
    public class Splash : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            
            StartActivity(typeof(MainActivity));
            // Create your application here
        }
    }
}