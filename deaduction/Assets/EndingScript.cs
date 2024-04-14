using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingScript : MonoBehaviour
{

    public int choice;
    public GameObject Vinny;
    public GameObject Emma;
    public GameObject Tyler;
    public GameObject LiamJail;

    void Start()
    {
        Vinny.SetActive(false);
        Emma.SetActive(false);
        Tyler.SetActive(false);
        LiamJail.SetActive(false);
        if (choice == 0)
        {
            Vinny.SetActive(true);
        }
        else if (choice == 1)
        {
            Emma.SetActive(true);
        }
        else if(choice == 2) {
            Tyler.SetActive(true);
        }
        else
        {
            LiamJail.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
