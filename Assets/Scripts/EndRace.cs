using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndRace : MonoBehaviour
{
    GameManager gm;

    private void Start()
    {
        gm = GameManager.instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision !");
        if (collision.gameObject.CompareTag("Poulpe"))
        {
            Debug.Log("It's a poulpe !");

            if (gm.octoHorseWinner == null)
            {
                gm.octoHorseWinner = collision.gameObject.GetComponent<Octopus>();
                gm.EndRace();
            }
        }
    }
}
