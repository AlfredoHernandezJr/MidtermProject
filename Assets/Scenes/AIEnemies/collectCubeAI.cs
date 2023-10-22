using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class collectCubeAI : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public GameObject canva, eventObj;
    public int score = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(1, 1, 1) * (Time.deltaTime * 50));
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other);
        score = Random.Range(1, 5);
        scoreText.text = "Score: " + canva.GetComponent<canvasScriptAI>().changeScore(score).ToString();
        //call event
        eventObj.GetComponent<eventScriptAI>().collectFoundFunc();
        Destroy(this.gameObject);
    }
}