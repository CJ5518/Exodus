using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class ObjectPool : MonoBehaviour 
{
    public static ObjectPool Instance { get; private set; }

    public GameObject prefab;
    public int poolSize;
    public bool willGrow;

    private List<GameObject> objects;

    private void Awake()
    {
        //this impliments the singleton pattern
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

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

        //allow for more objects to be created in the pool if needed
        if(willGrow)
        {
            for(int i = 0; i < poolSize; i++)
            {
                CreateObject();
            }
        }

        //if there are no availible objectsa nd willgrow is false then return null
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
