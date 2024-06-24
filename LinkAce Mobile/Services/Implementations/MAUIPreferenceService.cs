namespace LinkAce_Mobile.Services.Implementations;

internal class MAUIPreferenceService : IPreferenceService
{
    public string TokenKey => "APIToken";

    public async Task<string?> GetPreferenceString(string key)
    {
        string? result = null;
        
        if (!string.IsNullOrEmpty(key))
        {
            await Task.Run(() =>
            {
                try
                {
                    result = Preferences.Get(key, null);
                }
                catch (Exception e)
                {
                    App.Current.Logger.Error(e, "Error while getting preference string");
                }
            });
        }

        return result;
    }

    public async Task<bool> SetPreferenceString(string key, string value)
    {
        bool result = false;
        if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(value))
        {
            await Task.Run(() =>
            {
                try
                {
                    Preferences.Set(key, value);
                    result = true;
                }
                catch (Exception e)
                {
                    App.Current.Logger.Error(e, "Error while setting preference string");
                }
            });
        }
        return result;
    }
}
