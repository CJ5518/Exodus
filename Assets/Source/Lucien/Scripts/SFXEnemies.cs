using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script will allow us to make sound effects for the enemies and their functions
//All these sounds are plagarized from past video games
//this doesn't violate copyright law as if is for educational purposes...
public class SFXEnemies : MonoBehaviour
{
    
    public AudioSource archerDeath;        //this will be the sound for the archer enemy death

    public AudioSource banditDeath;        //this will be the sound for the bandit (melee) enemy death

    public AudioSource archerShoot;        //this is the sound that will be made every time an arrow is shot

    public AudioSource archerHitPlayer;    //this is the sound that will play every time an arrow hits the player

    public void PlayArcherDeath()
    {
        archerDeath.Play();
    }

    public void PlayBanditDeath()
    {
        banditDeath.Play();
    }

    public void PlayArcherShoot()
    {
        archerShoot.Play();
    }

    public void PlayArcherHitPlayer()
    {
        archerHitPlayer.Play();
    }
}
