using LinkAce_Mobile.ViewModels;

namespace LinkAce_Mobile.Pages
{
    public partial class PreferencesPage : ContentPage
    {
    	public PreferencesPage()
    	{
    		InitializeComponent();

    		BindingContext = App.Current.ServiceProvider.GetRequiredService<PreferenceViewModel>();
    	}
    }
}