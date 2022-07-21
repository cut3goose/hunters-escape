using System.Collections.Generic;
using UnityEngine;

public class ChildrenDetacher : MonoBehaviour
{
    [SerializeField] private List<Transform> visuals;
    [SerializeField] private DisableConfig disableConfig;

    public void TryDetachChildren()
    {
        if (visuals == null)
        {
            Debug.LogWarning("Missing components");
            return;
        }

        foreach (var selectedVisual in visuals)
        {
            if (!selectedVisual) continue;
            
            selectedVisual.SetParent(null);
            Destroy(selectedVisual.gameObject, disableConfig.DisableDelay);
        }
    }
}
