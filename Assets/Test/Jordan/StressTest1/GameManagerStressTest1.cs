using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManagerStressTest1 : MonoBehaviour
{
    public GameObject goBasicEnemy;
    public int iEnemyCount;
    public TextMeshProUGUI tmpEnemyCount;
    public TextMeshProUGUI tmpFPS;
    private int iBelow60;

    void Start()
    {
        iEnemyCount = 0;
        iBelow60 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float iFramerate = 1 / Time.smoothDeltaTime;

        if (Time.frameCount % 10 == 0 && iBelow60 < 5)
        {
            if (iFramerate > 60)
            {
                Instantiate(goBasicEnemy, new Vector3(0, 0, 0), Quaternion.identity);
                iEnemyCount++;
                tmpEnemyCount.SetText("Enemies: " + iEnemyCount);
            }
            else
            {
                iBelow60++;
            }

        }

        if (Time.frameCount % 20 == 0)
        {
            tmpFPS.SetText("FPS: " + iFramerate);
        }
    }
}
