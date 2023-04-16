using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class PotionPool : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private int poolSize;

    private List<GameObject> objects;
    
    void Start()
    {
        objects = new List<GameObject>();

        for(int i = 0; i < poolSize; i++)
        {
            CreateObject();
        }
    }

        //returns an availible object from the pool
    public GameObject GetObject()
    {  

        for(int i = 0; i < objects.Count; i++)
        {
            if(!objects[i].activeInHierarchy)
            {
                objects[i].SetActive(true);
                return objects[i];
            }
        }

        
        return null;
    }

    //this puts the object back into the pool
    public void ReleaseObject(GameObject obj)
    {
        obj.SetActive(false);
    }

    //this will make a new object and add the new object to the pool
    private GameObject CreateObject()
    {
        GameObject obj = Instantiate(prefab, transform);
        obj.SetActive(false);
        objects.Add(obj);
        return obj;
    }
}
