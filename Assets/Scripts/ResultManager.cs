using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultManager : MonoBehaviour
{
    public static ResultManager instance;
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

    [SerializeField] private Image HorseWinner = null;
    [SerializeField] private Text HorseWinnerName = null;
    [SerializeField] private Text Player1Result = null;
    [SerializeField] private Text Player2Result = null;
    [SerializeField] private Text Player3Result = null;
    [SerializeField] private Text Player4Result = null;

    [SerializeField] private GameObject defaultSelectedButton = null;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowResults()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(defaultSelectedButton);

        HorseWinner.sprite = GameManager.instance.OctoHorses[0].GetComponent<SpriteRenderer>().sprite;
        HorseWinnerName.text += " "+GameManager.instance.OctoHorses[0].attribute.name;

        if (GameManager.instance.Players[0].hasWon)
        {
            Player1Result.text += " Win";
        }
        else
        {
            Player1Result.text += " Lose";
        }
        if (GameManager.instance.Players[1].hasWon)
        {
            Player2Result.text += " Win";
        }
        else
        {
            Player2Result.text += " Lose";
        }
        if (GameManager.instance.Players[2].hasWon)
        {
            Player3Result.text += " Win";
        }
        else
        {
            Player3Result.text += " Lose";
        }
        if (GameManager.instance.Players[3].hasWon)
        {
            Player4Result.text += " Win";
        }
        else
        {
            Player4Result.text += " Lose";
        }
    }

    public void Restart()
    {
        GameManager.instance.ResetRace();
    }
    
    public void MainMenu()
    {
        SceneManager.LoadScene("UI_Scene");
    }
}
