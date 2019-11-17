using UnityEngine;
namespace ZTools
{
    public abstract class MonoSingleton<T> : MonoBehaviour where T:MonoSingleton<T>
    {
        private static T instance = null;

        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<T>();
                    if (FindObjectsOfType<T>().Length > 1)
                    {
                        Debug.LogWarning("than 1");
                        return instance;
                    }
                    if (instance == null)
                    {
                        var instanceName = typeof(T).Name;
                        GameObject instanceObj = GameObject.Find(instanceName);
                        if (!instanceObj)
                        {
                            instanceObj = new GameObject(instanceName);
                        }
                        instance = instanceObj.AddComponent<T>();
                        //DontDestroyOnLoad(instanceObj);
                    }
                    else
                    {

                    }
                }
                return instance;
            }
        }

        public virtual void OnDestroy()
        {
            instance = null;
        }

    }
}

