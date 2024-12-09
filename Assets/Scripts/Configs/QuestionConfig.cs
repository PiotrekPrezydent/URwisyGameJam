using UnityEngine;

[CreateAssetMenu(fileName = "QuestionConfig", menuName = "Scriptable Objects/QuestionConfig")]
public class QuestionConfig : ScriptableObject
{
    [SerializeField]
    string[] questions;
}
