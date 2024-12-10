using System.Collections.Generic;
using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerView : MonoBehaviour
{
    static readonly ActorConfig _actors;

    static readonly QuestionConfig _questions;

    [SerializeField]
    public NextDayManager NextDaySceneManager;

    [SerializeField]
    public TextMeshProUGUI AnserwText;

    [SerializeField]
    public TextMeshProUGUI Punkty;

    [SerializeField]
    Button YesButton;

    [SerializeField]
    Button NoButton;

    [SerializeField]
    Button Question1;

    [SerializeField]
    Button ShowHandButton;

    [SerializeField]
    Button DocumentsButton;

    [SerializeField]
    Button LooksLikeHuman;

    [SerializeField]
    Button SpeaksLikeHuman;

    [SerializeField]
    Button HumanDocuments;

    [SerializeField]
    public TextMeshProUGUI DocumentText;

    public ActorView currentActor;

    public HashSet<int> usedIndexes;

    int q1, q2, q3;

    int WrongDecisions;

    int CurrentDay;

    public int CurrentDecisions;

    public int DecisionLimit;


    bool HumanLooks = false;
    bool HumanSpeak = false;
    bool HumanDocs = false;

    private void Awake()
    {
        usedIndexes = new HashSet<int>();


        YesButton.gameObject.SetActive(false);
        NoButton.gameObject.SetActive(false);

        Question1.gameObject.SetActive(false);
        ShowHandButton.gameObject.SetActive(false);
        DocumentsButton.gameObject.SetActive(false);

        CurrentDay = 1;
        WrongDecisions = 0;
        CurrentDecisions = 0;
        DecisionLimit = Random.Range(8, 11);
        _actors.Initialize();

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _actors.Initialize();
        Question1.onClick.AddListener(OnQuestion1Click);
        YesButton.onClick.AddListener(OnYes);
        NoButton.onClick.AddListener(OnNo);
        ShowHandButton.onClick.AddListener(OnShowHand);
        DocumentsButton.onClick.AddListener(ShowDocuments);
        //Question2.onClick.AddListener(OnQuestion2Click);
        //Question3.onClick.AddListener(OnQuestion3Click);
        LooksLikeHuman.onClick.AddListener(OnLookButtonClick);
        SpeaksLikeHuman.onClick.AddListener(OnSpeakButtonClick);
        HumanDocuments.onClick.AddListener(OnDocumentsButtonClick);
    }

    public void ShowOptions(ActorView currentActor)
    {
        this.currentActor = currentActor;
        YesButton.gameObject.SetActive(true);
        NoButton.gameObject.SetActive(true);

        _questions.GetNotUsedQuestions(usedIndexes, out q1);

        Question1.GetComponentInChildren<TextMeshProUGUI>().text = "Zadaj Pytanie: " + _questions.questions[q1];

        Question1.gameObject.SetActive(true);
        ShowHandButton.gameObject.SetActive(true);
        DocumentsButton.gameObject.SetActive(true);
    }

    public void HideOpption()
    {
        YesButton.gameObject.SetActive(false);
        NoButton.gameObject.SetActive(false);
        Question1.gameObject.SetActive(false);
        DocumentsButton.gameObject.SetActive(false);
    }

    public void ChangeDay()
    {
        CurrentDecisions = 0;
        DecisionLimit = Random.Range(8, 11);
        CurrentDay++;
        NextDaySceneManager.LoadNextDayScene(CurrentDay);
        if (CurrentDay > 7)
        {
            SceneManager.LoadScene("EndGameWin");
            Debug.Log("koniec gry");
        }
    }

    public void WrongAnserw()
    {
        WrongDecisions++;

        if(WrongDecisions >= 14)
        {
            SceneManager.LoadScene("EndGameLose");
            Debug.Log("koniec gry");
        }
        //this is debug only
        Punkty.text = $"{WrongDecisions}/14";
    }


    void OnQuestion1Click()
    {
        currentActor.GiveAnserw(q1);
        Question1.gameObject.SetActive(false);
        ShowHandButton.gameObject.SetActive(false);
        DocumentsButton.gameObject.SetActive(false);
    }

    void OnShowHand()
    {
        currentActor.OnShowHand();
        Question1.gameObject.SetActive(false);
        ShowHandButton.gameObject.SetActive(false);
        DocumentsButton.gameObject.SetActive(false);
    }

    void ShowDocuments()
    {
        currentActor.OnShowDocuments();
        Question1.gameObject.SetActive(false);
        ShowHandButton.gameObject.SetActive(false);
        DocumentsButton.gameObject.SetActive(false);
    }

    void OnYes()
    {
        YesButton.GetComponent<AudioSource>().Play();
        Debug.Log(YesButton.GetComponent<AudioSource>());
        currentActor.OnYes();
    }

    void OnNo()
    {
        currentActor.OnNo();
    }

    void OnLookButtonClick(){

        HumanLooks = !HumanLooks;
        Debug.Log(HumanLooks);
        if(HumanLooks){
            LooksLikeHuman.GetComponent<Image>().color = new Color32(0,255,0,255);
        }else{
            LooksLikeHuman.GetComponent<Image>().color = new Color32(255,0,0,255);
        }
    }

    void OnSpeakButtonClick(){

        HumanSpeak = !HumanSpeak;
        if(HumanSpeak){
            SpeaksLikeHuman.GetComponent<Image>().color = new Color32(0,255,0,255);
        }else{
            SpeaksLikeHuman.GetComponent<Image>().color = new Color32(255,0,0,255);
        }
    }

    void OnDocumentsButtonClick(){

        HumanDocs = !HumanDocs;
        if(HumanDocs){
            HumanDocuments.GetComponent<Image>().color = new Color32(0,255,0,255);
        }else{
            HumanDocuments.GetComponent<Image>().color = new Color32(255,0,0,255);
        }
    }
}
