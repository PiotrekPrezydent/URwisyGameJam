using UnityEngine;

[CreateAssetMenu(fileName = "ActorConfig", menuName = "Scriptable Objects/ActorConfig")]
public class ActorConfig : ScriptableObject
{
    [SerializeField]
    public HairData[] HairDatas;

    [SerializeField]
    public HeadData[] HeadDatas;

    [SerializeField]
    public HandsData[] HandsDatas;

    [SerializeField]
    public TorseData[] TorseDatas;

    [SerializeField]
    GameObject ActorPrefab;

    GameObject ActorSpawner;

    
    public void Initialize()
    {
        ActorSpawner = GameObject.FindGameObjectWithTag("ActorSpawner");
    }

    public void CreateRandomPerson()
    {
        float ran = Random.Range(0, 10f);
        if(ran > 5)
        {
            //take only even
            var hair = HairDatas[Random.Range(0, HairDatas.Length / 2) * 2].Texture;
            var head = HeadDatas[Random.Range(0, HeadDatas.Length/2)*2].Texture;
            var hands = HandsDatas[Random.Range(0, HandsDatas.Length/2)*2].Texture;
            var torse = TorseDatas[Random.Range(0, TorseDatas.Length/2)/2*2].Texture;
            var actor = GameObject.Instantiate(ActorPrefab, ActorSpawner.transform);
            actor.GetComponent<ActorView>().Initialize(hair, head, torse, hands);
        }
        else
        {
            var hair = HairDatas[Random.Range(0, (HairDatas.Length-1)/2) * 2 +1].Texture;
            var head = HeadDatas[Random.Range(0, (HeadDatas.Length-1) / 2) * 2+1].Texture;
            var hands = HandsDatas[Random.Range(0, (HandsDatas.Length-1) / 2) * 2+1].Texture;
            var torse = TorseDatas[Random.Range(0, (TorseDatas.Length-1) / 2) * 2+1].Texture;
            var actor = GameObject.Instantiate(ActorPrefab, ActorSpawner.transform);
            actor.GetComponent<ActorView>().Initialize(hair, head, torse, hands);
        }



    }
}
