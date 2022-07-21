using TMPro;
using UnityEngine;

public class MoneyDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text label;

    public void DisplayNewValue(int newValue)
    {
        var formattedValue = ValueFormatter.KiloFormat(newValue);
        label.text = formattedValue;
    }
}
