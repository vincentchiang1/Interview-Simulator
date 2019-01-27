using System.IO;
using SpeechLib;
using UnityEngine;

public class InterviewerScript : MonoBehaviour
{
    private SpVoice voice;

    void Start()
    {
        voice = new SpVoice();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            voice.Volume = 60; // Volume (no xml)

            voice.Speak("", SpeechVoiceSpeakFlags.SVSFlagsAsync);
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            voice.Pause();

        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            voice.Resume();
        }

        //TEST PER ANDROID
        /*	if (Input.GetTouch)
		{

			voice.Resume();
		}*/


    }
}


