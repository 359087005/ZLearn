using UnityEngine;

namespace ZTools
{
    public class AudioManager : MonoSingleton<AudioManager>
    {
        private AudioListener audioListener;

        void CheckAudioListener()
        {
            if (!audioListener)
                audioListener = GameObject.FindObjectOfType<AudioListener>();
            if (!audioListener)
                audioListener = gameObject.AddComponent<AudioListener>();
        }
        AudioSource audioEffect;
        public void PlaySound(string name)
        {
            CheckAudioListener();

            audioEffect =  gameObject.AddComponent<AudioSource>();
            var clip = Resources.Load<AudioClip>(name);
            if (!clip)
            {
                audioEffect.clip = clip;
                audioEffect.Play();
            }
        }

        AudioSource audioBG;
        public void PlayMusic(string name,bool isLoop)
        {
            CheckAudioListener();

            if (!audioBG)
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

        public void StopMusic()
        {
            audioBG.Stop();
        }
        public void PauseMusic()
        {
            audioBG.Pause();
        }
        public void UnPauseMusic()
        {
            audioBG.UnPause();
        }

        public void MusicOff()
        {
            audioBG.Pause();
            audioBG.mute = true;
        }

        public void SoundOff()
        {
            var soundSources = GetComponents<AudioSource>();

            foreach (var item in soundSources)
            {
                if (item != audioBG)
                {
                    item.Pause();
                    item.mute = true;
                }
            }
        }

        public void SoundOn()
        {
            var soundSources = GetComponents<AudioSource>();

            foreach (var item in soundSources)
            {
                if (item != audioBG)
                {
                    item.UnPause();
                    item.mute = false;
                }
            }
        }
    }
}