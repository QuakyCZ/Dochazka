using Dochazka.Utils;
using Dochazka.Utils.DatabaseEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Dochazka
{
    class Student
    {
        public int ID;
        public int LVID;
        public string Name;
        public bool Present;

        public Student(int ID, int LVID, string Name)
        {
            this.ID = ID;
            this.LVID = LVID;
            this.Name = Name;
            Present = checkPresence(DateTime.Now.ToShortDateString());
        }

        public bool checkPresence(string date)
        {
            DbSet<PresenceEntity> presences = new PresenceDbContext().Presences;
            foreach (var presence in presences)
            {
                if (presence.Date == date && presence.StudentID == ID)
                    return false;
            }
            return true;
        }

        public void markAbsent(string date)
        {
            PresenceEntity absent = new PresenceEntity();
            absent.StudentID = ID;
            absent.Date = date;
            try
            {
                using (PresenceDbContext db = new PresenceDbContext())
                {
                    if (!checkPresence(date))
                        db.Presences.Remove(absent);
                    else
                        db.Presences.Add(absent);
                    db.SaveChanges();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                MessageBox.Show("Nastala chyba databaze.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
