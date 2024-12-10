using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ActorView : MonoBehaviour
{
    static readonly ActorConfig _config;
    static readonly QuestionConfig _configQuestion;
    static PlayerView player;

    static readonly HumanAnswerConfig humanAnswer;
    static readonly RobotAnswerConfig robotAnswer;
    static readonly NeutralAnswerConfig neutralAnswer;

    bool isRobot;

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

        float r = Random.Range(0, 10);
        if (r > 5.0f)
            isRobot = true;

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

        player.CurrentDecisions++;
        if (player.CurrentDecisions > player.DecisionLimit)
            player.ChangeDay();
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

        player.CurrentDecisions++;
        if (player.CurrentDecisions > player.DecisionLimit)
        {
            player.ChangeDay();
        }else
            Destroy(gameObject);
    }
    public void OnYes()
    {
        player.AnserwText.text = "";
        if (isRobot)
            player.WrongAnserw();
        StartCoroutine(AfterYesDecision());
    }

    public void OnNo()
    {
        player.AnserwText.text = "";
        if(!isRobot)
            player.WrongAnserw();
        StartCoroutine (AfterNoDecision());
    }

    public void GiveAnserw(int q)
    {
        float r = Random.Range(0, 10);
        string ans = "";
        if (r > 5)
        {
            var data = neutralAnswer.answers[q];

            ans = data.answer[Random.Range(0, data.answer.Length)];
            player.AnserwText.text = ans;
            return;
        }
        else if (isRobot)
        {
            var data = robotAnswer.answers[q];
            ans = data.answer[Random.Range(0, data.answer.Length)];
            player.AnserwText.text = ans;
            return;
        }
        else
        {
            var data = humanAnswer.answers[q];
            ans = data.answer[Random.Range(0, data.answer.Length)];
            player.AnserwText.text = ans;
            return;
        }
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
