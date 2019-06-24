﻿using FriendStorage.DataAccess;
using FriendStorage.Model;
using FriendStorage.UI.DataProvider;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FriendStorage.UI.ViewModel
{
    public class NavigationViewModel : ViewModelBase
    {
        private INavigationDataProvider _dataProvider;
        public NavigationViewModel(INavigationDataProvider dataProvider)
        {
            Friends = new ObservableCollection<Friend>();
            _dataProvider = dataProvider;
        }
        public void Load()
        {
            Friends.Clear();
            foreach (var item in _dataProvider.GetAllFriends())
            {
                Friends.Add(item);
            }
        }

        public ObservableCollection<Friend> Friends { get; private set; }

        
    }
}
