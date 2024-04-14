using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clipTester : MonoBehaviour
{
    public AudioSource sourcer;

    // Update is called once per frame
    public void clipTest(AudioClip theclip)
    {
        sourcer.clip = theclip;
        sourcer.Play();
    }
}
