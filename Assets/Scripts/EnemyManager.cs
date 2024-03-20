using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject AcidicSlime;
    public GameObject Sniper;


    void Update()
    {
        Vector3 mouseScreenPosition = Input.mousePosition;
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
        mouseWorldPosition.z = 0;

        if (Input.GetKeyDown(KeyCode.Alpha1)) // Alpha1 = "1"
        {
            GameObject enemyInstance = Instantiate(AcidicSlime, mouseWorldPosition, Quaternion.identity);
            AcidicSlime enemyScript = enemyInstance.GetComponent<AcidicSlime>();
            if (enemyScript != null)
            {
                enemyScript.playerPrefab = GameObject.FindGameObjectWithTag("Player"); // "Player" tag.
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) // Alpha1 = "1"
        {
            GameObject enemyInstance = Instantiate(Sniper, mouseWorldPosition, Quaternion.identity);
            Sniper enemyScript = enemyInstance.GetComponent<Sniper>();
            if (enemyScript != null)
            {
                
            }
        }

    }
}
