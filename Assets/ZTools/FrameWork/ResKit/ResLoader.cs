using System.Collections.Generic;
using UnityEngine;

namespace ZTools
{
    /// <summary>
    /// 记录脚本已经加载的资源
    /// </summary>
    public class ResLoader
    {
        public List<Res> mResRecord = new List<Res>();

        public T LoadSync<T>(string assetName) where T : Object
        {
            var res = mResRecord.Find(loadAsset => loadAsset.Name == assetName);
            if (res != null)
                return res.Asset as T;

             res = ResMgr.Instance.sharedLoadRes.Find(loadAssets => loadAssets.Name == assetName);
            if (res!= null)
            {
                mResRecord.Add(res);
                res.Retain();
                return res.Asset as T;
            }
            res = new Res(assetName);

            res.LoadSync();

            res.Retain();

            ResMgr.Instance.sharedLoadRes.Add(res);
            mResRecord.Add(res);
            return res.Asset as T;
        }

        public void ReleaseAll()
        {
            mResRecord.ForEach(loadedAssets =>
            {
                loadedAssets.Release();
            });

            mResRecord.Clear();
        }
    }

}