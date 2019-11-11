using UnityEditor;
using UnityEngine;

namespace ZTools
{
    public class TransformSimplifyExample : MonoBehaviour
    {
#if UNITY_EDITOR
        [MenuItem("ZTools/Example/Transform API简化", false, 4)]
#endif
        static void MenuClick()
        {
            GameObject go = new GameObject();
            TransformSimplify.SetLocalPosX(go.transform, 5.0f);
            TransformSimplify.SetLocalPosY(go.transform, 5.0f);
            TransformSimplify.SetLocalPosZ(go.transform, 5.0f);
            TransformSimplify.TransformReset(go.transform);

            Transform p = new GameObject("P").transform;
            Transform c = new GameObject("C").transform;
            TransformSimplify.AddChild(p, c);

        }
    }

}
