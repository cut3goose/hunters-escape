using UnityEngine;

public class EnemyMovement : CharacterMovement
{
    [field:SerializeField] public RaycastChecker UnderCharacterChecker { get; protected set; }
    [field:SerializeField] public RaycastChecker FrontPlayerChecker { get; protected set; }
    [field:SerializeField] public DistanceSpeedUpConfig DistanceSpeedUpConfig { get; protected set; }
    
    [SerializeField] protected StopDistanceConfig StopDistanceConfig;
    [SerializeField] protected ClimbSpeedConfig ClimbSpeedSlowDownConfig;
    [SerializeField] protected ClimbSpeedConfig MovementSpeedSlowDownConfig;

    public float CurrentClimbingSpeed { get; protected set; }

    protected override void Update()
    {
        base.Update();
        new JumpMovementCommand(this).Execute();
        
        if (!IsActive) return;

        if (new EnemyClimbMovementCommand(this).Execute()) return;
        new EnemyRunMovementCommand(this).Execute();
    }

    #region Movement Actions

    public override void Run()
    {
        if (!CheckIfCanMove()) return;
        
        var moveDirection = transform.forward;
        var motion = moveDirection * (CurrentMovementSpeed * CurrentSpeedBoost * Time.deltaTime);

        CharacterController.Move(motion);
    }

    public override void Climb()
    {
        var motion = Vector3.up * (CurrentClimbingSpeed * Time.deltaTime);
        CharacterController.Move(motion);
    }

    #endregion

    #region Speed Change

    public void SlowDownClimbingSpeed()
    {
        CurrentClimbingSpeed = ClimbSpeedSlowDownConfig.SlowedClimbSpeed;
    }
    
    public void SpeedUpClimbingSpeed()
    {
        CurrentClimbingSpeed = MovementConfig.ClimbingSpeed;
    }

    public void SlowDownRunSpeed()
    {
        CurrentMovementSpeed = MovementSpeedSlowDownConfig.SlowedClimbSpeed;
    }

    public override void EnableSpeedBoost()
    {
        CurrentMovementSpeed = DistanceSpeedUpConfig.BoostedSpeed;
    }

    #endregion

    #region Auxiliary Actions

    protected virtual bool CheckIfCanMove()
    {
        var playerTransform = PlayerReferencesSingleton.Instance.PlayerTransform;
        var distance = Vector3.Distance(transform.position, playerTransform.position);
        return distance > StopDistanceConfig.StopDistance;
    }

    #endregion

    #region Init

    protected override void Awake()
    {
        base.Awake();
        CurrentClimbingSpeed = MovementConfig.ClimbingSpeed;
        OnSpeedBoostEnded += (sender, args) => { DisableSpeedBoost(); };
    }

    #endregion
}