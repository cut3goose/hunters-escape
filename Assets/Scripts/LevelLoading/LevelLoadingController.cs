using UnityEngine;

public class LevelLoadingController : MonoBehaviour
{
    public void CallLevelLoading()
    {
        LevelLoader.Instance.LoadSuitableLevel();
    }

    public void CallMainMenuLoading()
    {
        LevelLoader.Instance.LoadMainMenu();
    }
}
