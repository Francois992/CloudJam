using Rewired;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public int playerNumber = 1;
    [SerializeField] private CameraMovement gameCamera = null;
    public CameraMovement GameCamera { get { return gameCamera; } }

    public List<int> player1Bets = new List<int>();
    public List<int> player2Bets = new List<int>();
    public List<int> player3Bets = new List<int>();
    public List<int> player4Bets = new List<int>();

    public List<Player> Players = new List<Player>();
    [HideInInspector] public List<Player> playersBetting = new List<Player>();
    public List<Octopus> OctoHorses = new List<Octopus>();
    [HideInInspector] public List<Octopus> OctoHorsesSorted = new List<Octopus>();
    [HideInInspector] public List<List<int>> PlayerBets = new List<List<int>>();

    [HideInInspector] public Octopus HorseWinner;

    public int betsAvailable = 1;

    public int gameLengthInSec = 10;
    public float elapsedTime = 0;

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
    public bool IsRacing { get { return isRacing; } }

    // Start is called before the first frame update
    void Start()
    {
        PlayerBets.Add(player1Bets);
        PlayerBets.Add(player2Bets);
        PlayerBets.Add(player3Bets);
        PlayerBets.Add(player4Bets);
    }

    private void FixedUpdate()
    {
        if (!isRacing) return;

        List<Octopus> tmpOcto = OctoHorses.OrderBy(octo => octo.transform.position.x).ToList();


        for (int i = 0; i < tmpOcto.Count; i++)
        {
            tmpOcto[i].SetPosition(i + 1);
        }
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

        if (isRacing)
        {
            elapsedTime += Time.deltaTime;

            if(elapsedTime >= gameLengthInSec)
            {
                EndRace();
            }
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

    public void EndRace()
    {
        isRacing = false;
        StartCoroutine(EndCountDown());
    }

    private IEnumerator EndCountDown()
    {
        yield return new WaitForSeconds(4);
        gameCamera.cameraCanMove = false;
        for (int i = 0; i < OctoHorses.Count; i++)
        {
            OctoHorses[i].HorseCanRun(false);
        }
        OctoHorsesSorted = OctoHorses;
        OctoHorsesSorted.Sort((s1, s2) => s1.transform.position.x.CompareTo(s2.transform.position.x));
        for(int j = 0; j < playersBetting.Count; j++)
        {
            if(OctoHorsesSorted[0] == OctoHorses[0])
            {
                if (PlayerBets[j][0] == 1) Players[j].hasWon = true;
            }
            else if (OctoHorsesSorted[0] == OctoHorses[1])
            {
                if (PlayerBets[j][0] == 2) Players[j].hasWon = true;
            }
            else if (OctoHorsesSorted[0] == OctoHorses[2])
            {
                if (PlayerBets[j][0] == 3) Players[j].hasWon = true;
            }
            else if (OctoHorsesSorted[0] == OctoHorses[3])
            {
                if (PlayerBets[j][0] == 4) Players[j].hasWon = true;
            }
        }
        ResultManager.instance.gameObject.SetActive(true);
        ResultManager.instance.ShowResults();
    }

    public void ResetRace()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        player1Bets = new List<int>();
        player2Bets = new List<int>();
        player3Bets = new List<int>();
        player4Bets = new List<int>();
    }
}
