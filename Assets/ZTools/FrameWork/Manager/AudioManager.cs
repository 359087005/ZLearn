using UnityEngine;

namespace ZTools

{
    public class AudioManager : MonoBehaviour
    {
        private static AudioManager instance;

        public static AudioManager Instance
        {
            get
            {
                if (!instance)
                {
                    instance = new GameObject("AudioManager").AddComponent<AudioManager>();
                    
                }
                return instance;
               }
        }

        private AudioListener audioListener;

        public void PlaySound(string name)
        {
            if(!audioListener)
                audioListener = gameObject.AddComponent<AudioListener>();

            AudioSource audioManagerAS =  gameObject.AddComponent<AudioSource>();
            var clip = Resources.Load<AudioClip>(name);
            if (!clip)
            {
                audioManagerAS.clip = clip;
                audioManagerAS.Play();
            }
        }

        AudioSource audioBG;
        public void PlayMusic(string name,bool isLoop)
        {
            if (!audioListener)
                audioListener = gameObject.AddComponent<AudioListener>();
            if(!audioBG)
            audioBG = gameObject.AddComponent<AudioSource>();

            if (!audioBG.isPlaying)
            {
                var clip = Resources.Load<AudioClip>(name);
                if (!clip)
                {
                    audioBG.clip = clip;
                    audioBG.Play();
                    audioBG.loop = isLoop;
                }
            }
          
        }
    }
}