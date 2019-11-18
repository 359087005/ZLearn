using System.Collections.Generic;
using UnityEngine;

namespace ZTools
{
public class ResourcesMgrExample : MonoBehaviour 
{
#if UNITY_EDITOR
        [UnityEditor.MenuItem("ZTools/Example/UnLoadExample", false, 21)]

        static void MenuItem()
        {
            UnityEditor.EditorApplication.isPlaying = true;

            new GameObject("UnLoadResources").AddComponent<UnLoadPrefab>();
        }
#endif

        ResLoader resLoader = new ResLoader();
    private void Start()
    {
       var audioClip1 = resLoader.LoadAsset<AudioClip>("audioClip1");
            resLoader.mLoadAssets.Add(audioClip1);
       var audioClip2 = resLoader.LoadAsset<AudioClip>("audioClip1");
            resLoader.mLoadAssets.Add(audioClip2);
        var audioClip3 = resLoader.LoadAsset<AudioClip>("audioClip1");
            resLoader.mLoadAssets.Add(audioClip3);
    }

    private void OnDestroy()
    {
            resLoader.mLoadAssets.ForEach(loadedAssets => 
        {
            Resources.UnloadAsset(loadedAssets);
        });

            resLoader.mLoadAssets.Clear(); 
    }
    }
}