using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class eventScriptAI : MonoBehaviour
{
    public GameObject c1, c2, c3, e1, e2, e3;
    public AudioSource bgMusic;
    public UnityEvent doorOpenEvent, collectFound, loseEvent;
    private bool collec = false;

    public void doorOpenActivationFunc()
    {
        Debug.Log("Door open event called\nCollectables Enabled!\nMusic Enabled!");
        c1.SetActive(true);
        c2.SetActive(true);
        c3.SetActive(true);
        if (bgMusic != null)
            bgMusic.Play();
    }

    public void collectFoundFunc()
    {
        Debug.Log("collectCube event called");
        if (!collec)
        {
            e1.SetActive(true);
            e2.SetActive(true);
            e3.SetActive(true);
            collec = true;
            Debug.Log("Enemies Activated");
        }
    }

    public void loseEventFunc()
    {
        Debug.Log("Lose event called");
        if (c1 != null)
            c1.SetActive(false);
        if (c2 != null)
            c2.SetActive(false);
        if (c3 != null)
            c3.SetActive(false);
        if (e1 != null)
            e1.SetActive(false);
        if (e2 != null)
            e2.SetActive(false);
        if (e3 != null)
            e3.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        if (doorOpenEvent == null)
            doorOpenEvent = new UnityEvent();

        if (collectFound == null)
            collectFound = new UnityEvent();

        if (loseEvent == null)
            loseEvent = new UnityEvent();

        loseEvent.AddListener(loseEventFunc);
        collectFound.AddListener(collectFoundFunc);
        doorOpenEvent.AddListener(doorOpenActivationFunc);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
