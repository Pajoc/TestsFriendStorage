using FriendStorage.Model;
using FriendStorage.UI.DataProvider;
using FriendStorage.UI.ViewModel;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace FriendStorage.UITests.ViewModel
{
    public class NavigationViewModelTests
    {
        [Fact]
        public void ShoulLoadFriends()
        {
            var viewModel = new NavigationViewModel(new NavigationDataProviderMock());

            viewModel.Load();

            Assert.Equal(4, viewModel.Friends.Count());
            var friend = viewModel.Friends.SingleOrDefault(f => f.Id == 2);
            Assert.NotNull(friend);
            Assert.Equal("Leonor Costa", friend.DisplayMember);
            friend = viewModel.Friends.SingleOrDefault(f => f.Id == 4);
            Assert.NotNull(friend);
            Assert.Equal("Mário Costa", friend.DisplayMember);

        }


        [Fact]
        public void ShoulLoadFriendsOnlyOnce()
        {
            var viewModel = new NavigationViewModel(new NavigationDataProviderMock());

            viewModel.Load();
            viewModel.Load();
            Assert.Equal(4, viewModel.Friends.Count());
        }

        public class NavigationDataProviderMock : INavigationDataProvider
        {
            public IEnumerable<FriendLookupItem> GetAllFriends()
            {
                yield return new FriendLookupItem { Id = 1, DisplayMember = "Paulo Costa" };
                yield return new FriendLookupItem { Id = 2, DisplayMember = "Leonor Costa" };
                yield return new FriendLookupItem { Id = 3, DisplayMember = "Odete Costa" };
                yield return new FriendLookupItem { Id = 4, DisplayMember = "Mário Costa" };
            }
        }
    }
}
