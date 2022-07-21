using UnityEngine;

public class OnSpeedBoosterPickedEventHandler : OnCollectableCollectedEventHandler
{
    protected override void HandleEvent(object s, (Transform, GameObject) args)
    {
        var playerMovement = args.Item2.gameObject.GetComponent<PlayerMovement>();
        if (playerMovement)
        {
            playerMovement.EnableSpeedBoost();
        }
        
        base.HandleEvent(s, args);
    }
}
