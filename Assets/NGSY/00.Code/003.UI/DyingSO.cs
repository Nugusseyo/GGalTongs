using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DyingSO", menuName = "Scriptable Objects/DyingSO")]
public class DyingSO : ScriptableObject
{
    public List<MessageSO> MessageList;
}
