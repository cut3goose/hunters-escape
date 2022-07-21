using DG.Tweening;
using UnityEngine;

public class ColorChangeEffect : MonoBehaviour, IDamageEffect
{
    [SerializeField] private ColorTweenConfig fadeConfig;
    [SerializeField] private SkinnedMeshRenderer skinnedMesh;

    private Color _originalColor;
    private Tween _fadeTween;

    public void ActivateEffect()
    {
        ChangeColorToDesired();
    }
    
    public void ChangeColorToDesired()
    {
        var materials = skinnedMesh.materials;
        
        var material = materials[0];
        _originalColor = materials[0].color;
        
        FadeColor(material, fadeConfig.DesiredColor).OnComplete(ChangeToOriginalColor);
    }

    private void ChangeToOriginalColor()
    {
        var material = skinnedMesh.materials[0];
        FadeColor(material, _originalColor);
    }

    #region Main Actions

    private Tween FadeColor(Material tweenedMaterial, Color desiredColor)
    {
        _fadeTween = tweenedMaterial.DOColor(desiredColor, fadeConfig.Duration).SetEase(fadeConfig.Ease);
        return _fadeTween;
    }

    #endregion

    #region State Change Reactions

    private void OnDestroy()
    {
        _fadeTween.Kill();
    }

    #endregion
}