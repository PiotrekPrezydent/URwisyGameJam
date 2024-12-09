using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ActorView : MonoBehaviour
{
    static readonly ActorConfig _config;
    static readonly QuestionConfig _configQuestion;
    static PlayerView player;

    [SerializeField]
    SpriteRenderer hairSprite;

    [SerializeField]
    SpriteRenderer headSprite;

    [SerializeField]
    SpriteRenderer torseSprite;

    [SerializeField]
    SpriteRenderer handsSprite;

    //Najwyzej przerobic jak jpg/png niebedzie sie lapac w tekstury
    public void Initialize(Sprite hair,Sprite head, Sprite torse, Sprite hands)
    {
        hairSprite.sprite = hair;
        headSprite.sprite = head;
        torseSprite.sprite = torse;
        handsSprite.sprite = hands;
        //zmien sprita wartosci
        StartCoroutine(WalkToMiddleOfScreen());
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerView>();
    }


    IEnumerator WalkToMiddleOfScreen()
    {
        while(transform.position.x < 0)
        {
            transform.position = new Vector3(transform.position.x+1,0,-1);
            yield return null;
        }
        player.ShowOptions(this);

    }
    IEnumerator AfterNoDecision()
    {
        player.HideOpption();
        while(transform.localScale.sqrMagnitude <200)
        {
            var t = transform.localScale;
            transform.localScale = new Vector3(t.x + 0.2f, t.y + 0.2f, t.z + 0.2f);
            yield return null;
        }
        Destroy(gameObject);

    }
    IEnumerator AfterYesDecision()
    {
        player.HideOpption();
        while (transform.position.x < 300)
        {
            transform.position = new Vector3(transform.position.x + 1, 0, -1);
            yield return null;
        }
        Destroy(gameObject);
        yield return null;
    }
    public void OnYes()
    {
        StartCoroutine(AfterYesDecision());
    }

    public void OnNo()
    {
        StartCoroutine (AfterNoDecision());
    }

    private void OnDestroy()
    {
        //replace with plansza next day 
        if(player.usedIndexes.Count+2 < _configQuestion.questions.Length)
            _config.CreateRandomPerson();
        else
            Application.Quit();
    }
}
