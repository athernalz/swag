using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Shopkeeper : MonoBehaviour
{
    public GameObject shopTriggerArea;
    public GameObject player;
    public TMP_Text shopText;
    public Button[] shopButtons;
    public Image darkenScreen;

    private void Start()
    {
        shopText.gameObject.SetActive(false);
    }

    private void Update()
    {
        // If player is in the shopkeeper area
        if (Vector3.Distance(player.transform.position, shopTriggerArea.transform.position) <= shopTriggerArea.transform.localScale.x / 2f)
        {
            shopText.gameObject.SetActive(true);

            // open the shop if player clicks b
            if (Input.GetKeyDown(KeyCode.B))
            {
                darkenScreen.gameObject.SetActive(true);
                foreach (Button button in shopButtons)
                {
                    button.gameObject.SetActive(true);
                }
            }
        }
    }
}

