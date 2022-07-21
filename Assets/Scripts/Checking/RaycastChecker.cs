using UnityEngine;

public class RaycastChecker : MonoBehaviour
{
    [SerializeField] protected Transform checkTransform;
    [SerializeField] protected RaycastConfig config;
    
    public virtual bool CheckForObstacle()
    {
        var isHit = Physics.Raycast(checkTransform.position, transform.forward, 
            config.CheckDistance, config.Masks);
        
        return isHit;
    }
}