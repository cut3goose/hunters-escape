using UnityEngine;

public class GameActivationController : MonoBehaviour
{
    private void Update()
    {
        if (!PlayerInput.HasActiveInput) return;
        
        GameStateData.TrySetNewGameState(GameState.Running);
        Destroy(this);
    }
}
