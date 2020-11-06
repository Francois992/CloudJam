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
    public struct HorseAttribute
    {
        public string name;
        [TextArea] public string anecdote;
        public string uselessStat;
        public int uselessStatValue;
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
    [SerializeField] private Image Horse1UselessStat;
    [SerializeField] private Text Horse1Name;
    [SerializeField] private Text Horse1Anecdote;
    [SerializeField] private Text Horse1Useless;

    private HorseAttribute horse1Attribute;

    [Header("Horse 2")]

    [SerializeField] private Image Horse2Speed;
    [SerializeField] private Image Horse2Hp;
    [SerializeField] private Image Horse2Panache;
    [SerializeField] private Image Horse2UselessStat;
    [SerializeField] private Text Horse2Name;
    [SerializeField] private Text Horse2Anecdote;
    [SerializeField] private Text Horse2Useless;

    private HorseAttribute horse2Attribute;

    [Header("Horse 3")]

    [SerializeField] private Image Horse3Speed;
    [SerializeField] private Image Horse3Hp;
    [SerializeField] private Image Horse3Panache;
    [SerializeField] private Image Horse3UselessStat;
    [SerializeField] private Text Horse3Name;
    [SerializeField] private Text Horse3Anecdote;
    [SerializeField] private Text Horse3Useless;

    private HorseAttribute horse3Attribute;

    [Header("Horse 4")]

    [SerializeField] private Image Horse4Speed;
    [SerializeField] private Image Horse4Hp;
    [SerializeField] private Image Horse4Panache;
    [SerializeField] private Image Horse4UselessStat;
    [SerializeField] private Text Horse4Name;
    [SerializeField] private Text Horse4Anecdote;
    [SerializeField] private Text Horse4Useless;

    private HorseAttribute horse4Attribute;

    #endregion

    private List<Image> playerImages = new List<Image>();

    public GameObject StartButton;
    public Image StartButtonLoad;

    // Start is called before the first frame update
    void Start()
    {
        StartButton.SetActive(false);

        List<HorseAttribute> attributesCopy = attributes;

        horse1Attribute = attributes[(int)(attributesCopy.Count * UnityEngine.Random.value)];
        GameManager.instance.OctoHorses[0].attribute = horse1Attribute;
        attributesCopy.Remove(horse1Attribute);
        horse2Attribute = attributes[(int)(attributesCopy.Count * UnityEngine.Random.value)];
        GameManager.instance.OctoHorses[1].attribute = horse2Attribute;
        attributesCopy.Remove(horse2Attribute);
        horse3Attribute = attributes[(int)(attributesCopy.Count * UnityEngine.Random.value)];
        GameManager.instance.OctoHorses[2].attribute = horse3Attribute;
        attributesCopy.Remove(horse3Attribute);
        horse4Attribute = attributes[(int)(attributesCopy.Count * UnityEngine.Random.value)];
        GameManager.instance.OctoHorses[3].attribute = horse4Attribute;

        playerImages.Add(player1Image);
        playerImages.Add(player2Image);
        playerImages.Add(player3Image);
        playerImages.Add(player4Image);

        Horse1Speed.fillAmount = (GameManager.instance.OctoHorses[0].octopusSpeed / 5f);
        Horse2Speed.fillAmount = (GameManager.instance.OctoHorses[1].octopusSpeed / 5f);
        Horse3Speed.fillAmount = (GameManager.instance.OctoHorses[2].octopusSpeed / 5f);
        Horse4Speed.fillAmount = (GameManager.instance.OctoHorses[3].octopusSpeed / 5f);
        /*
        Horse1Hp.fillAmount = (GameManager.instance.OctoHorses[0].tenacity / 5f);
        Horse2Hp.fillAmount = (GameManager.instance.OctoHorses[1].tenacity / 5f);
        Horse3Hp.fillAmount = (GameManager.instance.OctoHorses[2].tenacity / 5f);
        Horse4Hp.fillAmount = (GameManager.instance.OctoHorses[3].tenacity / 5f);

        Horse1Panache.fillAmount = (GameManager.instance.OctoHorses[0].panache / 5f);
        Horse2Panache.fillAmount = (GameManager.instance.OctoHorses[1].panache / 5f);
        Horse3Panache.fillAmount = (GameManager.instance.OctoHorses[2].panache / 5f);
        Horse4Panache.fillAmount = (GameManager.instance.OctoHorses[3].panache / 5f);*/

        Horse1UselessStat.fillAmount = horse1Attribute.uselessStatValue / 10f;
        Horse2UselessStat.fillAmount = horse2Attribute.uselessStatValue / 10f;
        Horse3UselessStat.fillAmount = horse3Attribute.uselessStatValue / 10f;
        Horse4UselessStat.fillAmount = horse4Attribute.uselessStatValue / 10f;

        Horse1Name.text = horse1Attribute.name;
        Horse2Name.text = horse2Attribute.name;
        Horse3Name.text = horse3Attribute.name;
        Horse4Name.text = horse4Attribute.name;

        Horse1Anecdote.text = "Trivia : " + horse1Attribute.anecdote;
        Horse2Anecdote.text = "Trivia : " + horse2Attribute.anecdote;
        Horse3Anecdote.text = "Trivia : " + horse3Attribute.anecdote;
        Horse4Anecdote.text = "Trivia : " + horse4Attribute.anecdote;

        Horse1Useless.text = horse1Attribute.uselessStat;
        Horse2Useless.text = horse2Attribute.uselessStat;
        Horse3Useless.text = horse3Attribute.uselessStat;
        Horse4Useless.text = horse4Attribute.uselessStat;

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
