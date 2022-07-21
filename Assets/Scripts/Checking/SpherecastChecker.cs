using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpherecastChecker : RaycastChecker
{
    public override bool CheckForObstacle()
    {
        return RaycastHelper.CheckSpherePresence<MonoBehaviour>(transform.position, config.CheckDistance, config.Masks);
    }
}
