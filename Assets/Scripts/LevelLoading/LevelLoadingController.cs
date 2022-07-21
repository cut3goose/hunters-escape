using UnityEngine;

public class LevelLoadingController : MonoBehaviour
{
    private void CallLevelLoading()
    {
        LevelLoader.Instance.LoadSuitableLevel();
    }

    #region Init

    private void Awake()
    {
        CallLevelLoading();
    }

    #endregion
}
