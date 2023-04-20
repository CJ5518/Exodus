using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this was strictly dor testing purposes and should not be used
public class TestLevelScene : MonoBehaviour
{
    [SerializeField]
    private LightBanditPool lightBanditPool;

    private void Start()
    {
        /*
        GameObject obj = ObjectPool.GetObject();

        obj.transform.position = new Vector3(8, -3, 0);
        obj.transform.rotation = Quaternion.identity;

        ObjectPool.ReleaseObject(obj);
        */
        
        //this is how you call in the light bandits in the correct position that you want them in
        GameObject obj1 = lightBanditPool.GetObject(); 
        obj1.transform.position = new Vector3(-7, -4, 0);
        obj1.transform.rotation = Quaternion.identity;
    }

}
