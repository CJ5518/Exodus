using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : BackgroundActor
{
    // Start is called before the first frame update
    private float fVerticalVelocity;
    void Start()
    {
        SetupActor();
        fChanceChangeState = 0.1f;
        fChanceChangeDir = 1f;
        fSpeed = 0.005f;
        fVerticalVelocity = 0;
    }

    public override void MakeDecisions()
    {
        if (Random.Range(0f, 10f) < fChanceChangeState)
        {
            if (bIsMoving)
            {
                if (transform.position.x > 1)
                {
                    fVerticalVelocity = fSpeed * -1;
                }
                else
                {
                    bIsMoving = !bIsMoving;
                    aAnimator.SetBool("Is_Flying", bIsMoving);
                }
            }
            else
            {
                bIsMoving = !bIsMoving;
                aAnimator.SetBool("Is_Flying", bIsMoving);
                fVerticalVelocity = fSpeed;
            }
            
        }
        ChangeDirection();
    }

    protected override void ChangeDirection()
    {
        if (transform.position.x > 10 || transform.position.x < -10)
        {
            transform.localScale = Vector3.Scale(transform.localScale, new Vector3(-1, 1, 1));
        }
        if (transform.position.y > 1 || transform.position.y < -5)
        {
            fVerticalVelocity *= -1;
        }

        if (Random.Range(0f, 10f) < fChanceChangeDir)
        {
            transform.localScale = Vector3.Scale(transform.localScale, new Vector3(-1, 1, 1));
        }

    }

    public override void Move()
    {
        if (bIsMoving)
            this.transform.position = transform.position + new Vector3(fSpeed * (transform.localScale.x / Mathf.Abs(transform.localScale.x)), fVerticalVelocity, 0);
    }

}
