using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StressTestSim : MonoBehaviour
{

    // Start is called before the first frame update
    private void Start()
    {
        //call the new memeber every 2 seconds
        InvokeRepeating("SpawnPoolObject", 0.5f, 0.5f);

        //this will release the object when we are done...
        //pool.ReleaseObject(obj);
    }

    //this will make the program wait...
    private void SpawnPoolObject()
    {   
        //get the object from the availible pool
        GameObject obj = ObjectPool.Instance.GetObject();

        obj.transform.position = new Vector3(0, 0, 0);
        obj.transform.rotation = Quaternion.identity;
    }
}
