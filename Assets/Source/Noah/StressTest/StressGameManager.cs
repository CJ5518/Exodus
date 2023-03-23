using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StressGameManager : MonoBehaviour
{
    private GameObject frog;
private static GameObject f;
private GameObject f1;
    private Vector3 up;
    private int maxSpeed;
    private float timer;


    // Start is called before the first frame update
    void Start()
    {
        maxSpeed = 5;
        timer = 0;
        frog = Resources.Load<GameObject>("prefabs/Noah/Frog");
    }

    // Update is called once per frame
    void Update()
    {
        //f1;
        timer += Time.deltaTime;
        if(timer >= 2){
            f = Instantiate(frog, new Vector2(4,0), Quaternion.identity, transform);
            f1 = f;
            Destroy(f, 2.0f);
            f.GetComponent<FrogScript>().receiveSpeed(maxSpeed);
            Debug.Log("stress speed: "+maxSpeed);
            maxSpeed += 5;
            timer = 0;
        }
        if(f != null && f.transform.position.x < 0) {
            Debug.Log("frog clips through wall at jump speed: "+maxSpeed);
            Destroy(this);
        }
    }
}
 