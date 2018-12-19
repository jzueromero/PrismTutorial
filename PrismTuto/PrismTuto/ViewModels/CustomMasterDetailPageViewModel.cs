using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrismTuto.ViewModels
{
	public class CustomMasterDetailPageViewModel : BindableBase
	{
        INavigationService _navigationService;
        public DelegateCommand<string> OnNavigationCommand { get; set; }
        public CustomMasterDetailPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            OnNavigationCommand = new DelegateCommand<string>(NavigateAsync);
        }

        private async void NavigateAsync(string page)
        {
            if(page == "Navigation/CustomTabbedPage" )
            {
                await _navigationService.NavigateAsync (new System.Uri("/NavigationPage/CustomTabbedPage?selectedTab=Tabbeb1Page", System.UriKind.Absolute));
            }
            if (page == "Navigation/CustomTabbedPageWBack")
            {
                await _navigationService.NavigateAsync(new System.Uri("/NavigationPage/CustomTabbedPageWBack?selectedTab=Tabbeb1Page", System.UriKind.Absolute));
            }
            await _navigationService.NavigateAsync(new Uri(page, UriKind.Relative));
        }
    }
}
