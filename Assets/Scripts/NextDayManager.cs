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
        "Tego dnia, 80 lat temu, naukowiec Klapacjusz odkry� silnik kwantowego inhibitora.",
        "Policja zaaresztowa�a pi�ciu mimikr�w kultu Ferrycego.",
        "Niedaleko najwi�kszej gwiazdy odkryto planet� eliptycznej formy.",
        "Dzisiaj zbudowano pierwszy silnik mrocznej materii.",
        "Dzisiaj w Nelopolis odb�dzie si� �Maraton Progresu�.",
        "Tego dnia, 80 lat temu, naukowiec Klapacjusz odkry� silnik kwantowego inhibitora.",
        "W centrum miasta kulty�ci mimikr�w podj�li pr�b� przej�cia urz�du Neolopolis.",
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
