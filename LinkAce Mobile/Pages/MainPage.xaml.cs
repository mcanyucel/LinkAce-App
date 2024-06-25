using LinkAce_Mobile.ViewModels;

namespace LinkAce_Mobile;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        BindingContext = App.Current.ServiceProvider.GetRequiredService<MainViewModel>();
    }
}
