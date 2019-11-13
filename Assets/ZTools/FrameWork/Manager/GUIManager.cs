using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ZTools
{
    public enum UILayer
    {
        BG,
        Common,
        Top
    }
    public class GUIManager
    {
        private static GameObject mUIRoot;

        public static GameObject UIRoot
        {
            get
            {
                if (mUIRoot == null)
                {
                    mUIRoot = Object.Instantiate(Resources.Load<GameObject>("UIRoot"));
                    mUIRoot.name = "UIRoot";
                }
                return mUIRoot;
            }
        }

        private static Dictionary<string, GameObject> panelDic = new Dictionary<string, GameObject>();

        public static void SetResolution(float width, float height, float matchWidthOrHeight)
        {
            var scaler=  UIRoot.GetComponent<CanvasScaler>();
            scaler.referenceResolution = new Vector2(width,height);
            scaler.matchWidthOrHeight = matchWidthOrHeight;
        }


        public static GameObject LoadPanel(string name,UILayer uILayer)
        {
            var panelPrefab = Resources.Load<GameObject>(name);

            var panelGameobject = Object.Instantiate(panelPrefab);
            panelGameobject.name = name;
            panelDic.Add(name,panelGameobject);
            var rectTrans = panelGameobject.transform as RectTransform;

            switch (uILayer)
            {
                case UILayer.BG:
                    panelGameobject.transform.SetParent(UIRoot.transform.Find("BG"));
                    break;
                case UILayer.Common:
                    panelGameobject.transform.SetParent(UIRoot.transform.Find("Common"));
                    break;
                case UILayer.Top:
                    panelGameobject.transform.SetParent(UIRoot.transform.Find("Top"));
                    break;
            }
            rectTrans.offsetMin = Vector2.zero;
            rectTrans.offsetMax = Vector2.zero;
            rectTrans.anchoredPosition3D = Vector3.zero;
            rectTrans.anchorMin = Vector2.zero;
            rectTrans.anchorMax = Vector2.one;

            return panelGameobject;
        }

        public static void UnLoadPanel(string name)
        {
            if (panelDic.ContainsKey(name))
            {
                Object.Destroy(panelDic[name]);
                panelDic.Remove(name);
            }
        }
    }
}