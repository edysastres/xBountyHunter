using System;
using SQLite;

namespace xBountyHunter.DependencyServices
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
