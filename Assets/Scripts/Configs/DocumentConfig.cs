using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

[CreateAssetMenu(fileName = "DocumentsConfig", menuName = "Scriptable Objects/DocumentsConfig")]
public class DocumentConfig : ScriptableObject
{
    [SerializeField]
    public DocumentData[] dokument;
}