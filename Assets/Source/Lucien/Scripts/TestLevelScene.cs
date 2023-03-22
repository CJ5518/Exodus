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
    }

}
