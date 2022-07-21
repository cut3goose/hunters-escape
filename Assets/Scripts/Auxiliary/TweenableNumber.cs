using DG.Tweening;

public class TweenableNumber
{
    public Tween Tween;
    public TweenMovementConfig ActivateConfig;
    public TweenMovementConfig DeactivateConfig;

    public TweenableNumber(TweenMovementConfig activateConfig, TweenMovementConfig deactivateConfig, float deactivateValue, float activatedValue)
    {
        ActivateConfig = activateConfig;
        DeactivateConfig = deactivateConfig;
    }

    public Tween DeactivateValue(float referenceValue)
    {
        return TweenValue(DeactivateConfig, referenceValue);
    }

    protected Tween TweenValue(TweenMovementConfig config, float desiredValue)
    {
        // Tween = DOTween.To(() => tweenedValue, x => tweenedValue = x, desiredValue, config.Duration)
        //     .SetEase(config.Ease);

        return Tween;
    }

    public void KillTween()
    {
        Tween.Kill();
    }

    public void ClearTween()
    {
        Tween = null;
    }
}
