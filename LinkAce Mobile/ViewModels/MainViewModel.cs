using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LinkAce_Mobile.Repositories;
using LinkAce_Mobile.Services;
using Serilog.Core;

namespace LinkAce_Mobile.ViewModels;

internal sealed partial class MainViewModel(IPreferenceService preferenceService, ILinkRepository linkRepository) : ObservableObject
{
    #region Properties

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(NavigateToPreferencesPageCommand))]  
    bool isBusy;

    #endregion

    bool IsBusyCanExecute => !IsBusy;   

    #region Lifecycle
     [RelayCommand]
    async Task Initialize()
    {
        string? token = await preferenceService.GetPreferenceString(preferenceService.TokenKey);
        if(token == null)
        {
            await NavigateToPreferencesPage();
        }
        else
        {
            logger.Information("Token found, navigating to main page");
            // Navigate to main page
        }
    }
    #endregion

    #region Navigation

    [RelayCommand(CanExecute = nameof(IsBusyCanExecute))]
    async Task NavigateToPreferencesPage() => await Shell.Current.GoToAsync("PreferencesPage");

    #endregion


    #region Fields
    readonly Logger logger = App.Current.Logger;
    #endregion
}
