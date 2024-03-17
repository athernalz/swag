using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Canvas menu;
    public Button backToGameBttn;
    public Button mainMenuBttn;

    private void Start()
    {
        Button backToGamebtn = backToGameBttn.GetComponent<Button>();
        Button mainMenubtn = mainMenuBttn.GetComponent<Button>();
        backToGameBttn.onClick.AddListener(OnButtonClickBackToGame);
        mainMenubtn.onClick.AddListener(OnButtonClickMainMenu);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            menu.gameObject.SetActive(true);
            Debug.Log("Main menu activated");
        }
    }
    void OnButtonClickBackToGame()
    {
        Time.timeScale = 1f;
        menu.gameObject.SetActive(false);
        Debug.Log("Going back to game");
    }
    void OnButtonClickMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Debug.Log("Main Menu Button");
    }
}
