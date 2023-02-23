using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private EventManager em;

    // Start is called before the first frame update
    void Start()
    {
        em = Resources.Load<EventManager>("prefabs/Noah/myEventManager");
        Instantiate(em);
 
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("h"))
            em.startEvent(1);
    }
}
 