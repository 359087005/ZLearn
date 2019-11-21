using UnityEngine;

namespace ZTools
{
    /// <summary>
    /// 负责资源的加载与卸载
    /// </summary>
    public class Res : SimpleRC
    {
        public Object Asset { get; private set; }

        public string Name { get { return Asset.name; } }

        private string mAssetPath;


        public Res(string assetPath)
        {
            mAssetPath = assetPath;
        }

        public bool LoadSync()
        {
            return Asset = Resources.Load(mAssetPath);
        }
        protected override void OnZeroRef()
        {
            Resources.UnloadAsset(Asset);

            ResMgr.Instance.sharedLoadRes.Remove(this);

            Asset = null;
        }
    }
}