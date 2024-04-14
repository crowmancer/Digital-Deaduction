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
    bool clockGoing = false;
    public bellRing bell;

    public void startClock()
    {
        if (clockGoing)
        {
            clockGoing = false;
            bell.stopConvo();
        }
        else
        {
            //reset clock
            clocktext.SetText("2:00");
            currentSeconds = 120;
            bell.iterateChar();
            StartCoroutine(doClock());
        }
        
        
    }

    IEnumerator doClock()
    {
        clockGoing = true;
        while (currentSeconds >= 0 && clockGoing)
        {
            yield return new WaitForSeconds(1f);
            var minutes = Math.Clamp(Math.Clamp(currentSeconds - (currentSeconds%60),0,120)/60,0, 60);
            var seconds = Math.Clamp(currentSeconds - minutes*60, 0, 60);

            //make seconds have 0 if infront of it
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
        //stop convo after time is up
        bell.stopConvo();
        Debug.Log("Clock Finished");
        clockGoing = false;

        //Add code to kill conversation here
    }
}
