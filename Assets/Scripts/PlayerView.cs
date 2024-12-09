using System.Collections.Generic;
using NUnit.Framework;
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

    ActorView currentActor;

    HashSet<int> usedIndexes;

    private void Awake()
    {
        YesButton.onClick.AddListener(OnYes);
        NoButton.onClick.AddListener(OnNo);
        YesButton.gameObject.SetActive(false);
        NoButton.gameObject.SetActive(false);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _actors.Initialize();
        _actors.CreateRandomPerson();

    }

    public void ShowOptions(ActorView currentActor)
    {
        YesButton.gameObject.SetActive(true);
        NoButton.gameObject.SetActive(true);
        this.currentActor = currentActor;
    }

    public void HideOpption()
    {
        YesButton.gameObject.SetActive(false);
        NoButton.gameObject.SetActive(false);
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
