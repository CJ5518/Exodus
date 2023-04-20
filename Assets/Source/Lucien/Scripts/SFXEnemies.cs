using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script will allow us to make sound effects for the enemies and their functions
//All these sounds are plagarized from past video games (SEGA Golden Axe II)
//original copyright rights - All compositions, arrangements, images, and trademarks are copyright their respective owners. Original content is copyright OverClocked ReMix, LLC.
//this violates becasue - The original artist that owns the rights to this song has not been dead for 70 years, and OverClocked ReMix, LLC. sold the game rights to SEGA
//if violated - Willful copyright infringement can result in criminal penalties including imprisonment of up to five years and fines of up to $250,000 per offense.
// Copyright infringement can also result in civil judgments.
//this doesn't violate copyright law as if is for educational purposes...

//this calls the sounds that are all in audio sources on the "audio" prefab that is attached to both of the enemy prefabs
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
