using System.IO;
using UnityEngine;
namespace ZTools
{
    public class AssetBundleExample : MonoBehaviour
    {
#if UNITY_EDITOR
        [UnityEditor.MenuItem("ZTools/Example/AssetBundleExample/Build AssetBundle", false, 24)]
        private static void MenuClick1()
        {
            if (!Directory.Exists(Application.streamingAssetsPath))
            {
                Directory.CreateDirectory(Application.streamingAssetsPath);
            }

            UnityEditor.BuildPipeline.BuildAssetBundles(Application.streamingAssetsPath,UnityEditor.BuildAssetBundleOptions.None,UnityEditor.BuildTarget.StandaloneWindows64);
        }
#endif


#if UNITY_EDITOR
        [UnityEditor.MenuItem("ZTools/Example/AssetBundleExample/Run", false, 24)]
        private static void MenuClick2()
        {
            UnityEditor.EditorApplication.isPlaying = true;

            new GameObject("assetbundleExample").AddComponent <AssetBundleExample> ();

        }
#endif
        private AssetBundle mBundle;

        private void Start()
        {
            mBundle = AssetBundle.LoadFromFile(Application.streamingAssetsPath + "/gameobject");

            var gameObj = mBundle.LoadAsset<GameObject>("GameObject");

            Instantiate(gameObj);
        }

        private void OnDestroy()
        {
            mBundle.Unload(true);
        }
    }
}

