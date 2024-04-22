using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDO_Life_Tracker.Database.Tables
{
    [Table("IncarnationClasses")]
    public class IncarnationClasses : IHasId
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        [NotNull]
        public int CharacterId { get; set; }
        [NotNull]
        public int IncarnationId { get; set; }
        [NotNull]
        public int ClassId { get; set; }
        [NotNull]
        public int CLassLevel { get; set; }
    }
}
