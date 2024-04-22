﻿using DDO_Life_Tracker.Models;
using DDO_Life_Tracker.Services;
using SQLite;

namespace DDO_Life_Tracker.Database.Tables
{
    [Table("Incarnations")]
    public class Incarnations : IHasId
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [NotNull]
        public int CharacterId {  get; set; }
        [NotNull]
        public int RaceId { get; set; }
    }
}
