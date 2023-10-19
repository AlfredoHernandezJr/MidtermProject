using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class doorDemoScriptAI : MonoBehaviour
{
    public GameObject frontDoorOne, frontDoorTwo, exitDoorOne, exitDoorTwo;
    private Vector3 frontDoorOneStartPosition, frontDoorTwoStartPosition, exitDoorOneStartPosition, exitDoorTwoStartPosition;
    public UnityEvent onDoorOpen;
    bool win = false;
    bool opened = false;

    // Add this line to define an AudioSource variable
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        frontDoorOneStartPosition = frontDoorOne.transform.position;
        frontDoorTwoStartPosition = frontDoorTwo.transform.position;
        exitDoorOneStartPosition = exitDoorOne.transform.position;
        exitDoorTwoStartPosition = exitDoorTwo.transform.position;

        //openFrontDoor();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setWin()
    {
        win = true;
    }

    public void closeExitDoor()
    {
        Debug.Log("Exit Trigger tried");
        if (win)
        {
            Debug.Log("Exit Trigger Granted");
            // Move frontDoorOne back to its starting position
            StartCoroutine(MoveDoor(exitDoorOne, exitDoorOneStartPosition - exitDoorOne.transform.position, 10f));

            // Move frontDoorTwo back to its starting position
            StartCoroutine(MoveDoor(exitDoorTwo, exitDoorTwoStartPosition - exitDoorOne.transform.position, 10f));
        }
        else
            Debug.Log("Exit Trigger Rejected");
    }

    public void openExitDoor()
    {
        Debug.Log("Exit Trigger tried");
        if (win)
        {
            Debug.Log("Exit Trigger Granted");
            // Move frontDoorOne to the left
            StartCoroutine(MoveDoor(exitDoorOne, Vector3.forward * 20f, 10f));

            // Move frontDoorTwo to the right
            StartCoroutine(MoveDoor(exitDoorTwo, Vector3.back * 20f, 10f));
        }
        else Debug.Log("Exit Trigger Denied");
    }

    public void closeFrontDoor()
    {
        Debug.Log("Front DoorClosed");
        // Move frontDoorOne back to its starting position
        StartCoroutine(MoveDoor(frontDoorOne, frontDoorOneStartPosition - frontDoorOne.transform.position, 10f));

        // Move frontDoorTwo back to its starting position
        StartCoroutine(MoveDoor(frontDoorTwo, frontDoorTwoStartPosition - frontDoorTwo.transform.position, 10f));
    }

    public void openFrontDoor()
    {
        if (!opened)
        {
            Debug.Log("Front DoorOpen");
            // Move frontDoorOne to the left
            StartCoroutine(MoveDoor(frontDoorTwo, Vector3.back * 15f, 10f));

            // Move frontDoorTwo to the right
            StartCoroutine(MoveDoor(frontDoorOne, Vector3.forward * 15f, 10f));

            // Invoke the UnityEngine onDoorOpen event
            onDoorOpen.Invoke();


            if (audioSource != null)
                audioSource.Play();
            Debug.Log("Music Started!");
            Debug.Log("Collectables Added!");
            opened = true;
        }
    }

    private IEnumerator MoveDoor(GameObject door, Vector3 direction, float speed)
    {
        // Calculate the target position of the door
        Vector3 targetPosition = door.transform.position + direction;

        // Move the door towards the target position over time
        while (Vector3.Distance(door.transform.position, targetPosition) > 0.1f)
        {
            door.transform.position = Vector3.MoveTowards(door.transform.position, targetPosition, speed * Time.deltaTime);
            yield return null;
        }

        // Snap the door to the target position to ensure it reaches its final position
        door.transform.position = targetPosition;
    }
}