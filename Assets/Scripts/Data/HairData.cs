using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "HairData", menuName = "Scriptable Objects/HairData")]
public class HairData : ScriptableObject
{
    [SerializeField]
    public Sprite Texture;
}
