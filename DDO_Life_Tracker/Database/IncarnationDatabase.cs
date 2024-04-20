using DDO_Life_Tracker.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDO_Life_Tracker.Database
{
    public class IncarnationDatabase
    {
        private SQLiteAsyncConnection? Database;

        public IncarnationDatabase()
        {         
        }

        public async Task Init()
        {
            if (Database is not null) 
            { 
                return;
            }

            Database = new SQLiteAsyncConnection(DBConstants.DatabasePath, DBConstants.Flags);
            var result = await Database.CreateTableAsync<Incarnation>();
        }
    }

    public static class DBConstants
    {
        public const string DATABASE_FILENAME = "IncarnationDatabase.db3";

        public const SQLiteOpenFlags Flags =
            SQLiteOpenFlags.ReadWrite |
            SQLiteOpenFlags.Create |
            SQLiteOpenFlags.SharedCache;

        public static string DatabasePath { 
            get 
            {
                return Path.Combine(FileSystem.AppDataDirectory, DATABASE_FILENAME);
            }
        }
    }
}
