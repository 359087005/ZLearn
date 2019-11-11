using UnityEngine;

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
        public static void Show(Transform go)
        {
            go.gameObject.SetActive(true);
        }
        public static void Hide(Transform go)
        {
            go.gameObject.SetActive(false);
        }
    }
}