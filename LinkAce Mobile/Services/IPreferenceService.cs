namespace LinkAce_Mobile.Services;

internal interface IPreferenceService
{
    /// <summary>
    /// Gets the string preference value for the given key.
    /// </summary>
    /// <param name="key"></param>
    /// <returns>Null if no key exists or exceptions</returns>
    Task<string?> GetPreferenceString(string key);

    /// <summary>
    /// Sets the string preference value for the given key.
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    Task<bool> SetPreferenceString(string key, string value);
}
