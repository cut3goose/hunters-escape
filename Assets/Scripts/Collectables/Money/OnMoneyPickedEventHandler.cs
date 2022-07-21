using UnityEngine;

public class OnMoneyPickedEventHandler : OnCollectableCollectedEventHandler
{
    private Money _money;
    
    private PickedMoneySpawner _pickedMoneySpawner;

    protected override void HandleEvent(object s, (Transform, GameObject) args)
    {
        base.HandleEvent(s, args);
        
        _pickedMoneySpawner.InitializePickedMoney(args.Item1, _money.MoneyForPick);
    }

    #region Init

    protected override void Awake()
    {
        base.Awake();
        
        _pickedMoneySpawner = FindObjectOfType<PickedMoneySpawner>();
        TryGetComponent(out _money);
    }

    #endregion
}