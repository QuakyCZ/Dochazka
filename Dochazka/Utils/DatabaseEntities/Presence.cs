using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.VisualBasic;

namespace Dochazka.Utils.DatabaseEntities {
    public class Presence {
        [Key]
        public Nullable<Int64> Id { get; set; }

        public Student Student { get; set; }
        public DateTime Date { get; set; }
        
        public PresenceType Type { get; set; }

        public override string ToString() {
            return string.Format("ID: {0}; Student: {1}; Date: {2}; Presence: {3};",Id,Student.Name,Date.ToShortDateString(),PresenceTypeEnum.ToString(Type));
        }
    }
}