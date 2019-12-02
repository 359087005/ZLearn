using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ZTools
{
    /// <summary>
    /// 记录脚本已经加载的资源
    /// </summary>
    public class ResLoader
    {
        public List<Res> mResRecord = new List<Res>();

        private Res GetResFromRecord(string assetName)
        {
           return mResRecord.Find(loadAsset => loadAsset.Name == assetName);
        }

        private Res GetFromResMgr(string assetName)
        {
          return  ResMgr.Instance.sharedLoadRes.Find(loadAssets => loadAssets.Name == assetName);
        }

        private void Add2Record(Res resFromResMgr)
        {
            mResRecord.Add(resFromResMgr);
            resFromResMgr.Retain();
        }
        private Res CreatRes(string assetName)
        {
            var res = new Res(assetName);
            ResMgr.Instance.sharedLoadRes.Add(res);
            Add2Record(res);

            return res;
        }

        private Res GetOrCreatRes(string assetName)
        {
            var res = GetResFromRecord(assetName);
            if (res != null) return res;

            res = GetFromResMgr(assetName);
            if (res != null) return res;

            res = CreatRes(assetName);
            return res;
        }





        public T LoadSync<T>(string assetName) where T : Object
        {
            var res = GetOrCreatRes(assetName);
            if (res != null)
            {
                return res.Asset as T;
            }
            //真正加载资源

            res =  CreatRes(assetName);

            res.LoadSync();

            return res.Asset as T;
        }

        public void LoadAsync<T>(string assetName, Action<T> onLoaded) where T : Object
        {
            var res = GetOrCreatRes(assetName);
            if (res != null)
            {
                onLoaded(res.Asset as T);
                return;
            }

            //真正加载资源
            res = CreatRes(assetName);
            res.LoadAsync(loaderRes =>
            {
                onLoaded(res.Asset as T);
            });
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