using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OpenAI;

public class ChatGPTManager : MonoBehaviour
{
    private OpenAIApi openAI = new OpenAIApi();
    private List<ChatMessage> messages = new List<ChatMessage>();
    //public emotionManager emotionMGR; //wait to start code later
    public teststart speaker;
    [TextArea(15,20)]
    public string Prompt; 
    
    public async void AskChatGPT(string newText)
    {
        
        ChatMessage newMessage = new ChatMessage();
        newMessage.Content = newText;
        newMessage.Role = "user";
        messages.Add(newMessage);

        CreateChatCompletionRequest request = new CreateChatCompletionRequest();
        request.Messages = messages;
        request.Model = "gpt-3.5-turbo";

        var response = await openAI.CreateChatCompletion(request);

        if(response.Choices != null &&  response.Choices.Count > 0)
        {
            //sets gpt response to varible
            var chatResponse = response.Choices[0].Message;
            messages.Add(chatResponse);

            //code to strip emotion from thing


            //start tts
            speaker.BeginSpeaking(chatResponse.Content);
            Debug.Log(chatResponse.Content);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        ChatMessage newMessage = new ChatMessage();
        newMessage.Content = Prompt;
        newMessage.Role = "user";
        messages.Add(newMessage);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
