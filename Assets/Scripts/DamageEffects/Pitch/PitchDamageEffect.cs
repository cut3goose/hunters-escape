using DG.Tweening;
using UnityEngine;

public class PitchDamageEffect : MonoBehaviour, IDamageEffect
{
    [SerializeField] private Transform affectedTransform;
    [SerializeField] private DamagePitchConfig damagePitchConfig;
    [SerializeField] private DamagePitchConfig deathPitchConfig;

    private Vector3 _startRotation;
    private Tween _movementTween;
    
    public void ActivateEffect()
    {
        RotateToDesiredRotation();
    }

    public void ActivateDeathPitchEffect()
    {
        KillTween();
        Rotate(deathPitchConfig.Pitch);
    }
    
    public void RotateToDesiredRotation()
    {
        if (_movementTween != null) return;

        _startRotation = affectedTransform.localRotation.eulerAngles;
        Rotate(damagePitchConfig.Pitch + _startRotation).OnComplete(RotateToStartRotation);
    }

    private void RotateToStartRotation()
    {
        Rotate(_startRotation).OnComplete(NullMovementTween);
    }

    #region Main Actions

    private Tween Rotate(Vector3 rotation)
    {
        _movementTween = affectedTransform.DOLocalRotate(rotation, damagePitchConfig.Duration).SetEase(damagePitchConfig.Ease);
        return _movementTween;
    }

    #endregion

    #region State Change Reactions

    private void OnDestroy()
    {
        KillTween();
    }

    #endregion

    #region Auxiliary Actions

    private void KillTween()
    {
        _movementTween.Kill();
        _movementTween = null;
    }

    private void NullMovementTween()
    {
        _movementTween = null;
    }

    #endregion
}