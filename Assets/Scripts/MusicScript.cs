using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour
{
    private static MusicScript _instance;

    public bool isMenu;

    public bool isPlayerSelect;

    public bool isStartingRace;
    public bool isRacing;

    public bool isSecondBreath;

    public bool isVictorious;

    public bool isCredits;

    public GameObject PlayerSelectAudioManager;

    public AudioSource source;
    public AudioSource sourceSecondBreath;

    public AudioClip menuMusic;
    public AudioClip raceStartMusic;
    public AudioClip raceMusic;
    public AudioClip secondBreathLoop;
    public AudioClip victoryMusic;
    public AudioClip creditsMusic;

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayerSelectAudioManager.SetActive(false);
        if ((!source.isPlaying) && (!isRacing))
        {
            source.clip = menuMusic;
            source.loop = true;
            source.Play();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isMenu)
        {
            StopAll();
            source.clip = menuMusic;
            source.loop = true;
            source.Play();
            isRacing = false;
            isMenu = false;
        }

        if (isPlayerSelect)
        {
            StopAll();
            PlayerSelectAudioManager.SetActive(true);
            isPlayerSelect = false;
        }

        if (isStartingRace)
        {
            StopAll();
            source.clip = raceStartMusic;
            source.loop = false;
            source.Play();
            isStartingRace = false;
            isSecondBreath = false;
            isMenu = false;
            isRacing = true;
        }
        if (isRacing)
        {
            if (!source.isPlaying && source.clip == raceStartMusic)
            {
                source.clip = raceMusic;
                source.loop = true;
                source.Play();

                sourceSecondBreath.clip = secondBreathLoop;
                sourceSecondBreath.loop = true;
                sourceSecondBreath.Play();
                //isRacing = false;
            }
            if (isSecondBreath && source.clip == raceMusic)
            {
                sourceSecondBreath.volume = 1;
            }
            else
            {
                sourceSecondBreath.volume = 0;
            }
        }
        if (isVictorious)
        {
            StopAll();
            source.clip = victoryMusic;
            source.loop = true;
            source.Play();
            isStartingRace = false;
            isRacing = false;
            isVictorious = false;
        }
        if (isCredits)
        {
            StopAll();
            source.clip = creditsMusic;
            source.loop = true;
            source.Play();
            isStartingRace = false;
            isRacing = false;
            isCredits = false;
        }
    }
    void StopAll()
    {
        source.Stop();
        sourceSecondBreath.Stop();
        PlayerSelectAudioManager.SetActive(false);
    }
}
