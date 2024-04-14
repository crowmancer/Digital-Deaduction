using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finscreen : MonoBehaviour
{
    
    public void win(int charnum)
    {
        PlayerPrefs.SetInt("charnumber", charnum);
        SceneManager.LoadScene("EndingScene");
    }
}
