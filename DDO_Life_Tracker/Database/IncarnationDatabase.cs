using DDO_Life_Tracker.Database.Tables;
using Microsoft.Extensions.Logging;
using SQLite;
using SQLiteNetExtensionsAsync.Extensions;

namespace DDO_Life_Tracker.Database
{
    public class IncarnationDatabase
    {
        private SQLiteAsyncConnection _database;
        private ILogger<IncarnationDatabase> _logger;

        public IncarnationDatabase(ILogger<IncarnationDatabase> logger)
        {
            _logger = logger;
        }

        private async Task Init()
        {
            if (_database is not null) 
            { 
                return;
            }

            _database = new SQLiteAsyncConnection(DBConstants.DatabasePath, DBConstants.Flags);
#if DEBUG
            //await _database.DropTableAsync<CharactersTable>();
            //await _database.DropTableAsync<IncarnationsTable>();
            //await _database.DropTableAsync<ClassesTable>();
#endif
            await _database.CreateTableAsync<CharactersTable>();
            await _database.CreateTableAsync<IncarnationsTable>();
            await _database.CreateTableAsync<ClassesTable>();

            _logger.LogInformation("DB intialized");
        }

        #region Characters Table Queries
        public async Task<List<CharactersTable>> GetCharactersAsync()
        {
            await Init();
            return await _database.GetAllWithChildrenAsync<CharactersTable>(recursive: true);
        }

        public async Task<CharactersTable> GetCharacterByIdAsync(int id)
        {
            await Init();
            return await _database.GetWithChildrenAsync<CharactersTable>(id, recursive: true);
        }

        public async Task<int> SaveCharacterAsync(CharactersTable character)
        {
            await Init();
            if(character.Id != 0)
            {
                await _database.InsertOrReplaceWithChildrenAsync(character, recursive: true);
            } else
            {
                await _database.InsertWithChildrenAsync(character, recursive: true);
            }

            return character.Id;
        }

        public async Task DeleteCharacterAsync(CharactersTable character)
        {
            await Init();
            await _database.DeleteAsync(character, recursive: true);
        }
        #endregion

        #region Incarnations Table Queries
        public async Task<List<IncarnationsTable>> GetIncarnationsAsync()
        {
            await Init();
            return await _database.GetAllWithChildrenAsync<IncarnationsTable>(recursive: true);
        }

        public async Task<List<IncarnationsTable>> GetIncarnationByCharacterIdAsync(int id)
        {
            await Init();
            return await _database.GetAllWithChildrenAsync<IncarnationsTable>(x => x.CharacterId == id, recursive: true);
        }

        public async Task<int> SaveIncarnationAsync(IncarnationsTable incarnation)
        {
            await Init();
            if (incarnation.Id != 0)
            {
                await _database.InsertOrReplaceWithChildrenAsync(incarnation, recursive: true);
            }
            else
            {
                await _database.InsertWithChildrenAsync(incarnation, recursive: true);
            }
            
            return incarnation.Id;
        }

        public async Task<int> DeleteIncarnationAsync(IncarnationsTable incarnation)
        {
            await Init();
            return await _database.DeleteAsync(incarnation);
        }
        #endregion

        #region Classes Table Queries

        public async Task<List<ClassesTable>> GetClassesByIncarnationIdAsync(int incarnationId)
        {
            await Init();
            return await _database.GetAllWithChildrenAsync<ClassesTable>(x => x.IncarnationId == incarnationId);
        }
        public async Task<int> SaveClassAsync(ClassesTable classItem)
        {
            await Init();
            if (classItem.Id != 0)
            {
                await _database.UpdateWithChildrenAsync(classItem);
            }
            else
            {
                await _database.InsertWithChildrenAsync(classItem, recursive: true);
            }

            return classItem.Id;
        }

        public async Task<int> DeleteClassAsync(ClassesTable classItem)
        {
            await Init();
            return await _database.DeleteAsync(classItem);
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
