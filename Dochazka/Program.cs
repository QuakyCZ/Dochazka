using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Dochazka.Utils;

namespace Dochazka {
    static class Program {
        public static string DBPATH = "dochazka.db";
        public static string DBPATH_BACKUP = "dochazka_backup.db";
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            using (StudentDbContext db = new StudentDbContext()) {
                db.Database.EnsureCreated();
                db.SaveChanges();
            }
            Application.Run(new Form1());
        }
    }
}