using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class AudioManager : MonoBehaviour
{
    public AudioSource soundSource;
    public AudioSource musicSource;

    public AudioClip resource;
    public AudioClip trapPlace;
    public AudioClip trapCatch;
    public AudioClip win;
    public AudioClip lose;

    public void PlayResource() => PlayAudio(resource);
    public void PlayTrapPlace() => PlayAudio(trapPlace);
    public void PlayTrapCatch() => PlayAudio(trapCatch);
    public void PlayWin()
    {
        musicSource.Stop();
        PlayAudio(win);
    }

    public void PlayLose()
    {
        musicSource.Stop();
        PlayAudio(lose);
    }

    public void PlayAudio(AudioClip clip, float volume = 1, bool onSource = false)
    {
        if (onSource)
        {
            soundSource.clip = clip;
            soundSource.volume = volume;
            soundSource.Play();

        }
        else
        {
            soundSource.PlayOneShot(clip, volume);
        }
    }

    public void Stop() => soundSource.Stop();
}
