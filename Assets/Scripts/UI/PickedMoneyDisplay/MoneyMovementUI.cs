using System;
using DG.Tweening;
using UnityEngine;

public class MoneyMovementUI : MonoBehaviour
{
    public event EventHandler<int> OnMoneyDestinationReached;

    [SerializeField] private MoneyMovementUIConfig config;

    private int _moneyForPick;
    private bool _transactionCompleted;
    
    public void MoveToDestination(Vector2 destinationPoint)
    {
        transform.DOMove(destinationPoint, config.MovementDuration).SetEase(config.Ease)
            .OnComplete(NotifyDestinationReached);
    }

    #region Fields Setting

    public void SetMoneyAmountForPick(int amount)
    {
        _moneyForPick = amount;
    }

    public void SetBoolTransactionCompleted(bool newValue)
    {
        _transactionCompleted = newValue;
    }

    #endregion

    #region Auxiliary Actions

    private void NotifyDestinationReached()
    {
        if (_transactionCompleted) return;
        
        OnMoneyDestinationReached?.Invoke(this, _moneyForPick);   
    }

    #endregion
}