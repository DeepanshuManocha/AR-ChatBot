using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReceiveResult : MonoBehaviour {

    public List<string> inputData = new List<string>();
    public List<string> reply = new List<string>();
    
    public InputField dataInputField, replyInputField;
    private int i, savedInputCount,savedReplyCount;

    private void Awake()
    {
        //PlayerPrefs.DeleteAll();
        LoadReplyData();
        LoadInputData();
    }

    public void SaveInputData()
    {
        for (int i = 0; i < inputData.Count;i++)
        {
            PlayerPrefs.SetString("InputData" + i, inputData[i]);
        }
        PlayerPrefs.SetInt("InputCount", inputData.Count);
    }
    public void LoadInputData()
    {
        inputData.Clear();
        savedInputCount = PlayerPrefs.GetInt("InputCount");
        for (int i = 0; i < savedInputCount; i++)
        {
            string input = PlayerPrefs.GetString("InputData" + i);
            inputData.Add(input);
        }

    }

    public void SaveReplyData()
    {
        for (int i = 0; i < reply.Count; i++)
        {
            PlayerPrefs.SetString("ReplyData" + i, reply[i]);
        }
        PlayerPrefs.SetInt("ReplyCount", reply.Count);
    }
    public void LoadReplyData()
    {
        reply.Clear();
        savedReplyCount = PlayerPrefs.GetInt("ReplyCount");
        for (int i = 0; i < savedReplyCount; i++)
        {
            string replyData = PlayerPrefs.GetString("ReplyData" + i);
            reply.Add(replyData);
        }
    }


    public void EnterInputData()
    {
        if(dataInputField.text != "")
        {
            if (!inputData.Contains(dataInputField.text))
            {
                inputData.Add(dataInputField.text);
                SaveInputData();
            }
        }
    }

    public void EnterReply()
    {
        if (replyInputField.text != "")
        {
            if (!reply.Contains(replyInputField.text))
            {
                reply.Add(replyInputField.text);
                SaveReplyData();
            }
        }
        
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
