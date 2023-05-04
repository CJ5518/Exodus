using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
//using UnityEngine.UI;

public class CoinCollect : MonoBehaviour
{
    public static CoinCollect instance;

    public TextMeshProUGUI coinText;
    public int currentCoins = 0;

    int cost;

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        coinText.text = currentCoins.ToString();
        currentCoins = 1;
    }

    public void CoinCollected()
    {
        currentCoins++;
        coinText.text = currentCoins.ToString();
    }

    public void useCoin()
    {
        currentCoins--;
    }
}
