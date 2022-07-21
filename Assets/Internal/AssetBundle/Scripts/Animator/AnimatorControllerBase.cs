using UnityEngine;

public class AnimatorControllerBase : MonoBehaviour
{
    [SerializeField] protected Animator Animator;

    protected void SetOnlyTrigger(string triggerName)
    {
        foreach (var selectedParameter in Animator.parameters)
        {
            if (selectedParameter.type != AnimatorControllerParameterType.Trigger) continue;

            SetTrigger(selectedParameter.name, selectedParameter.name == triggerName);
        }
    }
    
    protected void SetTrigger(string triggerName, bool newState)
    {
        if (newState)
        {
            Animator.SetTrigger(triggerName);
        }
        else
        {
            Animator.ResetTrigger(triggerName);
        }
    }

    protected void SetBool(string boolName, bool newState)
    {
        Animator.SetBool(boolName, newState);
    }

    protected void SetFloat(string floatName, float newValue)
    {
        Animator.SetFloat(floatName, newValue);
    }

    protected void SetInt(string intName, int newValue)
    {
        Animator.SetInteger(intName, newValue);
    }

    protected void SetAnimatorSpeed(float newSpeed)
    {
        Animator.speed = newSpeed;
    }
}
