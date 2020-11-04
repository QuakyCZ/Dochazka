using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;


namespace Dochazka.Utils.DatabaseEntities {
    [Table("Student")]
    public class Student {
        public Int64 Id { get; set; }

        public string Name { get; set; }
        public List<Presence> Presences { get; set; }
        public bool Equals(Student other) {
            return Id==other.Id && Name == other.Name && Presences.Equals(other.Presences);
        }
    }
}