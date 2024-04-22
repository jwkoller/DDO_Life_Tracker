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
        Incarnation CurrentIncarnation { get; set; }
        List<Incarnation> IncarnationHistory { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
