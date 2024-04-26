using DDO_Life_Tracker.Database;
using DDO_Life_Tracker.Database.Tables;
using DDO_Life_Tracker.Models;
using Microsoft.Extensions.Logging;


namespace DDO_Life_Tracker.Services
{
    public class IncarnationDBService
    {
        private readonly ILogger<IncarnationDBService> _logger;
        private readonly IncarnationDatabase _database;
        public IncarnationDBService(ILogger<IncarnationDBService> logger, IncarnationDatabase database) 
        {
            _logger = logger;
            _database = database;
        }

        #region Character Mapping
        public async Task<List<Character>> GetCharactersAsync()
        {
            try
            {
                _logger.LogDebug($"Getting Characters");

                List<CharactersTable> characters = await _database.GetCharactersAsync();

                return characters.Select(x => DataToModel(x)).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error getting characters: {ex}");
                throw;
            }
        }

        public async Task<Character> GetCharacterByIdAsync(int characterId)
        {
            try
            {
                _logger.LogDebug($"Getting Character by Id {characterId}");

                CharactersTable character = await _database.GetCharacterByIdAsync(characterId);

                return DataToModel(character);
            }
            catch(Exception ex) 
            {
                _logger.LogError($"Error getting Character: {ex}");
                throw;
            }
        }

        public async Task<Character> GetCharacterByNameAsync(string name)
        {
            try
            {
                _logger.LogDebug($"Getting character name: {name}");

                List<CharactersTable> characters =  await _database.GetCharactersAsync();
                CharactersTable found = characters.FirstOrDefault(x => x.Name == name) 
                    ?? throw new Exception($"No character found");

                return DataToModel(found);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Error getting character name {name}: {ex}");
                throw;
            }
        }

        public async Task<int> SaveCharacterAsync(Character character)
        {
            try
            {
                _logger.LogDebug($"Saving character id ({(character.Id == 0 ? "new" : character.Id)})");

                return await _database.SaveCharacterAsync(ModelToData(character));
            }
            catch(Exception ex)
            {
                _logger.LogError($"Error saving character: {ex}");
                throw;
            }
        }

        public async Task DeleteCharacterAsync(Character character)
        {
            try
            {
                _logger.LogDebug($"Deleting character id {character.Id}");

                await _database.DeleteCharacterAsync(ModelToData(character));
            }
            catch(Exception ex)
            {
                _logger.LogError($"Error deleting character: {ex}");
                throw;
            }
        }
        #endregion

        #region Incarnation Mapping
        public async Task<List<Incarnation>> GetIncarnationsByCharacterIdAsync(int characterId)
        {
            try
            {
                _logger.LogDebug($"Getting incarnations for Character id {characterId}");

                List<IncarnationsTable> incarnations = await _database.GetIncarnationByCharacterIdAsync(characterId);

                return incarnations.Select(x => DataToModel(x)).ToList();
            } 
            catch(Exception ex)
            {
                _logger.LogError($"Error getting Incarnations for character id {characterId}: {ex}");
                throw;
            }
        }

        public async Task<int> SaveIncarnationAsync(Incarnation incarnation)
        {
            try
            {
                _logger.LogDebug($"Saving incarnation for Character id {incarnation.CharacterId}");

                return await _database.SaveIncarnationAsync(ModelToData(incarnation));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error saving incarnation: {ex}");
                throw;
            }
        }

        public async Task DeleteIncarnation(Incarnation incarnation)
        {
            try
            {
                _logger.LogDebug($"Deleting incarnation id {incarnation.Id} for Character id {incarnation.CharacterId}");

                await _database.DeleteIncarnationAsync(ModelToData(incarnation));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error deleting incarnation: {ex}");
                throw;
            }
        }
        #endregion

        #region Classes Mapping
        public async Task<List<IClass>> GetClassesByIncarnationIdAsync(int incarnationId)
        {
            try
            {
                _logger.LogDebug($"Getting class for incarnation id {incarnationId})");
                
                List<ClassesTable> classData = await _database.GetClassesByIncarnationIdAsync(incarnationId);

                return classData.Select(x => DataToModel(x)).ToList();
            }
            catch(Exception ex)
            {
                _logger.LogError($"Error getting classes: {ex}");
                throw;
            }
        }

        public async Task<int> SaveClassAsync(IClass classItem)
        {
            try
            {
                _logger.LogDebug($"Saving class id ({(classItem.Id == 0 ? "new" : classItem.Id)})");

                return await _database.SaveClassAsync(ModelToData(classItem));
            }
            catch(Exception ex)
            {
                _logger.LogError($"Error saving class: {ex}");
                throw;
            }
        }

        public async Task DeleteClassAsync(IClass classItem)
        {
            try
            {
                _logger.LogDebug($"Deleting class id {classItem.Id}");

                await _database.DeleteClassAsync(ModelToData(classItem));
            }
            catch(Exception ex)
            {
                _logger.LogError($"Error saving class: {ex}");
                throw;
            }
        }
        #endregion

        private Character DataToModel(CharactersTable data)
        {
            IEnumerable<Incarnation> incarnations = data.Incarnations.Select(x => DataToModel(x));

            return new Character(data.Name, data.CreateDate, incarnations, data.Id);
        }

        private CharactersTable ModelToData(Character model)
        {
            return new CharactersTable
            {
                Id = model.Id,
                Name = model.Name,
                CreateDate = model.CreateDate,
                Incarnations = model.IncarnationHistory.Select(x => ModelToData(x)).ToList(),
            };
        }

        private Incarnation DataToModel(IncarnationsTable data)
        {
            IEnumerable<IClass> classes = data.Classes.Select(x => DataToModel(x));
            return new Incarnation(data.CharacterId, Definitions.IdToDDORace(data.RaceId), classes, data.Id);
        }

        private IncarnationsTable ModelToData(Incarnation model)
        {
            return new IncarnationsTable
            {
                Id = model.Id,
                CharacterId = model.CharacterId,
                RaceId = model.Race.Id,
                Classes = model.CurrentClassDefinitions.Select(x => ModelToData(x)).ToList(),
            };
        }

        private IClass DataToModel(ClassesTable data)
        {
            IClass current = Definitions.IdToDDOClass(data.ClassId);
            current.Id = data.Id;
            current.Level = data.Level;
            current.IncarnationId = data.IncarnationId;
            return current;
        }

        private ClassesTable ModelToData(IClass model)
        {
            return new ClassesTable
            {
                Id = model.Id,
                ClassId = model.ClassId,
                Level = model.Level,
                IncarnationId = model.IncarnationId,
            };
        }
    }
}
