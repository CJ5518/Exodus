using System.Collections;
using System.Collections.Generic;
using System.Collections.Concurrent;
using UnityEngine;

public class BackgroundActorsPool : MonoBehaviour
{
    private readonly ConcurrentBag<BackgroundActor> cbActors = new ConcurrentBag<BackgroundActor>();
    private int iActorCount;
    private int iMaxActors;
    private GameObject Bird;
    private GameObject Camel;
    private GameObject Frog;

    public BackgroundActorsPool (int iMaxIn)
    {
        iMaxActors = iMaxIn;
        Bird = (GameObject)Resources.Load("prefabs/Jordan/Bird", typeof(GameObject));
        Frog = (GameObject)Resources.Load("prefabs/Jordan/Frog", typeof(GameObject));
        Camel = (GameObject)Resources.Load("prefabs/Jordan/Camel", typeof(GameObject));

    }

    public BackgroundActor GetActor()
    {
        BackgroundActor baActor;

        if (cbActors.TryTake(out baActor))
        {
            iActorCount--;
            return baActor;
        }
        else
        {
            if (iActorCount < iMaxActors)
            {
                BackgroundActor tTempObject;
                float fRandomVal = Random.Range(0, 100);
                if (fRandomVal <= 40)
                    tTempObject = Instantiate(Bird, new Vector3(Random.Range(-10f, 10f), Random.Range(-4f, 1f)), Quaternion.identity).GetComponent<Bird>();
                else if (fRandomVal > 40 && fRandomVal < 80)
                    tTempObject = Instantiate(Frog, new Vector3(Random.Range(-10f, 10f), Random.Range(-4f, 1f)), Quaternion.identity).GetComponent<Frog>();
                else
                    tTempObject = Instantiate(Camel, new Vector3(Random.Range(-10f, 10f), Random.Range(-4f, 1f)), Quaternion.identity).GetComponent<Camel>();


                cbActors.Add(tTempObject);
                iActorCount++;
                return tTempObject;
            }
            else
                return null;

        }
    }

    public void Release(BackgroundActor item)
    {
        if (iActorCount < iMaxActors)
        {
            cbActors.Add(item);
            iActorCount++;
        }
    }
}
