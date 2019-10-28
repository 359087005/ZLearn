using UnityEngine;

namespace ZTools
{

    public partial class TransformSimplify
    {
        public static void AddChild(Transform parent, Transform child)
        {
            child.SetParent(parent);
        }
    }

    public class PartialKeyWord
    {
#if UNITY_EDITOR
        [UnityEditor.MenuItem("ZTools/8.Partial关键字", false, 8)]
#endif
        private static void MenuClick()
        {
            Transform p = new GameObject("P").transform;
            Transform c = new GameObject("C").transform;

            TransformSimplify.AddChild(p, c);

            GameObjectSimplify.Hide(p.gameObject);
        }
    }

}