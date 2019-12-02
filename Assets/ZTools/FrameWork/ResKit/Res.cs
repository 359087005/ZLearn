using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ZTools
{
    /// <summary>
    /// 负责资源的加载与卸载
    /// </summary>
    public class Res : SimpleRC
    {
        public Object Asset { get; private set; }

        public string Name { get; private set; }

        private string mAssetPath;


        public Res(string assetPath)
        {
            mAssetPath = assetPath;
            Name = assetPath;
        }

        public bool LoadSync()
        {
            return Asset = Resources.Load(mAssetPath);
        }

        public void LoadAsync(Action<Res> onLoaded)
        {
          var request =  Resources.LoadAsync(mAssetPath);

            request.completed += (operation=>
            {
                Asset = request.asset;
                onLoaded(this);
            });
        }



        protected override void OnZeroRef()
        {
            if (Asset is GameObject)
            {
                Asset = null;
                Resources.UnloadUnusedAssets();
            }
            else
            {
                Resources.UnloadAsset(Asset);
            }
            ResMgr.Instance.sharedLoadRes.Remove(this);
            Asset = null;
        }
    }
}