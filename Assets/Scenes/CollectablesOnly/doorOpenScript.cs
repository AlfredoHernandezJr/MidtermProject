using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class doorOpenScript : MonoBehaviour
{
    UnityEvent doorOpenCollectableEvent = new UnityEvent();

    // Start is called before the first frame update
    void Start()
    {
        doorOpenCollectableEvent.AddListener(doorOpen);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            GetComponentInParent<doorDemoScript>().openFrontDoor();
    }

    void doorOpen()
    {
        Debug.Log("Event trigger!");
    }
}
