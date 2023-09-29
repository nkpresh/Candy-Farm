using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AudioSettings;

public class AudioManager : Singleton<AudioManager>
{
    List<GameObject> audioPlayerCollection;

    public AudioClip[] GameAudioClips;

    private void Awake()
    {
        audioPlayerCollection = new List<GameObject>();
    }

    AudioSource GetAudioSource(AudioGroup audioGroup)
    {
        bool audioExists = audioPlayerCollection.Exists((player) => player.name == audioGroup.ToString());
        if (audioExists)
        {
            AudioSource audioSource = audioPlayerCollection.Find((player) => player.name == audioGroup.ToString()).GetComponent<AudioSource>();
            return audioSource;
        }
        AudioSource audioPlayer = new GameObject(audioGroup.ToString()).AddComponent<AudioSource>();
        audioPlayer.transform.SetParent(gameObject.transform);
        audioPlayerCollection.Add(audioPlayer.gameObject);
        return audioPlayer;
    }

    public AudioClip PlaySound(AudioGroup group, string clipName, bool loop = false)
    {
        AudioSource source = GetAudioSource(group);
        // print(Array.Find(GameAudioClips, (audioClip) => audioClip.name == clipName));
        AudioClip clip = Array.Find(GameAudioClips, (audioClip) => audioClip.name == clipName);
        source.playOnAwake = false;
        source.clip = clip;
        source.loop = loop;
        source.Play();
        return clip;
    }

    public void PlayMusic(bool loop)
    {
        PlaySound(AudioGroup.BgMusic, Enum.GetName(typeof(AudioClipNames.BgMusic), 0), loop);
    }

    public void PlayAmbience(bool loop)
    {
        PlaySound(AudioGroup.Ambience, AudioClipNames.Ambience.Ambience.ToString(), loop);

    }
    public void StopAudio(AudioGroup group)
    {
        bool audioExists = audioPlayerCollection.Exists((player) => player.name == group.ToString());
        if (audioExists)
        {
            AudioSource audioSource = audioPlayerCollection.Find((player) => player.name == group.ToString()).GetComponent<AudioSource>();
            audioSource.Stop();
        }
    }

    public void UpdateVolume(AudioGroup group, float volume)
    {
        bool audioExists = audioPlayerCollection.Exists((player) => player.name == group.ToString());
        if (audioExists)
        {
            AudioSource audioSource = audioPlayerCollection.Find((player) => player.name == group.ToString()).GetComponent<AudioSource>();
            bool volumeLowered = false;
            while (volumeLowered == false)
            {
                audioSource.volume -= Time.deltaTime;
                if (audioSource.volume <= volume)
                {
                    volumeLowered = true;
                }
            }

        }
    }
}
