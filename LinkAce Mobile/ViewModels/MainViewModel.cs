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
    bool isBusy;

    [ObservableProperty]
    ObservableCollection<LinkAceLink> links = [];

    #endregion

    bool IsBusyCanExecute => !IsBusy;   

    #region Lifecycle
     [RelayCommand]
    async Task Initialize()
    {
        IsBusy = true;
        string? token = await preferenceService.GetPreferenceString(preferenceService.TokenKey);
        if(token == null)
        {
            IsBusy = false;
            await NavigateToPreferencesPage();
        }
        else
        {
            try
            {
                var linkList = await linkRepository.GetAllLinks();

                Links = new(linkList);

                foreach (var link in Links)
                {
                    Debug.WriteLine(link.Title);
                }
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

    #region Navigation

    [RelayCommand(CanExecute = nameof(IsBusyCanExecute))]
    async Task NavigateToPreferencesPage() => await Shell.Current.GoToAsync("PreferencesPage");

    #endregion


    #region Fields
    readonly Logger logger = App.Current.Logger;
    #endregion
}
