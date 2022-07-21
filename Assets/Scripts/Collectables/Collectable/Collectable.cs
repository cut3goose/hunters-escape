using System;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public event EventHandler<(Transform, GameObject)> OnCollectablePicked;

    public void PickCollectable(GameObject collector)
    {
        NotifyCollectablePicked(collector);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(Globals.PlayerTag)) return;

        PickCollectable(other.gameObject);
    }

    #region Auxiliary Actions

    private void NotifyCollectablePicked(GameObject collector)
    {
        OnCollectablePicked?.Invoke(this, (transform, collector));
    }

    #endregion
}