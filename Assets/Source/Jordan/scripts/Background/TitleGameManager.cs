using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleGameManager : MonoBehaviour
{

    private int iTick;

    public GameObject Bird;
    public GameObject Camel;
    public GameObject Frog;
    private List<BackgroundActor> baBackgroundActors;
    private BackgroundActorsPool bpUnusedActors;
    void Start()
    {
        iTick = 0;
        baBackgroundActors = new List<BackgroundActor>();
        bpUnusedActors = new BackgroundActorsPool(20);

        for (int i = 0; i < 19; i++)
        {
            BackgroundActor baTempHolder = bpUnusedActors.GetActor();
            if (baTempHolder)
                baBackgroundActors.Add(baTempHolder);
        }
    }

    // Update is called once per frame
    void Update()
    {

        for (int i = 1; i < 20 - baBackgroundActors.Count; i++)
        {
            BackgroundActor baTempHolder;
            if (baTempHolder = bpUnusedActors.GetActor())
            {
                baBackgroundActors.Add(baTempHolder);
                baTempHolder.transform.position = new Vector3(Random.Range(-10f, 10f), Random.Range(-4f, 1f));
            }
            else
                break;
        }


        int j = 0;
        foreach (BackgroundActor aActor in baBackgroundActors)
        {
            if (aActor)
            {
                if (iTick % 50 == 0)
                    aActor.MakeDecisions();
                

                if (!aActor.Move() && aActor.iTTL > 5000)
                {
                    bpUnusedActors.Release(aActor);
                    baBackgroundActors.RemoveAt(j);
                    break;
                }

                j++;
                iTick++;
            }
        }
    }
}
