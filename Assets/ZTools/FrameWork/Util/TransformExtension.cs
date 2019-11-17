using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace ZTools
{
    public static partial class TransformExtension
    {
        public static void TransformReset(this Transform trans)
        {
            trans.localPosition = Vector3.zero;
            trans.localRotation = Quaternion.identity;
            trans.localScale = Vector3.one;
        }

        public static void TransformReset(this MonoBehaviour monoBehaviour)
        {
            monoBehaviour.transform.TransformReset();
        }

        public static void SetLocalPosX(this Transform trans, float x)
        {
            Vector3 localPos = trans.localPosition;
            localPos.x = x;
            trans.localPosition = localPos;
        }
        public static void SetLocalPosY(this Transform trans, float y)
        {
            Vector3 localPos = trans.localPosition;
            localPos.y = y;
            trans.localPosition = localPos;
        }
        public static void SetLocalPosZ(this Transform trans, float z)
        {
            Vector3 localPos = trans.localPosition;
            localPos.z = z;
            trans.localPosition = localPos;
        }
        public static void SetLocalPosXY(this Transform trans, float x, float y)
        {
            Vector3 localPos = trans.localPosition;
            localPos.x = x; localPos.y = y;
            trans.localPosition = localPos;
        }
        public static void SetLocalPosXZ(this Transform trans, float x, float z)
        {
            Vector3 localPos = trans.localPosition;
            localPos.x = x; localPos.z = z;
            trans.localPosition = localPos;
        }
        public static void SetLocalPosYZ(this Transform trans, float y, float z)
        {
            Vector3 localPos = trans.localPosition;
            localPos.y = y; localPos.z = z;
            trans.localPosition = localPos;
        }

        public static void AddChild(this Transform parent, Transform child)
        {
            child.SetParent(parent);
        }
    }
}