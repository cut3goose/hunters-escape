using System;
using UnityEngine;

public class OnMaterialTranparencyChangedEventHandler : MonoBehaviour
{
    private ObjectChainStateChanger _objectChain;
    
    private TransparentMaterialsActivator _transparentMaterialsActivator;
    
    private void HandleEvent(object s, bool newState)
    {
        _objectChain.ChangeGameObjectsStates(newState);
    }

    #region State Change Reactions

    private void OnDestroy()
    {
        _transparentMaterialsActivator.OnMaterialTransparencyChanged -= HandleEvent;
    }

    #endregion
    
    #region Initialization

    private void Awake()
    {
        TryGetComponent(out _objectChain);
        TryGetComponent(out _transparentMaterialsActivator);
        _transparentMaterialsActivator.OnMaterialTransparencyChanged += HandleEvent;
    }

    #endregion
}
