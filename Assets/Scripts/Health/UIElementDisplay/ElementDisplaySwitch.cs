using UnityEngine;

public class ElementDisplaySwitch : ElementDisplay
{
    [SerializeField] private GameObject enabledDisplay;
    [SerializeField] private GameObject disabledDisplay;
    
    public override void EnableDisplay()
    {
        enabledDisplay.SetActive(true);
        disabledDisplay.SetActive(false);
    }

    public override void DisableDisplay()
    {
        disabledDisplay.SetActive(true);
        enabledDisplay.SetActive(false);
    }
}
