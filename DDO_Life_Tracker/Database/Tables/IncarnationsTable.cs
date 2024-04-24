using DDO_Life_Tracker.Models;
using DDO_Life_Tracker.Services;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace DDO_Life_Tracker.Database.Tables
{
    [Table("Incarnations")]
    public class IncarnationsTable : IHasId
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [NotNull]
        [ForeignKey(typeof(CharactersTable))]
        public int CharacterId {  get; set; }
        [NotNull]
        public int RaceId { get; set; }
        public DateTime CreateDate { get; set; }
        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<ClassesTable> Classes { get; set; }
    }
}
