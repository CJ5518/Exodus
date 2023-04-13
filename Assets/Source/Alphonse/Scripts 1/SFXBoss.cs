using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXBoss : MonoBehaviour
{
    [SerializeField]
    AudioSource bossHurt;

    [SerializeField]
    AudioSource bossHitting;

    [SerializeField]
    AudioSource bossDeath;

    // Start is called before the first frame update
    public void playBossHurt()
    {
        bossHurt.Play();
    } 
    
    public void playBossDeath()
    {
        bossDeath.Play();
    }

    public void playBossHitting()
    {
        bossHitting.Play();
    }
}
