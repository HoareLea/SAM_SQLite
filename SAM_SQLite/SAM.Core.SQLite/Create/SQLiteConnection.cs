using System.Data.SQLite;

namespace SAM.Core.SQLite
{
    public static partial class Create
    {
        public static SQLiteConnection SQLiteConnection(this string path)
        {
            if (string.IsNullOrWhiteSpace(path) || !System.IO.File.Exists(path))
            {
                return null;
            }

            SQLiteConnection result = new SQLiteConnection(string.Format(@"Data Source= {0}", path));

            return result;
        }
    }
}