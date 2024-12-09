using UnityEngine;
using UnityEngine.InputSystem;

public static class InputSystem
{
    static readonly UIConfig _config;

    public static void Initialize()
    {
        Debug.Log(_config == null);
    }
}
