using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace ZTools
{
    public partial class GameObjectSimplify
    {
        public static void Show(GameObject go)
        {
            go.SetActive(true);
        }
        public static void Hide(GameObject go)
        {
            go.SetActive(false);
        }
#if UNITY_EDITOR
        [MenuItem("ZTools/7.物体开关激活简化", false, 7)]
#endif
        static void MenuClick7()
        {
            GameObject go = new GameObject();
            Hide(go);
        }
    }
}