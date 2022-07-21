using UnityEngine;

public class SkinFieldsForRagdollSetter : MonoBehaviour
{
    private void OnEnable()
    {
        var animator = GetComponent<Animator>();
        var ragdoll = GetComponentInParent<RagdollBase>();
        
        ragdoll.SetAnimator(animator);
        ragdoll.SetSkinWithRagdoll(animator.gameObject);
    }
}
