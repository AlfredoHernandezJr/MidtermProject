using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class eventScriptSlowEnemies : MonoBehaviour
{
    public GameObject c1, c2, c3, e1, e2, e3;
    public AudioSource bgMusic;
    public UnityEvent doorOpenEvent, collectFound;
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

    // Start is called before the first frame update
    void Start()
    {
        if (doorOpenEvent == null)
            doorOpenEvent = new UnityEvent();

        if (collectFound == null)
            collectFound = new UnityEvent();

        collectFound.AddListener(collectFoundFunc);
        doorOpenEvent.AddListener(doorOpenActivationFunc);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
