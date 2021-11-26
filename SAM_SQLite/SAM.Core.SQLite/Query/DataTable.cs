using System.Data;
using System.Data.SQLite;

namespace SAM.Core.SQLite
{
    public static partial class Query
    {
        public static DataTable DataTable(this SQLiteConnection sQLiteConnection, string tableName, params string[] columnNames)
        {
            if(sQLiteConnection == null || string.IsNullOrEmpty(tableName))
            {
                return null;
            }

            if(sQLiteConnection.State != ConnectionState.Open)
            {
                sQLiteConnection.Open();
            }

            string names = null;
            if(columnNames == null || columnNames.Length == 0)
            {
                names = "*";
            }
            else
            {
                names = string.Join(", ", columnNames);
            }

            DataTable result = null;
            using (SQLiteCommand sQLiteCommand = sQLiteConnection.CreateCommand())
            {
                sQLiteCommand.CommandText = string.Format("SELECT {0} FROM {1}", names, tableName);
                using (SQLiteDataReader sQLiteDataReader = sQLiteCommand.ExecuteReader(CommandBehavior.SingleResult))
                {
                    result = new DataTable();
                    result.Load(sQLiteDataReader);
                }
            }

            return result;
        }
    }
}