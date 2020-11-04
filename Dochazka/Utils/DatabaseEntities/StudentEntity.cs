using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;



namespace Dochazka.Utils.DatabaseEntities {
    [Table("STUDENTS")]
    public class StudentEntity {
        [Key]
        public Int64 Id { get; set; }

        [Column("NAME") ]
        private string Name { get; set; }
        
        public string GetName() {
            return Name;
        }

        public void SetName(string name) {
            Name = name;
        }
        
        public bool Equals(StudentEntity other) {
            return Id==other.Id && Name == other.Name;
        }
    }
}