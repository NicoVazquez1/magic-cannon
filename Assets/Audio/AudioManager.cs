using UnityEngine;
using UnityEngine.Audio;
using System;
public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;
   

    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void Play(string name)
    {
        Sound sound = Array.Find(sounds, s => s.name == name);
        sound.source.Play();
        
    }

    public AudioClip GetClip(string name)
    {
        Sound sound = Array.Find(sounds, s => s.name == name);        
        return sound.clip;
    }

}
