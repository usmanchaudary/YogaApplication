using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YogaApplication.ApplicationConstants
{
    /// <summary>
    /// Contains constants related to the database configuration.
    /// </summary>
    public static class DatabaseConstants
    {
        /// <summary>
        /// The filename of the database.
        /// </summary>
        public const string DatabaseFilename = "yogaapp.db3";

        /// <summary>
        /// The flags used to configure the database connection.
        /// </summary>
        public const SQLite.SQLiteOpenFlags Flags =
            // Open the database in read/write mode
            SQLite.SQLiteOpenFlags.ReadWrite |
            // Create the database if it doesn't exist
            SQLite.SQLiteOpenFlags.Create |
            // Enable multi-threaded database access
            SQLite.SQLiteOpenFlags.SharedCache;

        /// <summary>
        /// Gets the full path to the database file.
        /// </summary>
        public static string DatabasePath =>
            Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);
    }

}
