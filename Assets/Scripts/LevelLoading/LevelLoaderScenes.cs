using UnityEngine;
using UnityEngine.SceneManagement;
using static Globals;

public class LevelLoaderScenes : LevelLoader
{
    public override void LoadSuitableLevel()
    {
        Debug.Log(PassedLevelsAmountData.LevelsPassed);
        
        if (PassedLevelsAmountData.LevelsPassed == 0)
        {
            LoadGuideLevel();
        }
        else if (PassedLevelsAmountData.LevelsPassed < SceneManager.sceneCountInBuildSettings - 1)
        {
            Debug.Log($"passed {PassedLevelsAmountData.LevelsPassed}" +
                      $"\n available {SceneManager.sceneCountInBuildSettings}");
            
            LoadNextLevel();
        }
        else
        {
            LoadRandomLevel();
        }
    }

    public override void LoadNextLevel()
    {
        var currentSceneId = PassedLevelsAmountData.LevelsPassed;
        var nextLevelID = currentSceneId + 1;
        
        LoadScene(nextLevelID);
    }

    public override void LoadRandomLevel()
    {
        var currentSceneId = SceneManager.GetActiveScene().buildIndex;
        var randomSceneId = GetRandomSceneId(currentSceneId);

        LoadScene(randomSceneId);
    }

    public override void LoadGuideLevel()
    {
        LoadScene(GuideLevelID);
    }
    
    public override void RestartLevel()
    {
        var currentLevelID = SceneManager.GetActiveScene().buildIndex;
        LoadScene(currentLevelID);
    }

    #region Main Actions

    private void LoadScene(int nextLevelID)
    {
        SceneManager.LoadScene(nextLevelID);
    }

    #endregion

    #region Auxiliary Actions

    private int GetRandomSceneId(int currentSceneId)
    {
        while (true)
        {
            var randomSceneId = Random.Range(FirstLevelID, SceneManager.sceneCountInBuildSettings);

            if (randomSceneId != currentSceneId)
            {
                return randomSceneId;
            }
        }
    }


    #endregion
}
