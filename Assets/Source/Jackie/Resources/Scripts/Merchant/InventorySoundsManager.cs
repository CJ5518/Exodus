using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySoundsManager : MonoBehaviour
{
    // Start is called before the first frame update

    public static InventorySoundsManager Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
