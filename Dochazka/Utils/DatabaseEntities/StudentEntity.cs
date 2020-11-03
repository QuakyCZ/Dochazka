using System;


namespace Dochazka.Utils.DatabaseEntities {
    
    public class StudentEntity {
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