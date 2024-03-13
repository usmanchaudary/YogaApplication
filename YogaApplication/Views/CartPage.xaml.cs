using System.Collections.ObjectModel;
using System.Windows.Input;
using YogaApplication.Model;
using YogaApplication.Repositories.CartRepository;
using YogaApplication.Repositories.ReportsRepository;
using YogaApplication.Repositories.UserRepository;

namespace YogaApplication.Views;

/// <summary>
/// Represents the page displaying the user's shopping cart items.
/// </summary>
public partial class CartPage : ContentPage
{
    private readonly CartService _cartService = new CartService();
    private readonly ReportsService _reportsService = new ReportsService();
    private readonly YogaCourseService _yogaService = new YogaCourseService();

    /// <summary>
    /// Collection of items in the shopping cart.
    /// </summary>
    public ObservableCollection<Cart> CartItems { get; set; } = new ObservableCollection<Cart>();

    /// <summary>
    /// Command to remove an item from the shopping cart.
    /// </summary>
    public ICommand RemoveFromCartCommand { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="CartPage"/> class.
    /// </summary>
    public CartPage()
    {
        InitializeComponent();
        try
        {
            InitializeCommands();
            BindingContext = this;
        }
        catch (Exception e)
        {
            // Handle exceptions during initialization
            throw;
        }
    }

    /// <summary>
    /// Triggered when the page appears on the screen.
    /// </summary>
    protected override void OnAppearing()
    {
        base.OnAppearing();
        InitializeDataSource();
    }

    /// <summary>
    /// Initializes commands used in the page.
    /// </summary>
    private void InitializeCommands()
    {
        // Initialize the command for the "Remove" action
        RemoveFromCartCommand = new Command<Cart>(RemoveFromCart);
    }

    /// <summary>
    /// Removes an item from the shopping cart.
    /// </summary>
    /// <param name="cart">The item to be removed.</param>
    public async void RemoveFromCart(Cart cart)
    {
        await _cartService.RemoveFromCart(cart);
        await DisplayAlert("Remove from Cart", "Course removed from cart", "OK");
        InitializeDataSource();
    }

    /// <summary>
    /// Initializes the data source for the shopping cart items.
    /// </summary>
    private void InitializeDataSource()
    {
        var cartItems = _cartService.GetCartItems().Result;
        CartItems = new ObservableCollection<Cart>(cartItems);
        cvCartItems.ItemsSource = CartItems;
    }

    /// <summary>
    /// Proceeds to checkout with the items in the shopping cart.
    /// </summary>
    /// <param name="sender">The sender of the event.</param>
    /// <param name="e">The event arguments.</param>
    private async void ProceedToCheckout_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(userEmail.Text) || !userEmail.Text.Contains('@'))
        {
            await DisplayAlert("Email", "Entered Email is invalid or empty", "OK");
            return;
        }
        var cartItems = await _cartService.GetCartItems();
        if (cartItems.Count > 0)
        {
            foreach (var cartItem in cartItems)
            {
                var yogaCourse = await _yogaService.GetYogaCourse(cartItem.CourseId);
                await _reportsService.SaveReportDataAsync(new ReportData
                {
                    CourseId = cartItem.CourseId,
                    CourseName = cartItem.CourseName,
                    CourseDate = cartItem.CourseDate,
                    Total = cartItem.Total,
                    Duration = yogaCourse.Duration,
                    Description = yogaCourse.Description,
                    UserEmail = userEmail.Text
                });
                await _cartService.RemoveFromCart(cartItem);
                await _reportsService.Save();
            }
            await DisplayAlert("Success", "Order Completed! ", "OK");
            await Shell.Current.Navigation.PopToRootAsync();
        }
        else
        {
            await DisplayAlert("Cart", "No items in cart", "OK");
        }
    }
}
