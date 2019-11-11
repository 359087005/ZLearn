﻿using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace ZTools
{
    public partial class TransformSimplify
    {
        public static void TransformReset(Transform trans)
        {
            trans.localPosition = Vector3.zero;
            trans.localRotation = Quaternion.identity;
            trans.localScale = Vector3.one;
        }

        public static void SetLocalPosX(Transform trans, float x)
        {
            Vector3 localPos = trans.localPosition;
            localPos.x = x;
            trans.localPosition = localPos;
        }
        public static void SetLocalPosY(Transform trans, float y)
        {
            Vector3 localPos = trans.localPosition;
            localPos.y = y;
            trans.localPosition = localPos;
        }
        public static void SetLocalPosZ(Transform trans, float z)
        {
            Vector3 localPos = trans.localPosition;
            localPos.z = z;
            trans.localPosition = localPos;
        }
        public static void SetLocalPosXY(Transform trans, float x, float y)
        {
            Vector3 localPos = trans.localPosition;
            localPos.x = x; localPos.y = y;
            trans.localPosition = localPos;
        }
        public static void SetLocalPosXZ(Transform trans, float x, float z)
        {
            Vector3 localPos = trans.localPosition;
            localPos.x = x; localPos.z = z;
            trans.localPosition = localPos;
        }
        public static void SetLocalPosYZ(Transform trans, float y, float z)
        {
            Vector3 localPos = trans.localPosition;
            localPos.y = y; localPos.z = z;
            trans.localPosition = localPos;
        }

        public static void AddChild(Transform parent, Transform child)
        {
            child.SetParent(parent);
        }
    }
}