using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowHold : MonoBehaviour
{
    [SerializeField]
    private Transform enemy;            //this gets the enemy position and where it is aiming

    private void Update()
    {
        transform.localScale = enemy.localScale;
    }
}
