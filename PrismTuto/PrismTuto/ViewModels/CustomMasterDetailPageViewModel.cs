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
            await _navigationService.NavigateAsync(new Uri(page, UriKind.Relative));
        }
    }
}
