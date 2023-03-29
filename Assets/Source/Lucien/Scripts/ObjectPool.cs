using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.Diagnostics; 

//Bug with the CPU usage being monitored in unity... Otherwise it would work...
// https://forum.unity.com/threads/100-cpu-usage-on-all-cores-when-in-play-mode-editor-is-out-of-focus-or-minimized-2020-1-1.948604/

public class ObjectPool : MonoBehaviour 
{
    public static ObjectPool Instance { get; private set; }

    public GameObject prefab;
    public int poolSize;
    public bool willGrow;
    private float cpuThreshHold = 25; //CPU threshhold that will be used to trigger the prefab generation based on current usage

    private List<GameObject> objects;

    private PerformanceCounter cpuCounter;
    
    public void Awake()
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

        cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
        cpuCounter.NextValue();
    }

    //returns an availible object from the pool
    public GameObject GetObject()
    {
        //check the CPU usage
        float cpuUsage = GetCPUUsage();
        UnityEngine.Debug.Log("CPU usage: " + cpuUsage);
        if(cpuUsage < cpuThreshHold)
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

    //this function will retrueve the current cpu usage of the program
    private float GetCPUUsage()
    {
        float cpuUsage = cpuCounter.NextValue();
        Thread.Sleep(10);         //wait 10 milliseconds to allow the CPU to update...
        cpuUsage = cpuCounter.NextValue();
        return cpuUsage;
    }
}
