using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using PrismTuto.Events;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace PrismTuto.ViewModels
{
	public class FormularioViewModel : BindableBase
	{
        INavigationService _navigationService;
        IEventAggregator _ea;
        IPageDialogService _pds;

        private string _Titulo;
        public string Titulo
        {
            get { return _Titulo; }
            set { SetProperty(ref _Titulo, value); }
        }

        private bool _CanNavigateProp;
        public bool CanNavigateProp
        {
            get { return _CanNavigateProp; }
            set { SetProperty(ref _CanNavigateProp, value); }
        }

        public DelegateCommand NavigateCommad { get; set; }

        public FormularioViewModel(INavigationService navigationService, IEventAggregator ea, IPageDialogService pds)
        {
            _navigationService = navigationService;
            _ea = ea;
            _pds = pds;
            _ea.GetEvent<GoBackEvent>().Subscribe(WentBack);
            NavigateCommad = new DelegateCommand(Navigate).ObservesCanExecute(() => CanNavigateProp);
        }

        private async  void Navigate()
        {
            //1forma var result = await  _pds.DisplayAlertAsync("Alert con Prism", "Mensaje del alert", "Aceptar", "Rechazar");
            //2forma var result = await _pds.DisplayActionSheetAsync("Alert sheet con Prism", "cancel", "destroy", "other");

            IActionSheetButton Option1Action = ActionSheetButton.CreateButton("Option 1", new DelegateCommand(() => { Debug.WriteLine("Option 1"); }));
            IActionSheetButton Option2Action = ActionSheetButton.CreateButton("Option 2", new DelegateCommand(() => { Debug.WriteLine("Option 2"); }));
            IActionSheetButton cancelAction = ActionSheetButton.CreateCancelButton("cancel ", new DelegateCommand(() => { Debug.WriteLine("cancel"); }));
            IActionSheetButton destroyAction = ActionSheetButton.CreateDestroyButton("destroy", new DelegateCommand(() => { Debug.WriteLine("Destroy"); }));

            await _pds.DisplayActionSheetAsync("My action Sheet", Option1Action, Option2Action, cancelAction, destroyAction);
        }

        private void WentBack(string obj)
        {
            Titulo = obj;
        }

        //private void Navigate()
        //{
        //    var p = new NavigationParameters();
        //    p.Add("id", 1);
        //    p.Add("mensaje", "chocolate mas rico");
        //    _navigationService.NavigateAsync(new Uri("RecibeFormulario", UriKind.Relative) , p); //con parametros
        //    //sin parametros  _navigationService.NavigateAsync("RecibeFormulario");
        //}


    }
}
