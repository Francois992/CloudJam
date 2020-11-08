using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TutoScreen : MonoBehaviour
{
    [SerializeField] private GameObject defaultSelectedButton = null;

    private void OnEnable()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(defaultSelectedButton);
    }

    public void QuitTuto()
    {
        EventSystem.current.SetSelectedGameObject(null);
        GameManager.instance.tutoScreen.SetActive(false);
        PlayerNumScreen.instance.gameObject.SetActive(true);
    }
}
