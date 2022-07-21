using UnityEngine;

public abstract class ComboKillDisplay : MonoBehaviour
{
    [SerializeField] protected ComboEffect TransparencyChangerEffect;
    [SerializeField] protected ComboEffect TextTwistEffect;
    
    protected TextDisplayer TextDisplayer;

    public abstract void DisplayCombo(int killsAmount);
    
    #region Init

    protected virtual void Awake()
    {
        TryGetComponent(out TextDisplayer);
    }

    #endregion
}
