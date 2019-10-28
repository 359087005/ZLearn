using UnityEngine;
using System;
using System.Collections;

namespace ZTools
{
    public partial class MonoBehaviourSimplify
    {
        public void Delay(float second, Action onFinished)
        {
            StartCoroutine(DelayCoroutine(second, onFinished));
        }
        private IEnumerator DelayCoroutine(float second, Action onFinished)
        {
            yield return new WaitForSeconds(second);
            onFinished();
        }
    }

    public class DelayWithCoroutine : MonoBehaviourSimplify
    {
#if UNITY_EDITOR
        [UnityEditor.MenuItem("ZTools/11.定时功能", false, 11)]

        static void MenuClick()
        {
            UnityEditor.EditorApplication.isPlaying = true;
            new GameObject("Te").AddComponent<DelayWithCoroutine>();
        }
#endif
        private void Start()
        {
            Delay(5,()=>
            {
                Debug.Log("5秒之后"); Hide();
            });
           
        }
    }
}
