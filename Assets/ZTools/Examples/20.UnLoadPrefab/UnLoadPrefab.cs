
using UnityEngine;
namespace ZTools
{
    /// <summary>
    /// Resources.UnloadUnusedAssets();
    /// </summary>
    public class UnLoadPrefab : MonoBehaviourSimplify
    {
#if UNITY_EDITOR
        [UnityEditor.MenuItem("ZTools/Example/UnLoadPrefab", false, 20)]

        static void MenuItem()
        {
            UnityEditor.EditorApplication.isPlaying = true;

            new GameObject("UnLoadResources").AddComponent<UnLoadPrefab>();
        }
#endif
        private void Start()
        {
            var gameObject = Resources.Load("UIRoot");

            Delay(5, () =>
            {
                gameObject = null;
                Resources.UnloadUnusedAssets();
                Debug.Log("UnloadUnusedAssets");
            });
        }


        protected override void BeforeDestroy()
        {
        }
    }
}
