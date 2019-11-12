using UnityEngine;

namespace ZTools
{
    public class GUIManager
    {
        public static GameObject LoadPanel(string name)
        {
            var gameRoot = GameObject.Find("Canvas");

            var panelPrefab = Resources.Load<GameObject>(name);

            var panelGameobject = Object.Instantiate(panelPrefab);

            panelGameobject.transform.SetParent(gameRoot.transform);

            var rectTrans = panelGameobject.transform as RectTransform;

            rectTrans.offsetMin = Vector2.zero;
            rectTrans.offsetMax = Vector2.zero;
            rectTrans.anchoredPosition3D = Vector3.zero;
            rectTrans.anchorMin = Vector2.zero;
            rectTrans.anchorMax = Vector2.one;

            return panelGameobject;
        }
    }
}