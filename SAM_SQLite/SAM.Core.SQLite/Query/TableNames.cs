using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace SAM.Core.SQLite
{
    public static partial class Query
    {
        public static List<string> TableNames(this string path)
        {
            SQLiteConnection sQLiteConnection = new SQLiteConnection(string.Format(@"Data Source= {0}", path));

            return sQLiteConnection.TableNames();
        }

        public static List<string> TableNames(this SQLiteConnection sQLiteConnection)
        {
            if (sQLiteConnection == null)
                return null;

            if(sQLiteConnection.State != ConnectionState.Open)
            {
                sQLiteConnection.Open();
            }

            List<string> result = new List<string>();
            DataTable dataTable = sQLiteConnection.GetSchema("Tables");
            foreach (DataRow row in dataTable.Rows)
            {
                string tablename = (string)row[2];
                result.Add(tablename);
            }

            return result;
        }
    }
}