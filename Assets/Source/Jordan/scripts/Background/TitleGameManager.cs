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
            baBackgroundActors.Add(bpUnusedActors.GetActor());
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (BackgroundActor aActor in baBackgroundActors)
        {
            if (aActor)
            {
                if (iTick % 50 == 0)
                    aActor.MakeDecisions();
                aActor.Move();
                iTick++;
            }
        }
    }
}
