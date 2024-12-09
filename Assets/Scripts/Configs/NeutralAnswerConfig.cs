using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

[CreateAssetMenu(fileName = "NeutralAnswerConfig", menuName = "Scriptable Objects/NeutralAnswerConfig")]
public class NeutralAnswerConfig : ScriptableObject
{
    [SerializeField]
    NeutralAnswerData[] answers;
}