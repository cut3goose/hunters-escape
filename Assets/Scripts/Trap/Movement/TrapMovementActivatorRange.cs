using System;
using UnityEngine;
using static Globals;

public class TrapMovementActivatorRange : MonoBehaviour
{
    private ITrapMovement _trapMovement;

    private void OnTriggerEnter(Collider other)
    {
        var isPresenceFound = other.CompareTag(PlayerTag);
        if (isPresenceFound)
        {
            _trapMovement.ActivateTrapMovement();
        }
    }

    #region Init

    private void Awake()
    {
        TryGetComponent(out _trapMovement);
    }

    #endregion
}
