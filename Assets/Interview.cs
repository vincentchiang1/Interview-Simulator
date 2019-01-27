using System.Reflection;
using Assets;
using SpeechLib;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;
using Random = System.Random;

public class Interview : MonoBehaviour
{
	[SerializeField]
	public Canvas canvas;
    public string[] m_Keywords;
    public TextMeshProUGUI question;

    private InterviewQuestions bankOfQuestions;
    private KeywordRecognizer m_Recognizer;
    private SpVoice voice;

    private bool IsQ3 = false;
    public Image leftBorder;
    public Image middleBorder;
    public Image rightBorder;


    [SerializeField]
    public Image im1,im2,im3;

    private string stage = "behavioral";
    private bool intro = false;


    public Sprite Q1Good, Q1Wrong1, Q1Wrong2, Q2Good, Q2Wrong1, Q2Wrong2, Q3Good, Q3Wrong1, Q3Wrong2,
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

        if (args.text == m_Keywords[3])
        {
            voice.Volume = 60;
            voice.Speak("Hello Welcome, would you like to start your interview?");
            intro = true;

        }

        if (args.text == m_Keywords[0] && intro)
        {
            stage = "non-coding";
            var behaviouralQ = qs.BehaviouralQuestions[r.Next(qs.BehaviouralQuestions.Count)];
            question.text = behaviouralQ;
            voice.Speak(behaviouralQ);
        }

        if (args.text == m_Keywords[2])
		{
            switch (stage)
            {
                case "behavioral":
                    stage = "non-coding";
                    var behaviouralQ = qs.BehaviouralQuestions[r.Next(qs.BehaviouralQuestions.Count)];
                   question.text = behaviouralQ;
                    Debug.Log("Reached Behavioral");
                    voice.Speak(behaviouralQ);
                    break;
                case "non-coding":
                    stage = "coding";
                    var technicalNonCodingQ = qs.TechnicalNonCodingQuestions[r.Next(qs.TechnicalNonCodingQuestions.Count)];
                    question.text = technicalNonCodingQ;
                    Debug.Log("Reached Non Coding");
                    voice.Speak(technicalNonCodingQ);
                    break;
                case "coding":
                    stage = "";
                    IsQ3 = true;
                    var technicalCodingQ = qs.TechnicalCodingQuestions[r.Next(qs.TechnicalCodingQuestions.Count)];
                    question.text = technicalCodingQ.Item2;
                    Debug.Log("Reached Coding");
                    GetMultipleChoicePhotos(technicalCodingQ.Item1);
                    voice.Speak(technicalCodingQ.Item2);
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

   private void InstantiateMultipleChoicePhotos(Sprite image1, Sprite image2, Sprite image3)
   {
       im1.sprite = image1;
       im2.sprite = image2;
       im3.sprite = image3;
    }
    
    // Update is called once per frame
    void Update()
	{
        if (IsQ3)
        {
            middleBorder.gameObject.SetActive(true);
            IsQ3 = false;
        }

        if (OVRInput.GetDown(OVRInput.Button.DpadLeft))
        {
            if (middleBorder.IsActive())
            {
                middleBorder.gameObject.SetActive((false));
                leftBorder.gameObject.SetActive(true);
            }

            if (rightBorder.IsActive())
            {
                rightBorder.gameObject.SetActive(false);
                middleBorder.gameObject.SetActive(true);
            }
        }

        if (OVRInput.GetDown(OVRInput.Button.DpadRight))
        {
            if (middleBorder.IsActive())
            {
                middleBorder.gameObject.SetActive((false));
                rightBorder.gameObject.SetActive(true);
            }

            if (leftBorder.IsActive())
            {
                leftBorder.gameObject.SetActive(false);
                middleBorder.gameObject.SetActive(true);
            }
        }

        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            if (middleBorder.IsActive() && im2.sprite.name.Contains("Correct") ||
                leftBorder.IsActive() && im1.sprite.name.Contains("Correct") ||
                rightBorder.IsActive() && im3.sprite.name.Contains("Correct"))
            {
                voice.Speak("You got the correct answer");
            }
            else
            {
                voice.Speak("Sorry, that is not correct.");
            }
            middleBorder.gameObject.SetActive(false);
            leftBorder.gameObject.SetActive(false);
            rightBorder.gameObject.SetActive(false);
            voice.Speak("You have completed the interview, thank you, good bye!");
        }
    }
}
