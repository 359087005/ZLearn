using UnityEngine;
using System.Linq;
using System.Text.RegularExpressions;

namespace ZTools
{
    public partial class MonoBehaviourSimplify : MonoBehaviour 
    {
        public void Show()
        {
            GameObjectSimplify.Show(gameObject);
        }
        public void Hide()
        {
            GameObjectSimplify.Hide(gameObject);
        }
        public void Identity()
        {
            TransformSimplify.TransformReset(transform);
        }

    }
    public class Hide : MonoBehaviourSimplify
    {
        private void Awake()
        {

        }
       
        private void Start()
        {
          
        }

#if UNITY_EDITOR
        [UnityEditor.MenuItem("ZTools/10.Mono简化",false, 10)]
        static void MenuClick()
        {
            UnityEditor.EditorApplication.isPlaying = true;
            GameObject go = new GameObject();
            go.AddComponent<Hide>();
        }
#endif
    }
}