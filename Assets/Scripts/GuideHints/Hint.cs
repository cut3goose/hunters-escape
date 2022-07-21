using Cinemachine;
using UnityEngine;
using static Globals;

public class Hint : MonoBehaviour
{
    [SerializeField] private bool activateOnStart;
    
    [SerializeField] private CinemachineVirtualCamera relatedCamera;
    [SerializeField] private ObjectChainStateChanger relatedScreen;

    public void ActivateHint()
    {
        relatedScreen.ChangeGameObjectsStates(true);
        relatedCamera.Priority = ActiveCameraPriority;
    }
    
    public void DeactivateHint()
    {
        relatedScreen.ChangeGameObjectsStates(false);
        relatedCamera.Priority = InactiveCameraPriority;
    }

    #region Init

    private void Start()
    {
        if (activateOnStart)
        {
            ActivateHint();
        }
    }

    #endregion
}
