using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class SpringTrapMovement : MonoBehaviour
{
    [SerializeField] private Transform affectedTransform;
    
    [SerializeField] private Vector3 desiredRotation;
    [SerializeField] private Vector3 desiredPosition;
    [SerializeField] private float reactivationDelay;
    [SerializeField] private TweenMovementConfig rotationConfig;
    [SerializeField] private TweenMovementConfig movementConfig;

    private Vector3 _startPosition;
    private Vector3 _startRotation;
    private Tween _rotationTween;
    private Tween _movementTween;

    public IEnumerator ReactivateWithDelay()
    {
        yield return new WaitForSeconds(reactivationDelay);
        
        Reactivate();
    }
    
    public void Activate()
    {
        RotateToDesiredRotation();
        MoveToDesiredPosition();
    }

    public void Reactivate()
    {
        RotateToStartRotation();
        MoveToStartPosition();
    }

    private void MoveToDesiredPosition()
    {
        _startPosition = affectedTransform.localPosition;
        Move(desiredPosition);
    }
    
    private void MoveToStartPosition()
    {
        Move(_startPosition);
    }
    
    private void RotateToDesiredRotation()
    {
        _startRotation = affectedTransform.localRotation.eulerAngles;
        Rotate(_startRotation + desiredRotation);
    }

    private void RotateToStartRotation()
    {
        Rotate(_startRotation);
    }

    #region Main Actions

    private Tween Rotate(Vector3 rotation)
    {
        _rotationTween = affectedTransform.DOLocalRotate(rotation, rotationConfig.Duration).SetEase(rotationConfig.Ease);
        return _rotationTween;
    }

    private Tween Move(Vector3 position)
    {
        _movementTween = affectedTransform.DOLocalMove(position, movementConfig.Duration).SetEase(movementConfig.Ease);
        return _movementTween;
    }

    #endregion
}
