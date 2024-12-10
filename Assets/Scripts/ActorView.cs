using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ActorView : MonoBehaviour
{
    static readonly ActorConfig _config;
    static readonly QuestionConfig _configQuestion;
    static PlayerView player;
    static readonly DocumentConfig _configDocument;

    static readonly HumanAnswerConfig humanAnswer;
    static readonly RobotAnswerConfig robotAnswer;
    static readonly NeutralAnswerConfig neutralAnswer;

    GameObject MiddleOfScreen;

    GameObject RightOfScreen;

    public bool isRobot;

    [SerializeField]
    SpriteRenderer hairSprite;

    [SerializeField]
    SpriteRenderer headSprite;

    [SerializeField]
    SpriteRenderer torseSprite;

    [SerializeField]
    SpriteRenderer handsSprite;

    DocumentData data;


    int speed = 250;



    //Najwyzej przerobic jak jpg/png niebedzie sie lapac w tekstury
    public void Initialize(bool michalina)
    {
        if (michalina)
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerView>();
            MiddleOfScreen = GameObject.FindGameObjectWithTag("Middle");
            RightOfScreen = GameObject.FindGameObjectWithTag("End");
            data = _configDocument.dokument[25];
            StartCoroutine(WalkToMiddleOfScreen());
            return;
        }
        else
        {
            data = _configDocument.dokument[Random.Range(0, _configDocument.dokument.Length)];
        }

        if (data.imie.ToLower()[0] == 'n')
        {
            this.isRobot = true;
        }
        float ran = Random.Range(0, 10f);
        if (ran > 5)
        {
            //take only even
            hairSprite.sprite = _config.HairDatas[Random.Range(0, _config.HairDatas.Length / 2) * 2].Texture;
            headSprite.sprite = _config.HeadDatas[Random.Range(0, _config.HeadDatas.Length / 2) * 2].Texture;
            torseSprite.sprite = _config.TorseDatas[Random.Range(0, _config.TorseDatas.Length / 2) / 2 * 2].Texture;

            if (isRobot)
            {
                handsSprite.sprite = _config.HandsDatas[Random.Range(0, _config.HandsDatas.Length)].Texture;
            }
            else
            {
                handsSprite.sprite = _config.HandsDatas[Random.Range(0, 3)].Texture;
            }
        }
        else
        {
            hairSprite.sprite = _config.HairDatas[Random.Range(0, (_config.HairDatas.Length - 1) / 2) * 2 + 1].Texture;
            headSprite.sprite = _config.HeadDatas[Random.Range(0, (_config.HeadDatas.Length - 1) / 2) * 2 + 1].Texture;
            torseSprite.sprite = _config.TorseDatas[Random.Range(0, (_config.TorseDatas.Length - 1) / 2) * 2 + 1].Texture;

            if (isRobot)
            {
                handsSprite.sprite = _config.HandsDatas[Random.Range(0, _config.HandsDatas.Length)].Texture;
            }
            else
            {
                handsSprite.sprite = _config.HandsDatas[Random.Range(0, 3)].Texture;
            }
        }

        hairSprite.color = Random.ColorHSV();
        torseSprite.color = Random.ColorHSV();

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerView>();
        MiddleOfScreen = GameObject.FindGameObjectWithTag("Middle");
        RightOfScreen = GameObject.FindGameObjectWithTag("End");

        StartCoroutine(WalkToMiddleOfScreen());
    }


    IEnumerator WalkToMiddleOfScreen()
    {
        while(transform.position.x < MiddleOfScreen.transform.position.x)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, MiddleOfScreen.transform.position, step);
            yield return null;
        }
        player.ShowOptions(this);

    }
    IEnumerator AfterNoDecision()
    {
        player.HideOpption();
        var go = GameObject.FindGameObjectWithTag("ActorSpawner");
        while(transform.position.x > go.transform.position.x)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, go.transform.position, step);
            yield return null;
        }

        player.CurrentDecisions++;
        if (player.CurrentDecisions > player.DecisionLimit)
            player.ChangeDay();
        else
        {
            _config.CreateRandomPerson();
            Destroy(gameObject);
        }


    }
    IEnumerator AfterYesDecision()
    {
        player.HideOpption();
        while (transform.position.x < RightOfScreen.transform.position.x)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, RightOfScreen.transform.position, step);
            yield return null;
        }

        player.CurrentDecisions++;
        if (player.CurrentDecisions > player.DecisionLimit)
        {
            player.ChangeDay();
        }
        else
        {
            _config.CreateRandomPerson();
            Destroy(gameObject);
        }
    }
    public void OnYes()
    {
        player.AnserwText.text = "";
        if (isRobot)
        {
            player.WrongAnserwRobot();
            player.WrongAnserw();
        }
        else
        {
            player.GoodAnserw();
        }

        StartCoroutine(AfterYesDecision());
    }

    public void OnNo()
    {
        player.AnserwText.text = "";
        if (!isRobot)
        {
            player.WrongAnserwHuman();
            player.WrongAnserw();
        }
        else
        {
            player.GoodAnserw();
        }

        StartCoroutine(AfterNoDecision());
    }
    public void OnShowHand()
    {
        player.DocumentText.text = "";
        handsSprite.gameObject.SetActive(true);
    }

    public void HideHand()
    {
           handsSprite?.gameObject.SetActive(false);
    }

    public void OnShowDocuments()
    {
        handsSprite.gameObject.SetActive(false);
        player.DocumentText.text = "ID: " +data.id + "\n" +data.imie + " " + data.nazwisko+"\n"+ "P³eæ: " + data.plec+"\n" +"Data_Urodzenia: " + data.data_urodzenia + "\n" + "Pochodzenie: "+data.kraj + "\nMiasto: "+data.miasto;
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

}
