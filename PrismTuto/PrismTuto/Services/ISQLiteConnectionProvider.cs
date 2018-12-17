using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace PrismTuto.Services
{
    public interface ISQLiteConnectionProvider
    {
        SQLiteAsyncConnection GetConnection();

    }
}
