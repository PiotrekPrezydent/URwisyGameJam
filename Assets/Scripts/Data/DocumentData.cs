using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "DocumentsData", menuName = "Scriptable Objects/DocumentsData")]
public class DocumentData : ScriptableObject
{
    [SerializeField]
    public string imie;

    [SerializeField]
    public string nazwisko;

    [SerializeField]
    public string id;

    [SerializeField]
    public string data_urodzenia;

    [SerializeField]
    public string kraj;

    [SerializeField]
    public string miasto;

    [SerializeField]
    public string plec;
}
