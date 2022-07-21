using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using static Globals;

public class KillsPointer : MonoBehaviour
{
    [SerializeField] private KillsPointerConfig blinkingConfig;

    private RawImage _rawImage;
    private int _blinksCompleted;

    public void StartBlinking()
    {
        FadeIn();
    }

    private void FadeIn()
    {
        var desiredColor = _rawImage.color;
        desiredColor.a = MaxAlphaValue;

        _rawImage.DOColor(desiredColor, blinkingConfig.Duration).OnComplete(FadeOut);
    }

    private void FadeOut()
    {
        var desiredColor = _rawImage.color;
        desiredColor.a = 0;

        _rawImage.DOColor(desiredColor, blinkingConfig.Duration).OnComplete(()=>
        {
            _blinksCompleted++;
            if (_blinksCompleted < blinkingConfig.BlinksAmount)
            {
                FadeIn();
            }
        });
    }

    #region Auxiliary Actions

    private void SetTransparentColor()
    {
        var changedColor = _rawImage.color;
        changedColor.a = 0;
            
        _rawImage.color = changedColor;
    }

    #endregion

    #region Init

    private void Awake()
    {
        TryGetComponent(out _rawImage);
        SetTransparentColor();
    }

    #endregion
}