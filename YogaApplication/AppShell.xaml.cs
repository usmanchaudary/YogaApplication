using YogaApplication.Views;

namespace YogaApplication
{
    /// <summary>
    /// Represents the application shell, which defines the navigation structure of the application.
    /// </summary>
    public partial class AppShell : Shell
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppShell"/> class.
        /// </summary>
        public AppShell()
        {
            InitializeComponent();

            // Register navigation routes for pages in the application
            Routing.RegisterRoute(nameof(ViewClasses), typeof(ViewClasses));
            Routing.RegisterRoute(nameof(CartPage), typeof(CartPage));
            Routing.RegisterRoute(nameof(MyClasses), typeof(MyClasses));
        }
    }

}
