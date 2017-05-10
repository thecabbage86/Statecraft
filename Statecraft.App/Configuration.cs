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

namespace Statecraft.App
{
    public static class Configuration
    {
        #if DEBUG
            public const string BaseApiUrl = "http://192.168.1.159:64660/";
        #else
            public const string BaseApiUrl = "http://statecraftservices.azurewebsites.net/";
        #endif
    }
}