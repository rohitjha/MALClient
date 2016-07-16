﻿using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using MalClient.Shared.Models;
using MalClient.Shared.NavArgs;
using MalClient.Shared.Utils.Enums;
using MalClient.Shared.ViewModels;
using MALClient.ViewModels;
using MALClient.ViewModels.Main;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace MALClient.Pages.Main
{
    /// <summary>
    ///     An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ProfilePage : Page
    {
        private static ProfilePageNavigationArgs _lastArgs;

        public ProfilePage()
        {
            InitializeComponent();
            Loaded += OnLoaded;
        }

        public ProfilePageViewModel ViewModel => DataContext as ProfilePageViewModel;

        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            (DataContext as ProfilePageViewModel).LoadProfileData(_lastArgs);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ViewModelLocator.NavMgr.RegisterBackNav(PageIndex.PageAnimeList, _lastArgs);
            _lastArgs = e.Parameter as ProfilePageNavigationArgs;

            base.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            (DataContext as ProfilePageViewModel).Cleanup();
            base.OnNavigatedFrom(e);
            ViewModelLocator.NavMgr.DeregisterBackNav();
        }

        private void ListViewBase_OnItemClick(object sender, ItemClickEventArgs e)
        {
            ViewModelLocator.NavMgr.RegisterBackNav(PageIndex.PageProfile,new ProfilePageNavigationArgs {TargetUser = ViewModel.CurrentUser},PageIndex.PageProfile);
            MobileViewModelLocator.Main.Navigate(PageIndex.PageProfile, new ProfilePageNavigationArgs { TargetUser = (e.ClickedItem as MalUser).Name });
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            ViewModelLocator.NavMgr.RegisterBackNav(PageIndex.PageProfile, new ProfilePageNavigationArgs { TargetUser = ViewModel.CurrentUser },PageIndex.PageProfile);
            MobileViewModelLocator.Main.Navigate(PageIndex.PageProfile, new ProfilePageNavigationArgs { TargetUser = (string)(sender as Button).Tag });
        }

    }
}