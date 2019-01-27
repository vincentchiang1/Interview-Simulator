using System;
using System.Collections;
using SpeechLib;
using TMPro;
using UnityEngine;
using UnityEngine.Windows.Speech;
using static Assets.InterviewQuestions;

public class AudioSourceScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private string[] m_Keywords;
    private SpVoice voice;

    public TextMeshProUGUI timer;
    private string recordingStatus = "Stopped ";
    private Boolean stopped = true;
    private float time;
    private KeywordRecognizer m_Recognizer;

    // Start is called before the first frame update
    void Start()
    {
        m_Recognizer = new KeywordRecognizer(m_Keywords);
        m_Recognizer.OnPhraseRecognized += OnPhraseRecognized;
        m_Recognizer.Start();
        voice = new SpVoice();
    }

    private void OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        if (args.text == m_Keywords[0])
        {
            time = 0;
            stopped = false;
            recordingStatus = "Playing: ";
            if (Microphone.IsRecording("")) Microphone.End("");
            AudioSource audioSource = GetComponent<AudioSource>();
            audioSource.Play();
        }

        if (args.text == m_Keywords[1])
        {
            time = 0;
            stopped = false;
            recordingStatus = "Recording: ";
            AudioSource audioSource = GetComponent<AudioSource>();
            audioSource.clip = Microphone.Start("", true, 3599, 44100);
        }

        if (args.text == m_Keywords[2])
        {
            stopped = true;
            recordingStatus = "Stopped: " + $"{time / 60:00} : {time % 60:00}";
            Debug.Log("Microphone Ended");
            if (Microphone.IsRecording("")) Microphone.End("");
        }

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        var minutes = time / 60; //Divide the guiTime by sixty to get the minutes.
        var seconds = time % 60; //Use the euclidean division for the seconds.

        //update the label value
        timer.text = recordingStatus;
        if (!stopped)
            timer.text += $"{minutes:00} : {seconds:00}";
    }
}
