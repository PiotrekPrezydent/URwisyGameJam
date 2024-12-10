using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroView : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI[] texts;

    [SerializeField]
    Button StartButton;
    private void Awake()
    {
        StartButton.onClick.AddListener(StartButtonClick);
    }
    private void Start()
    {
        StartCoroutine(Intro());
    }

    IEnumerator Intro()
    {
        foreach(var t in texts)
        {
            while(t.alpha < 1)
            {
                t.alpha += 0.01f;
                yield return new WaitForSeconds(0.01f);
            }
        }
        while(StartButton.image.color.a < 1)
        {
            StartButton.image.color = new Color(StartButton.image.color.r, StartButton.image.color.g, StartButton.image.color.b, StartButton.image.color.a + 0.01f);
            StartButton.GetComponentInChildren<TextMeshProUGUI>().alpha += 0.01f;
            yield return new WaitForSeconds(0.01f);
        }
    }

    void StartButtonClick()
    {
        SceneManager.LoadScene(Constants.GameScene);
    }
}
