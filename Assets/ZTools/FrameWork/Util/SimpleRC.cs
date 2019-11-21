using UnityEngine;

namespace ZTools
{
    public interface IRefCounter
    {
       int RefCount { get; }

        void Retain(object refOwner = null);

        void Release(object refOwner = null);

    }

    public class SimpleRC : IRefCounter
    {
        public int RefCount
        {
            get;protected set;
        }

        public void Release(object refOwner = null)
        {
            RefCount--;
            if (RefCount == 0)
            {
                OnZeroRef();
            }
        }

        public void Retain(object refOwner = null)
        {
            RefCount++;
        }

        protected virtual void OnZeroRef()
        {

        }
    }
}

