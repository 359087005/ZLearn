#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace ZTools
{
    public class TransformSimplifyExample : MonoBehaviour
    {
#if UNITY_EDITOR
        [MenuItem("ZTools/Example/Transform API简化", false, 4)]

        static void MenuClick()
        {
            GameObject go = new GameObject();

            go.transform.SetLocalPosX(5.0f);
            go.transform.SetLocalPosY(5.0f);
            go.transform.SetLocalPosZ(5.0f);
            go.transform.TransformReset();

            Transform p = new GameObject("P").transform;
            Transform c = new GameObject("C").transform;
            p.AddChild(c);

        }
#endif
    }

}
