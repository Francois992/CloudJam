using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNumScreen : MonoBehaviour
{
    public static PlayerNumScreen instance;
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

    public void RemoveScreen()
    {
        gameObject.SetActive(false);
    }
}
