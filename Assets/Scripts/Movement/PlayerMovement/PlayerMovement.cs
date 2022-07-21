using System.Collections;
using UnityEngine;

public class PlayerMovement : CharacterMovement
{
    public float KnockBackProgress { get; protected set; }

    [SerializeField] protected KnockbackConfig KnockbackConfig;

    // Knocback
    protected Vector3 EndPosition;
    protected Vector3 StartPosition;

    protected override void Update()
    {
        if (new PlayerKnockBackMovementCommand(this).Execute()) return;
        new PlayerJumpMovementCommand(this).Execute();
        base.Update();
        
        if (!IsActive) return;

        if (new ClimbMovementCommand(this).Execute()) return;
        new PlayerRunMovementCommand(this).Execute();
    }

    public override void Run()
    {
        var moveDirection = new Vector3(PlayerInput.Direction.x, 0, PlayerInput.Direction.y);
        if (moveDirection != Vector3.zero)
        {
            moveDirection = moveDirection.normalized;
        }
        
        var motion = moveDirection * (MovementConfig.MovementSpeed * CurrentSpeedBoost * Time.deltaTime);

        CharacterController.Move(motion);
    }

    #region KnockBack

    public IEnumerator StartKnockBack(Vector3 knockBackDirection)
    {
        if (LastMovementType == MovementType.Knockback) yield break;

        KnockBackProgress = 0;
        StartPosition = transform.position;
        EndPosition = transform.position + (knockBackDirection * KnockbackConfig.DirectionMultiplier);
        SetLastMovementType(MovementType.Knockback);
    }

    public void KnockBackUpdate()
    {
        KnockBackProgress += KnockbackConfig.Speed * Time.deltaTime;
        KnockBackProgress = Mathf.Clamp01(KnockBackProgress);

        var nextPosition = MathParabola.Parabola(StartPosition, EndPosition, KnockbackConfig.Height, KnockBackProgress);
        var motion = nextPosition - transform.position;

        CharacterController.Move(motion);
    }

    #endregion

    #region Init

    protected override void Awake()
    {
        base.Awake();
        OnSpeedBoostEnded += (sender, args) => { DisableSpeedBoost(); };
    }

    #endregion
}