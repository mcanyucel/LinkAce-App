using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LinkAce_Mobile.Services;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using System.Drawing;

namespace LinkAce_Mobile.ViewModels;

internal sealed partial class PreferenceViewModel(IPreferenceService preferenceService) : ObservableObject
{
    [ObservableProperty]
    string serverUrl = string.Empty;

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
            Microsoft.Maui.Graphics.Color backgroundColor = result1 && result2 ? Colors.Green : Colors.Red;
            SnackbarOptions snackbarOptions = new()
            {
                BackgroundColor = backgroundColor,
                TextColor = Colors.White,
                CornerRadius = new(10),
                ActionButtonTextColor = Colors.White
            };
            

            var snackbar = Snackbar.Make(message, action, actionText, TimeSpan.FromSeconds(5), snackbarOptions);
            await snackbar.Show();
        }
        else
        {
            SnackbarOptions snackbarOptions = new()
            {
                BackgroundColor = Colors.Red,
                TextColor = Colors.White,
                CornerRadius = new(10),
                ActionButtonTextColor = Colors.White
            };
            await Snackbar.Make("Please fill in all fields.", visualOptions: snackbarOptions).Show();
        }
    }

    [RelayCommand]  
    async Task Initialize()
    {
        IsBusy = true;
        ServerUrl = await preferenceService.GetPreferenceString(preferenceService.UrlKey) ?? ServerUrl;
        Token = await preferenceService.GetPreferenceString(preferenceService.TokenKey) ?? Token;
        IsBusy = false;
    }

    [RelayCommand]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "Command Binding Requires Instance Method")]
    async Task OpenAPILinkHelp()
    {
        var url = "https://api-docs.linkace.org/#section/Usage";
        await Browser.OpenAsync(url);
    }
}
