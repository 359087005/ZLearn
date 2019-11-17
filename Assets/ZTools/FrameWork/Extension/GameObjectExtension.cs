using UnityEngine;

namespace ZTools
{
    public static partial class GameObjectSimplify
    {
        public static void Show(this GameObject go)
        {
            go.SetActive(true);
        }
        public static void Hide(this GameObject go)
        {
            go.SetActive(false);
        }
        public static void Show(this Transform go)
        {
            go.gameObject.SetActive(true);
        }
        public static void Hide(this Transform go)
        {
            go.gameObject.SetActive(false);
        }

        public static void Show(this MonoBehaviour monoBehaviour)
        {
            monoBehaviour.Show();
        }
        public static void Hide(this MonoBehaviour monoBehaviour)
        {
            monoBehaviour.Hide();
        }
    }
}