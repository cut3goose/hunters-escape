using UnityEngine;

public class SceneJoystickSetter : MonoBehaviour
{
    private PlayerInput _playerInput;

    private void TrySetJoystick()
    {
        var joystick = FindObjectOfType<Joystick>();
        _playerInput.TrySetJoystick(joystick);
    }
    
    #region Initialization

    private void Awake()
    {
        TryGetComponent(out _playerInput);
        TrySetJoystick();
    }

    #endregion
}
