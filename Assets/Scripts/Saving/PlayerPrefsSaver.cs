using UnityEngine;

public static class PlayerPrefsSaver
{
    public static void Save(string valueName, float value, bool instantSave = true)
    {
        PlayerPrefs.SetFloat(valueName, value);

        if (instantSave)
        {
            PlayerPrefs.Save();
        }
    }

    public static float Load(string valueName)
    {
        return PlayerPrefs.GetFloat(valueName);
    }
}
