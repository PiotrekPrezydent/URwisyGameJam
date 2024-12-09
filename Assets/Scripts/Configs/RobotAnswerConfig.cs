using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

[CreateAssetMenu(fileName = "RobotAnswerConfig", menuName = "Scriptable Objects/RobotAnswerConfig")]
public class RobotAnswerConfig : ScriptableObject
{
    [SerializeField]
    RobotAnswerData[] answers;
}