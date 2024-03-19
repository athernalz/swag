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
    public Animator animator;

    private void Start()
    {
        shopText.gameObject.SetActive(false);
    }

    private bool isPlayerInShopRange = false;

    private void Update()
    {
        bool playerCurrentlyInRange = Vector3.Distance(player.transform.position, shopTriggerArea.transform.position) <= shopTriggerArea.transform.localScale.x / 2f;

        // If the player has just entered the shop range
        if (playerCurrentlyInRange && !isPlayerInShopRange)
        {
            Debug.Log("Enter");
            isPlayerInShopRange = true;
            animator.SetTrigger("enterShopRange");
            shopText.gameObject.SetActive(true);
        }
        // If the player has just exited the shop range
        else if (!playerCurrentlyInRange && isPlayerInShopRange)
        { 
            Debug.Log("Exit");
            isPlayerInShopRange = false;
            animator.SetTrigger("exitShopRange");
        }

        // Open the shop if player clicks 'B' and is in range
        if (isPlayerInShopRange && Input.GetKeyDown(KeyCode.B))
        {
            Debug.Log("Open Shop");
            darkenScreen.gameObject.SetActive(true);
            foreach (Button button in shopButtons)
            {
                button.gameObject.SetActive(true);
            }
        }
    }
}

