using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NPCChat", menuName = "ScriptableObjects/ChatLines", order = 1)]
public class ChatLines : ScriptableObject
{
    public List<string> lines;
}
