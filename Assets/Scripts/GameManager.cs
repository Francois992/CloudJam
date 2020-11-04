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
    [SerializeField] private CameraMovement gameCamera = null;

    public List<int> player1Bets = new List<int>();
    public List<int> player2Bets = new List<int>();
    public List<int> player3Bets = new List<int>();
    public List<int> player4Bets = new List<int>();

    public List<Player> Players = new List<Player>();
    [HideInInspector] public List<Player> playersBetting = new List<Player>();
    public List<Octopus> OctoHorses = new List<Octopus>();
    [HideInInspector] public List<List<int>> PlayerBets = new List<List<int>>();

    public int betsAvailable = 1;

    private bool isBetting = false;
    public bool IsBetting
    {
        get
        {
            return isBetting;
        }
        set
        {
            isBetting = value;
        }
    }

    private bool isRacing = false;

    // Start is called before the first frame update
    void Start()
    {
        PlayerBets.Add(player1Bets);
        PlayerBets.Add(player2Bets);
        PlayerBets.Add(player3Bets);
        PlayerBets.Add(player4Bets);
    }

    public void AddPlayers()
    {
        playersBetting.Add(Players[0]);
        playersBetting.Add(Players[1]);
        if (playerNumber >= 3) playersBetting.Add(Players[2]);
        if (playerNumber >= 4) playersBetting.Add(Players[3]);

        for(int i = 0; i < playersBetting.Count; i++)
        {
            playersBetting[i].bets = betsAvailable;

        }
        isBetting = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isBetting)
        {
            for (int i = 0; i < playersBetting.Count; i++)
            {
                if (playersBetting[i].bets > 0)
                {
                    return;
                }
                
            }
            isBetting = false;
            BetManager.instance.gameObject.SetActive(false);
            StartRace();
        }
        
    }

    public void StartRace()
    {
        isRacing = true;
        gameCamera.cameraCanMove = true;

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
