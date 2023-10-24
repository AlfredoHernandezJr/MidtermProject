using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.UI.Image;

public class canvasScriptAI : MonoBehaviour
{
    public int enemyCount = 5;
    public int score = 0;
    private int collectCount = 0;
    public TextMeshProUGUI enemyText, scoreText, lostText, collectText, winText;
    public GameObject miniMap, ExitdoorTrig, eventObj;
    public int buttonWidth;
    public int buttonHeight;
    private int origin_x;
    private int origin_y;
    private bool isLost = false;
    private bool manic;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + score.ToString();
        enemyText.text = "Enemies Remaining: " + enemyCount;
        collectText.text = "Collectables found: " + collectCount;
        buttonWidth = 200;
        buttonHeight = 50;
        origin_x = Screen.width / 2 - buttonWidth / 2;
        origin_y = Screen.height / 2 - buttonHeight * 2;
        manic = false;
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
        collectText.gameObject.SetActive(false);
        miniMap.SetActive(false);
        lostText.gameObject.SetActive(true);
        isLost = true;
        //call event
        eventObj.GetComponent<eventScriptAI>().loseEventFunc();
    }

    public void youWin()
    {
        enemyText.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(false);
        collectText.gameObject.SetActive(false);
        miniMap.SetActive(false);
        winText.gameObject.SetActive(true);
        ExitdoorTrig.gameObject.GetComponent<doorDemoScriptAI>().setWin();
    }

    public int changeScore(int inp)
    {
        collectCount++;
        if (collectCount > 1)
        {
            Debug.Log("ENEMIES MANIC!");
            manic = true;
        }
        collectText.text = "Collectables found: " + collectCount;
        score += inp;
        if (enemyCount == 0 && collectCount == 3)
            youWin();
        return score;
    }

    public bool isManic()
    {
        return manic;
    }

    void OnGUI()
    {
        if (isLost)
        {
            if (GUI.Button(new Rect(origin_x, origin_y, buttonWidth, buttonHeight), "Restart?"))
            {
                Application.LoadLevel(4);
            }
        }
    }
}
