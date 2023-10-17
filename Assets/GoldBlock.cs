using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldBlock : MonoBehaviour
{
    public GameObject goldObj;

    // Start is called before the first frame update
    void Start()
    {
        goldObj = GameObject.Find("Canvas");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(1, 1, 1) * (Time.deltaTime * 50));
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("FROM BLOCK: " + other.gameObject.tag);
        //if (other.gameObject.tag == "Player")
        //{
            Debug.Log("FGOLD BLOCK HIT" + other);
            goldObj.gameObject.GetComponent<PlayerGold>().Add1Gold();
        //}
    }

    public void goner()
    {
        Destroy(this.gameObject);
    }
}
