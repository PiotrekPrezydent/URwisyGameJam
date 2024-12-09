using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "HeadData", menuName = "Scriptable Objects/HeadData")]
public class HeadData : ScriptableObject
{
    [SerializeField]
    public Sprite Texture;
}
