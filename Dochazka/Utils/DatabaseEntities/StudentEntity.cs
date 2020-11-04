using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;



namespace Dochazka.Utils.DatabaseEntities {
    public class StudentEntity {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public bool Equals(StudentEntity other) {
            return Id==other.Id && Name == other.Name;
        }
    }
}