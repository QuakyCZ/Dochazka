using System;
using System.Data.Entity;
using System.Runtime.Serialization;



namespace Dochazka.Utils.DatabaseEntities {
    
    public class StudentEntity:DbContext {
        private Int64 Uuid { get; }

        private string Name { get; set; }

        public Int64 GetId() {
            return Uuid;
        }

        public string GetName() {
            return Name;
        }

        public void SetName(string name) {
            Name = name;
        }
    }
}