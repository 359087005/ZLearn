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

            new GameObject("UnLoadResources")
                .AddComponent<ResourcesMgrExample>().gameObject
                .AddComponent<AAAAAAAAAAAAAAPanel>();
        }
#endif

        ResLoader resLoader = new ResLoader();
        private void Start()
        {
            var audioClip1 = resLoader.LoadSync<AudioClip>("weapon_enemy");
            var audioClip2 = resLoader.LoadSync<AudioClip>("weapon_enemy");
            var audioClip3 = resLoader.LoadSync<AudioClip>("weapon_enemy");

        }

        private void OnDestroy()
        {
            resLoader.ReleaseAll();
        }
    }


    public class AAAAAAAAAAAAAAPanel : MonoBehaviour
    {
        ResLoader resLoader = new ResLoader();
        private void Start()
        {
            var audioClip1 = resLoader.LoadSync<AudioClip>("weapon_enemy");
            var audioClip2 = resLoader.LoadSync<AudioClip>("weapon_enemy");
            var audioClip3 = resLoader.LoadSync<AudioClip>("weapon_enemy");
        }

        private void OnDestroy()
        {
            resLoader.ReleaseAll();
        }
    }
}