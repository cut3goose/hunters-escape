using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Slider _hpSlider;

    public void SetNewValue(int newValue)
    {
        _hpSlider.value = newValue;
    }

    #region Fields Setting

    public void SetSliderLimits(int minValue, int maxValue)
    {
        _hpSlider.maxValue = maxValue;
        _hpSlider.minValue = minValue;
    }

    #endregion

    #region Initialization

    private void Awake()
    {
        TryGetComponent(out _hpSlider);
    }

    #endregion
}
