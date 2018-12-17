using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using PrismTuto.Model;
using PrismTuto.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrismTuto.ViewModels
{
    public class MainPageViewModel : ViewModelBase,  INavigationAware
    {
       private ITodoItemService TodoItemService { get; }

        private IEnumerable<TodoItem> todoItems;

        public IEnumerable<TodoItem> TodoItems
        {
            get { return this.todoItems; }
            set { this.SetProperty(ref this.todoItems, value); }
        }

        private string inputText;

        public string InputText
        {
            get { return this.inputText; }
            set { this.SetProperty(ref this.inputText, value); }
        }

        public DelegateCommand AddCommand { get; }

        public DelegateCommand<TodoItem> DeleteCommand { get; }
        public  DelegateCommand<TodoItem> UpdateCommand { get;  }

        public MainPageViewModel(ITodoItemService todoItemService, INavigationService navigationService)
            :base(navigationService)
        {
            this.TodoItemService = todoItemService;

            this.AddCommand = new DelegateCommand(this.AddTodoItem, () => !string.IsNullOrEmpty(this.InputText))
                .ObservesProperty(() => this.InputText);

            this.DeleteCommand = new DelegateCommand<TodoItem>(this.DeleteTodoItem);
            this.UpdateCommand = new DelegateCommand<TodoItem>(this.UpdateTodoItem);
        }

        private async void DeleteTodoItem(TodoItem todoItem)
        {
            await this.TodoItemService.DeleteAsync(todoItem);
            this.TodoItems = await this.TodoItemService.GetAllAsync();
        }

        private async void UpdateTodoItem(TodoItem todoItem)
        {
            
            
            await this.TodoItemService.UpdateAsync(todoItem);
            this.TodoItems = await this.TodoItemService.GetAllAsync();
        }

        private async void AddTodoItem()
        {
            await this.TodoItemService.InsertAsync(new TodoItem { Title = this.InputText });
            this.InputText = "";
            this.TodoItems = await this.TodoItemService.GetAllAsync();
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public async void OnNavigatedTo(NavigationParameters parameters)
        {
            this.TodoItems = await this.TodoItemService.GetAllAsync();
        }
        //private ITodoItemService ToDoItemService { get; }

        //private IEnumerable<TodoItem> todoItems;

        //public IEnumerable<TodoItem> TodoItems
        //{
        //    get { return this.todoItems; }
        //    set { this.SetProperty(ref this.todoItems, value); }
        //}

        //private string inputText;

        //public string InputText
        //{
        //    get { return this.inputText; }
        //    set { this.SetProperty(ref this.inputText, value); }
        //}

        //public DelegateCommand AddCommand { get; }

        //public DelegateCommand<TodoItem> DeleteCommand { get; }

        //public MainPageViewModel(ITodoItemService todoItemService, INavigationService navigationService)
        //    :base(  navigationService)
        //{
        //    this.ToDoItemService = todoItemService;

        //    this.AddCommand = new DelegateCommand(this.AddTodoItem, () => !string.IsNullOrEmpty(this.InputText))
        //        .ObservesProperty(() => this.InputText);

        //    this.DeleteCommand = new DelegateCommand<TodoItem>(this.DeleteTodoItem);
        //}

        //private void DeleteTodoItem(TodoItem todoItem)
        //{
        //    this.ToDoItemService.Delete(todoItem.Id);
        //    this.TodoItems = this.ToDoItemService.GetAll();
        //}

        //private void AddTodoItem()
        //{
        //    this.ToDoItemService.Insert(new TodoItem { Title = this.InputText });
        //    this.InputText = "";
        //    this.TodoItems = this.ToDoItemService.GetAll();
        //}

        //public void OnNavigatedFrom(NavigationParameters parameters)
        //{

        //}

        //public void OnNavigatedTo(NavigationParameters parameters)
        //{
        //    this.TodoItems = this.ToDoItemService.GetAll();
        //}




    }
}
