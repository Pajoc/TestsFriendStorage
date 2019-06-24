﻿using FriendStorage.DataAccess;
using FriendStorage.UI.DataProvider;
using System;

namespace FriendStorage.UI.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            NavigationViewModel = new NavigationViewModel(
                new NavigationDataProvider(
                    () => new FileDataService()));
        }

        public NavigationViewModel NavigationViewModel { get; private set; }

        public  void Load()
        {
            NavigationViewModel.Load();
        }
    }
}