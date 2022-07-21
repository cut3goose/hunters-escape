using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnSpeedBoostEnableStartEventHandler : MonoBehaviour
{
    private CameraEffects _cameraEffects;
    private PlayerMovement _playerMovement;
    
    private void HandleEvent(object s, EventArgs args)
    {
        _cameraEffects.EnableSpeedBoostEffect();
    }

    #region State Change Reactions

    private void OnDestroy()
    {
        _playerMovement.OnSpeedBoostEnableStarted -= HandleEvent;
    }

    #endregion
    
    #region Initialization

    private void Awake()
    {
        TryGetComponent(out _playerMovement);
        _playerMovement.OnSpeedBoostEnableStarted += HandleEvent;

        _cameraEffects = FindObjectOfType<CameraEffects>();
    }

    #endregion
}
