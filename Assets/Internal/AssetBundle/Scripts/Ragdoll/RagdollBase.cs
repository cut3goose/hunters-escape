using System.Collections.Generic;
using UnityEngine;

public class RagdollBase : MonoBehaviour
{
    [SerializeField] protected GameObject SkinWithRagdoll;
    [SerializeField] protected Animator AnimatorToDisable;
    [SerializeField] protected RagdollConfig Config;

    protected List<Rigidbody> RagdollParts;

    public virtual void ChangeRagDollState(bool newState, bool disableAnimator = false)
    {
        TryChangeAnimatorState(disableAnimator);

        foreach (var selectedRigidbody in RagdollParts)
        {
            selectedRigidbody.constraints = CastConstraits(newState);
        }
    }

    public virtual void AddForce(Vector3 direction)
    {
        AddForce(direction, Config.DefaultForce, Config.DefaultForceMode);
    }
    
    public virtual void AddForce(Vector3 direction, int force, ForceMode desiredForceMode)
    {
        var desiredPushDirection = direction * force;

        foreach (var selectedRigidbody in RagdollParts)
        {
            if (!selectedRigidbody) continue;

            selectedRigidbody.AddForce(desiredPushDirection, desiredForceMode);
        }
    }

    #region Auxiliary Actions

    protected virtual void GetRagDollsFromSkin()
    {
        var rigidbodiesFromSkin = SkinWithRagdoll.GetComponentsInChildren<Rigidbody>();
        
        foreach (var selectedRigidbody in rigidbodiesFromSkin)
        {
            RagdollParts.Add(selectedRigidbody);
        }
    }

    protected void TryChangeAnimatorState(bool disableAnimator)
    {
        if (AnimatorToDisable && disableAnimator)
        {
            AnimatorToDisable.enabled = false;
        }
    }
    
    protected RigidbodyConstraints CastConstraits(bool newState)
    {
        return newState ? RigidbodyConstraints.None : RigidbodyConstraints.FreezeAll;
    }

    #endregion

    #region Fields Setting

    public void SetAnimator(Animator animator)
    {
        AnimatorToDisable = animator;
    }

    public void SetSkinWithRagdoll(GameObject skinWithRagdoll)
    {
        SkinWithRagdoll = skinWithRagdoll;
    }

    #endregion

    #region Initialization

    protected virtual void Start()
    {
        RagdollParts = new List<Rigidbody>();
        GetRagDollsFromSkin();

        if (Config.FreezeOnStart)
        {
            ChangeRagDollState(false);
        }
    }

    #endregion
}