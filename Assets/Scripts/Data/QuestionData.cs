using UnityEngine;

[CreateAssetMenu(fileName = "QuestionData", menuName = "Scriptable Objects/QuestionData")]
public class QuestionData : ScriptableObject
{
    [SerializeField]
    public string[] Questions; 
}
