using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
   public Text timerLabel;

   protected float time;

   void Update()
   {
      time += Time.deltaTime;

      var minutes = time / 60;
      var seconds = time % 60;
      var fraction = (time * 100) % 100;

      //update the label value
      timerLabel.text = string.Format("{0:00} : {1:00} : {2:000}", minutes, seconds, fraction);
    }
}
