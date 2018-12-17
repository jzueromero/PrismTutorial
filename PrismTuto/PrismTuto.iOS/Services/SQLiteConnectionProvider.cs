using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Foundation;
using PrismTuto.Services;
using SQLite;
using UIKit;

namespace PrismTuto.iOS.Services
{
    public class SQLiteConnectionProvider : ISQLiteConnectionProvider
    {
        private SQLiteAsyncConnection Connection { get; set; }

        public SQLiteAsyncConnection GetConnection()
        {
            if (this.Connection != null) { return this.Connection; }

            var path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            path = Path.Combine(path, "..", "Library", "database.db3");
            return this.Connection = new SQLiteAsyncConnection(path);
        }
    }
}