using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondBossScript : MonoBehaviour
{
    [SerializeField]
    private BossHealth bosshealth;

    // Update is called once per frame
    void Update()
    {
        if(bosshealth.healthAmt <= 0)
            BossSave.boss2Beat = true;
    }
}
