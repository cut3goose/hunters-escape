using Cinemachine;
using DG.Tweening;
using UnityEngine;

public class CameraEffects : MonoBehaviour
{
    [SerializeField] private CameraSpeedBoostEffectConfig speedEffectConfig;
    
    private CinemachineVirtualCamera _camera;
    private Tween _speedBoostEffectTween;
    private Tween _speedBoostDisableEffectTween;
    
    public void EnableSpeedBoostEffect()
    {
        _speedBoostEffectTween?.Kill();
        _speedBoostDisableEffectTween?.Kill();
        
        var enableProgress = 1 - (_camera.m_Lens.FieldOfView / speedEffectConfig.BoostedFOV);
        var enableTime = speedEffectConfig.EffectEnableTime * enableProgress;
        
        _speedBoostEffectTween = DOTween.To(() => _camera.m_Lens.FieldOfView, x => _camera.m_Lens.FieldOfView = x, 
                speedEffectConfig.BoostedFOV, enableTime)
            .SetEase(speedEffectConfig.EnableEase)
            .OnComplete(DisableSpeedBoostEffect);
    }

    protected void DisableSpeedBoostEffect()
    {
        _speedBoostDisableEffectTween = DOTween.To(() => _camera.m_Lens.FieldOfView, x => _camera.m_Lens.FieldOfView = x, 
                speedEffectConfig.DefaultFOV, speedEffectConfig.EffectDisableTime)
            .SetEase(speedEffectConfig.DisableEase);
    }

    #region Init

    private void Awake()
    {
        TryGetComponent(out _camera);
    }

    #endregion
}