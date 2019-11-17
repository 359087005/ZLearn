#if UNITY_EDITOR
using UnityEngine;
using NUnit.Framework;
namespace ZTools
{
    public class V0_0_4
    {
        class MonoSingletonTestClass : MonoSingleton<MonoSingletonTestClass>
        {
        }
        [Test]

    public void MonoSingletonTest()
        {
            var instanceA = MonoSingletonTestClass.Instance;
            var instanceB = MonoSingletonTestClass.Instance;
            Assert.AreEqual(instanceA.GetHashCode(), instanceB.GetHashCode());
        }
    }
}
#endif


