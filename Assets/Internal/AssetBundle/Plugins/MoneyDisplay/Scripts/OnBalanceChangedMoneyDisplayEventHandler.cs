using UnityEngine;

public class OnBalanceChangedMoneyDisplayEventHandler : MonoBehaviour
{
    private MoneyDisplay _moneyDisplay;

    private void HandleEvent(object s, ChangeAmount changeAmount)
    {
        _moneyDisplay.DisplayNewValue((int)changeAmount.NewValue);
    }

    #region State Change Reactions

    private void OnDestroy()
    {
        PlayerWallet.OnBalanceChanged -= HandleEvent;
    }

    #endregion

    #region Initialization

    private void Awake()
    {
        TryGetComponent(out _moneyDisplay);
        PlayerWallet.OnBalanceChanged += HandleEvent;
    }

    #endregion
}
