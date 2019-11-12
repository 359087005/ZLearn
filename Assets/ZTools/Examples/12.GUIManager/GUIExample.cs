using UnityEngine;
namespace ZTools
{
    public class GUIExample : MonoBehaviourSimplify
    {
        protected override void BeforeDestroy()
        {

        }

        private void Start()
        {
          var panel =   GUIManager.LoadPanel("GamePanel");

            Delay(3,()=>
            {
                Destroy(panel);
            });
        }
    }
}
