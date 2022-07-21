using static Globals;
using UnityEngine;
using Random = UnityEngine.Random;

public class PickedMoneySpawner : MonoBehaviour
{
    [SerializeField] private RectTransform destinationTransform;
    [SerializeField] private UIMoneySpawnConfig config;
    [SerializeField] private Transform defaultSpawnPosition;

    private Camera _mainCamera;

    public void InitializePickedMoney(int moneyPickAmount)
    {
        InitializePickedMoney(defaultSpawnPosition, moneyPickAmount, false);
    }
    
    public void InitializePickedMoney(Transform spawnTransform, int moneyPickAmount, bool castPosition = true)
    {
        var spawnMany = moneyPickAmount >= DefaultMoneyPickAmount;
        var spawnAmount = spawnMany ? config.MultiplyMoneySpawnAmount : 1 ;

        var leftMoney = CalculateLeftMoney(moneyPickAmount, spawnAmount);
        InitializeMoney(spawnTransform, castPosition, leftMoney);

        if (spawnMany)
        {
            var moneyPerPick = moneyPickAmount / spawnAmount;
            for (var i = 0; i < spawnAmount; i++)
            {
                InitializeMoney(spawnTransform, castPosition, moneyPerPick);
            }
        }
    }

    private int CalculateLeftMoney(int moneyPickAmount, int spawnAmount)
    {
        if (moneyPickAmount > MinMoneyPickAmount)
        {
            return moneyPickAmount % spawnAmount;
        }

        return MinMoneyPickAmount;
    }

    #region Main Actions

    private void InitializeMoney(Transform spawnTransform, bool castPosition, int moneyPerPick)
    {
        var spawnedMoney = SpawnMoneyPrefab(spawnTransform, castPosition, moneyPerPick);
        AddSpawnedMoneyToStorage(spawnedMoney);
    }
    
    private MoneyMovementUI SpawnMoneyPrefab(Transform spawnTransform, bool castPosition, int moneyForPick)
    {
        var uiSpawnPosition = GetUISpawnPosition(spawnTransform, castPosition);
        var randomizedUiPosition = GetRandomizedUIPosition(uiSpawnPosition);
        
        var spawnedPrefab = SpawnMoneyPrefab(randomizedUiPosition);
        spawnedPrefab.MoveToDestination(destinationTransform.position);
        spawnedPrefab.SetMoneyAmountForPick(moneyForPick);

        return spawnedPrefab;
    }

    private void AddSpawnedMoneyToStorage(MoneyMovementUI spawnedMoney)
    {
        SpawnedMoneyStorage.AddSpawnedMoneyInStorage(spawnedMoney);
    }

    #endregion
    
    #region Auxiliary Actions

    private MoneyMovementUI SpawnMoneyPrefab(Vector2 spawnPosition)
    {
        var spawnedPrefab = Instantiate(config.MoneyPrefab, 
            spawnPosition, config.MoneyPrefab.transform.rotation); spawnedPrefab.transform.SetParent(destinationTransform);

        return spawnedPrefab;
    }
    
    private Vector2 GetRandomizedUIPosition(Vector2 uiSpawnPosition)
    {
        uiSpawnPosition.x += Random.Range(config.SpawnPositionRandomizeRange.Min, config.SpawnPositionRandomizeRange.Max);
        uiSpawnPosition.y += Random.Range(config.SpawnPositionRandomizeRange.Min, config.SpawnPositionRandomizeRange.Max);

        return uiSpawnPosition;
    }

    private Vector2 GetUISpawnPosition(Transform spawnTransform, bool castPosition)
    {
        if (castPosition)
        {
            return _mainCamera.WorldToScreenPoint(spawnTransform.position);
        }

        return spawnTransform.position;
    }

    #endregion

    #region Init

    private void Awake()
    {
        _mainCamera = FindObjectOfType<Camera>();
    }

    #endregion
}