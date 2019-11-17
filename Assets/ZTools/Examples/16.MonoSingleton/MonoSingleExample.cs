using UnityEngine;
namespace ZTools
{
    public class MonoSingleExample : MonoSingleton<MonoSingleExample>
    {
#if UNITY_EDITOR
        [UnityEditor.MenuItem("ZTools/Example/MonoSingleExample", false, 16)]

        static void MenuClick()
        {
            UnityEditor.EditorApplication.isPlaying = true;
            new GameObject("MonoSingleExample").AddComponent<MonoTest>();
        }
#endif
    }
    public class MonoTest : MonoBehaviour
    {
        private void Start()
        {
           Debug.Log( MonoSingleExample.Instance);
        }
    }
}
