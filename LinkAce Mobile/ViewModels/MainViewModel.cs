using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LinkAce_Mobile.Models;
using LinkAce_Mobile.Repositories;
using LinkAce_Mobile.Services;
using Serilog.Core;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace LinkAce_Mobile.ViewModels;

internal sealed partial class MainViewModel(IPreferenceService preferenceService, ILinkRepository linkRepository) : ObservableObject
{
    #region Properties

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(NavigateToPreferencesPageCommand))]
    [NotifyCanExecuteChangedFor(nameof(RefreshLinksCommand))]
    [NotifyCanExecuteChangedFor(nameof(AddNewLinkCommand))]
    [NotifyCanExecuteChangedFor(nameof(SearchLinksCommand))]
    bool isBusy;

    [ObservableProperty]
    ObservableCollection<LinkAceLink> links = [];

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
            IsBusy = true;
            try
            {
                var linkList = await linkRepository.GetAllLinks();

                Links = new(linkList);
            }
            catch (HttpRequestException ex)
            {
                logger.Error(ex, "Error while fetching links");
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
    #endregion

    [RelayCommand(CanExecute = nameof(IsBusyCanExecute))]
    async Task RefreshLinks()
    {
        IsBusy = true;
        try
        {
            var linkList = await linkRepository.GetAllLinks();

            Links = new(linkList);
        }
        catch (HttpRequestException ex)
        {
            logger.Error(ex, "Error while fetching links");
            Debug.WriteLine(ex);
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand(CanExecute = nameof(IsBusyCanExecute))]
    async Task AddNewLink()
    {
        SnackbarOptions snackbarOptions = new()
        {
            BackgroundColor = Colors.Red,
            TextColor = Colors.White,
            CornerRadius = new(10),
            ActionButtonTextColor = Colors.White
        };

        await Snackbar.Make("Not implemented yet", visualOptions: snackbarOptions).Show();
    }

    [RelayCommand(CanExecute = nameof(IsBusyCanExecute))]
    async Task SearchLinks()
    {

       SnackbarOptions snackbarOptions = new()
        {
            BackgroundColor = Colors.Red,
            TextColor = Colors.White,
            CornerRadius = new(10),
            ActionButtonTextColor = Colors.White
        };

        await Snackbar.Make("Not implemented yet", visualOptions: snackbarOptions).Show();
    }

    #region Navigation

    [RelayCommand(CanExecute = nameof(IsBusyCanExecute))]
    async Task NavigateToPreferencesPage() => await Shell.Current.GoToAsync("PreferencesPage");

    #endregion


    #region Fields
    readonly Logger logger = App.Current.Logger;
    #endregion
}
