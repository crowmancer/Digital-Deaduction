using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LMNT;

public class teststart : MonoBehaviour
{
    private LMNTSpeech speech;

  public void BeginSpeaking(string passSpeech) 
  {
    // ... your code here ...
    speech = GetComponent<LMNTSpeech>();
    speech.dialogue = passSpeech;
    StartCoroutine(speech.Talk());
    
  }

  public IEnumerator waiter()
  {
    yield return new WaitForSeconds(3);
    speech.GetComponent<AudioSource>().Play();
  }
}
