using System;

public class LevelsPassedDataSaver : DataSaver
{
    public override void SaveData()
    {
        PlayerPrefsSaver.Save(ValueName, PassedLevelsAmountData.LevelsPassed);
    }

    public override void LoadData()
    {
        var loadedData = (int)PlayerPrefsSaver.Load(ValueName);
        PassedLevelsAmountData.SetPassedLevelsAmount(loadedData);
    }

    private void TriggerDataSave(object s, int newAmount)
    {
        SaveData();
    }
    
    #region State Change Reactions

    private void OnDestroy()
    {
        PassedLevelsAmountData.OnPassedLevelsAmountUpdated -= TriggerDataSave;
    }

    #endregion
    
    #region Init

    private void Awake()
    {
        ValueName = nameof(PassedLevelsAmountData.LevelsPassed);

        PassedLevelsAmountData.OnPassedLevelsAmountUpdated += TriggerDataSave;
        LoadData();
    }

    #endregion
}
