using DDO_Life_Tracker.Database.Tables;
using Microsoft.Extensions.Logging;
using SQLite;
using SQLiteNetExtensionsAsync.Extensions;

namespace DDO_Life_Tracker.Database
{
    public class IncarnationDatabase
    {
        private SQLiteAsyncConnection Database;
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
#if DEBUG
            await Database.DropTableAsync<CharactersTable>();
            await Database.DropTableAsync<IncarnationsTable>();
            await Database.DropTableAsync<ClassesTable>();
#endif
            await Database.CreateTableAsync<CharactersTable>();
            await Database.CreateTableAsync<IncarnationsTable>();
            await Database.CreateTableAsync<ClassesTable>();

            _logger.LogInformation("DB intialized");
        }

        #region Characters Table Queries
        public async Task<List<CharactersTable>> GetCharactersAsync()
        {
            await Init();
            return await Database.GetAllWithChildrenAsync<CharactersTable>(recursive: true);
        }

        public async Task<CharactersTable> GetCharacterByIdAsync(int id)
        {
            await Init();
            return await Database.GetWithChildrenAsync<CharactersTable>(id, recursive: true);
        }

        public async Task<CharactersTable> GetCharacterByName(string name)
        {
            await Init();
            List<CharactersTable> allCharacters = await Database.GetAllWithChildrenAsync<CharactersTable>();

            return allCharacters.FirstOrDefault(x => x.Name == name) ?? throw new Exception($"Character name {name} not found");
        }

        public async Task SaveCharacterAsync(CharactersTable character)
        {
            await Init();
            if(character.Id != 0)
            {
                await Database.InsertOrReplaceWithChildrenAsync(character, recursive: true);
            } else
            {
                await Database.InsertWithChildrenAsync(character, recursive: true);
            }
        }

        public async Task DeleteCharacterAsync(CharactersTable character)
        {
            await Init();
            await Database.DeleteAsync(character, recursive: true);
        }
        #endregion

        #region Incarnations Table Queries
        public async Task<List<IncarnationsTable>> GetIncarnationsAsync()
        {
            await Init();
            return await Database.GetAllWithChildrenAsync<IncarnationsTable>(recursive: true);
        }

        public async Task<List<IncarnationsTable>> GetIncarnationByCharacterIdAsync(int id)
        {
            await Init();
            return await Database.GetAllWithChildrenAsync<IncarnationsTable>(x => x.CharacterId == id, recursive: true);
        }

        public async Task SaveIncarnationAsync(IncarnationsTable incarnation)
        {
            await Init();
            if (incarnation.Id != 0)
            {
                await Database.InsertOrReplaceWithChildrenAsync(incarnation, recursive: true);
            }
            else
            {
                await Database.InsertWithChildrenAsync(incarnation, recursive: true);
            }
        }

        public async Task<int> DeleteIncarnationAsync(IncarnationsTable incarnation)
        {
            await Init();
            return await Database.DeleteAsync(incarnation);
        }
        #endregion

        #region Classes Table Queries

        public async Task<List<ClassesTable>> GetClassesByIncarnationIdAsync(int incarnationId)
        {
            await Init();
            return await Database.GetAllWithChildrenAsync<ClassesTable>(x => x.IncarnationId == incarnationId);
        }
        public async Task SaveClassAsync(ClassesTable classItem)
        {
            await Init();
            if (classItem.Id != 0)
            {
                await Database.UpdateWithChildrenAsync(classItem);
            }
            else
            {
                await Database.InsertWithChildrenAsync(classItem, recursive: true);
            }
        }

        public async Task<int> DeleteClassAsync(ClassesTable classItem)
        {
            await Init();
            return await Database.DeleteAsync(classItem);
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
