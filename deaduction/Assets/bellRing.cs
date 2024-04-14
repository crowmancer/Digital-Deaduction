using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bellRing : MonoBehaviour
{
    
    public AudioSource bell;

    void OnCollisionEnter(Collision other)
    {
        Debug.Log("this thing goes gong");
        bell.Play();
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("this thing goes gong but trigger");
        bell.Play();
    }
}
