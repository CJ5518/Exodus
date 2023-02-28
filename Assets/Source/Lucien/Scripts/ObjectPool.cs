using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class ObjectPool : MonoBehaviour
{

    public GameObject prefab;
    public int poolSize;
    public bool willGrow;
    private List<GameObject> objects;

    //this makes sure that multiple strings cannot be accessed by the same thing at a time
    private SemaphoreSlim semaphore;

    private void Awake()
    {
        objects = new List<GameObject>();
        semaphore = new SemaphoreSlim(poolSize, poolSize);

        for(int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab, transform);
            obj.SetActive(false);
            objects.Add(obj);
        }
    }

    //returns an availible object from the pool
    public GameObject GetObject()
    {
        semaphore.Wait();

        foreach (GameObject obj in objects)
        {
            if(!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                return obj;
            }
        }

        if(willGrow)
        {
            GameObject obj = Instantiate(prefab, transform);
            obj.SetActive(true);
            objects.Add(obj);
            semaphore.Release();
            return obj;
        }

        semaphore.Release();
        return null;
    }

    //this puts the object back into the pool
    public void ReleaseObject(GameObject obj)
    {
        obj.SetActive(false);
        semaphore.Release();
    }

}
