using YogaApplication.Views;

namespace YogaApplication
{
    /// <summary>
    /// Represents the main page of the application.
    /// </summary>
    public partial class MainPage : ContentPage
    {
        int count = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainPage"/> class.
        /// </summary>
        public MainPage()
        {
            InitializeComponent();
            Shell.Current.Navigation.PopToRootAsync(); // Ensure the navigation stack is cleared when the main page is loaded.
        }

        /// <summary>
        /// Event handler for the "View Classes" button click.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        private async void viewClasses_Clicked(object sender, EventArgs e)
        {
            // Navigate to the "View Classes" page
            await Shell.Current.GoToAsync(nameof(ViewClasses));
        }

        /// <summary>
        /// Event handler for the "My Classes" button click.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        private async void myClasses_Clicked(object sender, EventArgs e)
        {
            // Navigate to the "My Classes" page
            await Shell.Current.GoToAsync(nameof(MyClasses));
        }
    }


}
