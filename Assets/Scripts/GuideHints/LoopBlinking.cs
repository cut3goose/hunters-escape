using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using static Globals;

public class LoopBlinking : MonoBehaviour
{
    [SerializeField] private TweenMovementConfig blinkingConfig;
    [SerializeField] private RawImage blinkedImage;
    
    protected Tween EffectTween;
    
    public Tween ActivateEffect()
    {
        return ChangeTransparency(MaxAlphaValue, blinkingConfig).OnComplete(()=>DeactivateEffect());
    }

    public Tween DeactivateEffect()
    {
        return ChangeTransparency(0, blinkingConfig).OnComplete(()=>ActivateEffect());
    }

    private Tween ChangeTransparency(float endTransparency, TweenMovementConfig config)
    {
        KillTween();

        var desiredColor = Color.white;
        desiredColor.a = endTransparency;
        
        EffectTween = blinkedImage.DOColor(desiredColor, config.Duration).SetEase(config.Ease);
        return EffectTween;
    }

    #region Auxiliary Actions

    protected void KillTween()
    {
        EffectTween.Kill();
        EffectTween = null;
    }

    #endregion

    #region Init

    private void Awake()
    {
        blinkedImage.DOFade(0, 0);
        ActivateEffect();
    }

    #endregion
}
