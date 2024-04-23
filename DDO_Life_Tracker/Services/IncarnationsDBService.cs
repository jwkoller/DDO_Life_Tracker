using DDO_Life_Tracker.Database;
using DDO_Life_Tracker.Database.Tables;
using DDO_Life_Tracker.Models;
using Microsoft.Extensions.Logging;


namespace DDO_Life_Tracker.Services
{
    public class IncarnationsDBService : AbstractDBService<Incarnation, IncarnationsDB>
    {
        private readonly ILogger<IncarnationsDBService> _logger;
        private readonly IncarnationDatabase _database;
        public IncarnationsDBService(ILogger<IncarnationsDBService> logger, IncarnationDatabase database) 
        {
            _logger = logger;
            _database = database;
        }

        public async Task<List<Incarnation>> GetIncarnationByCharacterIdAsync(int characterId)
        {
            _logger.LogDebug($"Getting incarnations for Character id {characterId}");

            List<Incarnation> characterIncarnations = new List<Incarnation>();

            List<IncarnationsDB> incarnations = await _database.GetIncarnationsByCharacterIdAsync(characterId);
            List<IncarnationClassesDB> classes = await _database.GetClassesByCharacterIdAsync(characterId);

            foreach (IncarnationsDB inc in incarnations)
            {
                Incarnation newInc = DataToModel(inc);
                //TODO - pull from ClassesDBService?
                IEnumerable<IClass> incClasses = classes.Where(x => x.IncarnationId == inc.Id).Select(x => IdToDDOClass(x.ClassId));
                newInc.AddClasses(incClasses);
                characterIncarnations.Add(newInc);
            }

            return characterIncarnations;
        }

        public async Task<int> SaveIncarnationToDBAsync(Incarnation incarnation)
        {
            foreach(IClass clss in incarnation.CurrentClassDefinitions)
            {
                //TODO use ClassDBService
                await _database.SaveIncarnationClassAsync(new IncarnationClassesDB
                {
                    Id = clss.Id,
                    IncarnationId = incarnation.Id,
                    ClassId = clss.ClassId,
                    CLassLevel = clss.Level,
                    CharacterId = incarnation.CharacterId
                });
            }

            return await _database.SaveIncarnationAsync(ModelToData(incarnation));
        }

        public override Incarnation DataToModel(IncarnationsDB data)
        {
            return new Incarnation(data.CharacterId)
            {
                Id = data.Id,
                Race = IdToDDORace(data.RaceId),
            };
        }

        public override IncarnationsDB ModelToData(Incarnation model)
        {
            return new IncarnationsDB
            {
                Id = model.Id,
                CharacterId = model.CharacterId,
                RaceId = model.Race.Id,
            };
        }
    }
}
