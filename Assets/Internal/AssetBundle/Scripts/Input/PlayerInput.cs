using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public static Vector2 Direction { get; private set; }
    public static float MoveSpeed { get; private set; }
    public static bool HasActiveInput { get; private set; }
    
    [SerializeField] private Joystick dynamicJoystick;

    private void Update()
    {
        HasActiveInput = TryGetActiveInput();
        
        if (GameStateData.CurrentGameState != GameState.Running) return;
        
        Direction = TryGetJoystickInput();
        MoveSpeed = GetMoveSpeed();
    }

    #region Available Actions

    private float GetMoveSpeed()
    {
        var absDirectionX = Mathf.Abs(Direction.x);
        var absDirectionY = Mathf.Abs(Direction.y);

        if (absDirectionX >= absDirectionY)
        {
            return Direction.x;
        }

        return Direction.y;
    }
    
    private Vector2 TryGetJoystickInput()
    {
        return dynamicJoystick.Direction;
    }

    private bool TryGetActiveInput()
    {
        var isInputNotZero = dynamicJoystick.Direction.x != 0 || dynamicJoystick.Direction.y != 0;
        return isInputNotZero;
    }

    #endregion

    #region Fields Setting

    public void TrySetJoystick(Joystick newJoystick)
    {
        dynamicJoystick = newJoystick;
    }

    #endregion
}
