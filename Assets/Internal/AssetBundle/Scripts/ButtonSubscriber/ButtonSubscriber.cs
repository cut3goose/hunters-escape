using UnityEngine;
using UnityEngine.UI;

// This script is used to explicitly assign classes with which this button works.
public abstract class ButtonSubscriber : MonoBehaviour
{
    protected Button Button;

    protected abstract void SubscribeOnClickEvent();
    
    protected virtual void Start()
    {
        TryGetComponent(out Button);
        SubscribeOnClickEvent();
    }
}
