using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fifthround : MonoBehaviour
{
    public SpeechRecognitionTest speechR;
    public clock clock;
    // Start is called before the first frame update
    public GameObject set1;
    public GameObject set2;
    public GameObject set3;
    public GameObject set4;
    public GameObject set5;
    public void startfifth()
    {
        set1.SetActive(false);
        set4.SetActive(false);
        set2.SetActive(false);
        set3.SetActive(false);

        set5.SetActive(true);
    }

    public void doChar(int num)
    {
        speechR.SetGPT(num);
        clock.startClock();
        set5.SetActive(false);
        set4.SetActive(true);
    }
}
