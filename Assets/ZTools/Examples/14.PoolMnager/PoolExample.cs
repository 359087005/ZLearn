using System;
using UnityEngine;

namespace ZTools
{
    public class PoolExample 
    {
        class Fish
        {

        }
#if UNITY_EDITOR
        [UnityEditor.MenuItem("ZTools/Example/PoolManager", false, 14)]
#endif
        static void MenuClick()
        {
            PoolManager<Fish> fishPool =  new PoolManager<Fish>(()=>new Fish(),null,100);
            Debug.Log(fishPool.CurCount);

            Fish fish1 = fishPool.Allocate();
            Debug.Log(fishPool.CurCount);

            fishPool.Recycle(fish1);
            Debug.Log(fishPool.CurCount);


            for (int i = 0; i < 11; i++)
            {
                fishPool.Allocate();
            }
            Debug.Log(fishPool.CurCount);
        }
    }
}
