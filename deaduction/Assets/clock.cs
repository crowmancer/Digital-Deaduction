using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class clock : MonoBehaviour
{
    //int totalSeconds = 120;
    int currentSeconds = 120;
    public TMP_Text clocktext;

    public void startClock()
    {
        clocktext.SetText("2:00");
        currentSeconds = 5;
        StartCoroutine(doClock());
    }

    IEnumerator doClock()
    {
        while (currentSeconds >= 0)
        {
            yield return new WaitForSeconds(1f);
            var minutes = Math.Clamp(Math.Clamp(currentSeconds - (currentSeconds%60),0,120)/60,0, 60);
            var seconds = Math.Clamp(currentSeconds - minutes*60, 0, 60);

            if (seconds < 10)
            {
                clocktext.SetText($"{minutes}:0{seconds}");
            }
            else
            {
                clocktext.SetText($"{minutes}:{seconds}");
            }
            
            
            currentSeconds -= 1;
        }
        Debug.Log("Clock Finished");

        //Add code to kill conversation here
    }

    void Awake()
    {
        startClock();
    }
}
