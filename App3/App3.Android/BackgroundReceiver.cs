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
using Plugin.LocalNotifications;

namespace App3.Droid
{
    [BroadcastReceiver]
    public class BackgroundReceiver : BroadcastReceiver
    {

        public override void OnReceive(Context context, Intent intent)
        {

            var startTimeSpan = TimeSpan.Zero;
            var periodTimeSpan = TimeSpan.FromSeconds(5);
            PowerManager pm = (PowerManager)context.GetSystemService(Context.PowerService);
            PowerManager.WakeLock wakeLock = pm.NewWakeLock(WakeLockFlags.Partial, "BackgroundReceiver");
            wakeLock.Acquire();

            var timer = new System.Threading.Timer((e) =>
            {

                //  List<Kryesore> list = await ApiCall.getHome();

                CrossLocalNotifications.Current.Show("Test", "text brenda", 1, DateTime.Now.AddSeconds(5));

                CrossLocalNotifications.Current.Show("Test2", "text brenda", 2, DateTime.Now.AddSeconds(10));

                CrossLocalNotifications.Current.Show("Test3", "text brenda", 3, DateTime.Now.AddSeconds(15));

            }, null, startTimeSpan, periodTimeSpan);

            wakeLock.Release();

        }
    }
}