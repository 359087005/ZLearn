using System;
using System.Collections.Generic;
using UnityEngine;

namespace ZTools
{
    public interface IPool<T>
    {
        T Allocate();

        bool Recycle(T obj);
    }

    public interface IObjectFactory<T>
    {
        T Creat();
    }


    public abstract class MyPool<T> : IPool<T>
    {

        protected Stack<T> mCacheStack = new Stack<T>();

        protected IObjectFactory<T> mFactory;

        public int CurCount
        {
            get
            {
                return mCacheStack.Count;
            }
        }
        public virtual T Allocate()
        {
            return mCacheStack.Count > 0 ? mCacheStack.Pop() : mFactory.Creat();
        }

        public abstract bool Recycle(T obj);
    }

    public class CustomObjectFactory<T> : IObjectFactory<T>
    {
        public CustomObjectFactory(Func<T> factoryMethod)
        {
            mFactoryTemp = factoryMethod;
        }

        protected Func<T> mFactoryTemp;


        public T Creat()
        {
            return mFactoryTemp();
        }
    }

    public class PoolManager<T> : MyPool<T>
    {
        Action<T> resetMethod;

        public PoolManager(Func<T> factoryMethod, Action<T> resetMethod = null, int count = 0)
        {
            mFactory = new CustomObjectFactory<T>(factoryMethod);
            this.resetMethod = resetMethod;

            for (int i = 0; i < count; i++)
            {
                mCacheStack.Push(mFactory.Creat());
            }
        }

        public override bool Recycle(T obj)
        {
            if (resetMethod != null)
            {
                resetMethod(obj);
            }
            mCacheStack.Push(obj);

            return true;
        }
    }
}

