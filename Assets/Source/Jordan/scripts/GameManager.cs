using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    private Player pPlayer;
    public GameObject goPauseMenu;
    public BackgroundBlur goBlur;
    private HealthBar goHealthBar;
    public Canvas goDeathMenu;
    private CanvasGroup cgDeathMenu;
    public GameObject goBoss;
    private BossHealth bhBossHealth;

    private bool bLost;
    private bool bWon;
    private float fWinTick;

    private static GameManager instance = null;
    private static readonly object padlock = new object();


    public static GameManager Instance
    {
        get
        {
            lock (padlock)
            {
                if (instance == null)
                {
                    instance = new GameManager();
                }
                return instance;
            }
        }
    }

    void Start()
    {

        goPauseMenu.SetActive(false);
        pPlayer = GameObject.FindAnyObjectByType<Player>();
        goHealthBar = GameObject.FindAnyObjectByType<HealthBar>();
        cgDeathMenu = goDeathMenu.GetComponent<CanvasGroup>();
        bhBossHealth = goBoss.GetComponent<BossHealth>();

        cgDeathMenu.alpha = 0;
        bLost = false;
        bWon = false;
        fWinTick = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("tab"))
        {
            goPauseMenu.SetActive(true);
            Time.timeScale = 0;
        }

        goHealthBar.SetHealth(pPlayer.health);

        if (pPlayer.health <= 0 && !bLost)
            LoseGame();

        if (goBoss)
            if (bhBossHealth.healthAmt <= 0 && !bWon)
                WinGame();


        if (goBlur.bBlur && bLost && cgDeathMenu.alpha < 1f)
            cgDeathMenu.alpha += 0.03f;

        if (bWon)
        {
            if (fWinTick > 100)
            {
                SceneManager.LoadScene("GameComplete");
            }
            fWinTick++;
        }

    }

    public void ClosePauseMenu()
    {
        goPauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void LoseGame()
    {
        goBlur.bBlur = true;
        bLost = true;
    }

    public void WinGame()
    {
        goBlur.bBlur = true;
        bWon = true;
    }
}
    