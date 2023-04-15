using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SoundManager : MonoBehaviour
{
    public Slider sVolume;

    public void ChangeVolume()
    {
        AudioListener.volume = sVolume.value;
    }
}
