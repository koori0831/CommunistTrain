using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ChatSO", menuName = "Scriptable Objects/ChatSO")]
public class ChatSO : ScriptableObject
{
    public List<string> DialLog;
    public List<string> NameTag;
}
