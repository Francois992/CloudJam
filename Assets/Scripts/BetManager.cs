using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BetManager : MonoBehaviour
{
    public static BetManager instance;
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

    [Serializable]
    private struct HorseAttribute
    {
        public string name;
        [TextArea] public string anecdote;
    }

    [SerializeField] private List<HorseAttribute> attributes = new List<HorseAttribute>();

    [SerializeField] private Sprite checkImage;
    [SerializeField] private Sprite crossImage;

    [SerializeField] private Image player1Image;
    [SerializeField] private Image player2Image;
    [SerializeField] private Image player3Image;
    [SerializeField] private Image player4Image;

    #region Stats

    [Header ("Horse 1")] 

    [SerializeField] private Image Horse1Speed;
    [SerializeField] private Image Horse1Hp;
    [SerializeField] private Image Horse1Panache;
    [SerializeField] private Text Horse1Name;
    [SerializeField] private Text Horse1Anecdote;

    [Header("Horse 2")]

    [SerializeField] private Image Horse2Speed;
    [SerializeField] private Image Horse2Hp;
    [SerializeField] private Image Horse2Panache;
    [SerializeField] private Text Horse2Name;
    [SerializeField] private Text Horse2Anecdote;

    [Header("Horse 3")]

    [SerializeField] private Image Horse3Speed;
    [SerializeField] private Image Horse3Hp;
    [SerializeField] private Image Horse3Panache;
    [SerializeField] private Text Horse3Name;
    [SerializeField] private Text Horse3Anecdote;

    [Header("Horse 4")]

    [SerializeField] private Image Horse4Speed;
    [SerializeField] private Image Horse4Hp;
    [SerializeField] private Image Horse4Panache;
    [SerializeField] private Text Horse4Name;
    [SerializeField] private Text Horse4Anecdote;

    #endregion

    private List<Image> playerImages = new List<Image>();

    // Start is called before the first frame update
    void Start()
    {
        playerImages.Add(player1Image);
        playerImages.Add(player2Image);
        playerImages.Add(player3Image);
        playerImages.Add(player4Image);

        Horse1Speed.fillAmount = (GameManager.instance.OctoHorses[0].octopusSpeed / 5f);
        Horse2Speed.fillAmount = (GameManager.instance.OctoHorses[1].octopusSpeed / 5f);
        Horse3Speed.fillAmount = (GameManager.instance.OctoHorses[2].octopusSpeed / 5f);
        Horse4Speed.fillAmount = (GameManager.instance.OctoHorses[3].octopusSpeed / 5f);
        
        Horse1Hp.fillAmount = (GameManager.instance.OctoHorses[0].tenacity / 5f);
        Horse2Hp.fillAmount = (GameManager.instance.OctoHorses[1].tenacity / 5f);
        Horse3Hp.fillAmount = (GameManager.instance.OctoHorses[2].tenacity / 5f);
        Horse4Hp.fillAmount = (GameManager.instance.OctoHorses[3].tenacity / 5f);

        Horse1Panache.fillAmount = (GameManager.instance.OctoHorses[0].panache / 5f);
        Horse2Panache.fillAmount = (GameManager.instance.OctoHorses[1].panache / 5f);
        Horse3Panache.fillAmount = (GameManager.instance.OctoHorses[2].panache / 5f);
        Horse4Panache.fillAmount = (GameManager.instance.OctoHorses[3].panache / 5f);

        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectHorse(int playerId, int horseId, int betsLeft)
    {
        GameManager.instance.PlayerBets[playerId].Add(horseId);
        Debug.Log("player " + (playerId +1)  + " has chosen horse number " + horseId);
        if (betsLeft == 0) playerImages[playerId].sprite = checkImage;
    }
   
}
