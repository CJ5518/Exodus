using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCondition : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Pause the game if the Slot Object reaches outside of the walls
        if (collision.collider.tag == "Slot")
        {
            Time.timeScale = 0; 
        }
    }
}
