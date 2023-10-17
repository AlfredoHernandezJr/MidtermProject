using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//data save template for NPCs
[CreateAssetMenu(fileName = "NPC", menuName = "ScriptableObjects/Dialog", order = 1)]
public class Dialog : ScriptableObject
{
    public string Name;
    public string Job;

    //task requirement
    public List<int> needGold = new List<int> {0,1,3,5};

    //conversation lines. Whenever a task is done, show next set of lines.
    public int startLineIndex = 0;
    public List<ChatLines> ChatSets;

}
