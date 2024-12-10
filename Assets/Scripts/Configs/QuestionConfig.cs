using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestionConfig", menuName = "Scriptable Objects/QuestionConfig")]
public class QuestionConfig : ScriptableObject
{
    [SerializeField]
    public string[] questions;


    public void GetNotUsedQuestions(HashSet<int> usedQuestions, out int q1)
    {
        q1 = Random.Range(0, questions.Length);
        while (usedQuestions.Contains(q1))
            q1 = Random.Range(0, questions.Length);
        //q2 = Random.Range(0, questions.Length);
        //while (usedQuestions.Contains(q1) || q2 == q1)
        //    q2 = Random.Range(0, questions.Length);

        //q3 = Random.Range(0, questions.Length);
        //while (usedQuestions.Contains(q1) || q2 == q3 || q3 == q1)
        //    q3 = Random.Range(0, questions.Length);
    }
}
