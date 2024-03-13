using Microsoft.VisualBasic;
using YogaApplication.ApplicationConstants;
using YogaApplication.Enums;
using YogaApplication.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YogaApplication.Repositories.UserRepository
{
    /// <summary>
    /// Service class for managing yoga courses, extending the <see cref="DatabaseInit"/> class.
    /// </summary>
    public class YogaCourseService : DatabaseInit
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="YogaCourseService"/> class.
        /// </summary>
        public YogaCourseService()
        {
            // Initialize the database asynchronously
            Init().Wait();
        }

        /// <summary>
        /// Saves a yoga course asynchronously.
        /// </summary>
        /// <param name="course">The yoga course to save.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task SaveUserAsync(YogaCourse course)
        {
            if (course.Id == Guid.Empty)
            {
                // Generate a new GUID for the course if it doesn't have one
                course.Id = Guid.NewGuid();
                // Insert the course into the database
                Database.Insert(course);
                // Commit changes to the database
                Database.Commit();
            }
            else
            {
                // Update the existing course in the database
                Database.Update(course);
                // Commit changes to the database
                Database.Commit();
            }
        }

        /// <summary>
        /// Retrieves all yoga courses from the database asynchronously.
        /// </summary>
        /// <returns>A task representing the asynchronous operation that returns a list of yoga courses.</returns>
        public async Task<List<YogaCourse>> GetCourses()
        {
            // Retrieve all yoga courses from the database and return them as a list
            return Database.Table<YogaCourse>().ToList();
        }

        /// <summary>
        /// Retrieves a yoga course with the specified ID from the database asynchronously.
        /// </summary>
        /// <param name="courseId">The ID of the yoga course to retrieve.</param>
        /// <returns>A task representing the asynchronous operation that returns the yoga course.</returns>
        public async Task<YogaCourse> GetYogaCourse(Guid courseId)
        {
            // Retrieve a yoga course with the specified ID from the database
            return Database.Table<YogaCourse>().FirstOrDefault(c => c.Id == courseId);
        }

        /// <summary>
        /// Finalizer for the <see cref="YogaCourseService"/> class.
        /// </summary>
        ~YogaCourseService()
        {
            // Close the database connection when the object is finalized
            Database?.Close();
        }
    }

}
