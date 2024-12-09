using System.Collections.Generic;
using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerView : MonoBehaviour
{
    static readonly ActorConfig _actors;

    static readonly QuestionConfig _questions;

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

    ActorView currentActor;

    public HashSet<int> usedIndexes;

    int q1, q2, q3;

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
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _actors.Initialize();
        _actors.CreateRandomPerson();
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


    void OnQuestion1Click()
    {
        Debug.Log("Q1");
    }

    void OnQuestion2Click()
    {
        Debug.Log("Q2");
    }

    void OnQuestion3Click()
    {
        Debug.Log("Q3");
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
