using System.Collections;
using TMPro;
using UnityEngine;

public class NextDayManager : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI SceneText;

    [SerializeField]
    TextMeshProUGUI message;

    static readonly ActorConfig _actors;

    [SerializeField]
    public PlayerView player;

    string[] messagesArray ={
        "Dzisiejszego dnia zatrudniono nowego inspektora.",
        "Tego dnia, 80 lat temu, naukowiec Klapacjusz odkry³ silnik kwantowego inhibitora.",
        "Policja zaaresztowa³a piêciu mimikrów kultu Ferrycego.",
        "Niedaleko najwiêkszej gwiazdy odkryto planetê eliptycznej formy.",
        "Dzisiaj zbudowano pierwszy silnik mrocznej materii.",
        "Dzisiaj w Nelopolis odbêdzie siê “Maraton Progresu”.",
        "Tego dnia, 80 lat temu, naukowiec Klapacjusz odkry³ silnik kwantowego inhibitora.",
        "W centrum miasta kultyœci mimikrów podjêli próbê przejêcia urzêdu Neolopolis.",
        "Mimikr. Jest. Tu."
    };

    private void Awake()
    {
        StartCoroutine(StartNextDay(1, messagesArray[0]));
    }
    public void LoadNextDayScene(int day)
    {
        this.gameObject.SetActive(true);
        StartCoroutine(StartNextDay(day, messagesArray[day-1]));
    }

    IEnumerator StartNextDay(int day, string message)
    {
        SceneText.text = "Day " + day;
        this.message.text = message;
        yield return new WaitForSeconds(8);
        this.gameObject.SetActive(false);
        if(player.currentActor != null)
            Destroy(player.currentActor.gameObject);
        _actors.CreateRandomPerson();
    }
}
