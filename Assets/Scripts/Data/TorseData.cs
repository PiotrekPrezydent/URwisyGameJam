using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "TorseData", menuName = "Scriptable Objects/TorseData")]
public class TorseData : ScriptableObject
{
    [SerializeField]
    public Sprite Texture;
}
