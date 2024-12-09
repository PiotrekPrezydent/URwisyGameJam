using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

[CreateAssetMenu(fileName = "HumanAnswerConfig", menuName = "Scriptable Objects/HumanAnswerConfig")]
public class HumanAnswerConfig : ScriptableObject
{
    [SerializeField]
    HumanAnswerData[] answers;
}