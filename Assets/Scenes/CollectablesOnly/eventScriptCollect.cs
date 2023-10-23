using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class eventScriptCollect : MonoBehaviour
{
    public GameObject c1, c2, c3;
    public AudioSource bgMusic;
    public UnityEvent doorOpenEvent;

    public void doorOpenActivationFunc()
    {
        Debug.Log("Door open event called\nCollectables Enabled!\nMusic Enabled!");
        c1.SetActive(true);
        c2.SetActive(true);
        c3.SetActive(true);
        if (bgMusic != null)
            bgMusic.Play();
    }    

    // Start is called before the first frame update
    void Start()
    {
        if (doorOpenEvent == null)
            doorOpenEvent = new UnityEvent();

        doorOpenEvent.AddListener(doorOpenActivationFunc);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
