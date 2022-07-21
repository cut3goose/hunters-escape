using System;
using UnityEngine;

public class OnCollectableCollectedEventHandler : MonoBehaviour
{
    [SerializeField] private ParticleSystem pickParticles;

    private ChildrenDetacher _childrenDetacher;
    
    private Collectable _collectable;
    
    protected virtual void HandleEvent(object s, (Transform, GameObject) args)
    {
        if (_childrenDetacher)
        {
            _childrenDetacher.TryDetachChildren();
        }
        
        gameObject.SetActive(false);
        TryPlayParticles();
    }

    private void TryPlayParticles()
    {
        if (pickParticles)
        {
            pickParticles.Play();
        }
    }
    
    #region State Change Reactions

    private void OnDestroy()
    {
        _collectable.OnCollectablePicked -= HandleEvent;
    }

    #endregion
    
    #region Initialization

    protected virtual void Awake()
    {
        TryGetComponent(out _collectable);
        _collectable.OnCollectablePicked += HandleEvent;

        TryGetComponent(out _childrenDetacher);
    }

    #endregion
}
