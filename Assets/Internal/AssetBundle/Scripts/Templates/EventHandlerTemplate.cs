using System;
using UnityEngine;

public class EventHandlerTemplate : MonoBehaviour
{
    private void HandleEvent(object s, EventArgs args)
    {
    }

    #region State Change Reactions

    private void OnDestroy()
    {
        
    }

    #endregion
    
    #region Initialization

    private void Awake()
    {
    }

    #endregion
}
