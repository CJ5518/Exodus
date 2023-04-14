using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : BackgroundActor
{
    // Start is called before the first frame update
    void Start()
    {
        SetupActor();
        fChanceChangeState = 0.5f;
        fSpeed = 0.0005f;
    }

    public override void MakeDecisions()
    {
        if (Random.Range(0f, 10f) < fChanceChangeState)
        {
            bIsMoving = !bIsMoving;
            aAnimator.SetBool("Is_Moving", bIsMoving);
        }
        ChangeDirection();

    }

}
