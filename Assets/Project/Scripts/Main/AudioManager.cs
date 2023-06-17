using System;
using Main;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    private Sound[][] _allSounds;
    [HideInInspector] public Sound currentSound;

    //Array of all Sounds
    public Sound[] effectSounds;

    private void OnEnable()
    {
        _allSounds = new[] { effectSounds };

        foreach (Sound[] sArr in _allSounds)
        {
            foreach (Sound s in sArr)
            {
                s.source = gameObject.AddComponent<AudioSource>();
                s.source.clip = s.clip;
                s.source.loop = s.loop;
                s.source.volume = s.volume;
                s.source.pitch = s.pitch;
            }
        }
    }

    public void Play(string n, AudioSound audioSound)
    {
        Sound[] soundArr = _allSounds[(int) audioSound];
        //Plays the sound of the object with the name "name"
        for (int i = 0; i < soundArr.Length; i++)
        {
            if (soundArr[i].name == n)
            {
                currentSound = soundArr[i];
            }
        }
        currentSound.source.Play();
    }

    public void Stop(string n, AudioSound audioSound)
    {
        Sound[] soundArr = _allSounds[(int) audioSound];
        //Plays the sound of the object with the name "name"
        for (int i = 0; i < soundArr.Length; i++)
        {
            if (soundArr[i].name == n)
            {
                currentSound = soundArr[i];
            }
        }
        currentSound.source.Stop();
    }

    public enum AudioSound
    {
        EffectSounds = 0
    }
}


[Serializable]
public class Sound
{
    public string name;
    public bool loop = false;
    [HideInInspector] public bool isPlaying = false;

    public AudioClip clip;

    [Range(0f, 1f)] public float volume;
    [Range(.1f, 3f)] public float pitch;

    [HideInInspector] public AudioSource source;
}