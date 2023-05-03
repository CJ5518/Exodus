using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MummyDead : MonoBehaviour
{
    [SerializeField]
    private BossHealth bosshealth;

    public BackgroundBlur goBlur;
    [SerializeField]
    private CanvasGroup canvasBossBeat;

    [SerializeField]
    private GameObject BossBeatScreen;

    // Update is called once per frame
    void Update()
    {
        if(bosshealth.healthAmt <= 0)
        {
            BossSave.boss1Beat = true;
            goBlur.bBlur = true;
            BossBeatScreen.SetActive(true);
            canvasBossBeat.alpha += 0.03f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
}
