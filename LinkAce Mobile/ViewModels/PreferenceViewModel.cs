using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LinkAce_Mobile.Services;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

namespace LinkAce_Mobile.ViewModels;

internal sealed partial class PreferenceViewModel(IPreferenceService preferenceService) : ObservableObject
{
    [ObservableProperty]
    string serverUrl = "https://linkace.example.com";

    [ObservableProperty]
    string token = string.Empty;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SavePreferencesCommand))]
    bool isBusy;

    bool IsBusyCanExecute => !IsBusy;

    [RelayCommand(CanExecute = nameof(IsBusyCanExecute))]
    async Task SavePreferences()
    {
        if (!(string.IsNullOrEmpty(ServerUrl) || string.IsNullOrEmpty(Token)))
        {
            var result1 = await preferenceService.SetPreferenceString(preferenceService.UrlKey, ServerUrl);
            var result2 = await preferenceService.SetPreferenceString(preferenceService.TokenKey, Token);

            string message = result1 && result2 ? "Preferences saved" : "Error while saving preferences";
            string actionText = result1 && result2 ? "Ok" : "Retry";
            Action action = result1 && result2 ? () => { } : new Action(async () => await SavePreferences());

            var snackbar = Snackbar.Make(message, action, actionText, TimeSpan.FromSeconds(5));
        }
    }

    async Task Initialize()
    {
        IsBusy = true;
        ServerUrl = await preferenceService.GetPreferenceString(preferenceService.UrlKey) ?? ServerUrl;
        Token = await preferenceService.GetPreferenceString(preferenceService.TokenKey) ?? Token;
    }
}
