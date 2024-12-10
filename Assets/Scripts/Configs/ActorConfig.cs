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
    public DocumentData[] DocumentsDatas;

    [SerializeField]
    GameObject ActorPrefab;

    GameObject ActorSpawner;

    
    public void Initialize()
    {
        ActorSpawner = GameObject.FindGameObjectWithTag("ActorSpawner");
    }

    public void CreateRandomPerson()
    {
        var actor = GameObject.Instantiate(ActorPrefab, ActorSpawner.transform);
        actor.GetComponent<ActorView>().Initialize();
    }
}
