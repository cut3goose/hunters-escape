using UnityEngine;

public static class Globals
{
    public static Camera MainCamera { get; private set; } = Camera.main;

    #region Scene ID

    public const int GuideLevelID = 1;
    public const int FirstLevelID = 2;

    #endregion
    
    #region Values

    public const int DefaultMoneyPickAmount = 10;
    public const int MinMoneyPickAmount = 1;
    public const int ActiveCameraPriority = 100;
    public const int InactiveCameraPriority = 1;
    public const float MaxAlphaValue = 1f;

    #endregion
    
    #region Layer Masks

    public static LayerMask PlayerLayerMask { get; private set; } = LayerMask.GetMask("Player");
    public static LayerMask EnemyLayerMask { get; private set; } = LayerMask.GetMask("Enemy");
    public static LayerMask WallLayerMask { get; private set; } = LayerMask.GetMask("Wall");

    #endregion

    #region Animation Triggers

    public static string RunTrigger { get; private set; } = "RunTrigger";
    public static string JumpTrigger { get; private set; } = "JumpTrigger";
    public static string JumpEndTrigger { get; private set; } = "JumpEndTrigger";
    public static string FallTrigger { get; private set; } = "FallTrigger";
    public static string FallEndTrigger { get; private set; } = "FallEndTrigger";
    public static string ClimbTrigger { get; private set; } = "ClimbTrigger";
    public static string ClimbEndTrigger { get; private set; } = "ClimbEndTrigger";
    public static string IdleTrigger { get; private set; } = "IdleTrigger";
    public static string CheeringTrigger { get; private set; } = "CheeringTrigger";
    public static string MovementSpeedAnimatorFloat { get; private set; } = "MovementSpeed";

    #endregion

    #region Tags

    public const string PlayerTag = "Player";

    #endregion
}
