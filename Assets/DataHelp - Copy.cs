using UnityEngine;

public class DataHelper
{
    #region Save Data
    public bool SaveData(string key, int value)
    {
        if (string.IsNullOrEmpty(key)) return false;
        
        PlayerPrefs.SetInt(key, value);
        return true;
    }

    public bool SaveData(string key, float value)
    {
        if (string.IsNullOrEmpty(key)) return false;

        PlayerPrefs.SetFloat(key, value);
        return true;
    }

    public bool SaveData(string key, string value)
    {
        if (string.IsNullOrEmpty(key) || string.IsNullOrEmpty(value)) return false;

        PlayerPrefs.SetString(key, value);
        return true;
    }
    #endregion

    #region Load Data
    public int LoadDataInt(string key)
    {
        int value;
        bool isHasKey = PlayerPrefs.HasKey(key);
        if (!isHasKey) value = -1;
        else value = PlayerPrefs.GetInt(key);
        
        return value;
    }

    public float LoadDataFloat(string key)
    {
        float value;
        bool isHasKey = PlayerPrefs.HasKey(key);
        if (!isHasKey) value = -1;
        else value = PlayerPrefs.GetFloat(key);

        return value;
    }

    public string LoadDataString(string key)
    {
        string value;
        bool isHasKey = PlayerPrefs.HasKey(key);
        if (!isHasKey) value = "";
        else value = PlayerPrefs.GetString(key);

        return value;
    }
    #endregion
}
