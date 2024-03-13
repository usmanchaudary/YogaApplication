using System.Collections.ObjectModel;
using YogaApplication.Model;
using YogaApplication.Repositories.ReportsRepository;

namespace YogaApplication.Views;

/// <summary>
/// Represents a page displaying the user's classes.
/// </summary>
public partial class MyClasses : ContentPage
{
    private readonly ReportsService _reportsService = new ReportsService();

    /// <summary>
    /// Collection of report data representing the user's classes.
    /// </summary>
    public ObservableCollection<ReportData> ReportData { get; set; } = new ObservableCollection<ReportData>();

    /// <summary>
    /// Initializes a new instance of the <see cref="MyClasses"/> class.
    /// </summary>
    public MyClasses()
    {
        InitializeComponent();
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
    /// Initializes the data source for the report data.
    /// </summary>
    private void InitializeDataSource()
    {
        var reportData = _reportsService.GetReportData().Result;
        ReportData = new ObservableCollection<ReportData>(reportData);
        cvReportData.ItemsSource = ReportData;
    }
}