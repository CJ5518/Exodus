using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MerchantMechanics : MonoBehaviour
{
    private Transform Player;
    private GameObject Merchant;
    public GameObject goMerchant;

    // Start is called before the first frame update
    void Start()
    {
        //goMercahnt = GameObject.FindObject.tag("????")
        //goMerchant.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(Player.transform.position, gameObject.transform.position) < 3)
        {
            //goMerchant.SetActive(true);
        } 
        else if(Vector3.Distance(Player.transform.position, gameObject.transform.position) > 3)
        {
            //goMerchant.SetActive(true);
        }
    }
}
