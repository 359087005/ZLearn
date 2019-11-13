using UnityEngine;
namespace ZTools
{
    public class GUIExample : MonoBehaviourSimplify
    {
        protected override void BeforeDestroy()
        {

        }

#if UNITY_EDITOR
        [UnityEditor.MenuItem("ZTools/Example/GUIManager", false, 11)]
        static void MenuClick()
        {
            UnityEditor.EditorApplication.isPlaying = true;

            new GameObject("GUIExample").AddComponent<GUIExample>();
        }
#endif


        private void Start()
        {
            GUIManager.SetResolution(1280,720,0);

          var panel =   GUIManager.LoadPanel("HomePanel",UILayer.Common);

            Delay(3,()=>
            {
                GUIManager.UnLoadPanel("HomePanel");
            });
        }
    }
}
