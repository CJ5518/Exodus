using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLevelScene : MonoBehaviour
{
    private void Start()
    {
        GameObject obj = ObjectPool.Instance.GetObject();

        obj.transform.position = new Vector3(8, -3, 0);
        obj.transform.rotation = Quaternion.identity;

        ObjectPool.Instance.ReleaseObject(obj);

        //this is how you call in the light bandits in the correct position that you want them in
        GameObject obj1 = LightBanditPool.Instance.GetObject();
        obj1.transform.position = new Vector3(-7, -4, 0);
        obj1.transform.rotation = Quaternion.identity;
    }

}
