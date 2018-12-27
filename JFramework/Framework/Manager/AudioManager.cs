using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JFramework
{
    /// <summary>
    /// AudioManager的使用者直接通过单例调用即可，无需再场景中创建挂在AudioManager的物体
    /// GameManager物体将在AudioManager首次被调用时创建，并始终保留在场景中，而无需手动创建该物体
    /// </summary>
    public class AudioManager : MonoBehaviour
    {
        //单例
        private static AudioManager mInstance;
        public static AudioManager Instance
        {
            get
            {
                if (mInstance == null)
                {
                    mInstance = new GameObject("AudioManager").AddComponent<AudioManager>();
                    DontDestroyOnLoad(mInstance);
                }
                return mInstance;
            }
        }
        //GameManager物体将在AudioManager首次被调用时创建，并始终保留在场景中，而无需手动创建该物体

        /// <summary>
        /// 简单播放音效功能,每次音效播放，创建新的AudioSource组件进行播放
        /// </summary>
        /// <param name="soundName"></param>
        public void PlaySound(string soundName)
        {
            //gameObject.AddComponent<AudioListener>();
            var audioSource = gameObject.AddComponent<AudioSource>();

            var clip = Resources.Load<AudioClip>(soundName);
            audioSource.clip = clip;
            audioSource.Play();
        }


        private AudioSource mMusicSource = null;
        /// <summary>
        /// 播放BGM功能，每次播放使用同一个AS，而不是总创建新的
        /// </summary>
        /// <param name="musicName"></param>
        /// <param name="loop"></param>
        public void PlayMusic(string musicName,bool loop=true)
        {
            if (!mMusicSource) { mMusicSource = gameObject.AddComponent<AudioSource>(); }

            var clip = Resources.Load<AudioClip>(musicName);
            mMusicSource.clip = clip;
            mMusicSource.loop = loop;
            mMusicSource.Play();
        }

        public void StopMusic() { mMusicSource.Stop(); }
        public void PauseMusic() { mMusicSource.Pause(); }
        public void ResumeMusic() { mMusicSource.UnPause(); }
        public void MusicOFF() { mMusicSource.Pause();mMusicSource.mute = true; }
        public void MusicOn() { mMusicSource.UnPause();mMusicSource.mute = false; }

        public void SoundOff()
        {
            var audioSources = GetComponents<AudioSource>();
            foreach(var audioSource in audioSources)
            {
                if(audioSource != mMusicSource)
                {
                    audioSource.Pause();
                    audioSource.mute = true;
                }
            }
        }
        public void SoundOn()
        {
            var audioSources = GetComponents<AudioSource>();
            foreach (var audioSource in audioSources)
            {
                if (audioSource != mMusicSource)
                {
                    audioSource.UnPause();
                    audioSource.mute = false;
                }
            }
        }
    }
}
