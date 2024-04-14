using System.IO;
using HuggingFace.API;
using TMPro;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class SpeechRecognitionTest : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;

    private AudioClip clip;
    private byte[] bytes;
    private bool recording;
    private bool xDown;
    private bool activity = true;
    // OpenXR Input Actions
    public InputActionReference inputAction;
    public ChatGPTManager gpt;

    public ChatGPTManager gpt1;
    public ChatGPTManager gpt2;
    public ChatGPTManager gpt3;
    public ChatGPTManager gpt4;
    
    private void Start()
    {
        
    }

    public void SetGPT(int num)
    {
        switch(num) 
        {
            case 1:
                gpt = gpt1;
                break;
            case 2:
                gpt = gpt2;
                break;
            case 3:
                gpt = gpt3;
                break;
            case 4:
                gpt = gpt4;
                break;
        }
        Debug.Log(num);
        gpt.gameObject.SetActive(true);
    }
    public void SetActive(bool val) 
    {
        activity = val;
    }

    private void Update()
    {
        if (activity == false) {StopRecording();}
        else
        {
            if (inputAction.action.triggered)
            {
                if (!xDown) {
                    xDown=true;
                }
                else {
                    xDown=false;
                }
                if (xDown && !recording)
                {
                    StartRecording();
                }
                else if (!xDown && recording)
                {
                    StopRecording();
                }

                if (recording && Microphone.GetPosition(null) >= clip.samples)
                {
                    StopRecording();
                }
            }
        }
        
        
        
    }

    private void StartRecording()
    {
        text.color = Color.white;
        text.text = "Recording...";
        clip = Microphone.Start(null, false, 10, 44100);
        recording = true;
    }

    private void StopRecording()
    {
        var position = Microphone.GetPosition(null);
        Microphone.End(null);
        var samples = new float[position * clip.channels];
        clip.GetData(samples, 0);
        bytes = EncodeAsWAV(samples, clip.frequency, clip.channels);
        recording = false;
        SendRecording();
    }

    private void SendRecording()
    {
        text.color = Color.yellow;
        text.text = "Sending...";
        HuggingFaceAPI.AutomaticSpeechRecognition(bytes, response => {
            text.color = Color.white;
            text.text = response;
            gpt.AskChatGPT(response);
        }, error => {
            text.color = Color.red;
            text.text = error;
        });
    }


    private byte[] EncodeAsWAV(float[] samples, int frequency, int channels)
    {
        using (var memoryStream = new MemoryStream(44 + samples.Length * 2))
        {
            using (var writer = new BinaryWriter(memoryStream))
            {
                writer.Write("RIFF".ToCharArray());
                writer.Write(36 + samples.Length * 2);
                writer.Write("WAVE".ToCharArray());
                writer.Write("fmt ".ToCharArray());
                writer.Write(16);
                writer.Write((ushort)1);
                writer.Write((ushort)channels);
                writer.Write(frequency);
                writer.Write(frequency * channels * 2);
                writer.Write((ushort)(channels * 2));
                writer.Write((ushort)16);
                writer.Write("data".ToCharArray());
                writer.Write(samples.Length * 2);

                foreach (var sample in samples)
                {
                    writer.Write((short)(sample * short.MaxValue));
                }
            }
            return memoryStream.ToArray();
        }
    }
    
}
