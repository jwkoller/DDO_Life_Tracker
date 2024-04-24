using SQLite;
using SQLiteNetExtensions.Attributes;

namespace DDO_Life_Tracker.Database.Tables
{
    [Table("Characters")]
    public class CharactersTable : IHasId
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [NotNull]
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<IncarnationsTable> Incarnations { get; set; }
    }
}
