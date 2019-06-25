using FriendStorage.Model;
using FriendStorage.UI.DataProvider;
using FriendStorage.UI.ViewModel;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace FriendStorage.UITests.ViewModel
{
    public class NavigationViewModelTests
    {
        private NavigationViewModel _viewModel;

        public NavigationViewModelTests()
        {
            var navigationDataProvider = new Mock<INavigationDataProvider>();
            navigationDataProvider.Setup(dp => dp.GetAllFriends())
                .Returns(new List<FriendLookupItem>
                {
                    new FriendLookupItem { Id = 1, DisplayMember = "Paulo Costa" },
                    new FriendLookupItem { Id = 2, DisplayMember = "Leonor Costa" },
                    new FriendLookupItem { Id = 3, DisplayMember = "Odete Costa" },
                    new FriendLookupItem { Id = 4, DisplayMember = "Mário Costa" }
        });

            _viewModel = new NavigationViewModel(navigationDataProvider.Object);
        }

        [Fact]
        public void ShoulLoadFriends()
        {
            _viewModel.Load();

            Assert.Equal(4, _viewModel.Friends.Count());
            var friend = _viewModel.Friends.SingleOrDefault(f => f.Id == 2);
            Assert.NotNull(friend);
            Assert.Equal("Leonor Costa", friend.DisplayMember);
            friend = _viewModel.Friends.SingleOrDefault(f => f.Id == 4);
            Assert.NotNull(friend);
            Assert.Equal("Mário Costa", friend.DisplayMember);

        }


        [Fact]
        public void ShoulLoadFriendsOnlyOnce()
        {
            _viewModel.Load();
            _viewModel.Load();
            Assert.Equal(4, _viewModel.Friends.Count());
        }

        //public class NavigationDataProviderMock : INavigationDataProvider
        //{
        //    public IEnumerable<FriendLookupItem> GetAllFriends()
        //    {
        //        yield return new FriendLookupItem { Id = 1, DisplayMember = "Paulo Costa" };
        //        yield return new FriendLookupItem { Id = 2, DisplayMember = "Leonor Costa" };
        //        yield return new FriendLookupItem { Id = 3, DisplayMember = "Odete Costa" };
        //        yield return new FriendLookupItem { Id = 4, DisplayMember = "Mário Costa" };
        //    }
        //}
    }
}
