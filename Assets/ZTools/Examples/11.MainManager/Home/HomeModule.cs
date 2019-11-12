using UnityEngine;
using ZTools;

public class HomeModule : MainManager
{
    protected override void LaunchInDevelopMode()
    {
        Debug.Log("LaunchInDevelopMode");
    }

    protected override void LaunchInProductionMode()
    {
        
    }

    protected override void LaunchInTestMode()
    {
        GameModule.LoadModule();
    }
}