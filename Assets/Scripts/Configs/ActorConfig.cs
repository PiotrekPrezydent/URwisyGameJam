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
        var hair = HairDatas[Random.Range(0, HeadDatas.Length)].Texture;
        var head = HeadDatas[Random.Range(0, HeadDatas.Length)].Texture;
        var hands = HandsDatas[Random.Range(0, HandsDatas.Length)].Texture;
        var torse = TorseDatas[Random.Range(0, TorseDatas.Length)].Texture;

        var actor = GameObject.Instantiate(ActorPrefab,ActorSpawner.transform);
        actor.GetComponent<ActorView>().Initialize(hair, head, hands, torse);
    }
}
