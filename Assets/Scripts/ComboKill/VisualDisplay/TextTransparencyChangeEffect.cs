using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static Globals;

public class TextTransparencyChangeEffect : ComboEffect
{
    [SerializeField] private TweenMovementConfig activationConfig;
    [SerializeField] private TweenMovementConfig deactivationConfig;
    
    [SerializeField] private TextMeshProUGUI comboText;

    public override Tween ActivateEffect()
    {
        return ChangeTransparency(MaxAlphaValue, activationConfig);
    }

    public override Tween DeactivateEffect()
    {
        return ChangeTransparency(0, deactivationConfig);
    }

    private Tween ChangeTransparency(float endTransparency, TweenMovementConfig config)
    {
        KillTween();

        EffectTween = comboText.DOFade(endTransparency, config.Duration).SetEase(config.Ease);
        return EffectTween;
    }

    #region Init

    private void Awake()
    {
        comboText.DOFade(0, 0);
    }

    #endregion
}
