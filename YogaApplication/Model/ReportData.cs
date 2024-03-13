using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YogaApplication.Enums;

namespace YogaApplication.Model
{
    /// <summary>
    /// Represents report data for a course.
    /// </summary>
    public class ReportData
    {
        /// <summary>
        /// Gets or sets the unique identifier of the report data.
        /// </summary>
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the associated course.
        /// </summary>
        public Guid CourseId { get; set; }

        /// <summary>
        /// Gets or sets the name of the associated course.
        /// </summary>
        public string CourseName { get; set; }

        /// <summary>
        /// Gets or sets the date of the associated course.
        /// </summary>
        public DateTime CourseDate { get; set; }

        /// <summary>
        /// Gets or sets the duration of the associated course.
        /// </summary>
        public int Duration { get; set; }

        /// <summary>
        /// Gets or sets the total amount spent on the associated course.
        /// </summary>
        public double Total { get; set; }

        /// <summary>
        /// Gets or sets the description of the associated course.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the email address of the user associated with the report.
        /// </summary>
        public string UserEmail { get; set; }
    }


}
