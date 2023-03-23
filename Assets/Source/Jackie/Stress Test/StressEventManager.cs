using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StressEventManager : MonoBehaviour
{
    private int numberOfObjects = 0;
    public GameObject slot;
    private Vector2 vPos;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Number of Objects " + numberOfObjects );
        //Set initial Position
        vPos = new Vector2(0,0); 
        //Create a Object every .2 seconds
        InvokeRepeating("CreateSlot", 0.5f, 0.2f);
    }

    // Repeatility Called by InvokeRepeating
    private void CreateSlot()
    {   
        //Create new object at position(2,2,0) and increase count
        GameObject obj = Instantiate(slot); 
        obj.transform.position = new Vector3(2, 2, 0);
        obj.transform.rotation = Quaternion.identity;
        numberOfObjects++;
        Debug.Log("Number of Objects " + numberOfObjects );
    }
}
