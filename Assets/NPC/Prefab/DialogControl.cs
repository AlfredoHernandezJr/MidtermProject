using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogControl : MonoBehaviour
{
    public GameObject player;
    public Dialog dialogData;
    public GameObject dialogCanvas;
    public TextMeshProUGUI jobText;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI chatText;
    public TextMeshProUGUI questText;
    private Animator anim;
    public int goldCount = 0;
    bool goldOneFirst = true;
    int textIndex = 0;
    void Start()
    {
        dialogData.startLineIndex = 0;
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("met NPC!");
        if(other.gameObject.name==player.name)
        {
            dialogCanvas.SetActive(true);
            DisplayInfo();
            player.GetComponent<PlayerMove>().StopPlayer();
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Debug.Log("NextLine");
            textIndex++;
            if (textIndex == 2 && goldCount < 1) questText.text = "Quest: Find One Gold";
            else if (textIndex == 1 && goldCount == 1) questText.text = "Quest: Find Two More Gold";
            Show1Set(dialogData.ChatSets[dialogData.startLineIndex]);
        }
    }
    void OnTriggerExit(Collider other)
    {
        Debug.Log("leave NPC!");
        if (other.gameObject.name == player.name)
        {
            dialogCanvas.SetActive(false);
            textIndex = 0;
            anim.Play("Fox_Idle", 0, 1);
        }
    }

    private void DisplayInfo()
    {
        nameText.text = dialogData.Name;
        jobText.text = dialogData.Job;
        ChatDisplay();
    }
    private void ChatDisplay()
    {
        anim = GetComponent<Animator>();
        Debug.Log("needGold next level "+ dialogData.needGold[dialogData.startLineIndex + 1]);
        if (goldCount >= dialogData.needGold[dialogData.startLineIndex + 1])
        {
            anim.Play("Fox_Jump", 0, .25f);
            dialogData.startLineIndex++;
            Debug.Log("show chat index " + dialogData.startLineIndex.ToString());
            Show1Set(dialogData.ChatSets[dialogData.startLineIndex]);
            textIndex = 0;
        }
        else
        {
            anim.Play("Fox_Jump", 0, .25f);
            Debug.Log("show chat index" + dialogData.startLineIndex.ToString());
            Show1Set(dialogData.ChatSets[dialogData.startLineIndex]);
        }
            
    
    }

    private void Show1Set(ChatLines chat)
    {
        Debug.Log("Should show No. of text:" + chat.lines.Count.ToString());
        Debug.Log(chat.lines[0]);
        if(textIndex<chat.lines.Count)
        {
            chatText.text = chat.lines[textIndex];
        }
    }
}
