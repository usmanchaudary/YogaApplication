
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YogaApplication.ApplicationConstants;
using YogaApplication.Enums;
using YogaApplication.Model;

namespace YogaApplication.Repositories
{
    /// <summary>
    /// Helper class for initializing and interacting with the SQLite database.
    /// </summary>
    public class DatabaseInit
    {
        /// <summary>
        /// The SQLite database connection.
        /// </summary>
        protected SQLiteConnection Database;

        /// <summary>
        /// Initializes the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        protected async Task Init()
        {
            if (Database is not null)
                return;

            // Create a new SQLite database connection
            Database = new SQLiteConnection(DatabaseConstants.DatabasePath, DatabaseConstants.Flags);

            // Create tables if they do not exist
            Database.CreateTable<YogaCourse>();
            Database.CreateTable<Cart>();
            Database.CreateTable<ReportData>();

            // Seed the database with some dummy data if it's empty
            if (!Database.Table<YogaCourse>().Any())
            {
                Database.Insert(new YogaCourse
                {
                    Id = Guid.NewGuid(),
                    CourseDate = DateTime.Now,
                    Capacity = 10,
                    Duration = 60,
                    Instructor = "John Doe",
                    Price = 10,
                    ClassType = ClassType.FlowYoga,
                    Description = "This is a flow yoga class"
                });
                Database.Insert(new YogaCourse
                {
                    Id = Guid.NewGuid(),
                    CourseDate = DateTime.Now.AddHours(2),
                    Capacity = 10,
                    Duration = 60,
                    Instructor = "Jane Doe",
                    Price = 10,
                    ClassType = ClassType.AerialYoga,
                    Description = "This is an aerial yoga class"
                });
                Database.Insert(new YogaCourse
                {
                    Id = Guid.NewGuid(),
                    CourseDate = DateTime.Now.AddHours(4),
                    Capacity = 10,
                    Duration = 60,
                    Instructor = "John Doe",
                    Price = 10,
                    ClassType = ClassType.FamilyYoga,
                    Description = "This is a family yoga class"
                });
            }
        }

        /// <summary>
        /// Commits changes to the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task Save()
        {
            Database.Commit();
        }
    }

}
