﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelectMusicScript : MonoBehaviour
{
    private PlayerSelectMusicScript _instance;

    public MusicScript musicManager;

    public int nbPlayers;
    public int musicVolume = 1;
    public AudioSource source0Player;
    public AudioSource source1Player;
    public AudioSource source2Player;
    public AudioSource source3Player;
    public AudioSource source4Player;

 /*   void Awake()
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
    } */

    // Start is called before the first frame update
    void Awake()
    {
     
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //nbPlayers = musicManager.nbplayers;

        switch (nbPlayers)
        {
            case 0:
                source0Player.volume = musicVolume;
                source1Player.volume = 0;
                source2Player.volume = 0;
                source3Player.volume = 0;
                source4Player.volume = 0;
                break;

            case 1:
                source0Player.volume = musicVolume;
                source1Player.volume = musicVolume;
                source2Player.volume = 0;
                source3Player.volume = 0;
                source4Player.volume = 0;
                break;

            case 2:
                source0Player.volume = musicVolume;
                source1Player.volume = musicVolume;
                source2Player.volume = musicVolume;
                source3Player.volume = 0;
                source4Player.volume = 0;
                break;

            case 3:
                source0Player.volume = musicVolume;
                source1Player.volume = musicVolume;
                source2Player.volume = musicVolume;
                source3Player.volume = musicVolume;
                source4Player.volume = 0;
                break;

            case 4:
                source0Player.volume = musicVolume;
                source1Player.volume = musicVolume;
                source2Player.volume = musicVolume;
                source3Player.volume = musicVolume;
                source4Player.volume = musicVolume;
                break;
        }
    }
}
