using UnityEngine;

public class OnZeroHealthCharacterEventHandler : MonoBehaviour
{
    [SerializeField] protected DisableConfig DisableConfig;
    [SerializeField] protected LookAtPositionSmooth SmoothRotation;
    protected CharacterMovement CharacterMovement;

    protected Health Health;

    protected virtual void HandleEvent(object s, (Vector3, DamageType) args)
    {
        CharacterMovement.ChangeActiveState(false);
        SmoothRotation.SetNewActivityState(false);
        
        Destroy(gameObject, DisableConfig.DisableDelay);
    }

    #region State Change Reactions

    protected virtual void OnDestroy()
    {
        Health.OnZeroHealth -= HandleEvent;
    }

    #endregion
    
    #region Initialization

    protected virtual void Awake()
    {
        TryGetComponent(out Health);
        Health.OnZeroHealth += HandleEvent;

        TryGetComponent(out CharacterMovement);
    }

    #endregion
}