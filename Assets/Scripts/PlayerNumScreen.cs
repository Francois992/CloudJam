using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerNumScreen : MonoBehaviour
{
    public static PlayerNumScreen instance;
    [SerializeField] private GameObject defaultSelectedButton = null;

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

    void Start()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(defaultSelectedButton);
    }

    public void TwoPlayers()
    {
        GameManager.instance.playerNumber = 2;
        RemoveScreen();
    }
    public void ThreePlayers()
    {
        GameManager.instance.playerNumber = 3;
        RemoveScreen();
    }
    public void FourPlayers()
    {
        GameManager.instance.playerNumber = 4;
        RemoveScreen();
    }

    private void RemoveScreen()
    {
        gameObject.SetActive(false);
        BetManager.instance.gameObject.SetActive(true);
        GameManager.instance.AddPlayers();
    }
}
