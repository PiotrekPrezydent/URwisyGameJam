using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "UIConfig", menuName = "Scriptable Objects/UIConfig")]
public class UIConfig : ScriptableObject
{
    [SerializeField]
    public InputActionAsset inputAction;
}
