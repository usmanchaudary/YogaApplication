using System.Collections.ObjectModel;
using System.Windows.Input;
using YogaApplication.Model;
using YogaApplication.Repositories.CartRepository;
using YogaApplication.Repositories.UserRepository;

namespace YogaApplication.Views;

public partial class ViewClasses : ContentPage
{
    private readonly YogaCourseService _yogaService = new YogaCourseService();
    private readonly CartService _cartService = new CartService();
    public ObservableCollection<YogaCourse> YogaCourses { get; set; } = new ObservableCollection<YogaCourse>();
    public ICommand AddToCartCommand { get; private set; }
    public ViewClasses()
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
    /// Occurs when the page is about to be displayed.
    /// </summary>
    protected override void OnAppearing()
    {
        base.OnAppearing();
        InitializeDataSource();
    }

    /// <summary>
    /// Initializes the data source for the users.
    /// </summary>
    private void InitializeDataSource()
    {
        var users = _yogaService.GetCourses().Result;
        YogaCourses = new ObservableCollection<YogaCourse>(users);
        cvCourses.ItemsSource = YogaCourses;
    }
    /// <summary>
    /// Initializes the commands for the page.
    /// </summary>
    private void InitializeCommands()
    {
        // Initialize the command for the "Update" action
        AddToCartCommand = new Command<YogaCourse>(AddToCart);
    }
    ///Add To Cart
    public async void AddToCart(YogaCourse course)
    {
        await _cartService.AddToCart(course);
        //add to cart
        await DisplayAlert("Add to Cart", "Course added to cart", "OK");
    }

    private async void CheckOut_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(CartPage));
    }

    private async void ApplyFilters_Clicked(object sender, EventArgs e)
    {
        var date = datePicker.Date;
        var time = timePicker.Time;
        var courses = await _yogaService.GetCourses();
        List<YogaCourse> filteredCourses = new();
        //if time is 00:00 then only filter by date
        if (time.Hours == 0 && time.Minutes == 0)
        {
            filteredCourses = courses.Where(c => c.CourseDate.Date == date.Date).ToList();
            YogaCourses = new ObservableCollection<YogaCourse>(filteredCourses);
            cvCourses.ItemsSource = YogaCourses;
            return;
        }
        filteredCourses = courses.Where(c => c.CourseDate.Date == date.Date && c.CourseTime.Contains($"{time.Hours}")).ToList();
        YogaCourses = new ObservableCollection<YogaCourse>(filteredCourses);
        cvCourses.ItemsSource = YogaCourses;
    }
}