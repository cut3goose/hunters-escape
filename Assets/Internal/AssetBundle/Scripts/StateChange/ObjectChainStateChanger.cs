using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectChainStateChanger : MonoBehaviour
{
    public event EventHandler<bool> OnStateChanged;
    
    [SerializeField] private List<GameObject> gameObjectsChain;

    [SerializeField] private bool disableOnStart;
    [SerializeField] private bool disableOnAwake;

    public IEnumerator ChangeGameObjectsStatesWithDelay(bool newState, float delay)
    {
        yield return new WaitForSeconds(delay);
        ChangeGameObjectsStates(newState);
    }
    
    public void ChangeGameObjectsStates(bool newState)
    {
        foreach (var selectedGameObject in gameObjectsChain)
        {
            selectedGameObject.SetActive(newState);
        }

        NotifyObjectsStateChanged(newState);
    }

    #region Auxiliary

    private void NotifyObjectsStateChanged(bool newState)
    {
        OnStateChanged?.Invoke(this, newState);
    }

    #endregion
    
    #region Initialization

    private void Start()
    {
        if (disableOnStart)
        {
            ChangeGameObjectsStates(false);
        }
    }
    
    private void Awake()
    {
        if (disableOnAwake)
        {
            ChangeGameObjectsStates(false);
        }
    }

    #endregion
}
