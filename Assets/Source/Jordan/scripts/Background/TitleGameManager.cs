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
    void Start()
    {
        iTick = 0;
        baBackgroundActors = new List<BackgroundActor>();

        for (int i = 0; i < Random.Range(2, 3); i++)
        {
            baBackgroundActors.Add(Instantiate(Camel, new Vector3(Random.Range(-10f, 10f), Random.Range(-4f, 1f)), Quaternion.identity).GetComponent<Camel>());
        }
        for (int i = 0; i < Random.Range(4, 6); i++)
        {
            baBackgroundActors.Add(Instantiate(Frog, new Vector3(Random.Range(-10f, 10f), Random.Range(-4f, 1f)), Quaternion.identity).GetComponent<Frog>());
        }
        for (int i = 0; i < Random.Range(4, 6); i++)
        {
            baBackgroundActors.Add(Instantiate(Bird, new Vector3(Random.Range(-10f, 10f), Random.Range(-4f, 1f)), Quaternion.identity).GetComponent<Bird>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (BackgroundActor aActor in baBackgroundActors)
        {
            if (iTick % 50 == 0)
                aActor.MakeDecisions();
            aActor.Move();
            iTick++;
        }
    }
}
