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
            await Database.CreateTableAsync<Characters>();
            await Database.CreateTableAsync<Incarnations>();
            await Database.CreateTableAsync<IncarnationClasses>();

            _logger.LogInformation("DB intialized");
        }

        #region Characters Table Queries
        public async Task<List<Characters>> GetCharactersAsync()
        {
            await Init();
            return await Database.Table<Characters>().ToListAsync();
        }

        public async Task<Characters> GetCharacterByIdAsync(int id)
        {
            await Init();
            return await Database.Table<Characters>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<int> SaveCharacterAsync(Characters character)
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

        public async Task<int> DeleteCharacterAsync(Characters character)
        {
            await Init();
            return await Database.DeleteAsync(character);
        }
        #endregion

        #region Incarnations Table Queries
        public async Task<List<Incarnations>> GetIncarnationsAsync()
        {
            await Init();
            return await Database.Table<Incarnations>().ToListAsync();
        }

        public async Task<Incarnations> GetIncarnationByCharacterIdAsync(int id)
        {
            await Init();
            return await Database.Table<Incarnations>().Where(x => x.CharacterId == id).FirstOrDefaultAsync();
        }

        public async Task<int> SaveIncarnationAsync(Incarnations incarnation)
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

        public async Task<int> DeleteIncarnationAsync(Incarnations incarnation)
        {
            await Init();
            return await Database.DeleteAsync(incarnation);
        }
        #endregion

        #region IncarnationsClasses Table Queries
        public async Task<List<IncarnationClasses>> GetClassesByCharacterIdAsync(int characterId)
        {
            await Init();
            return await Database.Table<IncarnationClasses>().Where(x => x.CharacterId == characterId).ToListAsync();
        }

        public async Task<List<IncarnationClasses>> GetClassesByIncarnationIdAsync(int incarnationId)
        {
            await Init();
            return await Database.Table<IncarnationClasses>().Where(x => x.IncarnationId == incarnationId).ToListAsync();
        }
        public async Task<int> SaveIncarnationClassAsync(IncarnationClasses incarnationClass)
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

        public async Task<int> DeleteIncarnationClassAsync(IncarnationClasses incarnationClass)
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
