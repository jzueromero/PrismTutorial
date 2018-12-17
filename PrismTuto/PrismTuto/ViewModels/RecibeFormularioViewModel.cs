using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using PrismTuto.Events;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrismTuto.ViewModels
{
	public class RecibeFormularioViewModel : BindableBase, INavigationAware
	{
        INavigationService _navigationService;
        IEventAggregator _ea;
        private string _Title;
        public string Title
        {
            get { return _Title; }
            set { SetProperty(ref _Title, value); }
        }

        public DelegateCommand NavigateCommand { get; set; }


        public RecibeFormularioViewModel(INavigationService navigationService, IEventAggregator  ea)
        {
            _navigationService = navigationService;
            _ea = ea;

            NavigateCommand = new DelegateCommand(Navigate);
        }

        private void Navigate()
        {
            _ea.GetEvent<GoBackEvent>().Publish("Hello from recibe formulario");
            _navigationService.GoBackAsync();
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            throw new NotImplementedException();
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            Title = parameters["id"].ToString()  + parameters["mensaje"].ToString();
        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {
          
        }
    }
}
