using SQLite;

namespace DDO_Life_Tracker.Database.Tables
{
    [Table("CharactersDB")]
    public class CharactersDB : IHasId
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [NotNull]
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
