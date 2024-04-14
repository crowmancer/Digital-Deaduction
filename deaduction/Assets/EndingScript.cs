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
    public GameObject Win;
    public GameObject Loose;

    void Start()
    {
        Vinny.SetActive(false);
        Emma.SetActive(false);
        Tyler.SetActive(false);
        LiamJail.SetActive(false);
        Win.SetActive(false);
        Loose.SetActive(false);
        choice = PlayerPrefs.GetInt("charnumber");
        if (choice == 0)
        {
            Vinny.SetActive(true);
            Loose.SetActive(true);
        }
        else if (choice == 1)
        {
            Emma.SetActive(true);
            Loose.SetActive(true);
        }
        else if(choice == 2) {
            Tyler.SetActive(true);
            Loose.SetActive(true);
        }
        else
        {
            LiamJail.SetActive(true);
            Win.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
