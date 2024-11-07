using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "TrainTicket", menuName = "Scriptable Objects/TrainTicket")]
public class TrainTicket : ScriptableObject
{
    public string _ownerName;
    public string _personalNumber;
    [Range(1, 12)]
    public int _EffectiveDateMonth;
    [Range(1, 31)]
    public int _EffectiveDateDay;
    public string _startStation;
    public string _arriveStation;
    public string _sitNumber;
    public bool _isWrong;
    public string _whatIsWrong;
}
