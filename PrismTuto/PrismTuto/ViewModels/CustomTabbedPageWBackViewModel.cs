using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using PrismTuto.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using Unity;
using Unity.Lifetime;

namespace PrismTuto.ViewModels
{
	public class CustomTabbedPageWBackViewModel : BindableBase, IMyTabbedPageSelectedTab
	{
        private readonly IUnityContainer _UnitiContainer;
        private int _selectedTab;
        private string _Title;
        public string Title
        {
            get { return _Title; }
            set { SetProperty(ref _Title, value); }
        }

        public CustomTabbedPageWBackViewModel(INavigationService navigationService, IUnityContainer unityContainer)
        {
            Title = $"My Tabbed Page - Tab [{SelectedTab + 1}]";
            this._UnitiContainer = unityContainer;

            _UnitiContainer.RegisterInstance<IMyTabbedPageSelectedTab>(this, new ContainerControlledLifetimeManager());
        }

        
        public int SelectedTab
        {
            get { return _selectedTab; }
            set { SetProperty(ref _selectedTab, value);
                Title = $"My Tabbed Page - Tab [{SelectedTab + 1}]";
            }

        }

        public void SetSelectedTab(int tabIndex)
        {
            SelectedTab = tabIndex;
        }
    }
}
