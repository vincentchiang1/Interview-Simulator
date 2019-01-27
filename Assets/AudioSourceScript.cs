using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;

public class AudioSourceScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private string[] m_Keywords;

    public TextMeshProUGUI speech;
    private KeywordRecognizer m_Recognizer;

    // Start is called before the first frame update
    void Start()
    {
        m_Recognizer = new KeywordRecognizer(m_Keywords);
        m_Recognizer.OnPhraseRecognized += OnPhraseRecognized;
        m_Recognizer.Start();
    }

    private void OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        float newX = UnityEngine.Random.Range(-3, 3);
        float newZ = UnityEngine.Random.Range(-3, 3);
        speech.text = args.text;

        if (args.text == m_Keywords[0])
        {
        }

        if (args.text == m_Keywords[1])
        {
        }

        if (args.text == m_Keywords[2])
        {
            Microphone.End("");
            AudioSource audioSource = GetComponent<AudioSource>();
            audioSource.Play();
        }

        if (args.text == m_Keywords[3])
        {
            AudioSource audioSource = GetComponent<AudioSource>();
            audioSource.clip = Microphone.Start("", true, 3599, 44100);
        }

        if (args.text == m_Keywords[4])
        {
            Debug.Log("Microphone Ended");
            Microphone.End("");
        }

    }

    private IEnumerator startRecording()
    {
        yield return Application.RequestUserAuthorization(UserAuthorization.Microphone);
        if (Application.HasUserAuthorization(UserAuthorization.Microphone))
        {
            Debug.Log("Microphone found");
            AudioSource audioSource = GetComponent<AudioSource>();
            audioSource.clip = Microphone.Start("", false, 5, 44100);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
