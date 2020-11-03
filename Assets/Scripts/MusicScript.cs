using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour
{

    public AudioSource source;
    public AudioClip menuMusic;

    // Start is called before the first frame update
    void Awake()
    {
        if (!source.isPlaying)
        {
            source.PlayOneShot(menuMusic);
            source.loop = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
