using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "RobotAnswerData", menuName = "Scriptable Objects/RobotAnswerData")]
public class RobotAnswerData : ScriptableObject
{
    [SerializeField]
    public string[] answer;
}
