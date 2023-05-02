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
    public GameObject goDeathMenu;
    private CanvasGroup cgDeathMenu;
    private GameObject goBoss;
    private BossHealth bhBossHealth;
    private SettingsManager smSettingsManager;
    public GameObject apArrowPoint;

    private bool bLost;
    private bool bWon;
    private float fWinTick;
    private bool bDRBCMode;

    private float fTick;

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
        bDRBCMode = false;
        goPauseMenu.SetActive(false);
        pPlayer = GameObject.FindAnyObjectByType<Player>();
        goHealthBar = GameObject.FindAnyObjectByType<HealthBar>();
        cgDeathMenu = goDeathMenu.GetComponent<CanvasGroup>();
        bhBossHealth = GameObject.FindObjectOfType<BossHealth>();
        smSettingsManager = GameObject.FindObjectOfType<SettingsManager>();
        if (apArrowPoint)
            apArrowPoint.SetActive(false);

        cgDeathMenu.alpha = 0;
        goDeathMenu.SetActive(false);
        bLost = false;
        bWon = false;
        fWinTick = 0;
        fTick = 0;
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

        if (pPlayer.health <= 0 && !bLost && fTick > 100)
            LoseGame();

        if (bhBossHealth)
            if (bhBossHealth.healthAmt <= 0 && !bWon)
                WinGame();


        if (goBlur.bBlur && bLost && cgDeathMenu.alpha < 1f)
            cgDeathMenu.alpha += 0.03f;

        if (!bDRBCMode && smSettingsManager.bDrBCEnabled)
        {
            bDRBCMode = smSettingsManager.bDrBCEnabled;
            if (apArrowPoint)
                apArrowPoint.SetActive(true);
        } else if (bDRBCMode && !smSettingsManager.bDrBCEnabled)
        {
            bDRBCMode = smSettingsManager;
            if (apArrowPoint)
                apArrowPoint.SetActive(false);
        }

        if (bDRBCMode)
        {
            pPlayer.resetHealth();
            pPlayer.jumpForce = 1500.0f;
            Debug.Log("DRBC");
        } else { 
            //Reset the player jump force if not in bc mode
            if (pPlayer.jumpForce > 1400.0f) {
                 pPlayer.jumpForce = 440.0f;
            }
        }

        if (bWon)
        {
            if (fWinTick > 100)
            {
                SceneManager.LoadScene("GameComplete");
            }
            fWinTick++;
        }
        fTick++;

    }

    public void ClosePauseMenu()
    {
        goPauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void LoseGame()
    {
        goDeathMenu.SetActive(true);
        goBlur.bBlur = true;
        bLost = true;
    }

    public void WinGame()
    {
        goBlur.bBlur = true;
        bWon = true;
    }
}
    