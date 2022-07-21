using UnityEngine;

public class LookAtPlayerSmooth : LookAtPositionSmooth
{
    private void Update()
    {
        if (GameStateData.CurrentGameState != GameState.Running) return;
        
        var playerTransform = PlayerReferencesSingleton.Instance.PlayerTransform;
        var playerPosition = playerTransform.position;
        var lookPosition = new Vector3(playerPosition.x, transform.position.y, playerPosition.z);
        
        LookAtPosition(lookPosition);
    }
}
