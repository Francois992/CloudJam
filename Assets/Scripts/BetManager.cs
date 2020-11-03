using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectHorse(int playerId, int horseId)
    {
        GameManager.instance.PlayerBets[playerId].Add(horseId);
        Debug.Log("player " + (playerId +1)  + " has chosen horse number " + horseId);
    }
   
}
