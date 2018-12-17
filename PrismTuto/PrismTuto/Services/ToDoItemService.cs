using PrismTuto.Model;
using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Threading.Tasks;

namespace PrismTuto.Services
{
    public interface ITodoItemService
    {
        //IEnumerable<TodoItem> GetAll();
        //TodoItem GetById(int id);
        //void Update(TodoItem todoItem);
        //void Insert(TodoItem todoItem);
        //void Delete(int id);

        Task<IEnumerable<TodoItem>> GetAllAsync();
        Task<TodoItem> GetByIdAsync(int id);
        Task UpdateAsync(TodoItem todoItem);
        Task InsertAsync(TodoItem todoItem);
        Task DeleteAsync(TodoItem todoItem);
    }

    public class ToDoItemService : ITodoItemService
    {
        private ISQLiteConnectionProvider ConnectionProvider { get; }
        private SQLiteAsyncConnection Connection { get; }

        public ToDoItemService(ISQLiteConnectionProvider connectionProvider)
        {
            this.ConnectionProvider = connectionProvider;
            this.Connection = this.ConnectionProvider.GetConnection();
        }

        public async Task DeleteAsync(TodoItem todoItem)
        {
            await this.Connection.CreateTableAsync<TodoItem>();
            await this.Connection.DeleteAsync(todoItem);
        }

        public async Task<IEnumerable<TodoItem>> GetAllAsync()
        {
            await this.Connection.CreateTableAsync<TodoItem>();
            return await this.Connection.Table<TodoItem>().ToListAsync();
        }

        public async Task<TodoItem> GetByIdAsync(int id)
        {
            await this.Connection.CreateTableAsync<TodoItem>();
            return await this.Connection.Table<TodoItem>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task InsertAsync(TodoItem todoItem)
        {
            await this.Connection.CreateTableAsync<TodoItem>();
            await this.Connection.InsertAsync(todoItem);
        }

        public async Task UpdateAsync(TodoItem todoItem)
        {
            await this.Connection.CreateTableAsync<TodoItem>();
            await this.Connection.UpdateAsync(todoItem);
        }
    }
    #region Primer Implementacion sin async
    //public class ToDoItemService : ITodoItemService
    //{
    //    private ISQLiteConnectionProvider ConnectionProvider { get; }
    //    private SQLiteAsyncConnection Connection { get; }

    //    public ToDoItemService(ISQLiteConnectionProvider connectionProvider)
    //    {
    //        this.ConnectionProvider = connectionProvider;
    //        this.Connection = this.ConnectionProvider.GetConnection();
    //        this.Connection.CreateTableAsync<TodoItem>();
    //    }

    //    public void Delete(int id)
    //    {
    //        this.Connection.DeleteAsync<TodoItem>(id);
    //    }

    //    public IEnumerable<TodoItem> GetAll()
    //    {
    //        return this.Connection.table<TodoItem>().ToList();
    //    }

    //    public TodoItem GetById(int id)
    //    {
    //        return this.Connection.Table<TodoItem>().FirstOrDefault(x => x.Id == id);
    //    }

    //    public void Insert(TodoItem todoItem)
    //    {
    //        this.Connection.Insert(todoItem);
    //    }

    //    public void Update(TodoItem todoItem)
    //    {
    //        this.Connection.Update(todoItem);
    //    }
    //}
    #endregion
}

