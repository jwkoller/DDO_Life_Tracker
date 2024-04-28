using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDO_Life_Tracker.Models
{
    public interface IDDOCharacter
    {
        int Id { get; set; }
        string Name { get; set; }
        int NumberOfLives { get; }
        IEnumerable<Incarnation> IncarnationHistory { get; }
        public DateTime CreateDate { get; set; }
        void AddIncarnation(Incarnation incarnation);
        void AddIncarnations(IEnumerable<Incarnation> incarnations);

    }
}
