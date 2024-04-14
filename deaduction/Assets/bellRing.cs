using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bellRing : MonoBehaviour
{
    
    public AudioSource bell;
    public clock clock;
    public int characterNum = 0; //go one less
    public SpeechRecognitionTest speechR;
    public GameObject gptCube;
    bool delay = false;
    public fifthround fifthround;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("this thing goes gong but trigger");
        bell.Play();

        if (!delay)
        {
            clock.startClock();
            StartCoroutine(d_delay());
        }
        
    }
    
    IEnumerator d_delay()
    {
        delay = true;
        yield return new WaitForSeconds(5f);
        delay = false;
    }

    public void stopConvo()
    {
        StartCoroutine(waitforConvoOver());
        //code to stop convo and then iterate
        //do loop for when audio is playing
        
    }
    
    IEnumerator waitforConvoOver()
    {
        //find audio source on the speechr game object
        AudioSource audio = speechR.gpt.gameObject.GetComponentInChildren<AudioSource>();
        while(audio.isPlaying)
        {
            yield return new WaitForSeconds(1f);
        }
        //tell character to go away here or somewhere else
        speechR.gpt.gameObject.SetActive(false);
    }
    public void iterateChar()
    {
        if(characterNum + 1 >= 5){
            fifthround.startfifth();
        }
        else
        {
            characterNum++;
        }
        speechR.SetGPT(characterNum);
    }
}
