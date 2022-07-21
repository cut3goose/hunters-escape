using UnityEngine;

public class TextureMovement : MonoBehaviour
{
    [SerializeField] private Renderer affectedRenderer;

    [SerializeField] private Vector2 direction;
    [SerializeField] private int materialId;
    [SerializeField] private float speed = 1f;
    
    private float _currentSpeed;

    public void Update()
    {
        affectedRenderer.materials[materialId].mainTextureOffset += direction * (_currentSpeed * Time.deltaTime);

        if (affectedRenderer.materials[materialId].mainTextureOffset.y >= 1f)
        {
            affectedRenderer.materials[materialId].mainTextureOffset = Vector2.zero;
        }
    }

    #region Init

    private void Awake()
    {
        _currentSpeed = speed;
    }

    #endregion
}
