using System;
using System.Collections.Generic;
using System.Text;
using SQLite;


namespace PrismTuto.Model
{
    public class TodoItem
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }
        [NotNull]
        public string Title { get; set; }
    }
}
