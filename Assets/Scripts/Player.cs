using Rewired;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Rewired.Player playerController;
    public int playerId = 0;

    public int bets = 0;

    [SerializeField] private Image SelectFill = null;
    [SerializeField] private float SelectFillSpeed = 2f;

    [HideInInspector] public bool hasWon = false;
    
    // Start is called before the first frame update
    void Awake()
    {
        playerController = ReInput.players.GetPlayer(playerId);
    }

    // Update is called once per frame
    void Update()
    {
        if(bets > 0 && GameManager.instance.IsBetting)
        {
            if (playerController.GetButton("AButton"))
            {
                SelectFill.fillAmount += SelectFillSpeed * Time.deltaTime;
                if(SelectFill.fillAmount >= 1) {
                    bets--;
                    BetManager.instance.SelectHorse(playerId, 1, bets);
                }
            }
            else if (playerController.GetButton("BButton"))
            {
                SelectFill.fillAmount += SelectFillSpeed * Time.deltaTime;
                if (SelectFill.fillAmount >= 1)
                {
                    bets--;
                    BetManager.instance.SelectHorse(playerId, 2, bets);
                }
            }
            else if (playerController.GetButton("XButton"))
            {
                SelectFill.fillAmount += SelectFillSpeed * Time.deltaTime;
                if (SelectFill.fillAmount >= 1)
                {
                    bets--;
                    BetManager.instance.SelectHorse(playerId, 3, bets);
                }
            }
            else if (playerController.GetButton("YButton"))
            {
                SelectFill.fillAmount += SelectFillSpeed * Time.deltaTime;
                if (SelectFill.fillAmount >= 1)
                {
                    bets--;
                    BetManager.instance.SelectHorse(playerId, 4, bets);
                }
            }

            else
            {
                SelectFill.fillAmount -= SelectFillSpeed * Time.deltaTime;
            }
            
        }
        
    }
}
