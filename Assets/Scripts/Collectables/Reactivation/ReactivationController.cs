using System;
using System.Threading.Tasks;
using UnityEngine;

public class ReactivationController : MonoBehaviour
{
    [SerializeField] private ReactivationConfig config;

    private bool _isDestroyed;

    private void OnDisable()
    {
        Reactivate();
    }
    
    public async void Reactivate()
    {
        await Task.Delay(config.ReactivationTimeMilliseconds);

        if (!_isDestroyed)
        {
            gameObject.SetActive(true);
        }
    }

    #region State Change Reactions

    private void OnDestroy()
    {
        _isDestroyed = true;
    }

    #endregion
}