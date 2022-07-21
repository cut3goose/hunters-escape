public abstract class LevelLoader : Singleton<LevelLoader>
{
    public abstract void LoadSuitableLevel();
    public abstract void LoadGuideLevel();
    public abstract void LoadRandomLevel();
    public abstract void LoadNextLevel();
    public abstract void RestartLevel();
}