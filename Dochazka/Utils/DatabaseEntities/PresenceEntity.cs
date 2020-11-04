using System;

namespace Dochazka.Utils.DatabaseEntities {
    public class PresenceEntity {
        public Int64 Id { get; set; }
        public Int64 StudentId { get; set; }
        public StudentEntity Student { get; set; }
        public string Date { get; set; }
        
        public PresenceType Type { get; set; }

        public bool Equals(PresenceEntity other)
        {
            return Id == other.Id && StudentId == other.StudentId && Student == other.Student && Date == other.Date && Type == other.Type;
        }
    }
}