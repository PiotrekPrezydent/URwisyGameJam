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
    Button Question2;

    [SerializeField]
    Button Question3;

    public ActorView currentActor;

    public HashSet<int> usedIndexes;

    int q1, q2, q3;

    int WrongDecisions;

    int CurrentDay;

    public int CurrentDecisions;

    public int DecisionLimit;

    private void Awake()
    {
        usedIndexes = new HashSet<int>();
        YesButton.onClick.AddListener(OnYes);
        NoButton.onClick.AddListener(OnNo);
        YesButton.gameObject.SetActive(false);
        NoButton.gameObject.SetActive(false);

        Question1.gameObject.SetActive(false);
        Question2.gameObject.SetActive(false);
        Question3 .gameObject.SetActive(false);
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
        Question2.onClick.AddListener(OnQuestion2Click);
        Question3.onClick.AddListener(OnQuestion3Click);
    }

    public void ShowOptions(ActorView currentActor)
    {
        this.currentActor = currentActor;
        YesButton.gameObject.SetActive(true);
        NoButton.gameObject.SetActive(true);

        _questions.GetNotUsedQuestions(usedIndexes, out q1, out q2, out q3);

        Question1.GetComponentInChildren<TextMeshProUGUI>().text = _questions.questions[q1];
        Question2.GetComponentInChildren<TextMeshProUGUI>().text = _questions.questions[q2];
        Question3.GetComponentInChildren<TextMeshProUGUI>().text = _questions.questions[q3];

        Question1.gameObject.SetActive(true);
        Question2.gameObject.SetActive(true);
        Question3.gameObject.SetActive(true);
    }

    public void HideOpption()
    {
        YesButton.gameObject.SetActive(false);
        NoButton.gameObject.SetActive(false);
        Question1.gameObject.SetActive(false);
        Question2.gameObject.SetActive(false);
        Question3.gameObject.SetActive(false);
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
    }

    void OnQuestion2Click()
    {
        currentActor.GiveAnserw(q2);
        Question2.gameObject.SetActive(false);
    }

    void OnQuestion3Click()
    {
        currentActor.GiveAnserw(q3);
        Question3.gameObject.SetActive(false);
    }

    void OnYes()
    {
        currentActor.OnYes();
    }

    void OnNo()
    {
        currentActor.OnNo();
    }
}
