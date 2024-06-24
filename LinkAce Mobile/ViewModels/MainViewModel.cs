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
    bool isBusy;

    #endregion
    #region Lifecycle
    [RelayCommand]
    async Task Initialize()
    {
        string? token = await preferenceService.GetPreferenceString(preferenceService.TokenKey);
        if(token == null)
        {
            logger.Warning("No token found, navigating to login page");
            // Navigate to login page
        }
        else
        {
            logger.Information("Token found, navigating to main page");
            // Navigate to main page
        }
    }
    #endregion
    #region Fields
    Logger logger = App.Current.Logger;
    #endregion
}
