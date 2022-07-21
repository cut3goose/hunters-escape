using UnityEngine;

public class LookAtInputSmooth : LookAtPositionSmooth
{
    private void Update()
    {
        LookAtInput();
    }

    private bool LookAtInput()
    {
        if (!PlayerInput.HasActiveInput) return false;
        
        var moveDirection = new Vector3(PlayerInput.Direction.x, 0, PlayerInput.Direction.y);
        var lookPosition = transform.position + moveDirection;

        LookAtPosition(lookPosition);

        return true;
    }
}
