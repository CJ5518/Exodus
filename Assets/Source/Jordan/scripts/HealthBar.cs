using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Slider sHealthSlider;
    private float fMaxHealth;
    public float fCurrentHealth;
    void Start()
    {
        fMaxHealth = 100;
        sHealthSlider = GetComponent<Slider>();
        if (sHealthSlider)
        {
            sHealthSlider.maxValue = fMaxHealth;
            sHealthSlider.minValue = 0;
        }

        SetHealth(fMaxHealth);
    }

    public bool SetHealth(float fInHealth)
    {
        if (fInHealth < 0 || fInHealth > 100)
        {
            return false;
        }
        fCurrentHealth = fInHealth;
        if (sHealthSlider)
            sHealthSlider.value = fInHealth;

        return true;
    }

    public void SetMaxHealth(int fInMaxHealth)
    {
        fMaxHealth = fInMaxHealth;
        if (sHealthSlider)
            sHealthSlider.maxValue = fMaxHealth;
        if (fCurrentHealth > fMaxHealth)
        {
            fCurrentHealth = fMaxHealth;
        }
    }

    public float GetHealth()
    {
        return fCurrentHealth;
    }
}
