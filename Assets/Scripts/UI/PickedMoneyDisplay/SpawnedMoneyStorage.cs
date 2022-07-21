using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class SpawnedMoneyStorage
{
    public static List<MoneyMovementUI> SpawnedMoney { get; } = new List<MoneyMovementUI>();
    public static bool IsStorageEmpty => CheckIfListIsEmpty();

    public static void AddSpawnedMoneyInStorage(MoneyMovementUI spawnedMoney)
    {
        SpawnedMoney.Add(spawnedMoney);
    }

    public static void RemoveSpawnedMoneyFromStorage(GameObject spawnedMoneyGameObject)
    {
        var foundSpawnedObject = SpawnedMoney.FirstOrDefault
            (m => m.gameObject == spawnedMoneyGameObject);

        SpawnedMoney.Remove(foundSpawnedObject);
    }

    private static bool CheckIfListIsEmpty()
    {
        var foundMoney = SpawnedMoney.Where(m => m != null).ToArray();
        return foundMoney.Length == 0;
    }
}
