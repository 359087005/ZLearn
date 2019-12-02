using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;


#if UNITY_EDITOR
namespace ZTools
{
    public class V0_0_4
    {
        class SingletonTestClass : MonoSingleton<SingletonTestClass>
        {
            private SingletonTestClass()
            { }
        }

        [Test]
        public void SingletonTest()
        {
            var instanceA = SingletonTestClass.Instance;
            var instanceB = SingletonTestClass.Instance;
            Assert.AreEqual(instanceA.GetHashCode(), instanceB.GetHashCode());
        }

    }
}
#endif
