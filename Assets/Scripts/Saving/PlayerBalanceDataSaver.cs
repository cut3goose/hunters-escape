public class PlayerBalanceDataSaver : DataSaver
{
    public override void SaveData()
    {
        var balance = PlayerWallet.CurrentBalance;
        PlayerPrefsSaver.Save(ValueName, balance);
    }

    public override void LoadData()
    {
        var loadedData = (int)PlayerPrefsSaver.Load(ValueName);
        PlayerWallet.SetBalance(loadedData);
    }

    private void Start()
    {
        LoadData();
    }
}
