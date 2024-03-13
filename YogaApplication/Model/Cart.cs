using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YogaApplication.Model
{
    /// <summary>
    /// Represents a cart item.
    /// </summary>
    public class Cart
    {
        /// <summary>
        /// Gets or sets the unique identifier of the cart item.
        /// </summary>
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the associated yoga course.
        /// </summary>
        public Guid CourseId { get; set; }

        /// <summary>
        /// Gets or sets the name of the associated yoga course.
        /// </summary>
        public string CourseName { get; set; }

        /// <summary>
        /// Gets or sets the date of the associated yoga course.
        /// </summary>
        public DateTime CourseDate { get; set; }

        /// <summary>
        /// Gets or sets the total price of the cart item.
        /// </summary>
        public double Total { get; set; }
    }

}
