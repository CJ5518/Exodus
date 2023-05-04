using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MerchantMechanics : MonoBehaviour
{
    private GameObject player;
    public GameObject goMerchant;
    public ItemDatabase itemDatabase;
    //public bool merchantActive;
    public Inventory merchantInventory;
    CoinCollect ScoreManager;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        goMerchant = GameObject.Find("MerchantCanvas");
        goMerchant.SetActive(false);
        merchantInventory = GameObject.FindObjectOfType<Inventory>();
        ScoreManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<CoinCollect>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(player.transform.position, gameObject.transform.position) < 3)
        {
            goMerchant.SetActive(true);
            //iTime.timeScale = 0f;
            /*
            if (Input.GetKeyDown(KeyCode.1)) //Use a health potion
            {
                merchantInventory.GiveItem("Health Potion");
            }

            if (Input.GetKeyDown(KeyCode.2)) //Equip Jump pendant
            {
                merchantInventory.GiveItem("Jump Pendant");
            }

            if (Input.GetKeyDown(KeyCode.3)) //Equip Jump pendant
            {
                checkHealthPendant("Health Pendant");
            }

            if (Input.GetKeyDown(KeyCode.4)) //Equip Jump pendant
            {
                checkSpeedPendant("Speed Pendant");
            }

            if (Input.GetKeyDown(KeyCode.Q)) //Drop Item
            {
                Dropitem("Health Potion");
            }
            */
        } 
        else if(Vector3.Distance(player.transform.position, gameObject.transform.position) > 3)
        {
            goMerchant.SetActive(false);
            //Time.timeScale =1f;
        }
    }
}
