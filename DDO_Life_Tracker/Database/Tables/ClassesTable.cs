using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDO_Life_Tracker.Database.Tables
{
    [Table("Classes")]
    public class ClassesTable : IHasId
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        [ForeignKey(typeof(IncarnationsTable))]
        public int IncarnationId { get; set; }
        [NotNull]
        public int ClassId { get; set; }
        [NotNull]
        public int Level { get; set; }
    }
}
