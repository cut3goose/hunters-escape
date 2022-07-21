using DG.Tweening;
using UnityEngine;

public class TransformTwistEffect : ComboEffect
{
    [SerializeField] private Vector3 desiredRotation;
    [SerializeField] private TweenMovementConfig activationRotationConfig;
    [SerializeField] private TweenMovementConfig deactivationRotationConfig;

    private Vector3 _startRotation;
    
    public override Tween ActivateEffect()
    {
        return Rotate(activationRotationConfig, desiredRotation);
    }

    public override Tween DeactivateEffect()
    {
        return Rotate(deactivationRotationConfig, _startRotation);
    }

    #region Main Actions

    public Tween Rotate(TweenMovementConfig config, Vector3 newRotation)
    {
        KillTween();
        
        EffectTween = transform.DOLocalRotate(newRotation, config.Duration).SetEase(config.Ease);
        return EffectTween;
    }

    #endregion

    #region Init

    private void Awake()
    {
        _startRotation = transform.localRotation.eulerAngles;
    }

    #endregion
}
