using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class LightBanditPool : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private int poolSize;
    [SerializeField]
    private bool willGrow;

    private List<GameObject> objects;

    private float cpuThreshHold = 65; //CPU threshhold that will be used to trigger the prefab generation based on current usage
    private float holdCurrentCpuUsage = 0; //this will hold the current amount of cpu usage that we are using...

    private ProcessorUsage processorUsage;

    void Start()
    {
        objects = new List<GameObject>();

        for(int i = 0; i < poolSize; i++)
        {
            CreateObject();
        }

        processorUsage = new ProcessorUsage();
    }

    //returns an availible object from the pool
    public GameObject GetObject()
    {
        //check the CPU usage    
        holdCurrentCpuUsage = processorUsage.GetCurrentValue();
        UnityEngine.Debug.Log(holdCurrentCpuUsage);    
        if(holdCurrentCpuUsage < cpuThreshHold)
        {
            //create 10 new prefabs in down time...
            for(int i = 0; i < 10; i++)
            {
                CreateObject();
            }
        }

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
            for(int i = 0; i < objects.Count; i++)
            {
                if(!objects[i].activeInHierarchy)
                {
                    objects[i].SetActive(true);
                    return objects[i];
                }
            }
        }

        //if there are no availible objectsa nd willgrow is false then return null
        return null;
    }

    //this puts the object back into the pool
    public void ReleaseMeleeObject(GameObject obj)
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
