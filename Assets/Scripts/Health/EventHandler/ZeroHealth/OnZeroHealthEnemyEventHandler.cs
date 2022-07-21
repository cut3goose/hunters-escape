using UnityEngine;

public class OnZeroHealthEnemyEventHandler : OnZeroHealthCharacterEventHandler
{
    [SerializeField] private EnemyKillRewardConfig config;
    
    private PickedMoneySpawner _moneySpawner;
    private RagdollBase _ragdollBase;
    private ChildrenDetacher _detacher;
    
    protected override void HandleEvent(object s, (Vector3, DamageType) args)
    {
        base.HandleEvent(s, args);
        _moneySpawner.InitializePickedMoney(config.RewardAmount);
        SpawnedEnemyStorageMonoBehaviour.Instance.SpawnedEnemies.RemoveObjectFromStorage(GetComponent<EnemyMovement>());
        EnemySpawnController.Instance.TrySpawnEnemy();
        LevelStatistics.Instance.IncreaseEnemiesKilled();
        ComboKillCounter.Instance.IncreaseKillsAmount();
        TryEnableRagdoll(args.Item1);
        _detacher.TryDetachChildren();
    }

    #region Main Actions

    private void TryEnableRagdoll(Vector3 hitDirection)
    {
        _ragdollBase.ChangeRagDollState(true, true);
        _ragdollBase.AddForce(hitDirection);
    }

    #endregion

    #region Init

    protected override void Awake()
    {
        base.Awake();
        
        TryGetComponent(out _ragdollBase);
        TryGetComponent(out _detacher);
        _moneySpawner = FindObjectOfType<PickedMoneySpawner>();
    }

    #endregion
}