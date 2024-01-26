using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource soundSource;

    public AudioClip resource;
    public AudioClip trapPlace;
    public AudioClip trapCatch;
    public AudioClip win;

    public void PlayResource() => PlayAudio(resource);
    public void PlayTrapPlace() => PlayAudio(trapPlace);
    public void PlayTrapCatch() => PlayAudio(trapCatch);
    public void PlayWin() => PlayAudio(win);

    public void PlayAudio(AudioClip clip, float volume = 1) => soundSource.PlayOneShot(clip, volume);

}
