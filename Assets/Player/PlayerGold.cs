using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerGold : MonoBehaviour
{
    public int goldCnt=0;
    public GameObject fox;
    public TextMeshProUGUI goldText, questText;
    // Start is called before the first frame update
    public void Add1Gold()
    {
        goldCnt++;
        fox.GetComponent<DialogControl>().goldCount = goldCnt;
        ShowGold();
    }

    // Update is called once per frame
    void ShowGold()
    {
        goldText.text = goldCnt.ToString() + " Gold";
    }

    public void updateQuest(string quest)
    {
        questText.text = "Quest: " + quest;
    }

    private void Start()
    {
        GameObject fox = GameObject.Find("Fox");
    }
}
