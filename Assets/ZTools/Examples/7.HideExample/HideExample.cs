using UnityEngine;

namespace ZTools
{
    public class HideExample : MonoBehaviour
    {
#if UNITY_EDITOR
        [UnityEditor.MenuItem("ZTools/Example/Hide脚本", false, 7)]
#endif
        static void MenuClick()
        {
            UnityEditor.EditorApplication.isPlaying = true;
            GameObject go = new GameObject();
            go.AddComponent<Hide>();
        }
    }
}
