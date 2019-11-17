using System;
using System.Reflection;


namespace ZTools
{
    public abstract class Singleton<T> where T : Singleton<T>
    {
        private static T instance;

        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    //获取所有非public的构造方法
                    var ctors =  typeof(T).GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic);

                    //从ctors获取无参的构造方法
                   var ctor=  Array.Find(ctors,c=>c.GetParameters().Length==0);

                    if (ctor == null)
                    {
                        throw new Exception("没有无参构造方法");
                    }
                    instance =  ctor.Invoke(null) as T;
                }
                return instance;
            }
        }

        protected Singleton()
        {
        }

    }
}

