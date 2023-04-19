using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundActor : MonoBehaviour
{
    // Start is called before the first frame update
    protected Animator aAnimator;
    

    protected bool bIsMoving;
    protected float fChanceChangeState;
    protected float fChanceChangeDir;
    protected float fSpeed;
    public float iTTL;

    protected void SetupActor()
    {
        aAnimator = this.GetComponent<Animator>();
        bIsMoving = false;
        fSpeed = 0.01f;
        iTTL = 0;

    }
    public virtual void MakeDecisions()
    {
        if (Random.Range(0f, 10f) > 5)
            bIsMoving = false;
        else
            bIsMoving = true;
    }

    public virtual bool Move()
    {
        if (bIsMoving)
            this.transform.position = transform.position + new Vector3(fSpeed * (transform.localScale.x/Mathf.Abs(transform.localScale.x)), 0, 0);

        iTTL++;
        return transform.position.x > 10 || transform.position.x < -10 ? false : true;
    }

    protected virtual void ChangeDirection()
    {
        if (transform.position.x > 10 || transform.position.x < -10)
        {
            transform.localScale = Vector3.Scale(transform.localScale, new Vector3(-1, 1, 1));
            return;
        }

        if (Random.Range(0f, 10f) < fChanceChangeDir)
        {
            transform.localScale = Vector3.Scale(transform.localScale, new Vector3(-1, 1, 1));
        }

    }
}
