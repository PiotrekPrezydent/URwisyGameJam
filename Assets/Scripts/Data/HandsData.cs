using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "HandsData", menuName = "Scriptable Objects/HandsData")]
public class HandsData : ScriptableObject
{
    [SerializeField]
    public Sprite Texture;
}
