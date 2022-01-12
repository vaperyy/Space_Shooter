using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicLoop : MonoBehaviour
{
    /*
    https://www.youtube.com/watch?v=li2D_PEdST4
    */
    public AudioSource musicSource;
    // Start is called before the first frame update
    void Start()
    {
        musicSource.PlayScheduled(AudioSettings.dspTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
