using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextToSpeech : MonoBehaviour
{
    
    public AudioSource _audio;
    public string inputText;
    public string input;
    
    // Start is called before the first frame update
    void Start()
    {
        _audio=gameObject.GetComponent<AudioSource>();
       
    }

    // Update is called once per frame
    void Update()
    {  
        for(int i=0; i<(GameObject.Find("Camera").GetComponent<ReceiveResult>().reply.Count); i++)
        {
            if(inputText==(GameObject.Find("Camera").GetComponent<ReceiveResult>().reply[i]))
            {
                StartCoroutine (DownloadTheAudio());
                inputText=null;
            } 
        }
    }

    IEnumerator DownloadTheAudio()
    {
        string url="https://translate.google.com/translate_tts?ie=UTF-8&total=1&idx=0&textlen=32&client=tw-ob&q="+inputText+"&tl=En-gb";
        WWW www= new WWW (url);
        yield return www;

        _audio.clip = www.GetAudioClip (false, true, AudioType.MPEG);
        _audio.Play ();
    }

    public void ButtonClick()
    {
            
    }
}
