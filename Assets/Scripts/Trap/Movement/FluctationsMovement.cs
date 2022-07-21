using DG.Tweening;
using UnityEngine;

public class FluctationsMovement : MonoBehaviour
{
    public Vector3 MovementDirection { get; private set; }
    
    [SerializeField] private Vector3 desiredRotation;
    [SerializeField] private float startDelay;
    [SerializeField] private TweenMovementConfig rotationConfig;
    
    private Vector3 _startRotation;
    private Tween _movementTween;

    private void RotateToDesiredRotation()
    {
        Rotate(desiredRotation).OnComplete(RotateToStartRotation);
        MovementDirection = transform.right;
    }

    private void RotateToStartRotation()
    {
        Rotate(_startRotation).OnComplete(RotateToDesiredRotation);
        MovementDirection = -transform.right;
    }

    #region Main Actions

    private Tween Rotate(Vector3 rotation)
    {
        _movementTween = transform.DORotate(rotation, rotationConfig.Duration).SetEase(rotationConfig.Ease);
        return _movementTween;
    }

    #endregion

    #region State Change Reactions

    private void OnDestroy()
    {
        _movementTween.Kill();
        _movementTween = null;
    }

    #endregion
    
    #region Init

    private void Awake()
    {
        _startRotation = transform.rotation.eulerAngles;
        Invoke(nameof(RotateToDesiredRotation), startDelay);
    }

    #endregion
}
