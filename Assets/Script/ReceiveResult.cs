using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReceiveResult : MonoBehaviour {

    public List<string> inputData = new List<string>();
    public List<string> reply = new List<string>();
    
    public GameObject inputDataInputField, replyInputField;
    int i;
	// Use this for initialization
	void Start () 
    {
        //GameObject.Find("Text").GetComponent<Text>().text = "You need to be connected to Internet";
        //inputData.Add("hi");
        //inputData.Add("how are you");
        //inputData.Add(inputDataText);
        //reply.Add("hi deepanshu");
        //reply.Add("I am fine,thankyou!");
        //reply.Add(replyText);
	}

    public void EnterInputData()
    {
        inputData.Add(inputDataInputField.GetComponent<InputField>().text);
    }

    public void EnterReply()
    {
        reply.Add(replyInputField.GetComponent<InputField>().text);
    }
	
    public void onActivityResult(string recognizedText){
        char[] delimiterChars = {'~'};
        string[] result = recognizedText.Split(delimiterChars);

        //You can get the number of results with result.Length
        //And access a particular result with result[i] where i is an int
        //I have just assigned the best result to UI text
        GameObject.Find("STT").GetComponent<Text>().text = result[0];

        for (i = 0; i < reply.Count; i++) 
        {
            if(result[0]==inputData[i])
            {
                GameObject.Find("TTS").GetComponent<TextToSpeech>().inputText=reply[i];
            }
            
        
        }
        //i=0;
    }

	// Update is called once per frame
	void Update () {
		
	}
}
