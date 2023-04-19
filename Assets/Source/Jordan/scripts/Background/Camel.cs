using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camel : BackgroundActor
{
    // Start is called before the first frame update
    void Start()
    {
        SetupActor();
        fChanceChangeState = 0.3f;
        fChanceChangeDir = 0.3f;
        fSpeed = 0.001f;
    }

    public override void MakeDecisions()
    {
        if (Random.Range(0f,10f) < fChanceChangeState)
        {
            bIsMoving = !bIsMoving;
            aAnimator.SetBool("Is_Moving", bIsMoving);
        }
        ChangeDirection();
    }

    // Update is called once per frame

}
