using UnityEngine;
namespace ZTools
{
    public enum EnvironmentMode
    { 
        Develop,
        Test,
        Production
    }
    public abstract class MainManager : MonoBehaviour
    {
       public  EnvironmentMode mode;
        private static EnvironmentMode shareMode;
        private static bool isModeSetted = false;


        private void Start()
        {
            if(!isModeSetted)
            {
                shareMode = mode;
                isModeSetted = true;
            }
            switch (shareMode)
            {
                case EnvironmentMode.Develop:
                    LaunchInDevelopMode();
                    break;
                case EnvironmentMode.Test:
                    LaunchInTestMode();
                    break;
                case EnvironmentMode.Production:
                    LaunchInProductionMode();
                    break;
                default:
                    break;
            }
        }

        protected abstract void LaunchInDevelopMode();
        protected abstract void LaunchInTestMode();
        protected abstract void LaunchInProductionMode();
    }
}
