using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowingTrap : MonoBehaviour
{
    [SerializeField, Range(0,100)] private float _speedDropRate = 30f; //0 = pas de ralentissement, 100=arret

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Trigger");
        if (collision.gameObject.CompareTag("Poulpe"))
        {
            //Debug.Log("Un poulpe !");
            //collision.gameObject.GetComponent<Octopus>().HitByTrap(1 - _speedDropRate / 100);
            collision.gameObject.GetComponent<Octopus>().HitByTrap(_speedDropRate);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Debug.Log("Trigger");
        if (collision.gameObject.CompareTag("Poulpe"))
        {
            //Debug.Log("Un poulpe !");
            collision.gameObject.GetComponent<Octopus>().ResetSpeed();
        }
    }
}
