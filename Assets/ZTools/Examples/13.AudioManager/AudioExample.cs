using UnityEngine;

namespace ZTools
{

    public class AudioExample : MonoBehaviour
    {


#if UNITY_EDITOR
        [UnityEditor.MenuItem("ZTools/Example/AudioSource", false, 13)]

        static void MenuClick()
        {
            UnityEditor.EditorApplication.isPlaying = true;

            new GameObject("AudioExample").AddComponent<AudioExample>();
        }
#endif
        private void Start()
        {
            AudioManager.Instance.PlaySound("");
        }
    }
}