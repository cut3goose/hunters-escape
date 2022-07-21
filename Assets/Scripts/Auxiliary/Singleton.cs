using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Component
{
    #region Accessors
    public static T Instance { get; private set; }
    #endregion

    #region Unity Calls
    protected virtual void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);

        else
            Instance = this as T;
    }
    #endregion
}