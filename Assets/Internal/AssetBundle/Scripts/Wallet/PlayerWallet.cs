using System;
using UnityEngine;

public static class PlayerWallet
{
    public static event EventHandler<ChangeAmount> OnBalanceChanged;
    public static int CurrentBalance { get; private set; }

    public static bool TryChangeWalletBalance(int amountToChange)
    {
        if (CurrentBalance + amountToChange < 0)
        {
            Debug.Log("Operation can not be processed");
            return false;
        }

        var oldBalance = CurrentBalance;
        CurrentBalance += amountToChange;
        
        NotifyBalanceChanged(oldBalance);
        return true;
    }
    
    public static void SetBalance(int newBalance)
    {
        CurrentBalance = newBalance;
        NotifyBalanceChanged(CurrentBalance);
    }

    #region Auxiliary

    private static void NotifyBalanceChanged(int oldBalance)
    {
        Debug.Log("Balance was changed");

        var args = new ChangeAmount(oldBalance, CurrentBalance);
        OnBalanceChanged?.Invoke(null, args);
    }

    #endregion
}