using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;



namespace Dochazka.Utils.DatabaseEntities {

    public class PresenceEntity
    {
        public int StudentID { get; set; }
        public string Date { get; set; }

        public bool Equals(PresenceEntity other)
        {
            return StudentID == other.StudentID && Date == other.Date;
        }
    }
}