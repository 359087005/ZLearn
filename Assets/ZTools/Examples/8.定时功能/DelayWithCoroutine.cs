using UnityEngine;
using System;
using System.Collections;

namespace ZTools
{
    public class DelayWithCoroutine : MonoBehaviourSimplify
    {
#if UNITY_EDITOR
        [UnityEditor.MenuItem("ZTools/Example/定时功能", false, 8)]

        static void MenuClick()
        {
            UnityEditor.EditorApplication.isPlaying = true;
            new GameObject("Te").AddComponent<DelayWithCoroutine>();
        }
#endif
        private void Start()
        {
            Delay(5, () =>
             {
                 Debug.Log("5秒之后"); Hide();
             });

        }
        protected override void BeforeDestroy()
        {
        }
    }
}
