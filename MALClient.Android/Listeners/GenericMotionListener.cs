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

namespace MALClient.Android.Listeners
{
    public class GenericMotionListener : Java.Lang.Object, View.IOnGenericMotionListener
    {
        public bool OnGenericMotion(View v, MotionEvent e)
        {
            return false;
        }
    }
}