using RenovatorApp.UI.Models;
using RenovatorApp.UI.PageModels;

namespace RenovatorApp.UI.Pages;

public partial class MainPage : ContentPage
{
    public MainPage(MainPageModel model)
    {
        InitializeComponent();
        BindingContext = model;
    }
}