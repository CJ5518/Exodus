using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManagerStressTest1 : MonoBehaviour
{
    public GameObject goBasicEnemy;
    public int iEnemyCount;
    public TextMeshProUGUI tmpEnemyCount;
    void Start()
    {
        iEnemyCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.frameCount % 10 == 0)
        {
            Instantiate(goBasicEnemy, new Vector3(0, 0, 0), Quaternion.identity);
            iEnemyCount++;
            tmpEnemyCount.SetText("Enemies: " + iEnemyCount);
        }
    }
}
