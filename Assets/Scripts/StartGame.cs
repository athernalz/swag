using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    public Button startGameBttn;
    private void Start()
    {
        startGameBttn.onClick.AddListener(OnButtonClickStartGame);
        Button startGameBtn = startGameBttn.GetComponent<Button>();
    }

    void OnButtonClickStartGame()
    {
        SceneManager.LoadScene("GameScene");
        Debug.Log("Start gamed");
    }
}
