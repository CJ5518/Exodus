using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Script to generate a textbox describing the item for the user
public class Tooltip : MonoBehaviour
{
    private Text tooltipText;

    void Start()
    {
        tooltipText = GetComponentInChildren<Text>();
        gameObject.SetActive(false);
        tooltipText.gameObject.SetActive(false);
    }

    //Generate string and display text box
    public void GenerateTooltip(Item item)
    {
        string statText = ""; //Empty if no stats on item
        if(item.stats.Count > 0) //Check if item has stats
        {
            foreach(var stat in item.stats)
            {
                statText += stat.Key.ToString() +  ": " + stat.Value.ToString() + "\n";
            }
        }
        //generate string
        string tooltip = string.Format("<b>{0}</b>\n{1}\n\n<b>{2}</b>", item.title, item.description, statText);
        tooltipText.text = tooltip;
        gameObject.SetActive(true);
    }

    //Hide textbox when called
    public void HideTooltip()
    {
        gameObject.SetActive(false);
    }
}
