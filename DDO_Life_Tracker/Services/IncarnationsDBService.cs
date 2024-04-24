using DDO_Life_Tracker.Database;
using DDO_Life_Tracker.Database.Tables;
using DDO_Life_Tracker.Models;
using Microsoft.Extensions.Logging;


namespace DDO_Life_Tracker.Services
{
    public class IncarnationsDBService
    {
        private readonly ILogger<IncarnationsDBService> _logger;
        private readonly IncarnationDatabase _database;
        public IncarnationsDBService(ILogger<IncarnationsDBService> logger, IncarnationDatabase database) 
        {
            _logger = logger;
            _database = database;
        }

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

        public async Task<bool> SaveIncarnationAsync(Incarnation incarnation)
        {
            try
            {
                _logger.LogDebug($"Getting incarnation for Character id {incarnation.CharacterId}");

                await _database.SaveIncarnationAsync(ModelToData(incarnation));

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error saving incarnation: {ex}");
                throw;
            }
        }

        public async Task<bool> DeleteIncarnation(Incarnation incarnation)
        {
            try
            {
                _logger.LogDebug($"Deleting incarnation id {incarnation.Id} for Character id {incarnation.CharacterId}");

                await _database.DeleteIncarnationAsync(ModelToData(incarnation));

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error deleting incarnation: {ex}");
                throw;
            }
        }
        #endregion

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
                CreateDate = DateTime.Now,
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

        private ClassesTable ModelToData(IClass classItem)
        {
            return new ClassesTable
            {
                Id = classItem.Id,
                ClassId = classItem.ClassId,
                Level = classItem.Level,
                IncarnationId = classItem.IncarnationId,
            };
        }
    }
}
