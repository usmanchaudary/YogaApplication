using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YogaApplication.Enums;

namespace YogaApplication.Model
{
    /// <summary>
    /// Represents a yoga course.
    /// </summary>
    public class YogaCourse
    {
        /// <summary>
        /// Gets or sets the unique identifier of the yoga course.
        /// </summary>
        [PrimaryKey]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the date of the yoga course.
        /// </summary>
        public DateTime CourseDate { get; set; }

        /// <summary>
        /// Gets or sets the capacity of the yoga course.
        /// </summary>
        public int Capacity { get; set; }

        /// <summary>
        /// Gets or sets the duration of the yoga course.
        /// </summary>
        public int Duration { get; set; }

        /// <summary>
        /// Gets or sets the instructor of the yoga course.
        /// </summary>
        public string Instructor { get; set; }

        /// <summary>
        /// Gets or sets the price of the yoga course.
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Gets or sets the type of the yoga course.
        /// </summary>
        public ClassType ClassType { get; set; }

        /// <summary>
        /// Gets or sets the description of the yoga course.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets the time of the yoga course formatted as "HH:mm" (e.g., "09:00").
        /// </summary>
        public string CourseTime => CourseDate.ToString("t");
    }

}
