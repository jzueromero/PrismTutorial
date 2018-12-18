﻿using Prism;
using Prism.Ioc;
using PrismTuto.Services;
using PrismTuto.ViewModels;
using PrismTuto.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace PrismTuto
{
    public partial class App
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync(new System.Uri("/CustomMasterDetailPage/NavigationPage/Formulario", System.UriKind.Absolute));
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<HomePage, HomePageViewModel>();
            containerRegistry.RegisterForNavigation<RoomPage, RoomPageViewModel>();

            
            containerRegistry.RegisterForNavigation<Formulario, FormularioViewModel>();
            containerRegistry.RegisterForNavigation<RecibeFormulario, RecibeFormularioViewModel>();
            containerRegistry.RegisterForNavigation<CustomMasterDetailPage, CustomMasterDetailPageViewModel>();
            
            containerRegistry.Register<ITodoItemService, ToDoItemService>();
            
        }
    }
}
