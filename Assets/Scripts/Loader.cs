using UnityEngine.SceneManagement;

public static class SceneLoader 
{
    public enum Scenes
    {
        MainMenuScene,
        GamePlayScene,
    }

    public static void Load(Scenes targetScene)
    {
        SceneManager.LoadScene(targetScene.ToString());
    }
}
