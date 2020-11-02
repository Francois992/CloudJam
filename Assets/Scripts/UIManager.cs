using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;

    void Awake()
    {
        if (_instance == null)
        {

            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    [SerializeField] private Canvas MainMenu = null;
    [SerializeField] private Canvas LoseScreen = null;
    [SerializeField] private Canvas WinScreen = null;

    private Canvas currentScreen;
    
    // Start is called before the first frame update
    void Start()
    {
        currentScreen = MainMenu;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) LoadWinScreen();
        if (Input.GetKeyDown(KeyCode.L)) LoadLoseScreen();
    }

    public void LoadMainMenu()
    {
        currentScreen.gameObject.SetActive(false);

        MainMenu.gameObject.SetActive(true);
        currentScreen = MainMenu;
    }
    public void LoadLoseScreen()
    {
        SceneManager.LoadScene("UI_Scene");
        currentScreen.gameObject.SetActive(false);

        LoseScreen.gameObject.SetActive(true);
        currentScreen = LoseScreen;
    }
    public void LoadWinScreen()
    {
        SceneManager.LoadScene("UI_Scene");
        currentScreen.gameObject.SetActive(false);

        WinScreen.gameObject.SetActive(true);
        currentScreen = WinScreen;
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Main_Scene");
        currentScreen.gameObject.SetActive(false);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
