using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour
{

    public bool isRacing;
    public bool isStartingRace;

    public bool isVictorious;

    public bool isCredits;

    public AudioSource source;
    public AudioClip menuMusic;
    public AudioClip raceStartMusic;
    public AudioClip raceMusic;
    public AudioClip victoryMusic;
    public AudioClip creditsMusic;

    // Start is called before the first frame update
    void Start()
    {
        if ((!source.isPlaying) && (!isRacing))
        {
            source.clip = menuMusic;
            source.loop = true;
            source.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isStartingRace)
        {
            source.Stop();
            source.clip = raceStartMusic;
            source.loop = false;
            source.Play();
            isStartingRace = false;
            isRacing = true;
        }
        if ((isRacing) && (!source.isPlaying))
        {
            source.clip = raceMusic;
            source.loop = true;
            source.Play();
            //isRacing = false;
        }
        if (isVictorious)
        {
            source.Stop();
            source.clip = victoryMusic;
            source.loop = true;
            source.Play();
            isStartingRace = false;
            isRacing = false;
            isVictorious = false;
        }
        if (isCredits)
        {
            source.Stop();
            source.clip = creditsMusic;
            source.loop = true;
            source.Play();
            isStartingRace = false;
            isRacing = false;
            isCredits = false;
        }
    }
}
