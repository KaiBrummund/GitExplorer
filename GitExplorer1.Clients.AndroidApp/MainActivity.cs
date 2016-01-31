using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using GitExplorer1.Infrastructure;
using GitExplorer1.Domain.Services;
using GitExplorer1.Domain.Api;
using GitExplorer1.Clients.AndroidApp.Adapters;
using GitExplorer1.Clients.AndroidApp.Services;

namespace GitExplorer1.Clients.AndroidApp
{
    [Activity(Label = "GitExplorer", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private GitHubEventListViewModel _viewModel;
        private GitHubEventListAdapter _adapter;

        private ProgressBar _progressBar;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            var client = new GitHubOrganisationEventClient();

            // Alternative: Globale Events statt Organisation events anzeigen
            // var client = new GitHubGlobalEventClient();

            var service = new GitHubEventService(client);
            var browserTask = new AndroidBrowserTask(this);

            _viewModel = new GitHubEventListViewModel(service, browserTask);
            _adapter = new GitHubEventListAdapter(this, _viewModel);

            Button button = FindViewById<Button>(Resource.Id.main_button_refresh);
            Button buttonWebsite = FindViewById<Button>(Resource.Id.main_button_website);
            ListView listView = FindViewById<ListView>(Resource.Id.main_listview);

            _progressBar = FindViewById<ProgressBar>(Resource.Id.main_progressBar);

            button.Click += Button_Click;
            buttonWebsite.Click += (o, e) => { _viewModel.GoToGithubDotCom(); };
            listView.Adapter = _adapter;

            _viewModel.PropertyChanged += viewModel_PropertyChanged;

            UpdateViews(String.Empty);
        }

        private void viewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            UpdateViews(e.PropertyName);
        }

        private void UpdateViews(string propertyName)
        {
            if(propertyName == nameof(GitHubEventListViewModel.IsDownloading) || String.IsNullOrEmpty(propertyName))
            {
                _progressBar.Visibility = _viewModel.IsDownloading ? ViewStates.Visible : ViewStates.Gone;
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            _viewModel.UpdateEvents();
        }
    }
}

