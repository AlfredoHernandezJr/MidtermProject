using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class canvasScriptSlowEnemies : MonoBehaviour
{
    public int enemyCount = 5;
    public int score = 0;
    private int collectCount = 0;
    public TextMeshProUGUI enemyText, scoreText, lostText, collectText, winText;
    public GameObject miniMap , ExitdoorTrig;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + score.ToString();
        enemyText.text = "Enemies Remaining: " + enemyCount;
        collectText.text = "Collectables found: " + collectCount;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void badguyDown()
    {
        enemyCount--;
        enemyText.text = "Enemies Remaining: " + enemyCount;
        score += 10;
        scoreText.text = "Score: " + score;
        if (enemyCount == 0 && collectCount == 3)
            youWin();
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
        ExitdoorTrig.gameObject.GetComponent<doorDemoScriptSlowEnemies>().setWin();
    }

    public int changeScore(int inp)
    {
        collectCount++;
        collectText.text = "Collectables found: " + collectCount;
        score += inp;
        if (enemyCount == 0 && collectCount == 3)
            youWin();
        return score;
    }
}
