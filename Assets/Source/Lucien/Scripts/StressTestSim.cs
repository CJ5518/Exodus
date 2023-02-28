using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StressTestSim : MonoBehaviour
{

    public ObjectPool pool;

    // Start is called before the first frame update
    private void Start()
    {
        GameObject obj = pool.GetObject();

        //get the position of the object
        obj.transform.position = new Vector3(0, 0, 0);
        obj.transform.rotation = Quaternion.identity;

        //call the new memeber every 2 seconds
        InvokeRepeating("SpawnPoolObject", 2, 2);

        //this will release the object when we are done...
        //pool.ReleaseObject(obj);
    }

    //this will make the program wait...
    private void SpawnPoolObject()
    {   
        //get the object from the availible pool
        GameObject obj = pool.GetObject();

        //get the position of the object
        obj.transform.position = new Vector3(0, 0, 0);
        obj.transform.rotation = Quaternion.identity;
        
    }
}
