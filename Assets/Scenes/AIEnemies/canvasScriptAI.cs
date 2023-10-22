using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class canvasScriptAI : MonoBehaviour
{
    public int enemyCount = 3;
    public int score = 0;
    private int collectCount = 0;
    public TextMeshProUGUI enemyText, scoreText, lostText, collectText, winText;
    public GameObject miniMap, doorTrig;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + score.ToString();
        enemyText.text = "Collectables Remaining: " + enemyCount;
        collectText.text = "Collectables found: " + collectCount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void badguyDown()
    {
        enemyCount--;
        enemyText.text = "Collectables Remaining: " +enemyCount;
        score += 10;
        scoreText.text = "Score: " + score;
    }

    public void youLose()
    {
        enemyText.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(false);
        miniMap.SetActive(false);
        lostText.gameObject.SetActive(true);
    }

    public void youWin()
    {
        enemyText.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(false);
        miniMap.SetActive(false);
        winText.gameObject.SetActive(true);
        doorTrig.gameObject.GetComponent<doorDemoScriptAI>().setWin();
    }

    public int changeScore(int inp)
    {
        collectCount++;
        enemyCount--;
        enemyText.text = "Collectables Remaining: " + enemyCount;
        collectText.text = "Collectables found: " + collectCount;
        score += inp;
        if (collectCount == 3)
            youWin();
        return score;
    }
}
