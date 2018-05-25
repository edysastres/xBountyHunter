using System;
using SQLite;
using xBountyHunter.iOS;
using Xamarin.Forms;
using System.IO;

[assembly: Dependency (typeof(SQLiteiOS))]
namespace xBountyHunter.iOS
{
    public class SQLiteiOS : DependencyServices.ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            string sqliteFilename = "mFugitivos.db3";
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libPath = Path.Combine(docPath, "..", "Library");
            string path = Path.Combine(libPath, sqliteFilename);

            SQLiteConnection conn = new SQLiteConnection(path);
            return conn;
        }
    }
}
