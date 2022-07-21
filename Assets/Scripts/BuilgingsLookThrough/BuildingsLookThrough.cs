using UnityEngine;

public class BuildingsLookThrough : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float searchDistanceOffset;

    private TransparentMaterialsActivator _disabledRenderer;

    private void Update()
    {
        if (GameStateData.CurrentGameState != GameState.Running) return;
        
        var searchDistance = GetSearchDistance();
        var foundRenderer = RaycastHelper.TryFindObject<TransparentMaterialsActivator>(
            mainCamera.transform.position + offset, mainCamera.transform.forward, 
            searchDistance + searchDistanceOffset, Globals.WallLayerMask);

        if (foundRenderer)
        {
            ChangeVisibility(foundRenderer, false);
            
            if (_disabledRenderer && _disabledRenderer != foundRenderer)
            {
                ChangeVisibility(_disabledRenderer, true);
            }

            _disabledRenderer = foundRenderer;
        }
        else
        {
            if (_disabledRenderer)
            {
                ChangeVisibility(_disabledRenderer, true);
                _disabledRenderer = null;
            }
        }
    }

    private void ChangeVisibility(TransparentMaterialsActivator transparencyActivator, bool newState)
    {
        transparencyActivator.ChangeVisibilityState(newState);
    }

    #region Auxiliary Actions

    private float GetSearchDistance()
    {
        var playerPosition = PlayerReferencesSingleton.Instance.PlayerTransform.position;
        var cameraPosition = mainCamera.transform.position;

        var distance = Vector3.Distance(playerPosition, cameraPosition);
        return distance;
    }

    #endregion
}
