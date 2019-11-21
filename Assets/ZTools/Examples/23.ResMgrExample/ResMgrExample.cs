using System.Collections;
using UnityEngine;

namespace ZTools
{
    public class ResMgrExample : MonoBehaviour
    {
#if UNITY_EDITOR
        [UnityEditor.MenuItem("ZTools/Example/ResMrgExample", false, 23)]

        static void MenuItem()
        {
            UnityEditor.EditorApplication.isPlaying = true;

            new GameObject("ZTTTTT").AddComponent<ResMgrExample>();
        }
#endif
        ResLoader mResLoader = new ResLoader();

        private IEnumerator Start()
        {
            yield return new WaitForSeconds(2f);
            mResLoader.LoadSync<AudioClip>("weapon_enemy");
            yield return new WaitForSeconds(2f);
            mResLoader.LoadSync<GameObject>("UIRoot");
            yield return new WaitForSeconds(5f);
            mResLoader.ReleaseAll();
        }

    }
}
