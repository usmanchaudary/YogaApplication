using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YogaApplication.ApplicationConstants;
using YogaApplication.Model;

namespace YogaApplication.Repositories.CartRepository
{
    /// <summary>
    /// Service class for managing cart items, extending the <see cref="DatabaseInit"/> class.
    /// </summary>
    public class CartService : DatabaseInit
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CartService"/> class.
        /// </summary>
        public CartService()
        {
            // Initialize the database asynchronously
            Init().Wait();
        }

        /// <summary>
        /// Adds a yoga course to the cart asynchronously.
        /// </summary>
        /// <param name="course">The yoga course to add to the cart.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task AddToCart(YogaCourse course)
        {
            // Create a new cart item based on the provided yoga course
            var cart = new Cart
            {
                CourseId = course.Id,
                CourseName = course.ClassType.ToString(),
                CourseDate = course.CourseDate,
                Total = course.Price
            };
            // Insert the cart item into the database
            Database.Insert(cart);
        }

        /// <summary>
        /// Retrieves all cart items from the database asynchronously.
        /// </summary>
        /// <returns>A task representing the asynchronous operation that returns a list of cart items.</returns>
        public async Task<List<Cart>> GetCartItems()
        {
            // Retrieve all cart items from the database and return them as a list
            return Database.Table<Cart>().ToList();
        }

        /// <summary>
        /// Removes a cart item from the cart asynchronously.
        /// </summary>
        /// <param name="cart">The cart item to remove.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task RemoveFromCart(Cart cart)
        {
            // Delete the specified cart item from the database
            Database.Delete<Cart>(cart.Id);
        }
    }

}
