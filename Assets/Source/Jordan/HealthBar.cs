using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*using TMPro;
*/
public class HealthBar : MonoBehaviour
{
    /*private TextMeshProUGUI tmpHealthText;*/
    private Slider sHealthSlider;
    private float fMaxHealth;
    public float fCurrentHealth;
    void Start()
    {
        fMaxHealth = 100;
/*        tmpHealthText = GameObject.Find("HealthText").GetComponent<TextMeshProUGUI>();
        sHealthSlider = GetComponent<Slider>();*/
/*        sHealthSlider.maxValue = fMaxHealth;
        sHealthSlider.minValue = 0;*/
        SetHealth(fMaxHealth);
    }

    public bool SetHealth(float fInHealth)
    {
        if (fInHealth < 0 || fInHealth > 100)
        {
            return false;
        }
        fCurrentHealth = fInHealth;
/*        tmpHealthText.SetText(Mathf.RoundToInt(fInHealth) + "/" + fMaxHealth);
*/        //sHealthSlider.value = fInHealth;

        return true;
    }

    public void SetMaxHealth(int fInMaxHealth)
    {
        fMaxHealth = fInMaxHealth;
        //sHealthSlider.maxValue = fMaxHealth;
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
