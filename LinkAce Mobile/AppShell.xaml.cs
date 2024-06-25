using LinkAce_Mobile.Pages;

namespace LinkAce_Mobile;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute("HomePage", typeof(MainPage));
        Routing.RegisterRoute("PreferencesPage", typeof(PreferencesPage));
        Routing.RegisterRoute("TagsPage", typeof(TagsPage));
        Routing.RegisterRoute("ListsPage", typeof(ListsPage));  
    }
}
