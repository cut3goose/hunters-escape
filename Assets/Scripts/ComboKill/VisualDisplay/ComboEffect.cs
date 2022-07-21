using DG.Tweening;
using UnityEngine;

public abstract class ComboEffect : MonoBehaviour
{
    protected Tween EffectTween;
    
    public virtual Tween ActivateThenDeactivate()
    {
        return ActivateEffect().OnComplete(() => 
            DeactivateEffect());
    }
    
    public abstract Tween ActivateEffect();
    public abstract Tween DeactivateEffect();
    
    #region Auxiliary Actions

    protected void KillTween()
    {
        EffectTween.Kill();
        EffectTween = null;
    }

    #endregion
}
