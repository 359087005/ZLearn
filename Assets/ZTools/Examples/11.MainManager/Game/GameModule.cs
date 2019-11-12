using UnityEngine;
using UnityEngine.SceneManagement;
using ZTools;


public class GameModule : MainManager
{
    public static void LoadModule()
    {
        SceneManager.LoadScene("Game");
    }

    protected override void LaunchInDevelopMode()
    {
        Debug.Log("LaunchInDevelopMode");
    }

    protected override void LaunchInProductionMode()
    {
        Debug.Log("LaunchInProductionMode");
    }

    protected override void LaunchInTestMode()
    {
        Debug.Log("LaunchInTestMode");
    }
}