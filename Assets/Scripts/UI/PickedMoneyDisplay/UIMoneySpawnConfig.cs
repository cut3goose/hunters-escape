using UnityEngine;

[CreateAssetMenu(fileName = "UIMoneySpawnConfig", menuName = "Configs/Money/UIMoneySpawnConfig")]
public class UIMoneySpawnConfig : ScriptableObject
{
    public MoneyMovementUI MoneyPrefab;
    public MinMaxNumber SpawnPositionRandomizeRange;
    public int MultiplyMoneySpawnAmount;
}