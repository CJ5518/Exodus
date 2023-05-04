using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MerchantMechanics : MonoBehaviour
{
    private GameObject player;
    public GameObject goMerchant;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        goMerchant = GameObject.Find("MerchantCanvas");
        goMerchant.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(player.transform.position, gameObject.transform.position) < 3)
        {
            goMerchant.SetActive(true);
        } 
        else if(Vector3.Distance(player.transform.position, gameObject.transform.position) > 3)
        {
            goMerchant.SetActive(false);
        }
    }
}
