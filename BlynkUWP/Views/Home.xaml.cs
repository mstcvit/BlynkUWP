﻿using BlynkLibrary.DataManager;
using BlynkLibrary.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Microsoft.Toolkit.Uwp;
using System.Collections.ObjectModel;
using Windows.UI.Popups;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace BlynkUWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Home : Page
    {
        public Project project { get; set; }
        public List<Device> device { get; set; }
        public Device selected { get; set; }
        public Home()
        {
            this.InitializeComponent();
            //SystemNavigationManager.GetForCurrentView().BackRequested += OnBackRequested;
            project = DataManager.proj;
            if (project != null)
            {
                device = project.Devices;
            }
            
            //Windows.UI.Core.SystemNavigationManager.GetForCurrentView().BackRequested += App_BackRequested;
        }

        private void Logout_Button_Click(object sender, RoutedEventArgs e)
        {
            //await Windows.Storage.ApplicationData.Current.ClearAsync();
            var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            localSettings.Values.Remove("authToken");
            this.Frame.Navigate(typeof(MainPage));
        }

        private void ProjectList_ItemClick(object sender, ItemClickEventArgs e)
        {
            selected = (Device)e.ClickedItem;
            DataManager.navDevice = selected;
            this.Frame.Navigate(typeof(myProject));
        }


        //private void OnBackRequested(object sender, BackRequestedEventArgs e)
        //{

        //}

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            if (rootFrame.CanGoBack)
            {
                this.Frame.BackStack.Clear();
            }
        }

        private void ProjectList_Loaded(object sender, RoutedEventArgs e)
        {
            var listView = (ListView)sender;
            listView.ItemsSource = device;

        }
    }
}
