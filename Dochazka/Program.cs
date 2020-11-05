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
        public static string DBROOTFOLDER =
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Dochazka");
        public static string DBPATH = Path.Combine(DBROOTFOLDER,"dochazka.db");
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (Directory.Exists(DBROOTFOLDER) == false) {
                Directory.CreateDirectory(DBROOTFOLDER);
            }
            using (StudentDbContext db = new StudentDbContext()) {
                db.Database.EnsureCreated();
                db.SaveChanges();
            }
            Application.Run(new Form1());
        }
    }
}