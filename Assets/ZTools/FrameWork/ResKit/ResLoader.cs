using System.Collections.Generic;
using UnityEngine;

namespace ZTools
{

    public class ResLoader
    {
        public List<Object> mLoadAssets = new List<Object>();

        public T LoadAsset<T>(string assetName) where T : Object
        {
            var resultAsset = mLoadAssets.Find(loadAsset => loadAsset.name == assetName) as T;
            if (resultAsset)
                return resultAsset;

            resultAsset = Resources.Load<T>(assetName);
            mLoadAssets.Add(resultAsset);
            return resultAsset;
        }

        public void UnLoadAssets()
        {
            mLoadAssets.ForEach(loadedAssets =>
            {
                Resources.UnloadAsset(loadedAssets);
            });

            mLoadAssets.Clear();
        }
    }

}