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
using GitExplorer1.Domain.Models;
using GitExplorer1.Infrastructure;

namespace GitExplorer1.Clients.AndroidApp.Adapters
{
    public class GitHubEventListAdapter : BaseAdapter<GitHubEvent>
    {
        private readonly Activity _context;
        private readonly GitHubEventListViewModel _viewModel;

        public GitHubEventListAdapter(Activity context, GitHubEventListViewModel viewModel)
        {
            _context = context;
            _viewModel = viewModel;

            _viewModel.PropertyChanged += viewModel_PropertyChanged;
        }

        public override GitHubEvent this[int position]
        {
            get { return _viewModel.Events[position]; }
        }

        public override int Count
        {
            get { return _viewModel.Events.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            if(convertView == null)
            {
                convertView = _context.LayoutInflater.Inflate(Resource.Layout.main_githubeventlist_item, null);
            }

            var textView = convertView.FindViewById<TextView>(Resource.Id.main_githubeventlist_text);
            var listView = convertView.FindViewById<ListView>(Resource.Id.main_gihtubeventlist_commitlist);

            var item = _viewModel.Events[position];

            textView.Text = $"{item.Actor.Name} pushed to repo {item.Repository.FullName}.";
            listView.Adapter = new ArrayAdapter<string>(
                _context, 
                Android.Resource.Layout.SimpleListItem1,
                item.Commits.Select(c => c.Comment).ToArray()
            );

            return convertView;
        }

        private void viewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(GitHubEventListViewModel.Events))
            {
                NotifyDataSetChanged();
            }
        }

    }
}