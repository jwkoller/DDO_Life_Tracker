using DDO_Life_Tracker.Database.Tables;
using DDO_Life_Tracker.Models;
using Microsoft.Extensions.Logging;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDO_Life_Tracker.Database
{
    //TODO sure would be nice genericise all the duplicate code in the queries
    //TODO explore other options than SQLite as it has no FK implementation.
    //Cross platform compatibility is an issue
    public class IncarnationDatabase
    {
        public SQLiteAsyncConnection Database;
        private ILogger<IncarnationDatabase> _logger;

        public IncarnationDatabase(ILogger<IncarnationDatabase> logger)
        {
            _logger = logger;
        }

        public async Task Init()
        {
            if (Database is not null) 
            { 
                return;
            }

            Database = new SQLiteAsyncConnection(DBConstants.DatabasePath, DBConstants.Flags);
            await Database.CreateTableAsync<CharactersDB>();
            await Database.CreateTableAsync<IncarnationsDB>();
            await Database.CreateTableAsync<IncarnationClassesDB>();

            _logger.LogInformation("DB intialized");
        }

        #region Characters Table Queries
        public async Task<List<CharactersDB>> GetCharactersAsync()
        {
            await Init();
            return await Database.Table<CharactersDB>().ToListAsync();
        }

        public async Task<CharactersDB> GetCharacterByIdAsync(int id)
        {
            await Init();
            return await Database.Table<CharactersDB>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<int> SaveCharacterAsync(CharactersDB character)
        {
            await Init();
            if(character.Id != 0)
            {
                return await Database.UpdateAsync(character);
            } else
            {
                return await Database.InsertAsync(character);
            }
        }

        public async Task<int> DeleteCharacterAsync(CharactersDB character)
        {
            await Init();
            return await Database.DeleteAsync(character);
        }
        #endregion

        #region Incarnations Table Queries
        public async Task<List<IncarnationsDB>> GetIncarnationsAsync()
        {
            await Init();
            return await Database.Table<IncarnationsDB>().ToListAsync();
        }

        public async Task<List<IncarnationsDB>> GetIncarnationsByCharacterIdAsync(int id)
        {
            await Init();
            return await Database.Table<IncarnationsDB>().Where(x => x.CharacterId == id).ToListAsync();
        }

        public async Task<int> SaveIncarnationAsync(IncarnationsDB incarnation)
        {
            await Init();
            if (incarnation.Id != 0)
            {
                return await Database.UpdateAsync(incarnation);
            }
            else
            {
                return await Database.InsertAsync(incarnation);
            }
        }

        public async Task<int> DeleteIncarnationAsync(IncarnationsDB incarnation)
        {
            await Init();
            return await Database.DeleteAsync(incarnation);
        }
        #endregion

        #region IncarnationsClasses Table Queries
        public async Task<List<IncarnationClassesDB>> GetClassesByCharacterIdAsync(int characterId)
        {
            await Init();
            return await Database.Table<IncarnationClassesDB>().Where(x => x.CharacterId == characterId).ToListAsync();
        }

        public async Task<List<IncarnationClassesDB>> GetClassesByIncarnationIdAsync(int incarnationId)
        {
            await Init();
            return await Database.Table<IncarnationClassesDB>().Where(x => x.IncarnationId == incarnationId).ToListAsync();
        }
        public async Task<int> SaveIncarnationClassAsync(IncarnationClassesDB incarnationClass)
        {
            await Init();
            if (incarnationClass.Id != 0)
            {
                return await Database.UpdateAsync(incarnationClass);
            }
            else
            {
                return await Database.InsertAsync(incarnationClass);
            }
        }

        public async Task<int> DeleteIncarnationClassAsync(IncarnationClassesDB incarnationClass)
        {
            await Init();
            return await Database.DeleteAsync(incarnationClass);
        }
        #endregion
    }

    internal static class DBConstants
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
