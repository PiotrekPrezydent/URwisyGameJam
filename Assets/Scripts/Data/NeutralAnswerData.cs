using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NeutralAnswerData", menuName = "Scriptable Objects/NeutralAnswerData")]
public class NeutralAnswerData : ScriptableObject
{
    [SerializeField]
    public string[] answer;
}
