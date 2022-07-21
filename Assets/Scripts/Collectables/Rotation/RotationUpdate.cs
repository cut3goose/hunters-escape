using UnityEngine;

public class RotationUpdate : MonoBehaviour
{
    [SerializeField] private CollectableRotationConfig rotationConfig;
    
    private void Update()
    {
        var rotationSpeed = rotationConfig.RotationSpeed * Time.deltaTime;
        var rotationAxis = rotationConfig.RotationAxis * rotationSpeed;

        var newRotation = transform.localRotation.eulerAngles + rotationAxis;
        transform.localRotation = Quaternion.Euler(newRotation);
    }
}