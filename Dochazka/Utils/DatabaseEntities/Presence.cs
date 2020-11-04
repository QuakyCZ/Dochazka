using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dochazka.Utils.DatabaseEntities {
    public class Presence {
        public Int64 Id { get; set; }

        public Student Student { get; set; }
        public string Date { get; set; }
        
        public PresenceType Type { get; set; }
    }
}