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

    [SerializeField] private Sprite checkImage;
    [SerializeField] private Sprite crossImage;

    [SerializeField] private Image player1Image;
    [SerializeField] private Image player2Image;
    [SerializeField] private Image player3Image;
    [SerializeField] private Image player4Image;

    private List<Image> playerImages = new List<Image>();

    // Start is called before the first frame update
    void Start()
    {
        playerImages.Add(player1Image);
        playerImages.Add(player2Image);
        playerImages.Add(player3Image);
        playerImages.Add(player4Image);
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
