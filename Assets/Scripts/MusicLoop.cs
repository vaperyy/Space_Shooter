using UnityEngine;

public class MusicLoop : MonoBehaviour
/*
https://www.youtube.com/watch?v=li2D_PEdST4
*/
{
    public AudioSource musicSource;
    public AudioClip musicStart;

    void Start()
    {
        musicSource.PlayOneShot(musicStart);
        musicSource.PlayScheduled(AudioSettings.dspTime + musicStart.length);
    }
}