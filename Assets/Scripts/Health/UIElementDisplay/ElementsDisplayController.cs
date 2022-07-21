using System.Collections.Generic;
using UnityEngine;

public class ElementsDisplayController : MonoBehaviour
{
    [SerializeField] private List<ElementDisplay> Displays;
    
    public void DisplayElements(int amount)
    {
        for (int i = 0; i < Displays.Count; i++)
        {
            var selectedDisplay = Displays[i];
            
            if (i < amount)
            {
                selectedDisplay.EnableDisplay();
            }
            else
            {
                selectedDisplay.DisableDisplay();
            }
        }
    }
}