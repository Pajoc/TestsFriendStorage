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
            Assert.Equal("Leonor", friend.FirstName);
            friend = viewModel.Friends.SingleOrDefault(f => f.Id == 4);
            Assert.NotNull(friend);
            Assert.Equal("Mário", friend.FirstName);

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
            public IEnumerable<Friend> GetAllFriends()
            {
                yield return new Friend { Id = 1, FirstName = "Paulo" };
                yield return new Friend { Id = 2, FirstName = "Leonor" };
                yield return new Friend { Id = 3, FirstName = "Odete" };
                yield return new Friend { Id = 4, FirstName = "Mário" };
            }
        }
    }
}
