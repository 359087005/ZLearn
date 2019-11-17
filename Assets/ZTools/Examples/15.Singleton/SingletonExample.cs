using UnityEngine;

namespace ZTools
{
    public class SingletonExample : Singleton<SingletonExample>
    {
        private SingletonExample()
        {
            Debug.Log("SingletonExample");
        }


#if UNITY_EDITOR
        [UnityEditor.MenuItem("ZTools/Example/SingletonExample", false, 15)]
#endif
        static void MenuClick()
        {
            var initInstance = SingletonExample.Instance;
            initInstance = SingletonExample.Instance;
        }
    }
}
