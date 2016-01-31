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
using GitExplorer1.Infrastructure.RequiredInterfaces;

namespace GitExplorer1.Clients.AndroidApp.Services
{
    public class AndroidBrowserTask : IOpenBrowserTask
    {
        private readonly Activity _context;

        public AndroidBrowserTask(Activity context)
        {
            _context = context;
        }

        public void OpenBrowser(string url)
        {
            var uri = Android.Net.Uri.Parse(url);
            var intent = new Intent(Intent.ActionView, uri);

            _context.StartActivity(intent);
        }
    }
}