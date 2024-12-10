using System.Collections;
using TMPro;
using UnityEngine;

public class NextDayManager : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI SceneText;

    static readonly ActorConfig _actors;

    [SerializeField]
    public PlayerView player;

    private void Awake()
    {
        StartCoroutine(StartNextDay(1));
    }
    public void LoadNextDayScene(int day)
    {
        this.gameObject.SetActive(true);
        StartCoroutine(StartNextDay(day));
    }

    IEnumerator StartNextDay(int day)
    {
        SceneText.text = "Day " + day;
        yield return new WaitForSeconds(1);
        this.gameObject.SetActive(false);
        if(player.currentActor != null)
            Destroy(player.currentActor.gameObject);
        _actors.CreateRandomPerson();
    }
}
