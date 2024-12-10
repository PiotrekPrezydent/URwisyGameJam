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
    public GameObject Michalina;

    bool michalinaspawned;

    [SerializeField]
    GameObject ActorPrefab;

    GameObject ActorSpawner;

    
    public void Initialize()
    {
        ActorSpawner = GameObject.FindGameObjectWithTag("ActorSpawner");
        michalinaspawned = false;
    }

    public void CreateRandomPerson()
    {
        if (!michalinaspawned)
        {
            michalinaspawned = true;
            var actor = GameObject.Instantiate(Michalina, ActorSpawner.transform);
            actor.GetComponent<ActorView>().Initialize(true);
        }
        else
        {
            var actor = GameObject.Instantiate(ActorPrefab, ActorSpawner.transform);
            actor.GetComponent<ActorView>().Initialize(false);
        }

    }
}
