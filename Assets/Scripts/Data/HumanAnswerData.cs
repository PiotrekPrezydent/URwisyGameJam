using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "HumanAnswerData", menuName = "Scriptable Objects/HumanAnswerData")]
public class HumanAnswerData : ScriptableObject
{
    [SerializeField]
    public string[] answer;
}
