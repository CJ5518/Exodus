using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StressTestSim : MonoBehaviour
{ 
    [SerializeField]
    private Text count;

    private int countNum = 0;
    // Start is called before the first frame update
    private void Start()
    {
        count.text = "Number of enemies: " + countNum;
        //call the new memeber every 2 seconds
        InvokeRepeating("SpawnPoolObject", 0.5f, 0.5f);

        
        //this will release the object when we are done...
        //pool.ReleaseObject(obj);
    }

    //this will make the program wait...
    private void SpawnPoolObject()
    {   
        //get the object from the availible pool
        GameObject obj = LightBanditPool.Instance.GetObject();

        obj.transform.position = new Vector3(0, 4, 0);
        obj.transform.rotation = Quaternion.identity;

        if(obj != null)
        {
            countNum++;
            count.text = "Number of enemies: " + countNum;
        }
    }

}
