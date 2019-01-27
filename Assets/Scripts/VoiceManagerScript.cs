using System.Collections;
using System.Collections.Generic;
using System;
using System.Text;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class VoiceManagerScript : MonoBehaviour
{
    [SerializeField]
    private string[] m_Keywords;

    private KeywordRecognizer m_Recognizer;
    public GameObject Cube;

    // Start is called before the first frame update
    void Start()
    {
        m_Keywords = new string[1];
        m_Keywords[0] = "Fuck";
        m_Recognizer = new KeywordRecognizer(m_Keywords);
        m_Recognizer.OnPhraseRecognized += OnPhraseRecognized;
        m_Recognizer.Start();
    }

    private void OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        float newX = UnityEngine.Random.Range(-3, 3);
        float newZ = UnityEngine.Random.Range(-3, 3);

        if (args.text == m_Keywords[0])
        {
            Instantiate(Cube, new Vector3(newX, newZ, 1), Quaternion.identity);
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
