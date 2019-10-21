using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace ZTools
{
    public class GameObjectSimplify
    {
        public static void Show(GameObject go)
        {
            go.SetActive(true);
        }
        public static void Hide(GameObject go)
        {
            go.SetActive(false);
        }
    }

    public class GameObjectActive
    {
#if UNITY_EDITOR
        [MenuItem("ZTools/13.物体开关激活简化")]
#endif
        static void MenuClick13()
        {
            GameObject go = new GameObject();
            Hide(go);
        }

        public static void Show(GameObject go)
        {
            GameObjectSimplify.Show(go);
        }
        public static void Hide(GameObject go)
        {
            GameObjectSimplify.Hide(go);
        }
    }
}