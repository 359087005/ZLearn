using UnityEngine;

namespace ZTools
{
    public class Hide : MonoBehaviourSimplify
    {
        protected override void BeforeDestroy()
        {
            
        }

        private void Awake()
        {
            Hide();
        }
    }

}
