using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dochazka.Utils.DatabaseEntities {
    public class Presence {
        public Int64 Id { get; set; }
        public Int64 StudentId { get; set; }
        
        [ForeignKey("StudentId")]
        public Student Student { get; set; }
        public string Date { get; set; }
        
        public PresenceType Type { get; set; }

        public bool Equals(Presence other)
        {
            return Id == other.Id && StudentId == other.StudentId && Student == other.Student && Date == other.Date && Type == other.Type;
        }
    }
}