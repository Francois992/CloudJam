using Rewired;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public int playerNumber = 1;

    public List<int> player1Bets = new List<int>();
    public List<int> player2Bets = new List<int>();
    public List<int> player3Bets = new List<int>();
    public List<int> player4Bets = new List<int>();

    public List<Player> Players = new List<Player>();
    public List<Octopus> OctoHorses = new List<Octopus>();
    [HideInInspector] public List<List<int>> PlayerBets = new List<List<int>>();

    [HideInInspector] public bool isBetting = true;
    [HideInInspector] public bool isRacing = false;

    // Start is called before the first frame update
    void Start()
    {
        PlayerBets.Add(player1Bets);
        PlayerBets.Add(player2Bets);
        PlayerBets.Add(player3Bets);
        PlayerBets.Add(player4Bets);
    }

    // Update is called once per frame
    void Update()
    {
        if (isBetting)
        {
            for (int i = 0; i < Players.Count; i++)
            {
                if (Players[i].bets > 0)
                {
                    return;
                }
                
            }
            isBetting = false;
            BetManager.instance.gameObject.SetActive(false);
        }
        
    }

    public void StartRace()
    {
        isRacing = true;

        for(int i = 0; i < OctoHorses.Count; i++)
        {
            OctoHorses[i].HorseCanRun(true);
        }
    }

    public void ResetRace()
    {
        isRacing = false;

        player1Bets = new List<int>();
        player2Bets = new List<int>();
        player3Bets = new List<int>();
        player4Bets = new List<int>();
    }
}
