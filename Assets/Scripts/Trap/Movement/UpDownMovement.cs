using DG.Tweening;
using UnityEngine;

public class UpDownMovement : MonoBehaviour, ITrapMovement
{
    [Header("Moved Part")] 
    [SerializeField] private Transform movedPart;

    [Header("Unique Params")]
    [SerializeField] private bool activateOnStart;
    [SerializeField] private float startDelay;

    [Header("Movement Params")] 
    [SerializeField] private Transform upperPoint;
    [SerializeField] private Transform lowerPoint;
    [SerializeField] private TweenMovementConfig upMovementConfig;
    [SerializeField] private FreezeTweenMovementConfig downMovementConfig;
    
    private Tween _movementTween;

    public void ActivateTrapMovement()
    {
        if (_movementTween != null) return;
        
        MoveDown(false).OnComplete(() =>
        {
            MoveUp(false).OnComplete(KillMovementTween);
        });
    }

    private Tween MoveDown(bool triggerReverseMovement = true)
    {
        return Move(lowerPoint.position, downMovementConfig)
            .SetDelay(downMovementConfig.FreezeTime)
            .OnComplete(() =>
            {
                if (triggerReverseMovement)
                {
                    MoveUp();
                }
            });
    }

    private Tween MoveUp(bool triggerReverseMovement = true)
    {
        return Move(upperPoint.position, upMovementConfig).OnComplete(() =>
        {
            if (triggerReverseMovement)
            {
                MoveDown();
            }
        });
    }

    #region Main Actions

    private Tween Move(Vector3 destination, TweenMovementConfig relatedConfig)
    {
        KillMovementTween();
        _movementTween = movedPart.DOMove(destination, relatedConfig.Duration).SetEase(relatedConfig.Ease);
        
        return _movementTween;
    }

    #endregion

    #region Auxiliary Actions

    private void KillMovementTween()
    {
        _movementTween.Kill();
        _movementTween = null;
    }

    #endregion

    #region State Change Reactions

    private void OnDestroy()
    {
        KillMovementTween();
    }

    #endregion
    
    #region Init

    private void Awake()
    {
        movedPart.position = upperPoint.position;

        if (activateOnStart)
        {
            Invoke(nameof(MoveDown), startDelay);
        }
    }

    #endregion
}