using UnityEngine;
namespace ZTools
{
    public class UnLoadResourcesExample : MonoBehaviourSimplify
    {
#if UNITY_EDITOR
        [UnityEditor.MenuItem("ZTools/Example/UnLoadResources", false, 19)]
        static void MenuItem()
        {
            UnityEditor.EditorApplication.isPlaying = true;

            new GameObject("UnLoadResources").AddComponent<UnLoadResourcesExample>();
        }

#endif
        private void Start()
        {
            var gameObject = Resources.Load("weapon_enemy");

            Delay(5,()=>
            {
                Resources.UnloadAsset(gameObject);
                Debug.Log("UnloadAsset");
            });
        }


        protected override void BeforeDestroy()
        {
        }
    }
}

