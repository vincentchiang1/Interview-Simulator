using Assets;
using SpeechLib;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;
using Random = System.Random;

public class Interview : MonoBehaviour
{
	[SerializeField]
	public Canvas canvas;
    public string[] m_Keywords;
    public Text firstQuestion, secondQuestion, thirdQuestion;

    private InterviewQuestions bankOfQuestions;
    private KeywordRecognizer m_Recognizer;
    private SpVoice voice;

    private string stage = "behavioral";


    public SpriteRenderer Q1Good, Q1Wrong1, Q1Wrong2, Q2Good, Q2Wrong1, Q2Wrong2, Q3Good, Q3Wrong1, Q3Wrong2,
		Q4Good, Q4Wrong1, Q4Wrong2, Q5Good, Q5Wrong1, Q5Wrong2, Q6Good, Q6Wrong1, Q6Wrong2, Q7Good, Q7Wrong1, Q7Wrong2,
		 Q8Good, Q8Wrong1, Q8Wrong2, Q9Good, Q9Wrong1, Q9Wrong2, Q10Good, Q10Wrong1, Q10Wrong2, Q11Good, Q11Wrong1, Q11Wrong2;
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
		Random r = new Random();
		InterviewQuestions qs = new InterviewQuestions();

		if (args.text == m_Keywords[2])
		{
            switch (stage)
            {
                case "behavioral":
                    stage = "non-coding";
                    var behaviouralQ = qs.BehaviouralQuestions[r.Next(qs.BehaviouralQuestions.Count)];
                    Text f = Instantiate(firstQuestion, Vector3.zero, Quaternion.identity);
                    f.transform.SetParent(canvas.transform);
                    f.transform.position = new Vector3(154, 195, 394);
                    f.text = behaviouralQ;
                    Debug.Log("Reached Behavioral");
                    voice.Speak(behaviouralQ);
                    break;
                case "non-coding":
                    stage = "coding";
                    var technicalNonCodingQ = qs.TechnicalNonCodingQuestions[r.Next(qs.TechnicalNonCodingQuestions.Count)];
                    Text s = Instantiate(secondQuestion, Vector3.zero, Quaternion.identity);
                    s.transform.SetParent(canvas.transform);
                    s.transform.position = new Vector3(154, 195, 394);
                    s.text = technicalNonCodingQ;
                    Debug.Log("Reached Non Coding");
                    voice.Speak(technicalNonCodingQ);
                    break;
                case "coding":
                    stage = "";
                    var technicalCodingQ = qs.TechnicalCodingQuestions[r.Next(qs.TechnicalCodingQuestions.Count)];
                    Text t = Instantiate(thirdQuestion, Vector3.zero, Quaternion.identity);
                    t.transform.SetParent(canvas.transform);
                    t.transform.position = new Vector3(154, 195, 394);
                    t.text = technicalCodingQ.Item2;
                    Debug.Log("Reached Coding");
                    voice.Speak(technicalCodingQ.Item2);
                    GetMultipleChoicePhotos(technicalCodingQ.Item1);
                    break;
                default:
                    voice.Speak("You have completed the interview, Good Luck!");
                    break;
            }

		}
	}

    private void GetMultipleChoicePhotos(string val)
    {
        switch (val)
        {
            case "1":
                InstantiateMultipleChoicePhotos(Q1Good, Q1Wrong1, Q1Wrong2);
                break;
            case "2":
                InstantiateMultipleChoicePhotos(Q2Wrong2, Q2Good, Q2Wrong1);
                break;
            case "3":
                InstantiateMultipleChoicePhotos(Q3Good, Q3Wrong1, Q3Wrong2);
                break;
            case "4":
                InstantiateMultipleChoicePhotos(Q4Wrong2, Q4Wrong1, Q4Good);
                break;
            case "5":
                InstantiateMultipleChoicePhotos(Q5Wrong1, Q5Good, Q5Wrong2);
                break;
            case "6":
                InstantiateMultipleChoicePhotos(Q6Good, Q6Wrong1, Q6Wrong2);
                break;
            case "7":
                InstantiateMultipleChoicePhotos(Q7Wrong2, Q7Good, Q7Wrong1);
                break;
            case "8":
                InstantiateMultipleChoicePhotos(Q8Good, Q8Wrong1, Q8Wrong2);
                break;
            case "9":
                InstantiateMultipleChoicePhotos(Q9Wrong1, Q9Good, Q9Wrong2);
                break;
            case "10":
                InstantiateMultipleChoicePhotos(Q10Wrong2, Q10Wrong1, Q10Good);
                break;
            case "11":
                InstantiateMultipleChoicePhotos(Q11Wrong1, Q11Good, Q11Wrong2);
                break;
        }
    }

    private void InstantiateMultipleChoicePhotos(SpriteRenderer im1, SpriteRenderer im2, SpriteRenderer im3)
    {
        Instantiate(im1, new Vector3(154, 195, 394), Quaternion.identity);
        Instantiate(im2, new Vector3(154, 195, 394), Quaternion.identity);
        Instantiate(im3, new Vector3(154, 195, 394), Quaternion.identity);
    }

    //private void OnPhraseRecognized(PhraseRecognizedEventArgs args)
    //{
    //    Random r = new Random();
    //    InterviewQuestions qs = new InterviewQuestions();

    //    if (args.text == m_Keywords[2])
    //    {
    //        //first q
    //        var behaviouralQ = qs.BehaviouralQuestions[r.Next(qs.BehaviouralQuestions.Count)];
    //        Text f = Instantiate(firstQuestion, Vector3.zero, Quaternion.identity);
    //        f.transform.SetParent(canvas.transform);
    //        f.transform.position = new Vector3(154, 195, 394);
    //        f.text = behaviouralQ;
    //        voice.Speak(behaviouralQ);

    //        //second q
    //        var technicalNonCodingQ = qs.TechnicalNonCodingQuestions[r.Next(qs.TechnicalNonCodingQuestions.Count)];
    //        Text s = Instantiate(secondQuestion, Vector3.zero, Quaternion.identity);
    //        s.transform.SetParent(canvas.transform);
    //        s.transform.position = new Vector3(154, 195, 394);
    //        s.text = technicalNonCodingQ;
    //        voice.Speak(technicalNonCodingQ);

    //        //third q
    //        var technicalCodingQ = qs.TechnicalCodingQuestions[r.Next(qs.TechnicalCodingQuestions.Count)];
    //        Text t = Instantiate(thirdQuestion, Vector3.zero, Quaternion.identity);
    //        t.transform.SetParent(canvas.transform);
    //        t.transform.position = new Vector3(154, 195, 394);
    //        t.text = technicalCodingQ.Item2;
    //        voice.Speak(technicalCodingQ.Item2);

    //        switch (technicalCodingQ.Item1)
    //        {
    //            case "1":
    //                InstantiateMultipleChoicePhotos(Q1Good, Q1Wrong1, Q1Wrong2);
    //                break;
    //            case "2":
    //                InstantiateMultipleChoicePhotos(Q2Wrong2, Q2Good, Q2Wrong1);
    //                break;
    //            case "3":
    //                InstantiateMultipleChoicePhotos(Q3Good, Q3Wrong1, Q3Wrong2);
    //                break;
    //            case "4":
    //                InstantiateMultipleChoicePhotos(Q4Wrong2, Q4Wrong1, Q4Good);
    //                break;
    //            case "5":
    //                InstantiateMultipleChoicePhotos(Q5Wrong1, Q5Good, Q5Wrong2);
    //                break;
    //            case "6":
    //                InstantiateMultipleChoicePhotos(Q6Good, Q6Wrong1, Q6Wrong2);
    //                break;
    //            case "7":
    //                InstantiateMultipleChoicePhotos(Q7Wrong2, Q7Good, Q7Wrong1);
    //                break;
    //            case "8":
    //                InstantiateMultipleChoicePhotos(Q8Good, Q8Wrong1, Q8Wrong2);
    //                break;
    //            case "9":
    //                InstantiateMultipleChoicePhotos(Q9Wrong1, Q9Good, Q9Wrong2);
    //                break;
    //            case "10":
    //                InstantiateMultipleChoicePhotos(Q10Wrong2, Q10Wrong1, Q10Good);
    //                break;
    //            case "11":
    //                InstantiateMultipleChoicePhotos(Q11Wrong1, Q11Good, Q11Wrong2);
    //                break;
    //        }

    //    }
    //}
    // Update is called once per frame
    void Update()
	{
	}
}
