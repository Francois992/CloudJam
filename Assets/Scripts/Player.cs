using Rewired;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rewired.Player playerController;
    public int playerId = 0;

    public int bets = 1;

    // Start is called before the first frame update
    void Start()
    {
        playerController = ReInput.players.GetPlayer(playerId);
    }

    // Update is called once per frame
    void Update()
    {
        if(bets > 0)
        {
            if (playerController.GetButton("AButton"))
            {
                bets--;
                BetManager.instance.SelectHorse(playerId, 1, bets);
            }
            else if (playerController.GetButton("BButton"))
            {
                bets--;
                BetManager.instance.SelectHorse(playerId, 2, bets);
            }
            else if (playerController.GetButton("XButton"))
            {
                bets--;
                BetManager.instance.SelectHorse(playerId, 3, bets);
            }
            else if (playerController.GetButton("YButton"))
            {
                bets--;
                BetManager.instance.SelectHorse(playerId, 4, bets);
            }
            else if (playerController.GetButton("downButton"))
            {
                bets--;
                BetManager.instance.SelectHorse(playerId, 5, bets);
            }
            else if (playerController.GetButton("RightButton"))
            {
                bets--;
                BetManager.instance.SelectHorse(playerId, 6, bets);
            }
            else if (playerController.GetButton("LeftButton"))
            {
                bets--;
                BetManager.instance.SelectHorse(playerId, 7, bets);
            }
            else if (playerController.GetButton("UpButton"))
            {
                bets--;
                BetManager.instance.SelectHorse(playerId, 8, bets);
            }
        }
        
    }
}
