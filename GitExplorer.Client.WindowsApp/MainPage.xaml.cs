using GitExplorer.Client.WindowsApp.Services;
using GitExplorer1.Domain.Api;
using GitExplorer1.Domain.Services;
using GitExplorer1.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace GitExplorer.Client.WindowsApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            var client = new GitHubOrganisationEventClient();
            var service = new GitHubEventService(client);
            var task = new WindowsBrowserTask();

            ViewModel = new GitHubEventListViewModel(service, task);
        }

        public GitHubEventListViewModel ViewModel { get; private set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.UpdateEvents();
        }
    }
}
