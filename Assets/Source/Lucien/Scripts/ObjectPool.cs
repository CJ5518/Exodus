using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
/************************* CLASS DIAGRAM OR OBJECT POOL *******************************************************
 *  ----------                                         ------------------                                     *
 *  | Client | -------Asks for reusable object-------> | ObjectPool     |                                     *
 *  ----------                                         ------------------                                     *
 *      |                                              | +instance:array|                                     *
 *      |                                              ------------------                                     *
 *      |                                              |    +GetObject  |                                     *
 *      |                                              | +ReleaseObject |                                     *
 *      |                                              ------------------                                     *
 *      |                                                     /\                                              *
 *      |                                                     \/                                              *
 *      |                                                      |                                              *
 *      |                                                      |                   ------------------------   *
 *      |                                                      |                   |    PoolGameObject    |   *
 *      |                                                      |                   -----------------------    *
 *      |                                                      |                   |+DoPoolObjectScript()|    *
 *      |                                                      |                   -----------------------    *
 *      |                                                       -----------------> |                     |    *
 *      ----------------------- Uses --------------------------------------------> -----------------------    *
 **************************************************************************************************************/
//this is the pool where the arrows are stored and called from
public class ObjectPool : MonoBehaviour 
{
    public GameObject prefab; //the object that is being stored and called
    public int poolSize;        //this is the amount that will be in the pool upon initialization
    public bool willGrow;       //this is if the pool will grow in emergency cases
    private float cpuThreshHold = 65; //CPU threshhold that will be used to trigger the prefab generation based on current usage
    private float holdCurrentCpuUsage = 0; //this will hold the current amount of cpu usage that we are using...

    private List<GameObject> objects;   //refrence lists for the objects to be called and then stored again

    private ProcessorUsage processorUsage;  //gets the processor usage
    
    //function is called on initialization of the function
    public void Awake()
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
