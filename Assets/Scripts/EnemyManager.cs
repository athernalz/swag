using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject SimpleEnemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouseScreenPosition = Input.mousePosition;
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
        mouseWorldPosition.z = 0;

        if (Input.GetKeyDown(KeyCode.Alpha1)) // Alpha1 = "1"
        {
            GameObject enemyInstance = Instantiate(SimpleEnemyPrefab, mouseWorldPosition, Quaternion.identity);
            AcidicSlime enemyScript = enemyInstance.GetComponent<AcidicSlime>();
            if (enemyScript != null)
            {
                enemyScript.playerPrefab = GameObject.FindGameObjectWithTag("Player"); // "Player" tag.
            }
        }

    }
}
