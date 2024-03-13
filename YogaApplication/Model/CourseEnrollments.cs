using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YogaApplication.Model
{
    /// <summary>
    /// Represents a course enrollment record.
    /// </summary>
    public class CourseEnrollments
    {
        /// <summary>
        /// Gets or sets the unique identifier of the enrollment record.
        /// </summary>
        [SQLite.PrimaryKey]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the associated yoga course.
        /// </summary>
        public Guid YogaCourseId { get; set; }

        /// <summary>
        /// Gets or sets the email address of the student enrolled in the course.
        /// </summary>
        public string StudentEmail { get; set; }

        /// <summary>
        /// Gets or sets the enrollment date of the student in the course.
        /// </summary>
        public DateTime EnrollmentDate { get; set; }
    }

}
